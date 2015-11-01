using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TheCookieBakery
{
    public class CookieBakery : Store
    {
        public int SoldCookies { private set; get; }
        private readonly Random random = new Random();

        public int BakedCookies { private set; get; }//Just to test.
        private List<ICookie> _cookieBasket;
        private object cookieLock = new object();

        public int Limit {private set; get; }

        public CookieBakery()
        {
            _cookieBasket = new List<ICookie>();
            SoldCookies = 0;
            BakedCookies = 0;
            Limit = 64;
            
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
                _cookieBasket.Add(cookie);
                LogManager.GetInstance().LogCookieBaked(BakedCookies);
            }
        }

        public void sellTo(Customer customer)
        {
            lock (cookieLock)
            {
                if (_cookieBasket.Count() >= 1)
                {
                    ICookie cookie = _cookieBasket.Last();
                    SoldCookies ++;
                    LogManager.GetInstance().LogCookiePurchase(customer, cookie, SoldCookies);
                    _cookieBasket.Remove(cookie);
                }
                /*else
                {
                    LogManager.GetInstance().Log("Nope, nothing mr. {0}(debug)", customer.Name);
                }*/
            }
        }

        public bool isOpen()
        {
            return (SoldCookies - Limit) <= 0;
        }
    }
}
