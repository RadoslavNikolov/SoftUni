namespace Blobs.Core.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Infrastructure;

    public class ReportEvents : CommandAbstract
    {
        public ReportEvents(IList<string> parameters, IBlobsData data, IUnitFactory unitFactory)
            : base(parameters, data, unitFactory)
        {
        }

        public override string Execute()
        {
            this.Data.Blobs.Where(b => b.Health >= 0).ToList().ForEach(b => b.Update());

            return "";
        }
    }
}