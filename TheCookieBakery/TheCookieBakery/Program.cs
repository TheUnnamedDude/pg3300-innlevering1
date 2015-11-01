using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheCookieBakery
{
    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            CookieBakery cookieBakery = new CookieBakery();
            new Customer(cookieBakery, "Fred", 1000);
            new Customer(cookieBakery, "Ted", 1000);
            new Customer(cookieBakery, "Greg", 1000);
            cookieBakery.RunMainLoop();
        }
    }
}
