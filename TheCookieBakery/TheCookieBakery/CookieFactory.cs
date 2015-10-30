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
            ICookie cookie = new BasicCookie();
            Random r = new Random();
            int number = r.Next(1, 3);

            switch (number) {
                case 1:
                    return new VanillaDecorator(cookie);
                case 2:
                    return new ChocolateDecorator(cookie);
                case 3:
                    return new MangoDecorator(cookie);
            }

            return cookie;
        }
    }
}
