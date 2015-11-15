namespace BugTracker.RestServices.Models.ViewModels
{
    using System.Collections.Generic;

    public class BugDetailViewModel : BugViewModel
    {
        public string Description { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; } 
    }
}