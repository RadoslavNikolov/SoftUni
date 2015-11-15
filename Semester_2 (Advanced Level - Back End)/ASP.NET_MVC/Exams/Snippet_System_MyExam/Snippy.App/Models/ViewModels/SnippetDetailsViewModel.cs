namespace Snippy.App.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Infrastructure.Mapping;
    using Snippy.Models;

    public class SnippetDetailsViewModel : IMapFrom<Snippet>
    {

        public int Id { get; set; }
   
        public string Title { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

        public DateTime CreatedOn { get; set; }

        public LanguageViewModel Language { get; set; }

        public UserViewModel Author { get; set; }

        public IEnumerable<LabelViewModel> Labels { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
     
    }
}