using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCookieBakery
{
    public class DecoratorChocolate : ICookie
    {
        private string name;  
        public DecoratorChocolate()
        {
            name = "Chocolate Cookie";
        }
        public override string GetCookieDescription()
        {
            return name;
        }
    }
}
