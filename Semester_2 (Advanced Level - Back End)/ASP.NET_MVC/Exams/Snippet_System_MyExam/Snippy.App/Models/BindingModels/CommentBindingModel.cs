namespace Snippy.App.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class CommentBindingModel
    {
        public int SnippetId { get; set; }

        [Required]
        public string Content { get; set; }
    }
}