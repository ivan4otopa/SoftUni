namespace DossierSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Individual
    {
        private ICollection<Location> locations;
        private ICollection<Activity> activities;
        private ICollection<Individual> individuals;

        public Individual()
        {
            this.Locations = new HashSet<Location>();
            this.Activities = new HashSet<Activity>();
            this.Individuals = new HashSet<Individual>();
        }

        public string Id { get; set; }

        [Required]
        public string FullName { get; set; }

        public string Alias { get; set; }

        public DateTime? BirthDate { get; set; }

        public Status Status { get; set; }

        public virtual ICollection<Location> Locations
        {
            get
            {
                return this.locations;
            }

            set
            {
                this.locations = value;
            }
        }

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

        public virtual ICollection<Individual> Individuals
        {
            get
            {
                return this.individuals;
            }

            set
            {
                this.individuals = value;
            }
        }
    }
}
