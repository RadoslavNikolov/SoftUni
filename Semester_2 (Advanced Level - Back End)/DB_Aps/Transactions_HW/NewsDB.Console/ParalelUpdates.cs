namespace NewsDB.Console
{
    using System;
    using System.Linq;
    using Data;

    public class ParalelUpdates
    {
        public static void MakeParalelUpdate()
        {
            var context = new NewsDBContext();
            Console.WriteLine(context.News.Count());

            PrintNewsContent(context);

            var firstNew = context.News.FirstOrDefault();
            Console.WriteLine("Enter the new text: ");

            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var newText = Console.ReadLine();
                    firstNew.Content = newText;
                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    Console.WriteLine("\nThe changes were made successfully!");

                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    Console.WriteLine("Error: " + ex.Message);
                    MakeParalelUpdate();
                }
            }

            Console.WriteLine();
            PrintNewsContent(context);
        }


        private static void PrintNewsContent(NewsDBContext context)
        {
            var news = context.News
                .Select(n => n.Content)
                .ToList();
            news.ForEach(n => Console.WriteLine(n));
        }
    }
}