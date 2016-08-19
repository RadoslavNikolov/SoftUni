namespace Dynamic_Language_Runtime_Exercise
{
    using Microsoft.CSharp.RuntimeBinder;
    using System;

    class DynamicXmlParserProgram
    {
        static void Main(string[] args)
        {
            dynamic doc = new DynamicXml("Employees.xml");

            try
            {
                foreach (var employee in doc.Company)
                {
                    Console.WriteLine(employee.FirstName);
                }
            }
            catch (RuntimeBinderException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
