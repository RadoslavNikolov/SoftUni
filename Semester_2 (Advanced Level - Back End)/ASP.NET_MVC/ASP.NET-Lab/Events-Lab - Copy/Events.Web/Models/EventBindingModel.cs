﻿namespace Events.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;

    public class EventBindingModel
    {
        [Required(ErrorMessage = "Event title is required")]
        [StringLength(200, ErrorMessage = "The {0} must be betweeb {2} and {1} characters long.", MinimumLength = 1)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Date and Time")]
        public DateTime StartDateTime { get; set; }

        public TimeSpan? Duration { get; set; }

        public string Description { get; set; }

        [MaxLength(200)]
        public string Location { get; set; }

        [Display(Name = "Is Public?")]
        public bool IsPublic { get; set; }
    }
}