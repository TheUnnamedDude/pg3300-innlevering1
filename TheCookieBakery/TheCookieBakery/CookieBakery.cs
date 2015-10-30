using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TheCookieBakery
{
    public class CookieBakery
    {

        private Customer _fred;
        private Customer _ted;
        private Customer _greg;

        public int SoldCookies { private set; get; }
        private readonly Random random = new Random();

        public int BakedCookies { private set; get; }//Just to test.
        private List<ICookie> _cookies;
        private object cookieLock = new object();

        public int Limit {private set; get; }

        public CookieBakery()
        {
            _cookies = new List<ICookie>();
            SoldCookies = 0;
            BakedCookies = 0;
            Limit = 64;
            _fred = new Customer(this, "Fred", 1000);
            _ted = new Customer(this, "Ted", 1000);
            _greg = new Customer(this, "Greg", 1000);
        }

        public void RunMainLoop()
        {
            while (BakedCookies < Limit)
            {
                MakeCookie();
                Thread.Sleep(random.Next(500, 800));
            }
        }

        public void MakeCookie()
        {
            lock(cookieLock)
            {
                BakedCookies++;
                ICookie cookie = CookieFactory.MakeCookie();
                _cookies.Add(cookie);
                LogManager.GetInstance().LogCookieBaked(BakedCookies);
            }
        }

        public void SellCookieTo(Customer customer)
        {
            lock (cookieLock)
            {
                if (_cookies.Count() >= 1)
                {
                    ICookie cookie = _cookies.Last();
                    SoldCookies ++;
                    LogManager.GetInstance().LogCookiePurchase(customer, cookie, SoldCookies);
                    _cookies.Remove(cookie);
                }
                /*else
                {
                    LogManager.GetInstance().Log("Nope, nothing mr. {0}(debug)", customer.Name);
                }*/
            }
        }
    }
}
