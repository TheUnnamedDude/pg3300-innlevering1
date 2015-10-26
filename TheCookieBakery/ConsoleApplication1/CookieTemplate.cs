using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBakery
{
    abstract class CookieTemplate
    {
        string Name { get; set; }
        public abstract string GetCookieDescription();
    }
}
