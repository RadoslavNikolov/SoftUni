namespace Messages.RestServices.Models.ViewModels
{
    using System;
    using Data.Models;

    public class MessageViewModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime DateSent { get; set; }

        public string Sender { get; set; }
    }
}