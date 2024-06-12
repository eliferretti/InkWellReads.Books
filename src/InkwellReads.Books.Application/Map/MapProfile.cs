using AutoMapper;
using InkwellReads.Books.Application.Command.Books;
using InkwellReads.Books.Application.Command.Categories;
using InkwellReads.Books.Application.Dto;
using InkWellReads.Books.Domain.Entities;

namespace InkwellReads.Books.Application.Map
{
    public class MapProfile : Profile
    {
        public MapProfile() 
        {
            CreateMap<Author, AuthorDto>()
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.ToString("dd/MM/yyyy")))
                .ReverseMap();

            CreateMap<Author, AddAuthorDto>().ReverseMap();

            CreateMap<Book, BookDto>().ReverseMap();

            CreateMap<Book, AddBookDto>()
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorId))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.PublicationDate, opt => opt.MapFrom(src => src.PublicationDate.ToString("dd/MM/yyyy")))
                .ForMember(dest => dest.Synopsis, opt => opt.MapFrom(src => src.Synopsis))
                .ForMember(dest => dest.Isbn, opt => opt.MapFrom(src => src.Isbn))
                .ForMember(dest => dest.Publisher, opt => opt.MapFrom(src => src.Publisher))
                .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.Language))
                .ReverseMap();

            CreateMap<Book, UpdateBookCommand>()
                .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Book, opt => opt.MapFrom(src => src))
                .ReverseMap(); 

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, AddCategoryDto>().ReverseMap();
        }
    }
}
