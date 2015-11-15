namespace OnlineShop.Test
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Moq;
    using Services.Controllers;

    [TestClass]
    public class AdsControllerTests
    {
        private MockContainer mocks;

        [TestInitialize]
        public void InitTest()
        {
            this.mocks = new MockContainer();
            this.mocks.PrepareMocks();
        }

        [TestMethod]
        public void GetAllAds_Should_Return_Total_Ads_Sorted_By_TypeIndex()
        {
            var fakeAds = this.mocks.AdRepositoryMock.Object.All();

            var mockContext = new Mock<IOnlineShopData>();

            var adsController = new AdsController(mockContext.Object);
        }

        [TestMethod]
        public void CreateAd_Should_Successfully_Add_To_Repository()
        {
            var ads = new List<Ad>();

            var fakeUser = this.mocks.ApplicationUserRepositoryMock.Object.All().FirstOrDefault();
            if (fakeUser == null)
            {
                Assert.Fail("Cannot perform test - no users available");
            }


            this.mocks.AdRepositoryMock
                .Setup(r => r.Add(It.IsAny<Ad>()))
                .Callback((Ad ad) =>
                {
                    ad.Owner = fakeUser;
                    ads.Add(ad);
                });
        }
    }
}