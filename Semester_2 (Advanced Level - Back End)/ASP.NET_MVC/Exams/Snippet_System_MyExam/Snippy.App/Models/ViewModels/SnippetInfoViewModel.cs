namespace Snippy.App.Models.ViewModels
{
    using System.Collections.Generic;
    using AutoMapper;
    using Infrastructure.Mapping;
    using Snippy.Models;

    public class SnippetInfoViewModel : IMapFrom<Snippet>
    {
        public int Id { get; set; }
     
        public string Title { get; set; }

        public IEnumerable<LabelViewModel> Labels { get; set; }
    }
}