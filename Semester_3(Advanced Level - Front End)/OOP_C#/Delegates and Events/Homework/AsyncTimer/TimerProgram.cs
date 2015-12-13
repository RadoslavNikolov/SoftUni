namespace AsyncTimer
{
    using System;
    using System.Security.Cryptography.X509Certificates;

    class TimerProgram
    {
        static void Main()
        {
            AsyncTimer timer = new AsyncTimer(Action, 10, 1000);
            timer.Start();       
        }

        public static void Action(string str)
        {
            Console.WriteLine(str);
        }
    }
}
