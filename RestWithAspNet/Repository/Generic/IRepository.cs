using RestWithAspNet.Model.Base;
using System.Collections.Generic;

namespace RestWithAspNet.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindById(long id);
        T Update(T item);
        void Delete(long id);
        List<T> FindAll();
        bool Existis(long id);
        List<T> FindWithPagedSearch(string query);
        int GetCount(string query);
    }
}
