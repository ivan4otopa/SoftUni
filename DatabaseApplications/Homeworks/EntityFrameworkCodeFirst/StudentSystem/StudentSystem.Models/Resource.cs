namespace StudentSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Resource
    {
        private ICollection<License> licenses;

        public Resource()
        {
            this.licenses = new HashSet<License>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public ResourceType ResourceType { get; set; }

        public string URL { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public virtual ICollection<License> Licenses
        {
            get
            {
                return this.licenses;
            }

            set
            {
                this.licenses = value;
            }
        }
    }
}
