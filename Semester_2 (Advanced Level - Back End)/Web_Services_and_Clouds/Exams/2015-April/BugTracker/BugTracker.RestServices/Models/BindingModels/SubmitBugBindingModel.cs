namespace BugTracker.RestServices.Models.BindingModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;

    public class SubmitBugBindingModel
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
    }
}