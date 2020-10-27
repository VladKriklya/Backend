using AutoMapper;
using BLL.DataTransferObjects;
using BLL.Models;

namespace BLL.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Post, PostDto>();
            CreateMap<Comment, CommentDto>();
            CreateMap<PostForCreationDto, Post>();
            CreateMap<CommentForCreationDto, Comment>();
            CreateMap<PostForUpdateDto, Post>();
            CreateMap<CommentForUpdateDto, Comment>();
        }
    }
}
