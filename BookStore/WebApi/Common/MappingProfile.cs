using AutoMapper;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.Application.BookOperations.Queries.GetBookDetail;
using WebApi.Application.BookOperations.Queries.GetBooks;
using WebApi.Application.GenreOperations.Commands.Queries.GetGenres;
using WebApi.Application.GenreOperations.Queries.GetGenresDetail;
using WebApi.Entities;
using static WebApi.Application.BookOperations.Commands.CreateBook.CreateBookCommand;
using static WebApi.Application.BookOperations.Commands.UpdateBook.UpdateBookCommand;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel,Book>();
            CreateMap<Book,BookDetailViewModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book,BookViewModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Genre,GenresViewModel>();
            CreateMap<Genre,GenreDetailViewModel>();
            CreateMap<Author , AuthorsViewModel>();
            CreateMap<Author , AuthorDetailViewModel>()
            .ForMember(dest => dest.Book , opt=> opt.MapFrom(src => src.Book.Title));
            CreateMap<CreateAuthorModel, Author>();
            CreateMap<UpdateBookModel , Book >();
        }
    }
}