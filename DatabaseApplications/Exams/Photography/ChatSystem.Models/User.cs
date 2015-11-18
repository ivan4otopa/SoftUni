namespace ChatSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        private ICollection<Channel> channels;
        private ICollection<ChannelMessage> channelMessages;
        private ICollection<UserMessage> sentMessages;
        private ICollection<UserMessage> recievedMessages;

        public User()
        {
            this.channels = new HashSet<Channel>();
            this.channelMessages = new HashSet<ChannelMessage>();
            this.sentMessages = new HashSet<UserMessage>();
            this.recievedMessages = new HashSet<UserMessage>();
        }

        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public virtual ICollection<Channel> Channels
        {
            get
            {
                return this.channels;
            }

            set
            {
                this.channels = value;
            }
        }

        public virtual ICollection<ChannelMessage> ChannelMessages
        {
            get
            {
                return this.channelMessages;
            }

            set
            {
                this.channelMessages = value;
            }
        }

        [InverseProperty("Sender")]
        public virtual ICollection<UserMessage> SentMessages
        {
            get
            {
                return this.sentMessages;
            }

            set
            {
                this.sentMessages = value;
            }
        }

        [InverseProperty("Recipient")]
        public virtual ICollection<UserMessage> RecievedMessages
        {
            get
            {
                return this.recievedMessages;
            }

            set
            {
                this.recievedMessages = value;
            }
        }
    }
}
