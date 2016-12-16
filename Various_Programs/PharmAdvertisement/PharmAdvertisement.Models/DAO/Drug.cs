namespace PharmAdvertisement.Models.DAO
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;

    public class Drug
    {
        public Drug()
        {
            this.Diagnoses = new HashSet<Diagnosis>();
        }

        public int DrugId { get; set; }

        [Required]
        public string Name { get; set; }

        public byte[] Image { get; set; }

        public string Details { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        public virtual ICollection<Diagnosis> Diagnoses { get; set; }
    }
}
