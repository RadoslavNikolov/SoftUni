namespace TravelAgency.Test
{
    using System;
    using Data;
    using Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models.Enums;

    [TestClass]
    public class TicketCatalogTrainTicketTests
    {
        [TestMethod]
        public void TestAddTRainTicketReturnsTickedAdded()
        {
            ITicketCatalog catalog = new TicketCatalog();
            string cmdResult = catalog.AddTrainTicket("Sofia", "Varna", new DateTime(2015, 1, 30, 12, 55, 00), 130.50M, 100.25M);

            Assert.AreEqual("Ticket added", cmdResult);
            Assert.AreEqual(1, catalog.GetTicketsCount(TicketType.Train));
        }

        [TestMethod]
        public void TestAddTrainTicketDuplicates()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddTrainTicket("Sofia", "Varna", new DateTime(2015, 1, 30, 12, 55, 00), 130.50M, 100.25M);

            string cmdResult = catalog.AddTrainTicket("Sofia", "Varna", new DateTime(2015, 1, 30, 12, 55, 00), 130.50M, 100.25M);

            Assert.AreEqual("Duplicate ticket", cmdResult);
            Assert.AreEqual(1, catalog.GetTicketsCount(TicketType.Train));
        }

        [TestMethod]
        public void TestDeleteTrainTicketReturnsTickedDeleted()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddTrainTicket("Sofia", "Varna", new DateTime(2015, 1, 30, 12, 55, 00), 130.50M, 100.25M);

            string cmdResult = catalog.DeleteTrainTicket("Sofia", "Varna", new DateTime(2015, 1, 30, 12, 55, 00));

            Assert.AreEqual("Ticket deleted", cmdResult);
            Assert.AreEqual(0, catalog.GetTicketsCount(TicketType.Train));
        }

        [TestMethod]
        public void TestDeleteTrainTicketReturnsTickedDoesNotExist()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddTrainTicket("Sofia", "Varna", new DateTime(2015, 1, 30, 12, 55, 00), 130.50M, 100.25M);

            string cmdResult = catalog.DeleteTrainTicket("Sofia", "Varna", new DateTime(2016, 1, 30, 12, 55, 00));

            Assert.AreEqual("Ticket does not exist", cmdResult);
            Assert.AreEqual(1, catalog.GetTicketsCount(TicketType.Train));
        }

        [TestMethod]
        public void TestDeleteDeletedTrainTicketReturnsTickedDoesNotExist()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddTrainTicket("Sofia", "Varna", new DateTime(2015, 1, 30, 12, 55, 00), 130.50M, 100.25M);
            catalog.DeleteTrainTicket("Sofia", "Varna", new DateTime(2015, 1, 30, 12, 55, 00));

            string cmdResult = catalog.DeleteTrainTicket("Sofia", "Varna", new DateTime(2015, 1, 30, 12, 55, 00));

            Assert.AreEqual("Ticket does not exist", cmdResult);
            Assert.AreEqual(0, catalog.GetTicketsCount(TicketType.Train));
        }
    }
}