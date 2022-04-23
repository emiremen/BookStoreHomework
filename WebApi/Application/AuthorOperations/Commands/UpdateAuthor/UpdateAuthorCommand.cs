using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        public int AuthorId { get; set; }
        public UpdateAuthorModel AuthorModel { get; set; }
        private readonly BookStoreDbContext _dbContext;

        public UpdateAuthorCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public void Handle(){
            var author = _dbContext.Authors.SingleOrDefault(a=>a.Id == AuthorId);
            if(author is null){
                throw new InvalidOperationException("Güncellenecek yazar bulunamadı!");
            }


            author.Name = AuthorModel.Name != default ? AuthorModel.Name : author.Name;
            author.Surname = AuthorModel.Surname !=default ? AuthorModel.Surname : author.Surname;
            author.Birthday = AuthorModel.Birthday != default ? AuthorModel.Birthday : author.Birthday;

            _dbContext.SaveChanges();
        }

    }

    public class UpdateAuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
    }
}