using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;

namespace WebApi.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommand
    {
        public int BookId {get;set;}
        public UpdateBookModel BookModel { get; set; }
        private readonly BookStoreDbContext _dbContext;
        public UpdateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
            if (book is null)
            {
                throw new NotFoundException("Güncellenecek kitap bulunamadı!");
            }

            book.GenreId = BookModel.GenreId != default ? BookModel.GenreId : book.GenreId;
            book.PageCount = BookModel.PageCount != default ? BookModel.PageCount : book.PageCount;
            book.PublishDate = BookModel.PublishDate != default ? BookModel.PublishDate : book.PublishDate;
            book.Title = BookModel.Title != default ? BookModel.Title : book.Title;
            _dbContext.SaveChanges();
        }
    }

    public class UpdateBookModel{
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }

    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {

        }
    }
}