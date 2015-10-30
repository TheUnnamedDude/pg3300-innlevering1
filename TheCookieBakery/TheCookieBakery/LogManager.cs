using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheCookieBakery
{
    public class LogManager
    {
        private static LogManager instance;
        public static LogManager GetInstance()
        {
            if (instance == null)
            {
                instance = new LogManager();
            }
            return instance;
        }

        private LogManager()
        {
        }

        public void Log(string str)
        {
            Console.WriteLine(str);
        }

        public void Log(string format, params object[] args)
        {
            Log(string.Format(format, args));
        }

        public void LogCookiePurchase(Customer customer, ICookie cookie, int currentCookie)
        {
            Log("{0,80}", string.Format("{0} received {1}", customer.Name, string.Format(cookie.GetCookieDescription(), currentCookie)));
        }

        public void LogCookieBaked(int currentCookie)
        {
            Log("Bakery made cookie #{0}", currentCookie);
        }
    }
}
