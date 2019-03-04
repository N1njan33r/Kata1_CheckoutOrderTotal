using CheckoutOrderAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CheckoutOrderAPI.Controllers
{
    public class ScannedController : ApiController
    {
        public double Scan(Item item)
        {
            return item.Price;
        }
    }
}
