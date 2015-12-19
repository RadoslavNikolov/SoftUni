namespace MyCapitalism.Core.Commands
{
    using System.Collections.Generic;
    using Interfaces;

    public class CreateCompany : CommandAbstract
    {
        public CreateCompany(IEnumerable<string> parameters, ICapitalismData data, IReaderWriter readerWriter) 
            : base(parameters, data, readerWriter)
        {
        }

        public override void Execute()
        {
            this.ReaderWriter.Print(string.Format("I am {0}. And I was created successfully", this.GetType().Name));

            foreach (var parameter in Parameters)
            {
                this.ReaderWriter.Print(parameter);
            }
        }
    }
}