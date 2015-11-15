using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop_Web_API.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class PutBookBindingModel : BookBindingModel
    {
        [Required(ErrorMessage = "Author Id is required!")]
        public int AuthorId { get; set; }
    }
}