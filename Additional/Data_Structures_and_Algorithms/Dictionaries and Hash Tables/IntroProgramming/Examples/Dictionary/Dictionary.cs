using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Dictionary
    {
        static void Main(string[] args)
        {
            IDictionary<string, double> studentsMarks = new Dictionary<string, double>();

            studentsMarks["Gosho"] = 5.0;
            studentsMarks["Penka"] = 3.66;
            studentsMarks["Minka"] = 6.00;
            studentsMarks["Ivan"] = 3.12;
            studentsMarks["Mincho"] = 5.15;

            double goshoMark = studentsMarks["Gosho"];
            Console.WriteLine("Gosho`s marks: {0:0.00}", goshoMark);

            studentsMarks.Remove("Gosho");
            Console.WriteLine("Gosho`s mark removed");

            Console.WriteLine("Is Gosho in thi dictionary: {0}", studentsMarks.ContainsKey("Gosho") ? "Yes!" : "No!");


            double penkaMark = studentsMarks["Penka"];
            Console.WriteLine("Penka`s marks: {0:0.00}", penkaMark);
            studentsMarks["Penka"] = 6.00;
            Console.WriteLine("Penka`s mark changed");
            penkaMark = studentsMarks["Penka"];
            Console.WriteLine("Penka`s marks: {0:0.00}", penkaMark);

            double ivansMark;
            studentsMarks.TryGetValue("Ivan", out ivansMark);
            Console.WriteLine("Ivan`s marks: {0:0.00}", ivansMark);

            Console.WriteLine("Students marks:");
            foreach (var student in studentsMarks)
            {
                Console.WriteLine("{0} has {1:0.00}", student.Key, student.Value);
            }
            Console.WriteLine("There are {0} students", studentsMarks.Count);

            studentsMarks.Clear();
            Console.WriteLine("Students dictionary cleared!");
            Console.WriteLine("Is students dictionary cleared?  {0}", studentsMarks.Count == 0);

        }
    }
}
