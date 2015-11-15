using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Battleships.WebServices.Models.Binding_Models
{
    using System.ComponentModel.DataAnnotations;
    using Battleships.Models;

    public class ShipBindingModel
    {
        [Required(ErrorMessage = "PositionX is required!")]
        public int PositionX { get; set; }

        [Required(ErrorMessage = "PositionY is required!")]
        public int PositionY { get; set; }

    }
}