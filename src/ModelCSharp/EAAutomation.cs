using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Caffettiera.CSharp.Common;
using Caffettiera.CSharp.Common.IO;

namespace Caffettiera.CSharp.Generator.EAAutomation
{

    public class EAModel : IDisposable
    {
        protected EA.RepositoryClass repo;
        protected ChapterWriter ow;

        public EAModel(ChapterWriter ow, string filename)
        {
            this.ow = ow;
            Prelude.LogAction(ow,
                () => repo = new EA.RepositoryClass(),
                "opening EA repository...",
                "done", "failed");
            Prelude.LogAction(ow,
                () =>
                {
                    System.IO.FileInfo f = new System.IO.FileInfo(filename);
                    repo.OpenFile(f.FullName);
                },
                string.Format("loading EAP model file '{0}'...", filename),
                "done", "not found");
        }

        public void Dispose()
        {
            repo.Exit();
        }

        private EA.Package descendIntoPackage(string[] nodes, int i, EA.Package p)
        {
            return i == nodes.Length - 1

                ? Prelude.LogAction(ow,
                    () => (EA.Package)p.Packages.GetByName(nodes[i]),
                    string.Format("retrieving package '{0}'...", nodes[i]),
                    "done", "not found")

                : descendIntoPackage(nodes, i + 1,
                    Prelude.LogAction(ow,
                        () => (EA.Package)p.Packages.GetByName(nodes[i]),
                        string.Format("descending recursively into package '{0}'...", nodes[i]),
                        "done", "not found"));
        }

        private EA.Diagram descendIntoDiagram(string[] nodes, int i, EA.Package p)
        {
            return i == nodes.Length - 1

                ? Prelude.LogAction(ow,
                    () =>
                    {
                        var r = (EA.Diagram)p.Diagrams.GetByName(nodes[i]);
                        if (r == null) throw new NullReferenceException();
                        return r;
                    },
                    string.Format("retrieving diagram '{0}'...", nodes[i]),
                    "done", "not found")

                : descendIntoDiagram(nodes, i + 1,
                    Prelude.LogAction(ow,
                        () => (EA.Package)p.Packages.GetByName(nodes[i]),
                        string.Format("descending recursively into package '{0}'...", nodes[i]),
                        "done", "not found"));
        }

        private EA.Diagram findDiagram(string type, string path)
        {
            ow.WriteLine("scanning for {0} model located at '{1}':", type, path);
            ow.BeginChapter();

            char[] sep = { '/' };
            string[] nodes = path.Split(sep);

            ow.WriteLine("descending into model '{0}'", nodes[0]);
            var r = descendIntoDiagram(nodes, 1, (EA.Package)repo.Models.GetByName(nodes[0]));
            ow.EndChapter();
            return r;
        }

        private EA.Package findPackage(string path)
        {
            ow.WriteLine("scanning for package located at '{0}':", path);
            ow.BeginChapter();

            char[] sep = { '/' };
            string[] nodes = path.Split(sep);

            ow.WriteLine("descending into model '{0}'", nodes[0]);
            var r = descendIntoPackage(nodes, 1, (EA.Package)repo.Models.GetByName(nodes[0]));
            ow.EndChapter();
            return r;
        }

        private void fetchAttributes(EA.Element e, IAttributedItem i)
        {
            foreach (EA.Attribute x in e.Attributes)
            {
                Attribute a = new Attribute();
                a.Name = x.Name;
                a.Type = x.Type;
                a.Stereotype = x.Stereotype;
                ow.WriteLine("added attribute {0} : {1} <<{2}>>", a.Name, a.Type, a.Stereotype);
                i.AddAttribute(a);
            }
        }

        private void fetchMethods(EA.Element e, IMethodedItem i)
        {
            foreach (EA.Method x in e.Methods)
            {
                Method m = new Method();
                m.Name = x.Name;
                m.ReturnType = x.ReturnType;
                m.Stereotype = x.Stereotype;
                foreach (EA.Parameter p in x.Parameters)
                {
                    m.AddArgument(p.Type, p.Name);
                }
                ow.WriteLine("added method {0} {1}({2}) <<{3}>>",
                    m.ReturnType,
                    m.Name,
                    Prelude.MappenStrings((t) => string.Format("{0} {1}", t.fst, t.snd), ", ", m.Arguments),
                    m.Stereotype);
                i.AddMethod(m);
            }
        }

        private Class retrieveClassByID(Dictionary<int, Class> cache, int id)
        {
            EA.Element e = repo.GetElementByID(id);
            ow.Write("fetching class {0} <<{1}>> [{2}]...", e.Name, e.Stereotype, id);
            Class c;
            if (cache.TryGetValue(id, out c))
            {
                ow.WriteLine("cached");
            }
            else
            {
                ow.WriteLine("");
                ow.BeginChapter();
                c = new Class();
                c.Name = e.Name;
                c.Stereotype = e.Stereotype;
                fetchAttributes(e, c);
                fetchMethods(e, c);
                cache.Add(id, c);
                ow.EndChapter();
            }
            return c;
        }

        private Component retrieveComponentByID(Dictionary<int, Component> cache, int id)
        {
            EA.Element e = repo.GetElementByID(id);
            ow.Write("fetching component {0} <<{1}>> [{2}]...", e.Name, e.Stereotype, id);
            Component c;
            if (cache.TryGetValue(id, out c))
            {
                ow.WriteLine("cached");
            }
            else
            {
                ow.WriteLine("");
                ow.BeginChapter();
                c = new Component();
                c.Name = e.Name;
                c.Stereotype = e.Stereotype;
                fetchAttributes(e, c);
                fetchMethods(e, c);
                cache.Add(id, c);
                ow.EndChapter();
            }
            return c;
        }

        public ICollection<WUC> RetrieveWUCs(string path, string diagramname)
        {
            var root = findPackage(path);
            ow.BeginChapter();

            var wucs = new List<WUC>();
            var classcache = new Dictionary<int, Class>();
            var componentcache = new Dictionary<int, Component>();

            foreach (EA.Package p in root.Packages)
            {
                var d = findDiagram("component", string.Format("{0}/{1}/{2}", path, p.Name,
                    string.IsNullOrEmpty(diagramname) ? p.Name : diagramname));

                WUC wuc = new WUC();

                ow.WriteLine("scanning component diagram {0} in package {1}:", d.Name, p.Name);
                ow.BeginChapter();
                foreach (EA.DiagramObject o in d.DiagramObjects)
                {
                    EA.Element e = repo.GetElementByID(o.ElementID);
                    switch (e.Type)
                    {
                        case "Component":
                        {
                            var c = retrieveComponentByID(componentcache, e.ElementID);
                            wuc.View = c;
                            ow.WriteLine("added view component {0} of type {1}", c.Name, c.Stereotype);
                            break;
                        }

                        case "Class":
                        {
                            var c = retrieveClassByID(classcache, e.ElementID);
                            switch (e.Stereotype.ToLower())
                            {
                                case "dataobject":
                                case "data object":
                                case "do":
                                    wuc.DataObject = c;
                                    ow.WriteLine("added data object {0}", c.Name);
                                    break;

                                case "businessobject":
                                case "business object":
                                case "bo":
                                case "":
                                    wuc.BO = c;
                                    ow.WriteLine("added business object {0}", c.Name);
                                    break;

                                default:
                                    throw new NotSupportedException(string.Format("unsupported stereotype <<{0}>> in element {1}[{2}] of type {2}", e.Stereotype, e.Name, e.ElementID, e.Type));
                            }
                            break;
                        }

                        /*case "RequiredInterface":
                            wuc.AddRequiredInterface(e.Name);
                            ow.WriteLine("added required interface {0}", e.Name);
                            break;*/

                        default:
                            ow.WriteLine("skipping element {0}[{1}] of type {2}", e.Name, e.ElementID, e.Type);
                            break;
                    }
                }
                ow.EndChapter();
                if (wuc.IsValid()) wucs.Add(wuc);
                else ow.WriteLine("warning: ill-formed WUC in package {0}. Skipping...", p.Name);
                ow.EndChapter();
            }
            ow.EndChapter();
            return wucs;
        }

        public BLLM RetrieveBLLM(string path)
        {
            var d = findDiagram("component", path);

            BLLM m = new BLLM();
            var cache = new Dictionary<int, Component>();

            // populate edges

            ow.WriteLine("scanning connector edges:");
            ow.BeginChapter();
            foreach (EA.DiagramLink l in d.DiagramLinks)
            {
                EA.Connector c = repo.GetConnectorByID(l.ConnectorID);
                var source = retrieveComponentByID(cache, c.ClientID);
                var target = retrieveComponentByID(cache, c.SupplierID);
                Action<String> p = (name) => ow.WriteLine("added {0} {1} [{2} -> {3}] <<{4}>>", name,
                    string.IsNullOrEmpty(c.Name) ? "(unnamed)" : c.Name, source.Name, target.Name, c.Stereotype);
                switch (c.Type)
                {
                    case "Dependency":
                        p("dependency");
                        m.AddDependency(c.Name, c.Stereotype, source, target);
                        break;

                    default:
                        throw new NotSupportedException(string.Format("unsupported connector of type {0}", c.Type));
                }
            }
            ow.EndChapter();

            // populate nodes

            ow.WriteLine("rescanning all elements for unconnected component nodes:");
            ow.BeginChapter();
            foreach (EA.DiagramObject o in d.DiagramObjects)
            {
                EA.Element e = repo.GetElementByID(o.ElementID);
                switch (e.Type)
                {
                    case "Component":
                        m.AddComponent(retrieveComponentByID(cache, o.ElementID));
                        break;

                    /*case "ProvidedInterface":
                        m.AddProvidedInterface(e.Name);
                        ow.WriteLine("added provided interface {0}", e.Name);
                        break;*/

                    default:
                        ow.WriteLine("skipping element {0}[{2}] of type {1}", e.Name, e.Type, e.ElementID);
                        break;
                }
            }
            ow.EndChapter();

            return m;
        }

        public BOM RetrieveBOM(string path)
        {
            var d = findDiagram("class", path);

            BOM m = new BOM();
            var cache = new Dictionary<int, Class>();

            // populate edges

            ow.WriteLine("scanning connector edges:");
            ow.BeginChapter();
            foreach (EA.DiagramLink l in d.DiagramLinks)
            {
                EA.Connector c = repo.GetConnectorByID(l.ConnectorID);
                var target = retrieveClassByID(cache, c.ClientID);
                var source = retrieveClassByID(cache, c.SupplierID);
                Action<String> p = (name) => ow.WriteLine("added {0} {1} [{2} -> {3}] <<{4}>>", name,
                    string.IsNullOrEmpty(c.Name) ? "(unnamed)" : c.Name, source.Name, target.Name, c.Stereotype);
                switch (c.Type)
                {
                    case "Aggregation":
                        switch (c.Subtype)
                        {
                            case "Strong":
                                p("composition");
                                m.AddComposition(c.Name, c.Stereotype, source, target);
                                break;

                            default:
                                p("aggregation");
                                m.AddAggregation(c.Name, c.Stereotype, source, target);
                                break;
                        }
                        break;

                    case "Association":
                        p("association");
                        m.AddAssociation(c.Name, c.Stereotype, source, target);
                        break;

                    case "Generalization":
                        p("specialization");
                        m.AddSpecialization(c.Name, c.Stereotype, source, target);
                        break;

                    default:
                        throw new NotSupportedException(string.Format("unsupported connector of type {0}", c.Type));
                }
            }
            ow.EndChapter();

            // populate nodes

            ow.WriteLine("rescanning all elements for unconnected class nodes:");
            ow.BeginChapter();
            foreach (EA.DiagramObject o in d.DiagramObjects)
            {
                EA.Element e = repo.GetElementByID(o.ElementID);
                switch (e.Type)
                {
                    case "Class":
                        m.AddClass(retrieveClassByID(cache, o.ElementID));
                        break;

                    default:
                        ow.WriteLine("skipping element {0} of type {1}...", e.Name, e.Type);
                        break;
                }
            }
            ow.EndChapter();

            return m;
        }

    }
}
