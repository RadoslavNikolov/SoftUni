using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdsDB.ConsoleApp
{
    using System.Diagnostics;
    using AdsDBContext;
    using System.Data.Entity;

    class Program
    {
        static void Main(string[] args)
        {
            var context = new AdsEntities();


            ////Problem 1 - 1
            ////do not use Include()
            //var ads = context.Ads.ToList();
            //foreach (var ad in ads)
            //{
            //    Console.WriteLine("{0}  {1} {2} {3} {4}",
            //        ad.Title, ad.AdStatus.Status, ad.Category.Name, ad.Town.Name, ad.AspNetUser);
            //}


            //Use Include

            //var adsWithInclude = context.Ads
            //    .Include(a => a.Title)
            //    .Include(a => a.AdStatus)
            //    .Include(a => a.Category)
            //    .Include(a => a.Town)
            //    .Include(a => a.AspNetUser).ToList();

            //adsWithInclude.ForEach(ad =>
            //{
            //    Console.WriteLine("{0}  {1} {2} {3} {4}",
            //        ad.Title, ad.AdStatus.Status, ad.Category.Name, ad.Town.Name, ad.AspNetUser);
            //});




            ////Problem 3
            //var sw = new Stopwatch();
            //sw.Start();
            //var ever = context.Ads.ToList();
            //ever.ForEach(t => Console.WriteLine(t.Title));
            //Console.WriteLine("\nSelect everything: {0}\n", sw.Elapsed);
            //sw.Restart();

            //var title = context.Ads
            //    .Select(a => a.Title).ToList();
            //title.ForEach(t => Console.WriteLine(t));
            //Console.WriteLine("\nSelect only title: {0}\n", sw.Elapsed);
            //sw.Stop();

        }
    }
}
