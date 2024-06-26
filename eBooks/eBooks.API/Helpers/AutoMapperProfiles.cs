using AutoMapper;
using eBooks.API.DTOs;
using eBooks.API.Entities;

namespace eBooks.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<Books, BooksDto>()
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments));
            CreateMap<Comments, CommentsDto>();
        }
    }
}
