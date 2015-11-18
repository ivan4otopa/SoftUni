namespace ChatSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Channel
    {
        private ICollection<User> users;
        private ICollection<ChannelMessage> channelMessges;

        public Channel()
        {
            this.users = new HashSet<User>();
            this.channelMessges = new HashSet<ChannelMessage>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<User> Users 
        {
            get
            {
                return this.users;
            }

            set
            {
                this.users = value;
            }
        }

        public virtual ICollection<ChannelMessage> ChannelMessages
        {
            get
            {
                return this.channelMessges;
            }

            set
            {
                this.channelMessges = value;
            }
        }
    }
}
