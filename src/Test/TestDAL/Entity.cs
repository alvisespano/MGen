
using System.Collections;
using System.Collections.Generic;
using Caffettiera.CSharp.BLL;
using Caffettiera.CSharp.Common;


namespace Test.DAL
{

    public class KeyBase
    {
        protected int id;
        protected KeyBase(int id) { this.id = id; }
    }


    public interface IEntity
    {
        static class Key : KeyBase { }
        Key Pk { get; set; }
    }

    public interface IProvider<E> where E : IEntity
    {
        ICollection<E> RetrieveAll();
        E RetrieveByKey(E.Key k);
        void Insert(E e);
        void Update(E e);
        void Delete(E e);
    }
}