
using System.Collections;
using System.Collections.Generic;
using Caffettiera.CSharp.BLL;
using Caffettiera.CSharp.Common;


namespace Test.DAL
{


    public class B : IEntity
    {
        protected genTest.Entities.B entity;

        public class Key : KeyBase
        {
            public static explicit operator int(Key k) { return k.id; }
            public static explicit operator Key(A.Key a) { return new Key((int)a); }
            public static explicit operator Key(int id) { return new Key(id); }
        }

        public Key Pk
        {
            get { return entity.BId; }
            set { entity.BId = value; }
        }

        public Key BId
        {
            get { return this.Pk; }
            set { this.Pk = value; }
        }

        public E.Key? EId
        {
            get { return entity.EId.HasValue ? entity.EId.Value : null; }
            set { entity.EId = value.HasValue ? value.Value : null; }
        }

        public double z
        {
            get { return entity.Z; }
            set { entity.Z = value; }
        }
    }


}