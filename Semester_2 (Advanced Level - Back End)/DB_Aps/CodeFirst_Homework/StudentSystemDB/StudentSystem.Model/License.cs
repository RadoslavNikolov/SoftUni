namespace StudentSystem.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class License
    {
        private ICollection<Resource> resources;

        public License()
        {
            this.resources = new HashSet<Resource>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }


        public ICollection<Resource> Resources
        {
            get { return this.resources; }
            set { this.resources = value; }
        }

    }
}