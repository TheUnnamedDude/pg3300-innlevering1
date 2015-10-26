using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TheCookieBakery
{
    class Customer
    {
        private String _name;
        private Thread _thread;
        private int _interval;

        public Customer(String name, int interval)
        {
            _name = name;
            _interval = interval;
            _thread = new Thread(Run);
            _thread.Start();
        }

        public void Run()
        {
            while (true)
            {

                Thread.Sleep(_interval);
            }
        }
    }
}
