using System;
using System.Collections.Generic;
using Caffettiera;
using Caffettiera.CSharp.Common;
using Caffettiera.CSharp.Common.FSharpInterop;

namespace Caffettiera.CSharp.Generator
{

    // Item interface tree

    public interface INamedItem
    {
        string Name { get; set; }
    }

    public interface IStereotypedItem : INamedItem
    {
        string Stereotype { get; set; }
    }

    public interface ITypedItem : INamedItem
    {
        string Type { get; set; }
    }

    public interface IAttributedItem : INamedItem
    {
        void AddAttribute(Attribute a);
    }

    public interface IMethodedItem : INamedItem
    {
        void AddMethod(Method m);
    }


    // Attribute class

    public class Attribute : ITypedItem, IStereotypedItem
    {
        private string name, type;
        private string stereotype = null;

        public Attribute() { }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Stereotype
        {
            get { return stereotype; }
            set { stereotype = value; }
        }

        public static implicit operator FSharp.Generator.ClassModel.attribute(Attribute a)
        {
            return new FSharp.Generator.ClassModel.attribute(FSharp.Generator.ClassModel.parse_simple_ty("attribute", a.type), a.name, Conv.ToOption<string>(a.stereotype));
        }
    }


    // Method class

    public class Method : IStereotypedItem
    {
        private string rtype, name;
        private ICollection<Tuple<string, string>> args;
        private string stereotype = null;

        public Method()
        {
            rtype = "void";
            args = new List<Tuple<string, string>>();
        }

        public string Stereotype
        {
            get { return stereotype; }
            set { stereotype = value; }
        }

        public Method(string name)
            : this()
        {
            this.name = name;
        }

        public string ReturnType
        {
            get { return rtype; }
            set { rtype = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public ICollection<Tuple<string, string>> Arguments
        {
            get { return args; }
            set { args = value; }
        }

        public void AddArgument(string type, string name)
        {
            args.Add(new Tuple<string, string>(type, name));
        }

        public static implicit operator FSharp.Generator.ClassModel.methodd(Method m)
        {
            return new FSharp.Generator.ClassModel.methodd(
                FSharp.Generator.ClassModel.parse_ret_ty("method", m.rtype),
                m.name,
                Conv.ToList<Tuple<string, string>, Microsoft.FSharp.Core.Tuple<FSharp.Generator.Tyabsyn.complex, string>>(
                    m.args,
                    p => new Microsoft.FSharp.Core.Tuple<FSharp.Generator.Tyabsyn.complex, string>(
                                    FSharp.Generator.ClassModel.parse_complex_ty("method", p.fst),
                                    p.snd)),
                    Conv.ToOption<string>(m.stereotype));
        }
    }


    // Class class

    public class Class : IStereotypedItem, IAttributedItem, IMethodedItem
    {
        private string name;
        private bool isabstract;
        private List<Attribute> attributes;
        private List<Method> methods;
        private string stereotype = null;

        public Class()
        {
            isabstract = false;
            attributes = new List<Attribute>();
            methods = new List<Method>();
        }

        public string Stereotype
        {
            get { return stereotype; }
            set { stereotype = value; }
        }

        public Class(string name)
            : this()
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public bool IsAbstract
        {
            get { return isabstract; }
            set { isabstract = value; }
        }

        public void AddAttribute(Attribute a)
        {
            attributes.Add(a);
        }

        public void AddMethod(Method m)
        {
            methods.Add(m);
        }

        public static implicit operator FSharp.Generator.ClassModel.classs(Class c)
        {
            return new FSharp.Generator.ClassModel.classs(
                c.name,
                Conv.ToOption<string>(c.stereotype),
                c.isabstract,
                Conv.ToList<Attribute, FSharp.Generator.ClassModel.attribute>(c.attributes, (a) => a),
                Conv.ToList<Method, FSharp.Generator.ClassModel.methodd>(c.methods, (m) => m));
        }

        public static implicit operator FSharp.Generator.ClassModel.node(Class c)
        {
            return FSharp.Generator.ClassModel.node.Class(c);
        }
    }

    public class BOM
    {
        private FSharp.Common.Graph.t<FSharp.Generator.ClassModel.node, FSharp.Generator.ClassModel.edge> g;

        public BOM()
        {
            g = new FSharp.Common.Graph.t<FSharp.Generator.ClassModel.node, FSharp.Generator.ClassModel.edge>();
        }

        public void AddClass(Class c)
        {
            g.AddNode(c);
        }

        private void AddEdge(string name, string stereotype, FSharp.Generator.ClassModel.node n1, FSharp.Generator.ClassModel.connector conn, FSharp.Generator.ClassModel.node n2)
        {
            Fun.Apply<FSharp.Generator.ClassModel.node,
                      FSharp.Generator.ClassModel.edge,
                      FSharp.Generator.ClassModel.node>
                          (g.AddEdge,
                           n1,
                           new FSharp.Generator.ClassModel.edge
                                (Conv.ToOption<string>(name),
                                Conv.ToOption<string>(stereotype),
                                conn),
                           n2);
        }

        public void AddSpecialization(string name, string stereotype, Class superclass, Class subclass)
        {
            AddEdge(name, stereotype, subclass, FSharp.Generator.ClassModel.connector.Specializes, superclass);
        }

        public void AddComposition(string name, string stereotype, Class one, Class many)
        {
            AddEdge(name, stereotype, one, FSharp.Generator.ClassModel.connector.Composes, many);
        }

        public void AddAggregation(string name, string stereotype, Class one, Class many)
        {
            AddEdge(name, stereotype, one, FSharp.Generator.ClassModel.connector.Aggregates, many);
        }

        public void AddAssociation(string name, string stereotype, Class a, Class b)
        {
            AddEdge(name, stereotype, a, FSharp.Generator.ClassModel.connector.Associates, b);
        }

        public FSharp.Common.Graph.t<FSharp.Generator.ClassModel.node, FSharp.Generator.ClassModel.edge> ToFSharp()
        {
            return this;
        }

        public static implicit operator FSharp.Common.Graph.t<FSharp.Generator.ClassModel.node, FSharp.Generator.ClassModel.edge>(BOM cm)
        {
            return cm.g;
        }

    }
}
