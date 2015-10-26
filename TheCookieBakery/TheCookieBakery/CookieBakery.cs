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
<<<<<<< HEAD
        
        
=======

        public CookieBakery() {
            _soldCookies = 0;
        }


>>>>>>> 22c556256474e5ae8b133f6cd524bf5fefabc7e5
    public void MakeCookie()
    {

        /*ICookie cookie = new Cookie();
        _cookies.add(cookie);*/
    }

        public void SellCookieTo(Customer customer)
        {
            if (_numberOfCookies >= 1)
            {
                /*System.WriteLine(customer + " recieved " + cookie.name + " number " + _soldCookies + 1);
                numberOfCookies--;
                soldCookies++;*/
            }
        }
    }
}
