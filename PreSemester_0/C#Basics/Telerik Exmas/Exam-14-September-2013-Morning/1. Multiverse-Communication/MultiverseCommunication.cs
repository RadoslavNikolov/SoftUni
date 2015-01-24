using System;
using System.Text;

class MultiverseCommunication
{
    static void Main()
    {
        string inputStr = Console.ReadLine().Trim().ToUpper();
        int count=0;
        long sum=0;
        for (int i = inputStr.Length-3; i >= 0; i-=3)
        {
            string tempStr = inputStr.Substring(i,3);
            long tempSum = 0;
            switch (tempStr)
            {
                case "CHU": tempSum += 0; break;
                case "TEL": tempSum += 1; break;
                case "OFT": tempSum += 2; break;
                case "IVA": tempSum += 3; break;
                case "EMY": tempSum += 4; break;
                case "VNB": tempSum += 5; break;
                case "POQ": tempSum += 6; break;
                case "ERI": tempSum += 7; break;
                case "CAD": tempSum += 8; break;
                case "K-A": tempSum += 9; break;
                case "IIA": tempSum += 10; break;
                case "YLO": tempSum += 11; break;
                case "PLA": tempSum += 12; break;
                default:
                    break;
            }
            sum += tempSum * (int)Math.Pow(13,count);
            count++;
        }
        Console.WriteLine(sum);
    }
}
