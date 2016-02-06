namespace TravelAgency.Execution
{
    using System;
    using Data;
    using Interfaces;
    public class CommandDispatcher
    {
        public CommandDispatcher(ITicketCatalog ticketCatalog)
        {
            this.TicketCatalog = ticketCatalog;
        }

        public CommandDispatcher()
            :this(new TicketCatalog())
        {
            
        }

        private ITicketCatalog TicketCatalog { get; set; }

        public string DispatchCommand(string inputLine)
        {

            int firstSpaceIndex = inputLine.IndexOf(' ');

            if (firstSpaceIndex == -1)
            {
                return "Invalid command!";
            }

            string cd = inputLine.Substring(0, firstSpaceIndex); 

            //switch (cd)
            //{
            //    case "AddAir":
            //        string allParameters = inputLine.Substring(firstSpaceIndex + 1);
            //        string[] parameters = allParameters.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            //        for (int i = 0; i < parameters.Length; i++)
            //        {
            //            parameters[i] = parameters[i].Trim();
            //        }

            //        return this.AddAirTicket(parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], parameters[5]);
            //    case "DeleteAir":
            //        allParameters = inputLine.Substring(firstSpaceIndex + 1); 
            //        parameters = allParameters.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            //        for (int i = 0; i < parameters.Length; i++)
            //        {
            //            parameters[i] = parameters[i].Trim();
            //        }

            //        return this.DeleteAirTicket(parameters[0]);
            //    case "AddTrain":
            //        allParameters = inputLine.Substring(firstSpaceIndex + 1);
            //        parameters = allParameters.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            //        for (int i = 0; i < parameters.Length; i++)
            //        {
            //            parameters[i] = parameters[i].Trim();
            //        }

            //        return this.AddTrainTicket(parameters[0], parameters[1], parameters[2],parameters[3], parameters[4]);
            //    case "DeleteTrain": 
            //        allParameters = inputLine.Substring(firstSpaceIndex + 1); 
            //        parameters = allParameters.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            //        for (int i = 0; i < parameters.Length; i++)
            //        {
            //            parameters[i] = parameters[i].Trim();
            //        } 

            //        return this.DeleteTrainTicket(parameters[0], parameters[1], parameters[2]);
            //    case "AddBus": 
            //        allParameters = inputLine.Substring(firstSpaceIndex + 1);
            //        parameters = allParameters.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            //        for (int i = 0; i < parameters.Length; i++)
            //        {
            //            parameters[i] = parameters[i].Trim();
            //        }

            //        return this.basKaTicketKaIzafah(parameters[0], parameters[1], parameters[2],parameters[3], parameters[4]);
            //    case "DeleteBus":
            //        allParameters = inputLine.Substring(firstSpaceIndex + 1); parameters = allParameters.Split(
            //            new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            //        for (int i = 0; i < parameters.Length; i++)
            //        {
            //            parameters[i] = parameters[i].Trim();
            //        }

            //        return this.DeleteBusTicket(parameters[0], parameters[1], parameters[2], parameters[3]);
            //    case "FindTickets":
            //        allParameters = inputLine.Substring(firstSpaceIndex + 1);
            //        parameters = allParameters.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            //        for (int i = 0; i < parameters.Length; i++)
            //        {
            //            parameters[i] =parameters[i].Trim();
            //        }

            //        return this.FindTickets(parameters[0], parameters[1]);

            //    case "FindTicketsInInterval":
            //        allParameters = inputLine.Substring(firstSpaceIndex + 1);
            //        parameters = allParameters.Split(new char[] { ';' },StringSplitOptions.RemoveEmptyEntries);
            //        for (int i = 0; i < parameters.Length; i++)
            //        {
            //            parameters[i] = parameters[i].Trim();
            //        } 
            //        return this.FindTicketsInInterval(parameters[0], parameters[1]);

            //    default:
            //        return "Invalid command!";
            //}

            return "";
        }
    }
}