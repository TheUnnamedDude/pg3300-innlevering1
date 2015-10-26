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

        public Customer(String name)
        {
            _name = name;
            _thread = new Thread;
        }
    }
}
