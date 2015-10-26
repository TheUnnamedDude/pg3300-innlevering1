using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCookieBakery
{
    class DecoratorChocolate : CookieDecorator
    {

        public DecoratorChocolate(ICookie IC) : base(IC){ }
        public override string GetCookieDescription()
        {
            return base.GetCookieDescription() + " with Chocolate chips";
        }
    }
}
