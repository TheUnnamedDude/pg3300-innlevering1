using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCookieBakery
{
    class DecoratorChocolate : ICookie
    {
        private string name;
        public DecoratorChocolate()
        {
            name = "Chocolate Cookie";
        }
        public string GetCookieDescription()
        {
            return name;
        }
    }
}
