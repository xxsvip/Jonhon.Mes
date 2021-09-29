using System;
using D3.TwistPin.Controllers;
using D3.TwistPin.Service.Test;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace D3.TwistPin.Controller.Test
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
        public ActionResult GetAll()
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            var allBooks = _bookService.GetAllBooks();
            return Ok(allBooks);
        }
        
        [HttpGet("get/{id}")]
        public ActionResult GetById(int id)
        {
            var book = _bookService.GetBook(id);
            return Ok(book);
        }


        [HttpPost("add")]
        public ActionResult<Book> Add([FromBody] BookRequest bookRequest)
        {
            var addedBook = _bookService.AddBook(bookRequest);
            return addedBook;
        }
        
        
        [HttpDelete("delete/{id}")]
        public ActionResult<Book> DeleteById(int id)
        {
            _bookService.DeleteBook(id);
            return Ok($"book deleted with id {id}");
        }



    }
}