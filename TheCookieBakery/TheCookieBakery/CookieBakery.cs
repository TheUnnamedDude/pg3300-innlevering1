using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCookieBakery
{
    class CookieBakery
    {

        private int _numberOfCookies { set; get; }
        private int _soldCookies { set; get; }

        private List<ICookie> _cookies;

        public CookieBakery {
            _soldCookies = 0;
        }
        
        
    public void MakeCookie()
    {

        ICookie cookie = new Cookie();
        _cookies.add(cookie);
    }

        public void SellCookieTo(Customer customer)
        {
            if (_numberOfCookies >= 1)
            {
                System.WriteLine(customer + " recieved " + cookie.name + " number " + _soldCookies + 1);
                numberOfCookies--;
                soldCookies++;
            }
        }
    }
}
