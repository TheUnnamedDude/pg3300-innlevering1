using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCookieBakery
{
    class MangoDecorator : ICookie
    {
        private ICookie unDecorated;
        protected MangoDecorator(ICar original)
        {
            this.original = original;
        }

        public virtual string GetDescription()
        {
            return original.GetDescription();
        }
    }
}
