using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class ShoppingCartVM
    {
        public IEnumerable<ShoppingCard> shoppingCards { get; set; }
        public OrderHeader OrderHeader{ get; set; }
        public OrderDetail OrderDetail{ get; set; }

    }
}
