using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using D3.TwistPin.Service.Test;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace D3.TwistPin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {

        private readonly ILogger<BooksController> _logger;
        private readonly IBookService _bookService;
        public BooksController(ILogger<BooksController> logger,IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        [HttpGet("all")]
        public ActionResult Get()
        {
            return Ok("hello");
        }


        [HttpPost("add")]
        public ActionResult<Book> Add(Book book)
        {
            var addedBook = _bookService.AddBook(book);
            return addedBook;
        }
        
        
        [HttpGet("getOne")]
        public ActionResult<Book> getOne(int bookId)
        {
            var book = _bookService.GetBook(bookId);
            return book;
        }



    }
}