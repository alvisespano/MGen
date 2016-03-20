using System;
using System.Collections.Generic;
using Caffettiera;
using Caffettiera.CSharp.Common;
using Caffettiera.CSharp.Common.FSharpInterop;
using Caffettiera.FSharp.Generator;
using Caffettiera.FSharp.Common;

namespace Caffettiera.CSharp.Generator
{
    // BBLM class

    public class BLLM
    {
        private Graph.t<ComponentModel.node, ComponentModel.edge> g;

        public BLLM()
        {
            g = new Graph.t<ComponentModel.node, ComponentModel.edge>();
        }

        public void AddComponent(Component c)
        {
            g.AddNode(c);
        }

        private void AddEdge(string name, string stereotype, FSharp.Generator.ComponentModel.node n1, FSharp.Generator.ComponentModel.connector conn, FSharp.Generator.ComponentModel.node n2)
        {
            Fun.Apply<FSharp.Generator.ComponentModel.node,
                      FSharp.Generator.ComponentModel.edge,
                      FSharp.Generator.ComponentModel.node>
                          (g.AddEdge,
                           n1,
                           new FSharp.Generator.ComponentModel.edge
                                (Conv.ToOption<string>(name),
                                Conv.ToOption<string>(stereotype),
                                conn),
                           n2);
        }

        public void AddDependency(string name, string stereotype, Component source, Component target)
        {
            AddEdge(name, stereotype, source, FSharp.Generator.ComponentModel.connector.Dependency, target);
        }

        public Graph.t<ComponentModel.node, ComponentModel.edge> ToFSharp()
        {
            return this;
        }

        public static implicit operator Graph.t<ComponentModel.node, ComponentModel.edge>(BLLM bllm)
        {
            return bllm.g;
        }
    }



    // Component class

    public class Component : IAttributedItem, IMethodedItem, IStereotypedItem
    {
        private string name;
        private string stereotype = null;
        private ICollection<string> provides, requires;
        private ICollection<Attribute> attributes;
        private ICollection<Method> methods;

        public Component()
        {
            provides = new List<string>();
            requires = new List<string>();
            methods = new List<Method>();
            attributes = new List<Attribute>();
        }

        public Component(string name) : this()
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Stereotype
        {
            get { return stereotype; }
            set { stereotype = value; }
        }

        public void AddProvidedInterface(string pi)
        {
            provides.Add(pi);
        }

        public void AddRequiredInterface(string ri)
        {
            requires.Add(ri);
        }

        public void AddAttribute(Attribute a)
        {
            attributes.Add(a);
        }

        public void AddMethod(Method m)
        {
            methods.Add(m);
        }

        public ComponentModel.componentt ToFSharp()
        {
            return this;
        }

        public static implicit operator ComponentModel.componentt(Component c)
        {
            return new ComponentModel.componentt(
                c.name,
                Conv.ToOption<string>(c.stereotype),
                Conv.ToList(c.requires),
                Conv.ToList(c.provides),
                Conv.ToList<Attribute, ClassModel.attribute>(c.attributes, (a) => a),
                Conv.ToList<Method, ClassModel.methodd>(c.methods, (m) => m));
        }

        public static implicit operator FSharp.Generator.ComponentModel.node(Component c)
        {
            return FSharp.Generator.ComponentModel.node.Component(c);
        }
    }


    // WUC class

    public class WUC
    {
        private Class dataobject, bo;
        private Component view;

        public WUC() {}

        public Class BO
        {
            get { return bo; }
            set { bo = value; }
        }

        public Class DataObject
        {
            get { return dataobject; }
            set { dataobject = value; }
        }

        public Component View
        {
            get { return view; }
            set { view = value; }
        }

        public ComponentModel.wuc ToFSharp()
        {
            return this;
        }

        public static implicit operator ComponentModel.wuc(WUC wuc)
        {
            return new ComponentModel.wuc(wuc.view, wuc.bo, wuc.dataobject);
        }

        public bool IsValid()
        {
            return dataobject != null && bo != null && view != null;
        }
    }

}
