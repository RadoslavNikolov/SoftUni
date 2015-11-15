namespace Snippy.App.Models.ViewModels
{
    using Infrastructure.Mapping;
    using Snippy.Models;

    public class LanguageViewModel : IMapFrom<Language>
    {
        public int Id { get; set; }

        public string Name { get; set; } 
    }
}