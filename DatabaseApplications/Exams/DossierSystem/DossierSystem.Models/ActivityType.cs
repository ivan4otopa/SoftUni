namespace DossierSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ActivityType
    {
        private ICollection<Activity> activities;

        public ActivityType()
        {
            this.Activities = new HashSet<Activity>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Activity> Activities
        {
            get
            {
                return this.activities;
            }

            set
            {
                this.activities = value;
            }
        }
    }
}
