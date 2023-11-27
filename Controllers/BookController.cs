using libreria_AGGP.Data.Services;
using libreria_AGGP.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace libreria_AGGP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        public BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            try
            {
                var allbooks = _bookService.GetAllBks();
                return Ok(allbooks);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookByID(int id)
        {
            try
            {
                var book = _bookService.GetBookById(id);
                return Ok(book);
            }
            catch
            {
                return BadRequest();
            }
            
        }

        [HttpPost("add-book-with-authors")]
        public IActionResult AddBook([FromBody]BookVM book)
        {
            try
            {
                _bookService.AddBookWithAuthors(book);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpPut("update-book-by-id/{id}")]

        public IActionResult UpdateBookById(int id, [FromBody]BookVM book)
        {
            try
            {
                var updateBook = _bookService.UpdateBookById(id, book);
                return Ok(updateBook);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult DeleteBookById(int id)
        {
            try
            {
                _bookService.DeleteBookById(id);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
