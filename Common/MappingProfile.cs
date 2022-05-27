using AutoMapper;
using WebApi.BookOperations.CreateBooks;
using Webapi.BookOperations.GetBookDetail;
using WebApi.BookOperations.GetBooks;

namespace WebApi.Common
{

    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();   // Birinci source diğeri target Book objesiini src ye maple demek 
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, BooksViewModel>().ForMember(dest=> dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));

        }

    }
}