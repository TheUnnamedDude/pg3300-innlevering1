using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCookieBakery
{
    class ChocolateDecorator : CookieDecorator
    {

        public ChocolateDecorator(ICookie IC) : base(IC){ }
        public override string GetCookieDescription()
        {
            return base.GetCookieDescription() + " with Chocolate chips";
        }
    }
}
