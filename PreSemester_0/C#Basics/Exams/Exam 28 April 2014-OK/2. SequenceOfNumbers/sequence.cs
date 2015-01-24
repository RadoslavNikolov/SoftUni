using System;

class sequence
{
    static void Main(string[] args)
    {
        string inputNumber = Console.ReadLine();
        inputNumber=inputNumber + " " + 10000;
        int k = int.Parse(Console.ReadLine());
        string[] inputSequence = inputNumber.Split(' ');
        int count = 1;
        int prevNumber=int.Parse(inputSequence[0]);
        for (int i = 1; i < inputSequence.Length; i++)
        {
            if (int.Parse(inputSequence[i])==prevNumber)
            {
                count++;
            }
            else
            {
                for (int j = 0; j < count%k; j++)
                {
                    Console.Write(prevNumber + " ");
                }
                count = 1;
            }

            prevNumber = int.Parse(inputSequence[i]);
        }
    }
}
