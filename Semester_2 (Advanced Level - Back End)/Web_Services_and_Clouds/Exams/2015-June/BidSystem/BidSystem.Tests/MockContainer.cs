namespace BidSystem.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data.Models;
    using Data.Repositories;
    using Moq;

    public class MockContainer
    {
        public int InitialOffersCount { get; private set; }

        public int InitialBidsCount { get; private set; }

        public Mock<IRepository<Bid>> BidsRepositoryMock { get; set; }

        public Mock<IRepository<Offer>> OffersRepositoryMock { get; set; }

        public Mock<IRepository<User>> UserRepositoryMock { get; set; }

        public IList<Offer> OffersFakeRepo { get; set; }

        public IList<Bid> BidsFakeRepo { get; set; }


        public void PrepareMocks()
        {
            this.SetupFakeUsers();
            this.SetupFakeOffer();
            this.SetupFakeBids();
            this.InitialOffersCount = this.OffersFakeRepo.Count;
            this.InitialBidsCount = this.BidsFakeRepo.Count;
        }

        private void SetupFakeBids()
        {
            this.BidsFakeRepo = new List<Bid>
            {
                new Bid
                {
                    Id = 1,
                    BidderId = this.UserRepositoryMock.Object.All().First().Id,
                    Bidder = this.UserRepositoryMock.Object.All().First(),
                    OfferId = 1,
                    Comment = "Mock Bid1",
                    OfferedPrice = 25,
                    DateCreated = DateTime.Now,
                },
                new Bid
                {
                    Id = 2,
                    BidderId = this.UserRepositoryMock.Object.All().First().Id,
                    Bidder = this.UserRepositoryMock.Object.All().First(),
                    OfferId = 2,
                    Comment = "Mock Bid2",
                    OfferedPrice = 30,
                    DateCreated = DateTime.Now,
                }
            };

            this.BidsRepositoryMock = new Mock<IRepository<Bid>>();
            this.BidsRepositoryMock.Setup(r => r.All())
                .Returns(this.BidsFakeRepo.AsQueryable());

            this.BidsRepositoryMock.Setup(r => r.Find(It.IsAny<int>()))
                .Returns((int id) =>
                {
                    var ad = this.BidsFakeRepo.FirstOrDefault(a => a.Id == id);
                    return ad;
                });

            this.BidsRepositoryMock
                .Setup(r => r.Add(It.IsAny<Bid>()))
                .Callback((Bid bids) =>
                {
                    bids.Bidder = this.UserRepositoryMock.Object.All().FirstOrDefault();
                    this.BidsFakeRepo.Add(bids);
                });

        }

        private void SetupFakeOffer()
        {
            this.OffersFakeRepo = new List<Offer>
            {
                new Offer()
                {
                    Id = 1,
                    Title = "Offer #1",
                    Description = "Mock Offer",
                    SellerId = this.UserRepositoryMock.Object.All().First().Id,
                    Seller = this.UserRepositoryMock.Object.All().First(),
                    InitialPrice = 20,
                    DatePublished = DateTime.Now,
                    ExpirationDateTime = DateTime.Now.AddMonths(5)
                },
                new Offer()
                {
                    Id = 2,
                    Title = "Offer #2",
                    Description = "Mock Offer",
                    SellerId = this.UserRepositoryMock.Object.All().First().Id,
                    Seller = this.UserRepositoryMock.Object.All().First(),
                    InitialPrice = 100,
                    DatePublished = DateTime.Now,
                    ExpirationDateTime = DateTime.Now.AddMonths(5)
                }
            };

            this.OffersRepositoryMock = new Mock<IRepository<Offer>>();
            this.OffersRepositoryMock.Setup(r => r.All())
                .Returns(this.OffersFakeRepo.AsQueryable());

            this.OffersRepositoryMock.Setup(r => r.Find(It.IsAny<int>()))
                .Returns((int id) =>
                {
                    var ad = this.OffersFakeRepo.FirstOrDefault(a => a.Id == id);
                    return ad;
                });

            this.OffersRepositoryMock
                .Setup(r => r.Add(It.IsAny<Offer>()))
                .Callback((Offer offers) =>
                {
                    offers.Seller = this.UserRepositoryMock.Object.All().FirstOrDefault();
                    this.OffersFakeRepo.Add(offers);
                });
        }

        private void SetupFakeUsers()
        {
            var fakeUsers = new List<User>
            {
                new User() {UserName = "vanko1", Email = "vanko1@abv.bg"},
            };

            this.UserRepositoryMock = new Mock<IRepository<User>>();

            this.UserRepositoryMock
                .Setup(r => r.All())
                .Returns(fakeUsers.AsQueryable());
        }
    }
}