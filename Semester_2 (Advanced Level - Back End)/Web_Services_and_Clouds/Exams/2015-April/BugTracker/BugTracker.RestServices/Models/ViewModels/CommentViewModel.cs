﻿namespace BugTracker.RestServices.Models.ViewModels
{
    using System;

    public class CommentViewModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string Author { get; set; }

        public DateTime DateCreated { get; set; }
    }
}