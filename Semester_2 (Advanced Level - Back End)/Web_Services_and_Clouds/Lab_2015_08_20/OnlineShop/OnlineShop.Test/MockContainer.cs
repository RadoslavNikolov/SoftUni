namespace OnlineShop.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data.Repositories;
    using Models;
    using Moq;

    public class MockContainer
    {
        public Mock<IRepository<Ad>> AdRepositoryMock { get; set; }

        public Mock<IRepository<Category>> CategoryRepositoryMock { get; set; }

        public Mock<IRepository<AdType>> AdTypeRepositoryMock { get; set; }

        public Mock<IRepository<ApplicationUser>> ApplicationUserRepositoryMock { get; set; }

        public void PrepareMocks()
        {
            this.SetupFakeAds();
            this.SetupFakeCategories();
            this.SetupFakeUsers();
            this.SetupFakeAdTypes();
        }

        private void SetupFakeAdTypes()
        {
            var fakeAdTypes = new List<AdType>()
            {
                new AdType() {Id = 1, Name = "Normal", Index = 100, PricePerDay = 400},
                new AdType() {Id = 5, Name = "Premium", Index = 200, PricePerDay = 1000}
            };

            this.AdTypeRepositoryMock = new Mock<IRepository<AdType>>();
            this.AdTypeRepositoryMock.Setup(r => r.All())
                .Returns(fakeAdTypes.AsQueryable());

            this.AdTypeRepositoryMock.Setup(r => r.Find(It.IsAny<int>()))
                .Returns((int id) =>
                {
                    var adType = fakeAdTypes.FirstOrDefault(a => a.Id == id);
                    return adType;
                });
        }

        private void SetupFakeUsers()
        {
            var fakeUsers = new List<ApplicationUser>()
            {
                new ApplicationUser(){UserName = "gosho", Id = "122"},
                new ApplicationUser(){UserName = "pesho", Id = "144"},
                new ApplicationUser(){UserName = "minka", Id = "222"},
                new ApplicationUser(){UserName = "penka", Id = "333"},
            };

            this.ApplicationUserRepositoryMock = new Mock<IRepository<ApplicationUser>>();
            this.ApplicationUserRepositoryMock.Setup(r => r.All())
                .Returns(fakeUsers.AsQueryable());

            this.ApplicationUserRepositoryMock.Setup(r => r.Find(It.IsAny<string>()))
                .Returns((string id) =>
                {
                    var user = fakeUsers.FirstOrDefault(u => u.Id == id);
                    return user;
                });
        }

        private void SetupFakeAds()
        {
            var adTypes = new List<AdType>()
            {
                new AdType() {Name = "Normal", Index = 100},
                new AdType() {Name = "Premium", Index = 200}
            };

            var fakeAds = new List<Ad>()
            {
                new Ad()
                {
                    Id = 5,
                    Name = "Audi A6",
                    Type = adTypes[0],
                    PostedOn = DateTime.Now.AddDays(-6),
                    Owner = new ApplicationUser(){UserName = "gosho", Id = "123"},
                    Price = 400,
                    Status = AdStatus.Open
                   
                },
                new Ad()
                {
                    Id = 5,
                    Name = "Audi RS6",
                    Type = adTypes[1],
                    PostedOn = DateTime.Now.AddDays(-10),
                    Owner = new ApplicationUser(){UserName = "penka", Id = "12"},
                    Price = 40000,
                    Status = AdStatus.Open
                }
            };

            this.AdRepositoryMock = new Mock<IRepository<Ad>>();
            this.AdRepositoryMock.Setup(r => r.All())
                .Returns(fakeAds.AsQueryable());

            this.AdRepositoryMock.Setup(r => r.Find(It.IsAny<int>()))
                .Returns((int id) =>
                {
                    var ad = fakeAds.FirstOrDefault(a => a.Id == id);
                    return ad;
                });
        }

        private void SetupFakeCategories()
        {           
            var fakeCategories = new List<Category>()
            {
                new Category(){Id = 5, Name = "plane"},
                new Category(){Id = 55, Name = "bike"},
                new Category(){Id = 100, Name = "car"},
                new Category(){Id = 102, Name = "rocket"},
                new Category(){Id = 233, Name = "bus"},
            };

            this.CategoryRepositoryMock = new Mock<IRepository<Category>>();
            this.CategoryRepositoryMock.Setup(c => c.All())
                .Returns(fakeCategories.AsQueryable());

            this.CategoryRepositoryMock.Setup(c => c.Find(It.IsAny<int>()))
                .Returns((int id) =>
                {
                    var category = fakeCategories.FirstOrDefault(c => c.Id == id);
                    return category;
                });
        }
    }
}