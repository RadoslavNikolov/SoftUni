namespace SportSystem.App.Models.BindigModels
{
    using System.ComponentModel.DataAnnotations;
    using Infrastructure.Mapping;
    using Model;

    public class CommentBindingModel
    {
        public int MatchId { get; set; }

        [Required]
        public string Content { get; set; }
    }
}