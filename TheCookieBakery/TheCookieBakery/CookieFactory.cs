using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCookieBakery
{
    class CookieFactory
    {
        public static ICookie MakeCookie()
        {
            Random r = new Random();

            switch (r.Next(0, 2))
            {
                case 0:
                    return new VanillaDecorator(new BasicCookie());
                case 1:
                    return new ChocolateDecorator(new BasicCookie());
                case 2:
                    return new MangoDecorator(new BasicCookie());
                default:
                    return new BasicCookie();
            }
        }
    }
}
