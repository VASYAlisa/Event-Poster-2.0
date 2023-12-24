﻿

using System.Collections.ObjectModel;

namespace UnitTests.Mocks
{
    public interface IRepository<T> where T : class
    {
        List<T> GetList();
        T GetItem(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
