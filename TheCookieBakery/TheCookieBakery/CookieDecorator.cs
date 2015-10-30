using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCookieBakery
{
    abstract class CookieDecorator : ICookie
    {
        ICookie IC;

        protected CookieDecorator(ICookie original)
        {
            this.IC = original;
        }

        public virtual string GetCookieDescription()
        {
            return IC.GetCookieDescription();
        }
    }
}
