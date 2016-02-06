namespace TravelAgency.Test
{
    using System;
    using Data;
    using Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models.Enums;

    [TestClass]
    public class TicketCatalogBusTicketsTests
    {
        [TestMethod]
        public void TestAddBusTicketReturnsTickedAdded()
        {
            ITicketCatalog catalog = new TicketCatalog();
            string cmdResult = catalog.AddBusTicket("Sofia", "Varna", "Test Company", new DateTime(2015, 1, 30, 12, 55, 00), 130.50M);

            Assert.AreEqual("Ticket added", cmdResult);
            Assert.AreEqual(1, catalog.GetTicketsCount(TicketType.Bus));
        }

        [TestMethod]
        public void TestAddBusTicketDuplicates()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddBusTicket("Sofia", "Varna", "Test Company", new DateTime(2015, 1, 30, 12, 55, 00), 130.50M);

            string cmdResult = catalog.AddBusTicket("Sofia", "Varna", "Test Company", new DateTime(2015, 1, 30, 12, 55, 00), 130.50M);

            Assert.AreEqual("Duplicate ticket", cmdResult);
            Assert.AreEqual(1, catalog.GetTicketsCount(TicketType.Bus));
        }

        [TestMethod]
        public void TestDeleteBusTicketReturnsTickedDeleted()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddBusTicket("Sofia", "Varna", "Test Company", new DateTime(2015, 1, 30, 12, 55, 00), 130.50M);

            string cmdResult = catalog.DeleteBusTicket("Sofia", "Varna", "Test Company", new DateTime(2015, 1, 30, 12, 55, 00));

            Assert.AreEqual("Ticket deleted", cmdResult);
            Assert.AreEqual(0, catalog.GetTicketsCount(TicketType.Bus));
        }

        [TestMethod]
        public void TestDeleteBusTicketReturnsTickedDoesNotExist()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddBusTicket("Sofia", "Varna", "Test Company", new DateTime(2015, 1, 30, 12, 55, 00), 130.50M);

            string cmdResult = catalog.DeleteBusTicket("Sofia", "Varna", "Test Company", new DateTime(2016, 1, 30, 12, 55, 00));

            Assert.AreEqual("Ticket does not exist", cmdResult);
            Assert.AreEqual(1, catalog.GetTicketsCount(TicketType.Bus));
        }

        [TestMethod]
        public void TestDeleteDeletedBusTicketReturnsTickedDoesNotExist()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddBusTicket("Sofia", "Varna", "Test Company", new DateTime(2015, 1, 30, 12, 55, 00), 130.50M);
            catalog.DeleteBusTicket("Sofia", "Varna", "Test Company", new DateTime(2015, 1, 30, 12, 55, 00));

            string cmdResult = catalog.DeleteBusTicket("Sofia", "Varna", "Test Company", new DateTime(2015, 1, 30, 12, 55, 00));

            Assert.AreEqual("Ticket does not exist", cmdResult);
            Assert.AreEqual(0, catalog.GetTicketsCount(TicketType.Bus));
        }
    }
}