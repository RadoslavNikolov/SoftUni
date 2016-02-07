namespace Huy_Phuong.Core.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Infrastructure;

    public class PrintAllPerformances : CommandAbstract
    {
        public PrintAllPerformances(IList<string> parameters, ITheatreData data) 
            : base(parameters, data)
        {
        }

        public override string Execute()
        {
            var performances = this.Data.ListAllPerformances();
            if (!performances.Any())
            {
                return "No performances";
            }

            var output = new StringBuilder();
            performances.ToList().ForEach(p =>
            {
                output.AppendFormat("{0}, ", p.Print());
            });

            return output.ToString().TrimEnd().TrimEnd(',');
        }
    }
}