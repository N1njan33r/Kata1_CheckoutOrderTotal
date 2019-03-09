using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckoutOrderAPI.Models
{
    public class Scanned
    {
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public double Weight { get; set; }
        public double LineTotal { get; set; }
        public bool HasMarkdown { get; set; }
        public bool IsOnSale { get; set; }


        public Scanned(Item item, double weight)
        {
            LineTotal = item.Price * weight;
        }
        public Scanned(Item item, double weight, double markdown)
        {
            if (markdown < item.Price)
                LineTotal = markdown * weight;
            else
                LineTotal = item.Price * weight;
        }
        public Scanned(Item item, double weight, int requiredQty, double percentOff)
        {

        }
    }
}