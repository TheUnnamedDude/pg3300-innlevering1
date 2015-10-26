using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TheCookieBakery
{
    public class Customer
    {
        public string Name {get; private set;}
        private Thread _thread;
        private int _interval;

        public Customer(String name, int interval)
        {
            Name = name;
            _interval = interval;
            _thread = new Thread(Run);
            _thread.Start();
        }

        public void Run()
        {
            while (true)
            {
                ICookie cookie = null; // TODO: ask mr bakery
                if (cookie != null)
                {
                    LogManager.GetInstance().LogCookiePurchase(this, cookie);
                }
                Thread.Sleep(_interval);
            }
        }
    }
}
