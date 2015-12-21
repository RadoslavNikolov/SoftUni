namespace Blobs.Core.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Infrastructure;

    public class Create : CommandAbstract
    {
        public Create(IList<string> parameters, IBlobsData data, IUnitFactory unitFactory) 
            : base(parameters, data, unitFactory)
        {
        }

        public override string Execute()
        {
            var unit = this.UnitFactory.CreateUnit(this.Parameters);
            this.Data.AddBlob(unit);

//#if DEBUG
//            this.Output.AppendLine(string.Format("I am {0}. And I was created successfully", this.GetType().Name));

//            if (this.Parameters != null)
//            {
//                foreach (var parameter in this.Parameters)
//                {
//                    this.Output.AppendLine(parameter);
//                }
//            }

//            return this.Output.ToString();
//#endif      

            this.Data.Blobs.Where(b => b.Health >= 0).ToList().ForEach(b => b.Update());

            return "";
        }
    }
}