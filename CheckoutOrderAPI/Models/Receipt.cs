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

        public static void Clear()
        {
            OrderTotal = 0.00;
        }
    }
}