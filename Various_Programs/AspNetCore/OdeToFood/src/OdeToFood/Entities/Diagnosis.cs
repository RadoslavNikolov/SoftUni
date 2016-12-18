using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Entities
{
    public class Diagnosis
    {
        [Required]
        public int DiagnosisId { get; set; }

        [Required]
        public string Name { get; set; }


        public string Code { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        public bool IsDiag { get; set; } = true;

        public ICollection<Diagnosis> Diagnoses { get; set; }
    }
}
