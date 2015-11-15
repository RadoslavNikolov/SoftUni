﻿namespace Messages.RestServices.Models.BindingModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;

    public class ChannelMessageBindingModel
    {
        [Required]
        public string Text { get; set; }
    }
}