
using System.Collections;
using System.Collections.Generic;
using Caffettiera.CSharp.BLL;
using Caffettiera.CSharp.Common;


namespace Test.DAL
{


    public class A : IEntity
    {
        protected internal genTest.Entities.A entity;
        protected IProvider<A> p;

        public A(IProvider<A> p)
        {
            entity = new genTest.Entities.A();
            this.p = p;
        }

        public static class Key : KeyBase
        {
            public static explicit operator int(Key k) { return k.id; }
            public static explicit operator Key(int id) { return new Key(id); }
        }

        public Key Insert()
        {
            p.Insert(this);
            return this.Pk;
        }

        public Key Pk
        {
            get { return entity.AId; }
            set { entity.AId = value; }
        }

        public Key AId
        {
            get { return this.Pk; }
            set { this.Pk = value; }
        }

        public C.Key? CId
        {
            get { return entity.CId.HasValue ? entity.CId.Value : null; }
            set { entity.CId = value.HasValue ? value.Value : null; }
        }

        public string y
        {
            get { return entity.Y; }
            set { entity.Y = value; }
        }
    }


}