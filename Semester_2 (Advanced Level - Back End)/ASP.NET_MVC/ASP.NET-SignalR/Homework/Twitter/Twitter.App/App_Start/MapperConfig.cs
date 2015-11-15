namespace Twitter.App
{
    using AutoMapper;

    public static class MapperConfig
    {
        public static void ConfigureMappings()
        {
            //Mapper.CreateMap<Post, PostConciseViewModel>()
            //    .ForMember(model => model.Author, config => config.MapFrom(post => post.Author.UserName));
            //Mapper.CreateMap<Post, PostFullViewModel>()
            //    .ForMember(model => model.Author, config => config.MapFrom(post => post.Author.UserName));
        }
    }
}