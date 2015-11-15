using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Data
{
    class test
    {
        public static void Main(string[] args)
        {
            var context = ApplicationDbContext.Create();
            context.Games.Count();
        }
    }
}
