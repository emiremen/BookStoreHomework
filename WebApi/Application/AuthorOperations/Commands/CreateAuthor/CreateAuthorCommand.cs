using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorModel authorModel { get; set; }
        private readonly BookStoreDbContext _bookStoreDbContext;
        private readonly IMapper _mapper;

        public CreateAuthorCommand(BookStoreDbContext bookStoreDbContext, IMapper mapper)
        {
            _bookStoreDbContext = bookStoreDbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author = _bookStoreDbContext.Authors.SingleOrDefault(a => a.Name == authorModel.Name && a.Surname == authorModel.Surname);
            if (author is not null)
            {
                throw new InvalidOperationException("Yazar zaten mevcut!");
            }
            author = _mapper.Map<Author>(authorModel);
            _bookStoreDbContext.Add(author);
            _bookStoreDbContext.SaveChanges();
        }


    }
    public class CreateAuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
    }
}