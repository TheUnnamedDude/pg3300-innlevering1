using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace NewBakery
{
    class Customer
    {
        public string Name {get; private set;}
        private int interval;
        public Customer(string name, int interval)
        {
            Name = name;
            Thread customerThread = new Thread(Run);
            customerThread.Start();
        }

        public void Run()
        {
            while (true)
            {
                // TODO: Logic for checking for cake
                
                Thread.Sleep(interval);
            }
        }
    }
}
