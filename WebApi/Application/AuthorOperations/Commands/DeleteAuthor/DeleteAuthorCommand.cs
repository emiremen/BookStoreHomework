using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DBOperations;

namespace Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        public int AuthorId { get; set; }
        private readonly BookStoreDbContext _dbContext;

        public DeleteAuthorCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(a => a.Id == AuthorId);
            if (author is null)
            {
                throw new InvalidOperationException("Silinecek yazar bulunamadı!");
            }
            else if (_dbContext.Books.Where(a => a.IsPublished == true && a.AuthorId == author.Id).Count() !> 0)
            {
                throw new InvalidOperationException("Yazarın yayında kitabı bulunduğundan silme işlemi gerçekleştirilemedi!");
            }
            _dbContext.Remove(author);
            _dbContext.SaveChanges();
        }
    }
}