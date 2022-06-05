using RestWithAspNet.Model;

namespace RestWithAspNet.Repository.Generic
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person Disable(long id);
    }
}
