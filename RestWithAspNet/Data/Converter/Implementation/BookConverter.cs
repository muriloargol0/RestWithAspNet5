using RestWithAspNet.Data.Converter.Contract;
using RestWithAspNet.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestWithAspNet.Data.Converter.Implementation
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        public BookVO Parse(Book origin)
        {
            if (origin == null) return null;

            return new BookVO
            {
                Author = origin.Author,
                Id = origin.Id,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price,   
                Title = origin.Title,
            };
        }

        public Book Parse(BookVO origin)
        {
            if(origin == null) return null;

            return new Book
            {
                Author = origin.Author,
                Id = origin.Id,
                LaunchDate = origin.LaunchDate,
                Title = origin.Title,   
                Price = origin.Price,
            };
        }

        public List<Book> Parse(List<BookVO> origin)
        {
            return origin.Select(o => Parse(o)).ToList();
        }

        public List<BookVO> Parse(List<Book> origin)
        {
            return origin.Select(o => Parse(o)).ToList();
        }

    }
}

