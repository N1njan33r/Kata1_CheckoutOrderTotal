using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckoutOrderAPI.Models
{
    public static class Receipt
    {
        public static double OrderTotal { get; set; }
        public static List<Scanned> ScannedItems { get; set; }

        static Receipt()
        {
            ScannedItems = new List<Scanned>();
        }

        public static void Sum()
        {
            double orderTotal = 0;
            foreach (Scanned scanned in ScannedItems)
            {
                orderTotal += scanned.LineTotal;
            }
            OrderTotal = Math.Round(orderTotal, 2);
        }

        public static void Clear()
        {
            OrderTotal = 0.00;
            ScannedItems.Clear();
        }
    }
}