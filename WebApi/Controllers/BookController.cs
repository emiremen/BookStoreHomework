using System;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.DeleteBookCommand;
using WebApi.BookOperations.GetBookById;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.UpdateBook;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {

        private readonly BookStoreDbContext _dbContext;

        public BookController(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_dbContext);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetBookByIdQuery query = new GetBookByIdQuery(_dbContext);
            var result = query.Handle(id);
            return Ok(result);
        }

        // [HttpGet]
        // public Book GetByIdWithQuery([FromQuery] string id){
        //     var book = BookList.Where(x => x.Id == int.Parse(id)).SingleOrDefault();
        //     return book;
        // }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand createBookCommand = new CreateBookCommand(_dbContext);
            try
            {
                createBookCommand.BookModel = newBook;
                createBookCommand.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }

        // [HttpPut]
        // public IActionResult UpdateBook([FromBody] Book updatedBook){
        //     var book = BookList.SingleOrDefault(x=> x.Id == updatedBook.Id);
        //     if (book is null)
        //     {
        //         return BadRequest();
        //     }

        //     book.GenreId = updatedBook.GenreId != default ? updatedBook.GenreId : book.GenreId;
        //     book.PageCount = updatedBook.PageCount != default ? updatedBook.PageCount : book.PageCount;
        //     book.PublishDate = updatedBook.PublishDate != default ? updatedBook.PublishDate : book.PublishDate;
        //     book.Title = updatedBook.Title != default ? updatedBook.Title : book.Title;
        //     return Ok();
        // }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommand updateBookCommand = new UpdateBookCommand(_dbContext);
            try
            {
                updateBookCommand.BookModel = updatedBook;
                updateBookCommand.Handle(id);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand bookCommand = new DeleteBookCommand(_dbContext);
            try
            {
                bookCommand.BookId = id;
                bookCommand.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}