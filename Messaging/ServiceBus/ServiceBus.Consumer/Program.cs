using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBus.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Subscription number");
            var num = int.Parse(Console.ReadLine());
            var sender = new Subscription(num);
            sender.Receive();

            Console.WriteLine("Press any key to quit.");
            Console.ReadKey();
        }
    }
}
