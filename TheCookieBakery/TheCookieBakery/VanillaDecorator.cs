using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCookieBakery
{
    class VanillaDecorator : ICookie
    {
        public VanillaDecorator() 
        {
            name = "Vanilla Cookie";
        }
        public string GetCookieDescription()
        {
            return name;
        }
    }
}
