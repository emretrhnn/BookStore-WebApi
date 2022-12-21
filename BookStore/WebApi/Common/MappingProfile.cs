using AutoMapper;
using WebApi.Application.BookOperations.Queries.GetBookDetail;
using WebApi.Application.BookOperations.Queries.GetBooks;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Entities;
using static WebApi.Application.BookOperations.Commands.CreateBook.CreateBookCommand;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel,Book>();
            CreateMap<Book,BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book,BookViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            //booksviewmodel içerisindeki genre yı  su sekılde maple sana bununla ilgili config 
            //vermek istiyorum.map from yanı neyden mapleyeceğini söylüyorum src üzeindeki genreıdyi 
            //genre enumından cast ederek bu ıd yi enum a dönüştür sonrasında bana genreenum ın fıeldın 
            //strıng karsılıgını getır.
            CreateMap<Genre,GenresViewModel>();
        }
    }
}