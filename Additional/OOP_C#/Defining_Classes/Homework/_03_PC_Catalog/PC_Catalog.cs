﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_PC_Catalog
{
    public class PC_Catalog
    {
        public static void Main()
        {
            List<Computer> computers = new List<Computer>();
            Computer acer = new Computer(
                    "Acer Aspire",
                    new Component("Processor", 350.36m, "Intel i7"),
                    new Component("Ram", 105.25m, "8GB DDR3"));

            acer.AddComponents(new Component("Hdd", 200.00M), new Component("Monitor", 300.0m, "LG 13 Wide"));

            Computer toshiba = new Computer(
                "Toshiba Satellite",
                new Component("Graphic card", 420.16m, "Ati Radeon R9 1GB"),
                new Component("Motherboard", 160.00m));

            //Console.WriteLine(acer);
            //Console.WriteLine(toshiba);

            //sort by price
            computers.Add(acer);
            computers.Add(toshiba);
            computers = computers.OrderBy(computer => computer.TotalPrice).ToList();
            foreach (Computer computer in computers)
            {
                Console.WriteLine("--------------------------------\n" + computer);
            }

        }
    }
}
