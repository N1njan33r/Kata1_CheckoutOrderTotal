using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutOrderTotal
{
    class Products
    {
        public static List<Item> Create()
        {
            List<Item> items = new List<Item>();

            items.Add(new Item("bananas", 2.99, true));

            return items;
        }
    }
}
