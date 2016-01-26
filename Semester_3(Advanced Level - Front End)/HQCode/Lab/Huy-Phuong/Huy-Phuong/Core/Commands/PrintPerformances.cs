namespace Huy_Phuong.Core.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Infrastructure;

    public class PrintPerformances : CommandAbstract
    {
        public PrintPerformances(IList<string> parameters, ITheatreData data) 
            : base(parameters, data)
        {
        }

        public override string Execute()
        {
            var theatreName = this.Parameters[0];
            var performances = this.Data.ListPerformances(theatreName);

            if (!performances.Any())
            {
                return "No performances";
            }

            return string.Join(", ", performances);
        }
    }
}