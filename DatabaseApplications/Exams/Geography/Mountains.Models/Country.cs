namespace Mountains.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Country
    {
        private ICollection<Mountain> mountains;

        public Country()
        {
            this.mountains = new HashSet<Mountain>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(2)]
        [MinLength(2)]
        public string CountryCode { get; set; }

        [Required]
        public string CountryName { get; set; }

        public virtual ICollection<Mountain> Mountains
        {
            get
            {
                return this.mountains;
            }

            set
            {
                this.mountains = value;
            }
        }
    }
}
