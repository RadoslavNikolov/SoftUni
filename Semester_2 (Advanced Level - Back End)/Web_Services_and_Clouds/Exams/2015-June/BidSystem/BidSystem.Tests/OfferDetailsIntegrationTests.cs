namespace BidSystem.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;

    [TestClass]
    public class OfferDetailsIntegrationTests
    {
        [TestMethod]
        public void CreateOfferWithBids_ListDeatilOfferById_ShouldListOfferCorrectly()
        {
            // Arrange -> create a offers  with  2 bids
            TestingEngine.CleanDatabase();
            var userSession = TestingEngine.RegisterUser("peter", "pAssW@rd#123456");
            var offerToAdd = new OfferModel() { Title = "Second Offer (Active 3 months)", Description = "Description", InitialPrice = 500, ExpirationDateTime = DateTime.Now.AddMonths(3)};
            var httpResultOffer = TestingEngine.CreateOfferHttpPost(userSession.Access_Token, offerToAdd.Title, offerToAdd.Description, offerToAdd.InitialPrice, offerToAdd.ExpirationDateTime);
            Assert.AreEqual(HttpStatusCode.Created, httpResultOffer.StatusCode);
            var offer = httpResultOffer.Content.ReadAsAsync<OfferModel>().Result;
            var offersCount = TestingEngine.GetOffersCountFromDb();
            Assert.AreEqual(1, offersCount);

            //create a few bids
            userSession = TestingEngine.LoginUser("peter", "pAssW@rd#123456");
            var bidsToAdds = new BidModel[]
            {
                new BidModel() { BidPrice = 600, Comment = "My first bid" },
                new BidModel() { BidPrice = 700 }
            };

            foreach (var bid in bidsToAdds)
            {
                var httpResultBid = TestingEngine.CreateBidHttpPost(userSession.Access_Token, offer.Id, bid.BidPrice, bid.Comment);
                Assert.AreEqual(HttpStatusCode.OK, httpResultBid.StatusCode);
            }

            var bidsCount = TestingEngine.GetBidsCountFromDb();
            Assert.AreEqual(2, bidsCount);

            //Act
            var httpResponse = TestingEngine.HttpClient.GetAsync("/api/offers/details/" + offer.Id).Result;

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            var bidsFromService = httpResponse.Content.ReadAsAsync<DetailOfferModel>().Result;
            Assert.AreEqual("Description", bidsFromService.Description);
            Assert.AreEqual(500, bidsFromService.InitialPrice);
            Assert.AreEqual(2, bidsFromService.Bids.Count());


            var httpFakeBidRespone = TestingEngine.CreateBidHttpPost(userSession.Access_Token, 150, 150, "Not Found");
            Assert.AreEqual(HttpStatusCode.NotFound, httpFakeBidRespone.StatusCode);

        }
         
    }
}