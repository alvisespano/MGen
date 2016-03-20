
using System.Collections;
using System.Collections.Generic;
using Caffettiera.CSharp.BLL;
using Caffettiera.CSharp.Common;


namespace Test.DAL
{
public class C : IEntity
    {
        protected genTest.Entities.A entity;

        public class Key : KeyBase
        {
            public static implicit operator int(Key k) { return k.id; }
            public static implicit operator Key(int id) { return new Key(id); }
        }

        public Key Pk
        {
            get { return entity.AId; }
            set { entity.AId = value; }
        }

  

    }


}
