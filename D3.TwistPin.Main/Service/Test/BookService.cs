using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace D3.TwistPin.Service.Test
{
    public class BookService : IBookService
    {
        
        private readonly IDbConnection _db;


        public BookService(IConfiguration configuration)
        {
            _db = new OracleConnection(configuration.GetConnectionString("Nas_Oracle"));
        }
        
        public List<Book> GetAllBooks()
        {
            return null;
        }

        public Book GetBook(int bookId)
        {
            var sql = "select * from test_book where id = :id";
            return _db.QueryFirst<Book>(sql,new {id = bookId});
        }

        public Book AddBook(Book book)
        {
            var sql1 = @"insert into test_book(id,name,create_time,update_time) values(test_book_seq.nextval,:name,:create_time,:update_time)";
            _db.Execute(sql1, new {name = book.Name, create_time = new DateTime(), update_time = new DateTime()});
            var sql2 = "select test_book_seq.currval from dual";
            var id = _db.QueryFirst<int>(sql2);
            book.Id = id;
            return book;
        }

        public void DeleteBook(int bookId)
        {
            throw new System.NotImplementedException();
        }
    }
    
    
}