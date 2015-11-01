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
        private Store _store;

        public Customer(Store store, String name, int interval)
        {
            Name = name;
            _store = store;
            _interval = interval;
            _thread = new Thread(Run);
            _thread.Start();
        }

        public void Run()
        {
            while (_store.isOpen())
            {
                _store.sellTo(this);
                Thread.Sleep(_interval);
            }
        }
    }
}
