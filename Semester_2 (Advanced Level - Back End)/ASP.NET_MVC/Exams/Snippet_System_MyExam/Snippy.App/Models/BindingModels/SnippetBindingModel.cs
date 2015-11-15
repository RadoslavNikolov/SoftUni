namespace Snippy.App.Models.BindingModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Snippy.Models;

    public class SnippetBindingModel
    {
        [Required]
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Title { get; set; }

        [Required]
        //[StringLength(255, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Description { get; set; }

        [Required]
        public string Code { get; set; }


        //public int LanguageId { get; set; }

        //public virtual Language Language { get; set; }

        //[Required]
        //public string AuthorId { get; set; }

        //public virtual User Author { get; set; }

        //public virtual ICollection<Label> Labels
        //{
        //    get { return this.labels; }
        //    set { this.labels = value; }
        //}

        //public virtual ICollection<Comment> Comments
        //{
        //    get { return this.comments; }
        //    set { this.comments = value; }
        //} 
    }
}