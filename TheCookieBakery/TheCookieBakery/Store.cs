using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCookieBakery
{
    public interface Store
    {
         bool isOpen();

        void sellTo(Customer buyer);

    }
}
