using GameStore.DAL;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exampless
{
    class Program
    {
        

        static void Main(string[] args)
        {
            var context = new ApplicationContext();
            context.Database.Log = Log;
            foreach (var item in context.Games)
            {
                Console.WriteLine($"{item.Name} =>{item.Genre}");
            }

          
        }

        private static void Log(string obj)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(obj);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
