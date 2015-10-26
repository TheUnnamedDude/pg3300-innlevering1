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

        public void log(string str)
        {
            Console.WriteLine(str);
        }

        public void LogCookiePurchase(Customer customer, ICookie cookie)
        {
            log(string.Format("{} received cookie {}", customer.Name, cookie.GetCookieDescription()));
        }
    }
}
