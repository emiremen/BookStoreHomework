using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        public int GenreId { get; set; }
        private readonly BookStoreDbContext _bookStoreDbContext;
        private readonly IMapper _mapper;

        public GetGenreDetailQuery(BookStoreDbContext bookStoreDbContext, IMapper mapper)
        {
            _bookStoreDbContext = bookStoreDbContext;
            _mapper = mapper;
        }

        public GenreDetailViewModel Handle()
        {
            var genre = _bookStoreDbContext.Genres.SingleOrDefault(g => g.IsActive && g.Id == GenreId);
            if(genre is null){
                throw new InvalidOperationException("Kitap türü bulunamadı.");
            }
            GenreDetailViewModel genresViewModel = _mapper.Map<GenreDetailViewModel>(genre);
            return genresViewModel;
        }

    }
    public class GenreDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}