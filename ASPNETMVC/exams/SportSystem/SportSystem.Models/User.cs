namespace SportSystem.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;    

    public class User : IdentityUser
    {
        private ICollection<Comment> comments;
        private ICollection<Bet> bets;
        private ICollection<Vote> votes;

        public User()
        {
            this.Comments = new HashSet<Comment>();
            this.Bets = new HashSet<Bet>();
            this.Votes = new HashSet<Vote>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            
            return userIdentity;
        }

        public virtual ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }

            set
            {
                this.comments = value;
            }
        }

        public virtual ICollection<Bet> Bets
        {
            get
            {
                return this.bets;
            }

            set
            {
                this.bets = value;
            }
        }

        public virtual ICollection<Vote> Votes
        {
            get
            {
                return this.votes;
            }

            set
            {
                this.votes = value;
            }
        }
    }
}
