namespace SportSystem.App.Models.BindigModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TeamBindingModel
    {
        [Required(ErrorMessage = "The {0} is required!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The {0} should be between {2} and {1}")]
        public string Name { get; set; }

        [StringLength(100, MinimumLength = 3, ErrorMessage = "The {0} should be between {2} and {1}")]
        public string NickName { get; set; }

        [Url(ErrorMessage = "Invalid {0}")]
        public string WebSite { get; set; }

        public DateTime? Founded { get; set; }

        public ICollection<string> Players { get; set; }
    }
}