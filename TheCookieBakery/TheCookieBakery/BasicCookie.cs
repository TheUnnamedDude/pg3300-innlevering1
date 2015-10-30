using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCookieBakery
{
    class BasicCookie : ICookie
    {
        private string type;
        public BasicCookie()
        {
            type = "Cookie";
        }
        public string GetCookieDescription()
        {
            return type;
        }

       
    }
}
