namespace Bookmarks.App.App_Start
{
    using System;
    using AutoMapper;
    using Bookmarks.Models;
    using Models;
    using System.Linq;

    public class MapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<Bookmark, BookmarkViewModel>();
            Mapper.CreateMap<Bookmark, BookmarkDetailsViewModel>()
                .ForMember("CategoryName", c => c.MapFrom(b => b.Category.Name));
            Mapper.CreateMap<Comment, CommentViewModel>()
                .ForMember("Author", c => c.MapFrom(co => co.Author.UserName));
        }
    }
}