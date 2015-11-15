namespace Template.App.Models.ViewModels
{
    using System;
    using System.Linq.Expressions;
    using Template.Models;

    public class TownViewModel
    {
        public string Name { get; set; }

        public static Expression<Func<Town, TownViewModel>> Create
        {
            get
            {
                return t => new TownViewModel
                {
                    Name = t.Name
                };
            }
        } 
    }
}