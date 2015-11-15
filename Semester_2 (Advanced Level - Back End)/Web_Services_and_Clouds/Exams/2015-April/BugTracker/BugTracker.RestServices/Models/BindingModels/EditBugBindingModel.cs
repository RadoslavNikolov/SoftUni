namespace BugTracker.RestServices.Models.BindingModels
{
    using Data.Models;

    public class EditBugBindingModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public BugStatus? Status { get; set; }
    }
}