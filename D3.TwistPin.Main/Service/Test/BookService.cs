using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using D3.TwistPin.Controllers;
using Dapper;
using Microsoft.AspNetCore.Mvc;
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
            var sql = "select id,name,to_char(CREATE_TIME,'yyyy-mm-dd hh24:mi:ss') CreateTime,to_char(UPDATE_TIME,'yyyy-mm-dd hh24:mi:ss') UpdateTime from test_book ";
            return _db.Query<Book>(sql).ToList();
        }

        public Book GetBook(int bookId)
        {
            var sql = "select id,name,to_char(CREATE_TIME,'yyyy-mm-dd hh24:mi:ss') CreateTime,to_char(UPDATE_TIME,'yyyy-mm-dd hh24:mi:ss') UpdateTime from test_book where id = :id";
            return _db.QueryFirst<Book>(sql,new {id = bookId});
        }

        public Book AddBook([FromBody] BookRequest bookRequest)
        {
            var sql1 = @"insert into test_book(id,name,create_time,update_time) values(test_book_seq.nextval,:name,to_date(:create_time,'YYYY-MM-DD HH24:mi:ss'),to_date(:update_time,'YYYY-MM-DD HH24:mi:ss'))";
            _db.Execute(sql1, new {name = bookRequest.Name, create_time = "2019-09-09 09:09:09", update_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")});
           
            var sql2 = "select test_book_seq.currval from dual";
            var id = _db.QueryFirst<int>(sql2);
            
            var sqlQuery = "select id,name,to_char(CREATE_TIME,'yyyy-mm-dd hh:mi:ss') CreateTime,to_char(UPDATE_TIME,'yyyy-mm-dd hh:mi:ss') UpdateTime from test_book where id = :id";
            var returnBook = _db.QueryFirstOrDefault<Book>(sqlQuery,new {id = id});
            return returnBook;
        }

        public void DeleteBook(int bookId)
        {
            var sql = "delete from TEST_BOOK where ID = :id";
            _db.Execute(sql, new {id = bookId});
        }
    }
    
    
}