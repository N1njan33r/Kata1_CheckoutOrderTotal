using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutOrderTotal
{
    class Item
    {
        public string Name { get; set; }
        public double BasePrice { get; set; }
        public bool ByWeight { get; set; }

        public Item(string name, double price, bool byweight)
        {
            Name = name;
            BasePrice = price;
            ByWeight = byweight;
        }
    }
}
