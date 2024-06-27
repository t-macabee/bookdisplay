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
            .ForMember(dest => dest.Liked, opt => opt.MapFrom(src => src.Liked ?? false))
            .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments.Select(c => new CommentsDto
            {
                Id = c.Id,
                Content = c.Content
            }).ToList()));

            CreateMap<Comments, CommentsDto>();
            CreateMap<CommentsDto, Comments>();
        }
    }
}
