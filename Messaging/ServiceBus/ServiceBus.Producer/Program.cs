﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBus.Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            var sender = new Sender();

            for (int i = 0; i < 100; i++)
            {
                sender.Send("Important message: " + i);
            }

            Console.WriteLine("Press any key to quit.");
            Console.ReadKey();
        }
    }
}
