namespace Phonebook.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        private ICollection<Channel> channels;
        private ICollection<UserMessage> sentMessages;
        private ICollection<UserMessage> recievedMessages;

        public User()
        {
            this.channels = new HashSet<Channel>();
            this.sentMessages = new HashSet<UserMessage>();
            this.recievedMessages = new HashSet<UserMessage>();
        }

        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public virtual ICollection<UserMessage> SentMessage
        {
            get { return this.sentMessages; }
            set { this.sentMessages = value; }
        }

        public virtual ICollection<UserMessage> RecievedMessage
        {
            get { return this.recievedMessages; }
            set { this.recievedMessages = value; }
        }

        public virtual ICollection<Channel> Channels
        {
            get { return this.channels; }
            set { this.channels = value; }
        }
    }
}