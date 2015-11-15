namespace BidSystem.Tests
{
    using System.Linq;
    using Data.UnitOfWork;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using RestServices.Controllers;
    using RestServices.Providers;

    [TestClass]
    public class MockTestMyBids
    {
        private MockContainer mocks;

        private Mock<IBidSystemData> mockContext;

        private Mock<IUserProvider> mockUserProvider;

        private BidsController controller;

        [TestInitialize]
        public void InitTest()
        {
            this.mocks = new MockContainer();
            this.mocks.PrepareMocks();
            this.mockContext = new Mock<IBidSystemData>();
            this.PrepareMockContext();
            this.mockUserProvider = new Mock<IUserProvider>();
            this.PrepareMockUserProvider();

            //this.controller = new NewsController(this.mockContext.Object, this.mockUserProvider.Object);
            //this.SetupController(this.controller);
        }





        private void PrepareMockContext()
        {
            this.mockContext.Setup(c => c.Bids)
                .Returns(this.mocks.BidsRepositoryMock.Object);
            this.mockContext.Setup(c => c.Offers)
                .Returns(this.mocks.OffersRepositoryMock.Object);
            this.mockContext.Setup(c => c.Users)
                .Returns(this.mocks.UserRepositoryMock.Object);
            this.mockContext.Setup(c => c.Users.Find(It.IsAny<string>()))
                .Returns(this.mocks.UserRepositoryMock.Object.All().FirstOrDefault());
        }

        private void PrepareMockUserProvider()
        {
            this.mockUserProvider.SetupGet(ip => ip.IsAuthenticated)
                .Returns(true);
            this.mockUserProvider.Setup(ip => ip.GetUserId())
                .Returns(this.mocks.UserRepositoryMock.Object.All().First().Id);
        }
    }
}