using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCookieBakery
{
    class MangoDecorator : ICookie
    {
        private ICookie _ic;
        protected MangoDecorator(ICookie ic)
        {
            _ic = ic;
        }

        public string GetCookieDescription()
        {
            return _ic.GetCookieDescription();
        }
    }
}
