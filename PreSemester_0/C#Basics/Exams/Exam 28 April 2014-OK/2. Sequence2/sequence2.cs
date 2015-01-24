using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Sequence2
{
    class sequence2
    {
        static void Main(string[] args)
        {
            string inputNumber = Console.ReadLine().Trim();
            int k = int.Parse(Console.ReadLine());
            string[] strInput = inputNumber.Split(' ');
            for (int i = 0; i < strInput.Length; i++)
            {
                if (strInput[i]!="?")
                {
                    int count=0;
                    for (int j = 1; j <= k-1; j++)
                    {
                        if (i+j<strInput.Length)
                        {
                            if (strInput[i]==strInput[i+j])
                            {
                                count++;
                            }
                        }
                        else
                        {
                            break;
                        }                                               
                    }

                    if (count==k-1)
                    {
                        if (true)
                        {
                            for (int j = 0; j < k; j++)
                            {
                                strInput[i + j] = "?";
                            }
                        }
                        else
                        {
                            break;
                        }                        
                    }
                }
            }
            for (int i = 0; i < strInput.Length; i++)
            {
                if (strInput[i]!="?")
                {
                    Console.Write("{0} ",strInput[i]); 
                }
            }           
        }
    }
}
