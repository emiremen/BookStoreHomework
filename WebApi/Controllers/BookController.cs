using System;
using System.Collections;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.BookOperations.Commands.CreateBook;
using WebApi.Application.BookOperations.Commands.DeleteBook;
using WebApi.Application.BookOperations.Commands.UpdateBook;
using WebApi.Application.BookOperations.Queries.GetBookById;
using WebApi.Application.BookOperations.Queries.GetBooks;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {

        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public BookController(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_dbContext, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetBookByIdQuery query = new GetBookByIdQuery(_dbContext, _mapper);
            query.BookId = id;
            GetBookByIdValidator validator = new GetBookByIdValidator();
            validator.ValidateAndThrow(query);
            var result = query.Handle();
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
            CreateBookCommand createBookCommand = new CreateBookCommand(_dbContext, _mapper);

            createBookCommand.BookModel = newBook;
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            validator.ValidateAndThrow(createBookCommand);
            createBookCommand.Handle();

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

            updateBookCommand.BookModel = updatedBook;
            updateBookCommand.BookId = id;
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            validator.ValidateAndThrow(updateBookCommand);
            updateBookCommand.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand bookCommand = new DeleteBookCommand(_dbContext);

            bookCommand.BookId = id;
            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            validator.ValidateAndThrow(bookCommand);
            bookCommand.Handle();

            return Ok();
        }
    }
}