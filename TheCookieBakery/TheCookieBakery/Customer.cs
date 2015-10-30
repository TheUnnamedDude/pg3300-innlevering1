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
        private CookieBakery _bakery;

        public Customer(CookieBakery bakery, String name, int interval)
        {
            Name = name;
            _bakery = bakery;
            _interval = interval;
            _thread = new Thread(Run);
            _thread.Start();
        }

        public void Run()
        {
            while (_bakery.Limit > _bakery.SoldCookies)
            {
                _bakery.SellCookieTo(this);
                Thread.Sleep(_interval);
            }
        }
    }
}
