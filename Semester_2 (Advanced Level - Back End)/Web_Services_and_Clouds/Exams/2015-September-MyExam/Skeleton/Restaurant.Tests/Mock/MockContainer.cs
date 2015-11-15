namespace Restaurant.Tests.Mock
{
    using System.Collections.Generic;
    using System.Linq;
    using Restaurants.Data.Repositories;
    using Restaurants.Models;
    using Moq;

    public class MockContainer
    {
        public int InitialTownsCount { get; private set; }

        public int InitialRestaurantsCount { get; private set; }

        public Mock<IRepository<Town>> TownRepositoryMock { get; set; }

        public Mock<IRepository<Restaurant>> RestaurantRepositoryMock { get; set; }

        public Mock<IRepository<User>> UserRepositoryMock { get; set; }

        public IList<Town> TownsFakeRepo { get; set; }

        public IList<Restaurant> RestaurantsFakeRepo { get; set; }

        public IList<User> UserFakeRepo { get; set; }


        public void PrepareMocks()
        {
            this.SetupFakeTowns();
            this.SetupFakeRestaurants();
            this.SetupFakeUsers();
            this.InitialTownsCount = this.TownsFakeRepo.Count;
            this.InitialRestaurantsCount = this.RestaurantsFakeRepo.Count;
        }


        private void SetupFakeTowns()
        {
            this.TownsFakeRepo = new List<Town>
            {
                new Town() {Id = 1, Name = "Varna"},
                new Town() {Id = 2, Name = "Sofia"},
            };

            this.TownRepositoryMock = new Mock<IRepository<Town>>();

            this.TownRepositoryMock
                .Setup(r => r.All())
                .Returns(this.TownsFakeRepo.AsQueryable());

            this.TownRepositoryMock.Setup(r => r.Find(It.IsAny<int>()))
                .Returns((int id) =>
                {
                    var ad = this.TownsFakeRepo.FirstOrDefault(t => t.Id == id);
                    return ad;
                });
        }

        private void SetupFakeRestaurants()
        {
            this.RestaurantsFakeRepo = new List<Restaurant>
            {
                new Restaurant()
                {
                    Id = 1,
                    Name = "First moq restaurant",
                    Town = this.TownRepositoryMock.Object.All().FirstOrDefault(t => t.Id == 1),
                    //Owner  = this.UserRepositoryMock.Object.All().FirstOrDefault(u => u.Id == "1")
                },
                new Restaurant()
                {
                    Id = 2,
                    Name = "Second moq restaurant",
                    Town = this.TownRepositoryMock.Object.All().FirstOrDefault(t => t.Id == 2),
                    //Owner  = this.UserRepositoryMock.Object.All().FirstOrDefault(u => u.Id == "1")
                }
            };

            this.RestaurantRepositoryMock = new Mock<IRepository<Restaurant>>();
            this.RestaurantRepositoryMock.Setup(r => r.All())
                .Returns(this.RestaurantsFakeRepo.AsQueryable());

            this.RestaurantRepositoryMock.Setup(r => r.Find(It.IsAny<int>()))
                .Returns((int id) =>
                {
                    var ad = this.RestaurantsFakeRepo.FirstOrDefault(a => a.Id == id);
                    return ad;
                });
        }


        private void SetupFakeUsers()
        {
            this.UserFakeRepo = new List<User>
            {
                new User() {Id = 1.ToString() , UserName = "user1", Email = "user1@abv.bg"},
            };

            this.UserRepositoryMock = new Mock<IRepository<User>>();

            this.UserRepositoryMock
                .Setup(r => r.All())
                .Returns(this.UserFakeRepo.AsQueryable());

            this.UserRepositoryMock.Setup(r => r.Find(It.IsAny<int>()))
                .Returns((int id) =>
                {
                    var ad = this.UserFakeRepo.First();
                    return ad;
                });
        }
       
    }
}