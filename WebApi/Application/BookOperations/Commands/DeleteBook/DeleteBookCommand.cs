using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DBOperations;

namespace WebApi.Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; }
        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(book => book.Id == BookId);
            if (book is null)
            {
                throw new InvalidOperationException("Silinecek kitap bulunamad─▒!");
            }
            //else if(book.)
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();

        }
    }
}