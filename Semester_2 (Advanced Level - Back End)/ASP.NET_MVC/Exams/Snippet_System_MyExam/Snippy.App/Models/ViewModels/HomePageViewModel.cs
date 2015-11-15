namespace Snippy.App.Models.ViewModels
{
    using System.Collections.Generic;

    public class HomePageViewModel
    {
        public IEnumerable<SnippetInfoViewModel> SnippetInfoViewModel { get; set; }

        public IEnumerable<CommentViewModel> CommentViewModel { get; set; }

        public IEnumerable<LabelInfoViewModel> LabelInfoViewModel { get; set; } 
    }
}