using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model.InputModels
{
    public class PatientInputModel
    {
        public int? Id { get; set; }

        [Required]
        public string Egn { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string FamilyName { get; set; }

        public string Address { get; set; }

        [Required]
        public int CitizenShip { get; set; }

        [Required]
        public int Country { get; set; }

        [Required]
        public int Residentship { get; set; }
    }
}
