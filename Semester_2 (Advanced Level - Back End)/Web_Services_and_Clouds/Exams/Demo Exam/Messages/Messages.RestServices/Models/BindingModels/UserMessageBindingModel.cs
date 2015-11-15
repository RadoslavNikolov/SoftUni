namespace Messages.RestServices.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class UserMessageBindingModel
    {
        [Required]
        public string Text { get; set; }

        [Required]
        public string Recipient { get; set; }
    }
}