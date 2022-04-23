using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DBOperations;

namespace Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly BookStoreDbContext _bookStoreDbContext;
        private readonly IMapper _mapper;

        public GetAuthorsQuery(BookStoreDbContext bookStoreDbContext, IMapper mapper)
        {
            _bookStoreDbContext = bookStoreDbContext;
            _mapper = mapper;
        }

        public List<GetAuthorsModel> Handle()
        {
            var authors = _bookStoreDbContext.Authors.OrderBy(a=>a.Id);

            List<GetAuthorsModel> authorsModels = _mapper.Map<List<GetAuthorsModel>>(authors);

            return authorsModels;
        }
    }

    public class GetAuthorsModel{
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Birthday { get; set; }
    }
}