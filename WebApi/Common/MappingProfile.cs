using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.Application.BookOperations.Commands.CreateBook;
using WebApi.Application.BookOperations.Queries.GetBookById;
using WebApi.Application.BookOperations.Queries.GetBooks;
using WebApi.Entities;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using Application.AuthorOperations.Queries.GetAuthors;
using Application.AuthorOperations.Queries.GetAuthorById;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookViewModel>().ForMember(dest=> dest.Genre, opt => opt.MapFrom(src=>src.Genre.Name));
            CreateMap<Book, BooksViewModel>()
            .ForMember(dest=> dest.Genre, opt => opt.MapFrom(src=>src.Genre.Name))
            .ForMember(dest=>dest.PublishDate, opt => opt.MapFrom(src=>src.PublishDate.ToShortDateString()));
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
            CreateMap<Author, CreateBookModel>();
            CreateMap<Author, GetAuthorsModel>().ForMember(d=>d.Birthday, opt => opt.MapFrom(src=>src.Birthday.ToShortDateString()));
            CreateMap<Author, GetAuthorDetailModel>().ForMember(d=>d.Birthday, opt => opt.MapFrom(src=>src.Birthday.ToShortDateString()));;
        }
    }
}