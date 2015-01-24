using System;
using System.Linq;

class printMorseCode
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int nSum = 0;
        int count = 0;
        string[] morseCodes = { "-----", ".----", "..---", "...--", "....-", "....." };
        while (n>0)
        {
            nSum += n % 10;
            n /= 10;
        }

        for (int i0 = 0; i0 <=5; i0++)
        {
            for (int i1 = 0; i1 <= 5; i1++)
            {
                for (int i2 = 0; i2 <=5; i2++)
                {
                    for (int i3 = 0; i3 <= 5; i3++)
                    {
                        for (int i4 = 0; i4 <= 5; i4++)
                        {
                            for (int i5 = 0; i5 <= 5; i5++)
                            {
                                int tempSum = i0 * i1 * i2 * i3 * i4 * i5;
                                if (tempSum==nSum)
                                {
                                    //PrintMetod(i0,i2,i3,i4,i5,i6);
                                    string output = morseCodes[i0] + "|" +
                                                    morseCodes[i1] + "|" +
                                                    morseCodes[i2] + "|" +
                                                    morseCodes[i3] + "|" +
                                                    morseCodes[i4] + "|" +
                                                    morseCodes[i5] + "|";

                                    Console.WriteLine(output);
                                    count++;
                                }
                            }
                        }
                    }
                }
            }
        }

        if (count==0)
        {
            Console.WriteLine("No");
        }
    }

    //private static void PrintMetod(int i1, int i2, int i3, int i4, int i5, int i6)
    //{
    //    string output = "";
    //    int[] tempNumber = {i1,i2,i3,i4,i5,i6};
    //    foreach (var item in tempNumber)
    //    {
    //        switch (item)
    //        {
    //            case 0: output += "-----|"; break;
    //            case 1: output += ".----|"; break;
    //            case 2: output += "..---|"; break;
    //            case 3: output += "...--|"; break;
    //            case 4: output += "....-|"; break;
    //            case 5: output += ".....|"; break;
    //            default:
    //                break;
    //        }
    //    }
    //    Console.WriteLine(output);
    //}
}
