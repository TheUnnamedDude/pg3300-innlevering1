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

        public void LogCookiePurchase(Customer customer, ICookie cookie)
        {
            Log("{0} received {1}", customer.Name, cookie.GetCookieDescription());
        }
    }
}
