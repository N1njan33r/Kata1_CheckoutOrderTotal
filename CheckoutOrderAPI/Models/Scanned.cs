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

        public Scanned(Item item)
        {
            if (!Receipt.ScannedItems.Any(x => x.Item.Id == item.Id))
            {
                Item = item;
                Quantity = 1;
                Receipt.ScannedItems.Add(this);
            }
            else
            {
                var obj = Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id);
                if (obj != null)
                {
                    obj.Quantity++;
                }
            }
            LineTotal = Item.Price * Quantity;
        }
        public Scanned(Item item, double weight)
        {
            if (!Receipt.ScannedItems.Any(x => x.Item.Id == item.Id))
            {
                Item = item;
                Weight = weight;
                Receipt.ScannedItems.Add(this);
            }
            else
            {
                var obj = Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id);
                if (obj != null)
                {
                    obj.Weight += Weight;
                }
            }
            LineTotal = Item.Price * Weight;
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
            LineTotal = item.Price;
        }
    }
}