namespace PharmAdvertisement.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using PharmAdvertisement.Models.DAO;

    public class Diagnosis
    {
        public Diagnosis()
        {
            this.Drugs = new HashSet<Drug>();
        }

        public int DiagnosisId { get; set; }

        public Diagnosis Parent { get; set; }

        [Required]
        [MaxLength(255)]
        public string DiagnosisName { get; set; }

        [MaxLength(10)]
        public string DiagnosisCode { get; set; }

        [Required]
        public bool IsDiag { get; set; } = true;

        [Required]
        public bool IsActive { get; set; } = true;

        public bool IsAkmp { get; set; } = false;

        public string MkbAkmpMapping { get; set; }

        public virtual ICollection<Drug> Drugs { get; set; }
    }
}
