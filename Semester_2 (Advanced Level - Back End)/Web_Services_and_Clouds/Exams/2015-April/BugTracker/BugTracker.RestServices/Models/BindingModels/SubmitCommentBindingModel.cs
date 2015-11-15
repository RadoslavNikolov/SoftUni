namespace BugTracker.RestServices.Models.BindingModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;

    public class SubmitCommentBindingModel
    {
        [Required]
        public string Text { get; set; }
    }
}