namespace ChatSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserMessage
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime Datetime { get; set; }

        public int RecipientId { get; set; }

        public virtual User Recipient { get; set; }

        public int SenderId { get; set; }

        public virtual User Sender { get; set; }
    }
}
