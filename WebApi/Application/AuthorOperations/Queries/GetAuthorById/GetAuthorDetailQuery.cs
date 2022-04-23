using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DBOperations;

namespace Application.AuthorOperations.Queries.GetAuthorById
{
    public class GetAuthorDetailQuery
    {
        public int AuthorId { get; set; }
        private readonly BookStoreDbContext _bookStoreDbContext;
        private readonly IMapper _mapper;

        public GetAuthorDetailQuery(BookStoreDbContext bookStoreDbContext, IMapper mapper)
        {
            _bookStoreDbContext = bookStoreDbContext;
            _mapper = mapper;
        }

        public GetAuthorDetailModel Handle()
        {
            var author = _bookStoreDbContext.Authors.SingleOrDefault(a => a.Id == AuthorId);
            if (author is null)
            {
                throw new InvalidOperationException("Yazar bulunamadı!");
            }

            GetAuthorDetailModel authorDetailModel = _mapper.Map<GetAuthorDetailModel>(author);
            return authorDetailModel;
        }
    }

    public class GetAuthorDetailModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Birthday { get; set; }
    }
}