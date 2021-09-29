using System.Collections.Generic;
using D3.TwistPin.Controllers;

namespace D3.TwistPin.Service.Test
{
    public interface IBookService
    {
        public List<Book> GetAllBooks();
        public Book GetBook(int bookId);
        public Book AddBook(BookRequest bookRequest);
        public void DeleteBook(int bookId);
    }
}