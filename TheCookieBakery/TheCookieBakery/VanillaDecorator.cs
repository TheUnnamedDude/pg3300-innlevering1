using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCookieBakery
{
    class VanillaDecorator : CookieDecorator
    {
        public VanillaDecorator(ICookie original) : base(original) { }
        
        public override string GetCookieDescription()
        {
            return base.GetCookieDescription() + " with Vanilla";
        }
    }
}
