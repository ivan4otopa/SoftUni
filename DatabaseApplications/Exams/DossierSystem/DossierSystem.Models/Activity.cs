namespace DossierSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Activity
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime ActiveFrom { get; set; }

        public DateTime? ActiveTo { get; set; }

        [Required]
        public string IndividualId { get; set; }

        public virtual Individual Individual { get; set; }

        public int ActivityTypeId { get; set; }

        public virtual ActivityType ActivityType { get; set; }
    }
}
