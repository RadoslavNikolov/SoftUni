namespace BugTracker.RestServices.Models.ViewModels
{
    public class CommentDetailViewModel : CommentViewModel
    {
        public int BugId { get; set; }

        public string BugTitle { get; set; }
    }
}