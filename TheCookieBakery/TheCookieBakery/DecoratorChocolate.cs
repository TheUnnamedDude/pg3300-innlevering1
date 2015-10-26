using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCookieBakery
{
    class DecoratorChocolate : CookieDecorator
    {
<<<<<<< HEAD
        public DecoratorChocolate(ICookie IC) : base(IC){
                
            }
        
        public override string GetCookieDescription()
=======
        private string name;
        public DecoratorChocolate()
        {
            name = "Chocolate Cookie";
        }
        public string GetCookieDescription()
>>>>>>> 22c556256474e5ae8b133f6cd524bf5fefabc7e5
        {
            return base.GetCookieDescription() + " with Chocolate chips";
        }
    }
}
