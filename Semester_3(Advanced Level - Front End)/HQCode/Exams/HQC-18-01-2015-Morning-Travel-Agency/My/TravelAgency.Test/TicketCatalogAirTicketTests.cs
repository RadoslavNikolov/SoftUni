using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TravelAgency.Test
{
    using Data;
    using Interfaces;
    using Models.Enums;

    [TestClass]
    public class TicketCatalogAirTicketTests
    {
        [TestMethod]
        public void TestAddAirTicketReturnsTickedAdded()
        {
            ITicketCatalog catalog = new TicketCatalog();
            string cmdResult = catalog.AddAirTicket("FX215", "Sofia", "Varna", "Bulgaria Air", new DateTime(2015, 1, 30, 12, 55, 00), 130.50M);

            Assert.AreEqual("Ticket added", cmdResult);
            Assert.AreEqual(1, catalog.GetTicketsCount(TicketType.Air));
        }

        [TestMethod]
        public void TestAddAirTicketDuplicates()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddAirTicket("FX215", "Sofia", "Varna", "Bulgaria Air", new DateTime(2015, 1, 30, 12, 55, 00), 130.50M);

            string cmdResult = catalog.AddAirTicket("FX215", "Sofia", "Varna", "Bulgaria Air", new DateTime(2015, 1, 30, 12, 55, 00), 130.50M);

            Assert.AreEqual("Duplicate ticket", cmdResult);
            Assert.AreEqual(1, catalog.GetTicketsCount(TicketType.Air));
        }

        [TestMethod]
        public void TestDeleteAirTicketReturnsTickedDeleted()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddAirTicket("FX215", "Sofia", "Varna", "Bulgaria Air", new DateTime(2015, 1, 30, 12, 55, 00), 130.50M);

            string cmdResult = catalog.DeleteAirTicket("FX215");

            Assert.AreEqual("Ticket deleted", cmdResult);
            Assert.AreEqual(0, catalog.GetTicketsCount(TicketType.Air));
        }

        [TestMethod]
        public void TestDeleteAirTicketReturnsTickedDoesNotExist()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddAirTicket("FX215", "Sofia", "Varna", "Bulgaria Air", new DateTime(2015, 1, 30, 12, 55, 00), 130.50M);

            string cmdResult = catalog.DeleteAirTicket("FX217");

            Assert.AreEqual("Ticket does not exist", cmdResult);
            Assert.AreEqual(1, catalog.GetTicketsCount(TicketType.Air));
        }

        [TestMethod]
        public void TestDeleteDeletedAirTicketReturnsTickedDoesNotExist()
        {
            ITicketCatalog catalog = new TicketCatalog();
            catalog.AddAirTicket("FX215", "Sofia", "Varna", "Bulgaria Air", new DateTime(2015, 1, 30, 12, 55, 00), 130.50M);
            catalog.DeleteAirTicket("FX215");

            string cmdResult = catalog.DeleteAirTicket("FX215");

            Assert.AreEqual("Ticket does not exist", cmdResult);
            Assert.AreEqual(0, catalog.GetTicketsCount(TicketType.Air));
        }
    }
}
