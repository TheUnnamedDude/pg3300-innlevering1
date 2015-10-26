using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCookieBakery
{
    class MangoDecorator : CookieDecorator
    {
        public MangoDecorator(ICookie IC) : base(IC) { }

        public override string GetCookieDescription()
        {
            return base.GetCookieDescription() + " with mango flavor, wtf? is that any good?";
        }
    }
}
