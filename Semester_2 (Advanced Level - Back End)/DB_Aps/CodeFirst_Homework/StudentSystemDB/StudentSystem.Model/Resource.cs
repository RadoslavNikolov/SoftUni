namespace StudentSystem.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

    public class Resource
    {
        private ICollection<License> licenses;

        public Resource(ICollection<License> licenses = null)
        {
            this.licenses = new HashSet<License>();
        }


        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public ResourseType ResourseType { get; set; }

        public string Url { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        public ICollection<License> Licenses
        {
            get { return this.licenses; }
            set { this.licenses = value; }
        }
    }
}