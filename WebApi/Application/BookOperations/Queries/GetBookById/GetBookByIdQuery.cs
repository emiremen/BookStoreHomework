using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.Application.BookOperations.Queries.GetBookById
{
    public class GetBookByIdQuery
    {
        public int BookId {get;set;}
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBookByIdQuery(BookStoreDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public BookViewModel Handle()
        {
            var book = _dbContext.Books.Include(x=>x.Genre).SingleOrDefault(book=>book.Id == BookId);
            if(book is null){
                throw new InvalidOperationException("Kitap bulunamadı!");
            }
            BookViewModel bookViewModel = _mapper.Map<BookViewModel>(book);
            return bookViewModel;
        }
    }

    public class BookViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
        public bool IsPublished { get; set; }
    }
}