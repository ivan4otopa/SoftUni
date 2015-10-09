namespace Twitter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tweet
    {
        private ICollection<User> usersWhoFavorited;
        private ICollection<Report> reports;

        public Tweet()
        {
            this.UsersWhoFavourited = new HashSet<User>();
            this.Reports = new HashSet<Report>();
        }

        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        public string URL { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<User> UsersWhoFavourited
        {
            get
            {
                return this.usersWhoFavorited;
            }

            set
            {
                this.usersWhoFavorited = value;
            }
        }

        public virtual ICollection<Report> Reports
        {
            get
            {
                return this.reports;
            }

            set
            {
                this.reports = value;
            }
        }
    }
}
