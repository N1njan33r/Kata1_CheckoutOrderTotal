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

        //public Receipt(Scanned scanned)
        //{
        //    //var item = new Item(13, "brick", 1.99, false);
        //    //Scanned scanned = new Scanned(item);
            
        //}
    }
}