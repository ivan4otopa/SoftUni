﻿namespace Snippy.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<Snippet> snippets;
        private ICollection<Comment> comments;

        public User()
        {
            this.Snippets = new HashSet<Snippet>();
            this.Comments = new HashSet<Comment>();
        }
        
        public virtual ICollection<Snippet> Snippets
        {
            get
            {
                return this.snippets;
            }

            set
            {
                this.snippets = value;
            }
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

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            
            return userIdentity;
        }
    }
}
