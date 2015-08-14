using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mountains_Code_First
{
    class MountainsCodeFirst
    {
        static void Main(string[] args)
        {
            var context = new MountainsContext();
            //Console.WriteLine(context.Countries.Count());

            //Country c = new Country()
            //{
            //    Code = "AB",
            //    Name = "Absurdistan"
            //};

            //Mountain m = new Mountain(){ Name = "Absurdistan Hills"};
            //m.Peaks.Add(new Peak()
            //{
            //    Name = "Great Peak", Mountain = m
            //});
            //m.Peaks.Add(new Peak()
            //{
            //    Name = "Small Peak",
            //    Mountain = m
            //});
            //c.Mountains.Add(m);
            //context.Countries.Add(c);
            //context.SaveChanges();


            var countriesQuery = context.Countries.Select(c => new
            {
                CountryName = c.Name,
                Mountains = c.Mountains.Select(m => new
                {
                    m.Name,
                    m.Peaks
                })
            }).ToList();

            foreach (var country in countriesQuery)
            { 
                Console.WriteLine("Country: " + country.CountryName);

                foreach (var mountain in country.Mountains)
                {
                    Console.WriteLine("  Mountain: " + mountain.Name);

                    foreach (var peak in mountain.Peaks)
                    {
                        Console.WriteLine("\t{0}  ({1})", peak.Name, peak.Elevation);
                    }
                }
                
            }
        }
    }
}
