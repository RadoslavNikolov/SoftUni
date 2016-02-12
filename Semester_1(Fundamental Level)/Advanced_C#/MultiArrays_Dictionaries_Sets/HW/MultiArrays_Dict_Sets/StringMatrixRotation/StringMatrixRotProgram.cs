namespace StringMatrixRotation
{
    using System;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography.X509Certificates;
    using Interfaces;

    public class StringMatrixRotProgram
    {
        private static IRotateCommand rotateCommand;
        public static void Main()
        {
            
            while (true)
            {
                Console.Write("Enter input: ");
                string inputLine = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(inputLine))
                {
                    Console.WriteLine("Have a nice day");
                    Environment.Exit(0);
                }

                if (inputLine.Contains("Rotate"))
                {
                    if (rotateCommand != null)
                    {
                        Console.WriteLine("Already exists rotate command");
                        Environment.Exit(0);
                    }

                    int degrees = int.Parse(inputLine.Trim().Split('(').Last().Replace(")", string.Empty).Trim());
                    
                    rotateCommand = new RotateCommand(degrees);
                    continue;
                }

                if (inputLine.ToLower().Equals("end") && rotateCommand != null)
                {
                    rotateCommand.DoRotation();
                    Console.WriteLine(rotateCommand.ToString());
                    Environment.Exit(0);
                }

                if (rotateCommand != null)
                {
                    rotateCommand.AddString(inputLine);
                }              
            }
        }
    }
}
