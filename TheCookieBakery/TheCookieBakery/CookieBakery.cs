using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCookieBakery
{
    public class CookieBakery
    {

        private int _soldCookies { set; get; }

        private List<ICookie> _cookies;
        private object cookieLock = new object();

        public CookieBakery() {
            _soldCookies = 0;
        }

        public void MakeCookie()
        {

            /*ICookie cookie = new Cookie();
            _cookies.add(cookie);*/
        }

        public void SellCookieTo(Customer customer)
        {
            lock (cookieLock)
            {
                if (_cookies.Count() >= 1)
                {
                    ICookie cookie = _cookies.Last();
                    LogManager.GetInstance().LogCookiePurchase(customer, cookie);
                    _cookies.Remove(cookie);
                }
            }
        }
    }
}
