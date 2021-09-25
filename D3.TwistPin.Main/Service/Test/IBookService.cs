using System.Collections.Generic;

namespace D3.TwistPin.Service.Test
{
    public interface IBookService
    {
        public List<Book> GetAllBooks();
        public Book GetBook(int bookId);
        public Book AddBook(Book book);
        public void DeleteBook(int bookId);
    }
}