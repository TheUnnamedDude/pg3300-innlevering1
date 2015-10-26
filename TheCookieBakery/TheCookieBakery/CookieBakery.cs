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

        private int _soldCookies { set; get; }
        private readonly Random random = new Random();

        private List<ICookie> _cookies;
        private object cookieLock = new object();

        public CookieBakery()
        {
            _cookies = new List<ICookie>();
            _soldCookies = 0;
            _fred = new Customer(this, "Fred", 1000);
            _ted = new Customer(this, "Ted", 666);
            _greg = new Customer(this, "Greg", 987);
        }

        public void RunMainLoop()
        {
            while (true)
            {
                MakeCookie();
                Thread.Sleep(random.Next(0, 10000));
            }
        }

        public void MakeCookie()
        {
            lock(cookieLock)
            {
                _cookies.Add(CookieFactory.MakeCookie());
            }
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
                /*else
                {
                    LogManager.GetInstance().Log("Nope, nothing mr. {0}(debug)", customer.Name);
                }*/
            }
        }
    }
}
