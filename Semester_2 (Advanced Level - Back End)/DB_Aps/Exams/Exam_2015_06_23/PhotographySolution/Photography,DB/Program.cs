using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photography_DB
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PhotographySystemEntities();
            var manifacturers = context.Cameras
                .OrderBy(c => c.Manufacturer.Name)
                .ThenBy(c => c.Model)
                .Select(c => new
                {
                    c.Manufacturer.Name,
                    c.Model
                }).ToList();

            manifacturers.ForEach(c =>
            {
                Console.WriteLine("{0}  {1}", c.Name, c.Model);
            });
        }
    }
}
