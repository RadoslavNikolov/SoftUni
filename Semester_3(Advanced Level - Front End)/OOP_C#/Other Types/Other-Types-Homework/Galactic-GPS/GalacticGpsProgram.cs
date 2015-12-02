namespace Galactic_GPS
{
    using System;
    using System.Runtime.InteropServices;

    public class GalacticGpsProgram
    {
        public static void Main()
        {
            Location home = new Location(18.037986, 28.870097, Planet.Earth);
            Console.WriteLine(home);
        }
        
    }
}
