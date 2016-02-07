namespace Blobs.Core.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Infrastructure;

    public class Status : CommandAbstract
    {
        public Status(IList<string> parameters, IBlobsData data, IUnitFactory unitFactory) 
            : base(parameters, data, unitFactory)
        {
        }

        public override string Execute()
        {
            if (!this.Data.Blobs.Any())
            {
                return "No Blobs created";
            }
       
            this.Data.Blobs.ToList().ForEach(b =>
            {
                this.Output.AppendLine(b.ToString());
            });

            this.Data.Blobs.Where(b => b.Health >= 0).ToList().ForEach(b => b.Update());

            return this.Output.ToString().Trim();
        }
    }
}