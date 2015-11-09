﻿namespace Snippy.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Language
    {
        private ICollection<Snippet> snippets;

        public Language()
        {
            this.Snippets = new HashSet<Snippet>();
        }

        [Key]
        public string Name { get; set; }

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
    }
}