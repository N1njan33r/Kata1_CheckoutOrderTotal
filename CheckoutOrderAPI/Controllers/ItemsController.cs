﻿using CheckoutOrderAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace CheckoutOrderAPI.Controllers
{
    public class ItemsController : ApiController
    {
        List<Item> items = new List<Item>();

        public ItemsController() { items = TestItems(); }

        public ItemsController(List<Item> items)
        {
            this.items = items;
        }

        // GET: api/Items
        //[ResponseType(typeof(IEnumerable<Item>))]
        public IEnumerable<Item> GetAllItems()
        {
            return items;
        }

        #region API Calls
        // GET: api/Items/{id}
        public IHttpActionResult ScanItem(int id)
        {
            var lineItem = items.FirstOrDefault((p) => p.Id == id);
            if (lineItem == null)
            {
                return NotFound();
            }

            Receipt.OrderTotal += Math.Round(lineItem.Price, 2);
            return Ok(Receipt.OrderTotal);
        }
        
        // GET: api/Items/GetId?id={id}&weight={weight}
        // If item is counted by unit, weight = 1
        public IHttpActionResult ScanItemEnterWeight(int id, double weight)
        {
            var lineItem = items.FirstOrDefault((p) => p.Id == id);
            if (lineItem == null)
            {
                return NotFound();
            }

            if (lineItem.Eaches)
            {
                weight = 1.00;
            }
            Scanned scanned = new Scanned(lineItem, weight);
            Receipt.OrderTotal += Math.Round(scanned.LineTotal, 2);
            return Ok(Receipt.OrderTotal);
        }

        //public IHttpActionResult ScanItemWithMarkdown(int id, double markdown)
        //{
        //    var lineItem = items.FirstOrDefault((p) => p.Id == id);
        //    if (lineItem == null)
        //    {
        //        return NotFound();
        //    }
        //    Scanned scanned = new Scanned(lineItem, weight);
        //    Receipt.OrderTotal += Math.Round(scanned.LineTotal, 2);
        //    return Ok(Receipt.OrderTotal);
        //}

        //public IHttpActionResult ScanItemBuyXGetX(int id, int requiredQty, double percentOff)
        //{
        //    var lineItem = items.FirstOrDefault((p) => p.Id == id);
        //    if (lineItem == null)
        //    {
        //        return NotFound();
        //    }
        //    Scanned scanned = new Scanned(lineItem, weight);
        //    Receipt.OrderTotal += Math.Round(scanned.LineTotal, 2);
        //    return Ok(Receipt.OrderTotal);
        //}

        //public IHttpActionResult ScanItemWithSetPriceForQty(int id, int requiredQty, double setPrice)
        //{
        //    var lineItem = items.FirstOrDefault((p) => p.Id == id);
        //    if (lineItem == null)
        //    {
        //        return NotFound();
        //    }
        //    Scanned scanned = new Scanned(lineItem, weight);
        //    Receipt.OrderTotal += Math.Round(scanned.LineTotal, 2);
        //    return Ok(Receipt.OrderTotal);
        //}
        #endregion

        private List<Item> TestItems()
        {
            items.Add(new Item { Id = 1, Name = "chicken", Price = 2.99, Eaches = false });
            items.Add(new Item { Id = 2, Name = "beef", Price = 5.49, Eaches = false });
            items.Add(new Item { Id = 3, Name = "pork", Price = 1.99, Eaches = false });
            items.Add(new Item { Id = 4, Name = "shrimp", Price = 5.99, Eaches = false });
            items.Add(new Item { Id = 5, Name = "eggs", Price = 1.79, Eaches = true });
            items.Add(new Item { Id = 6, Name = "butter", Price = 3.19, Eaches = true });
            items.Add(new Item { Id = 7, Name = "cheese", Price = 5.99, Eaches = true });
            items.Add(new Item { Id = 8, Name = "milk", Price = 4.59, Eaches = true });
            items.Add(new Item { Id = 9, Name = "apples", Price = 0.99, Eaches = false });
            items.Add(new Item { Id = 10, Name = "bananas", Price = 0.39, Eaches = false });
            items.Add(new Item { Id = 11, Name = "lemons", Price = 0.69, Eaches = true });
            items.Add(new Item { Id = 12, Name = "limes", Price = 0.50, Eaches = true });

            return items;
        }
    }
}
