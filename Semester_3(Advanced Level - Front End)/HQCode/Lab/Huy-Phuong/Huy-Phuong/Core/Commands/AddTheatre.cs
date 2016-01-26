namespace Huy_Phuong.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Infrastructure;

    public class AddTheatre : CommandAbstract
    {
        public AddTheatre(IList<string> parameters, ITheatreData data) 
            : base(parameters, data)
        {
            if (parameters.Count < 0)
            {
                throw new ArgumentException(string.Format("{0} command must have theatre name as parameter", this.GetType().Name));
            }
        }

        public override string Execute()
        {
            try
            {
                this.Data.AddTheatre(this.Parameters.First());
                return "Theatre added";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public override string ToString()
        {
            return String.Format("{0} with parameters: {1}", this.GetType().Name, String.Join("/", this.Parameters));
        }
    }
}