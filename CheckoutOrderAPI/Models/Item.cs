using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckoutOrderAPI.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool Eaches { get; set; }

        public Item()
        {

        }
        public Item(int _id, string _name, double _price, bool _eaches)
        {
            Id = _id;
            Name = _name;
            Price = _price;
            Eaches = _eaches;
        }
    }
}