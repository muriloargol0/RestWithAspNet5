using RestWithAspNet.Data.VO;
using RestWithAspNet.Hypermedia.Utils;
using RestWithAspNet.Model;
using System.Collections.Generic;

namespace RestWithAspNet.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindById(long id);
        List<PersonVO> FindByName(string firstName, string lastName);
        PersonVO Update(PersonVO person);
        void Delete(long id);
        List<PersonVO> FindAll();
        PagedSearchVO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int currentPage);
        PersonVO Disable(long id);
    }
}
