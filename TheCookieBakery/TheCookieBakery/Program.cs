using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheCookieBakery
{
    public class Program
    {
        private Object lockedObject = new object();
        private Customer fred;
        private Customer ted;
        private Customer Greg;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            

            lock (lockedObject)
            {

            }
        }
    }
}
