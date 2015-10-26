using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCookieBakery
{
    class BasicCookie : ICookie
    {
        private string name;
        public BasicCookie()
        {
            name = "Basic Cookie";
        }
        public override string GetCookieDescription()
        {
            return name;
        }

       
    }
}
