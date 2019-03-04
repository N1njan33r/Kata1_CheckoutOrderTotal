using CheckoutOrderAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace CheckoutOrderAPI.Controllers
{
    public class ItemsController : ApiController
    {
        public List<double> checkoutTotal = new List<double>();
        private Item[] items = new Item[]
        {
            new Item { Id = 1, Name = "chicken", Price = 2.99, Eaches = false },
            new Item { Id = 2, Name = "beef", Price = 5.49, Eaches = false },
            new Item { Id = 3, Name = "pork", Price = 1.99, Eaches = false },
            new Item { Id = 4, Name = "shrimp", Price = 5.99, Eaches = false },
            new Item { Id = 5, Name = "eggs", Price = 1.79, Eaches = true },
            new Item { Id = 6, Name = "butter", Price = 3.19, Eaches = true },
            new Item { Id = 7, Name = "cheese", Price = 5.99, Eaches = true },
            new Item { Id = 8, Name = "milk", Price = 4.59, Eaches = true },
            new Item { Id = 9, Name = "apples", Price = 0.99, Eaches = false },
            new Item { Id = 10, Name = "bananas", Price = 0.39, Eaches = false },
            new Item { Id = 11, Name = "lemons", Price = 0.69, Eaches = true },
            new Item { Id = 12, Name = "limes", Price = 0.50, Eaches = true }
        };

        // GET: api/Items
        [ResponseType(typeof(IEnumerable<Item>))]
        public IEnumerable<Item> Get()
        {
            return items;
        }
        
        // GET: api/Items/{id}
        public IHttpActionResult Get(int id)
        {
            var lineItem = items.FirstOrDefault((p) => p.Id == id);
            if (lineItem == null)
            {
                return NotFound();
            }
            return Ok(lineItem);
        }
        
        // GET: api/Items/GetId?id={id}&weight={weight}
        // If item is counted by unit, weight = 1
        public IHttpActionResult Get(int id, double weight)
        {
            var lineItem = items.FirstOrDefault((p) => p.Id == id);
            if (lineItem == null)
            {
                return NotFound();
            }

            // Decide if by weight or not...
            if (!lineItem.Eaches)
            {
                // Add item as weighed item with {weight}

                return Ok("By weight.");
            }
            else
            {
                // Add item as eaches item without {weight}
                return Ok("By unit");
            }

            //return Ok(checkoutTotal.Sum());
        }
    }
}
