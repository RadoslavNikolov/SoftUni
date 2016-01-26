namespace Huy_Phuong.Core.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Infrastructure;

    public class PrintAllTheatres : CommandAbstract
    {
        public PrintAllTheatres(IList<string> parameters, ITheatreData data) : base(parameters, data)
        {
        }

        public override string Execute()
        {
            var allTheatres = this.Data.ListTheatres();

            if (!allTheatres.Any())
            {
                return "No theatres";
            }

            return string.Join(", ", allTheatres);
        }
    }
}