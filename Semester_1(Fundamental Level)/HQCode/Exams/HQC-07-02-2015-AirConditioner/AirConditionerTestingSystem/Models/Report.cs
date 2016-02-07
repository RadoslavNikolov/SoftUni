namespace AirConditionerTestingSystem.Models
{
    using System.Text;

    public class Report : ModelAbstract
    {
        public Report(string manufacturer, string model, int mark)
            : base(manufacturer, model)
        {
            this.Mark = mark;
        }

        public int Mark { get; private set; }

        public override string ToString()
        {
            ////Fixing this with StringBuilder
            var result = new StringBuilder();

            result.AppendLine("Report");
            result.AppendLine("====================");
            result.AppendLine(string.Format("Manufacturer: {0}", this.Manufacturer));
            result.AppendLine(string.Format("Model: {0}", this.Model));
            result.AppendLine(string.Format("Mark: {0}", this.Mark == 0 ? "Failed" : "Passed"));
            result.Append("====================");

            return result.ToString();
        }
    }
}