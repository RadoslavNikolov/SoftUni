namespace BangaloreUniversityLearningSystem.Views
{
    using System.Text;
    using Interfaces;

    public abstract class ViewAbstract : IView
    {
        protected ViewAbstract(object model)
        {
            this.Model = model;
        }

        public object Model { get; private set; }

        public string Display()
        {
            var viewResult = new StringBuilder();
            this.BuildViewResult(viewResult);
            return viewResult.ToString().Trim();
        }

        protected abstract void BuildViewResult(StringBuilder viewResult);
    }
}
