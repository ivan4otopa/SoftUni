namespace Snippy.App.App_Start
{
    using AutoMapper;

    using Models;

    using Snippy.Models;

    public class MapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<Snippet, SnippetViewModel>();
            Mapper.CreateMap<Comment, CommentViewModel>()
                .ForMember("Author", c => c.MapFrom(co => co.Author.UserName));
            Mapper.CreateMap<Label, LabelViewModel>()
                .ForMember("SnippetsCount", c => c.MapFrom(l => l.Snippets.Count));
            Mapper.CreateMap<Label, SnippetLabelViewModel>();
            Mapper.CreateMap<Snippet, SnippetDetailsViewModel>()
                .ForMember("Author", c => c.MapFrom(s => s.Author.UserName))
                .ForMember("AuthorId", c => c.MapFrom(s => s.AuthorId));
            Mapper.CreateMap<Comment, SnippetDetailsCommentViewModel>()
                .ForMember("Author", c => c.MapFrom(co => co.Author.UserName))
                .ForMember("SnippetId", c => c.MapFrom(co => co.SnippetId))
                .ForMember("AuthorId", c => c.MapFrom(co => co.AuthorId));
            Mapper.CreateMap<Snippet, CommentSnippetViewModel>();
        }
    }
}