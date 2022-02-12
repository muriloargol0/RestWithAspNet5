using RestWithAspNet.Model;
using System.Collections.Generic;

namespace RestWithAspNet.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO book);
        BookVO FindById(long id);
        BookVO Update(BookVO book);
        void Delete(long id);
        List<BookVO> FindAll();
    }
}
