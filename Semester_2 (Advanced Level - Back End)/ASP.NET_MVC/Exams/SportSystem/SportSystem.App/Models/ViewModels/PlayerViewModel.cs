namespace SportSystem.App.Models.ViewModels
{
    using System;
    using Infrastructure.Mapping;
    using Model;

    public class PlayerViewModel : IMapFrom<Player>
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public double Height { get; set; }
    }
}