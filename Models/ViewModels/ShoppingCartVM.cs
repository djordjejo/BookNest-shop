using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class ShoppingCartVM
    {
        public IEnumerable<ShoppingCard> shoppingCards { get; set; }
        public double OrderTotal { get; set; }


    }
}
