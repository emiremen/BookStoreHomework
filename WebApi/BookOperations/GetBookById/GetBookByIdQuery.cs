using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.BookOperations.GetBooks;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBookById
{
    public class GetBookByIdQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBookByIdQuery(BookStoreDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public BookViewModel Handle(int id)
        {
            var book = _dbContext.Books.Find(id);
            BookViewModel bookViewModel = _mapper.Map<BookViewModel>(book);
            // BookViewModel bookViewModel = new BookViewModel()
            // {
            //     Title = book.Title,
            //     Genre = ((GenreEnum)book.GenreId).ToString(),
            //     PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy"),
            //     PageCount = book.PageCount
            // };
            return bookViewModel;
        }
    }

    public class BookViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}