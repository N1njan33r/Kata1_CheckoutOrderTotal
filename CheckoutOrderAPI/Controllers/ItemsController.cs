using CheckoutOrderAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace CheckoutOrderAPI.Controllers
{
    public class ItemsController : ApiController
    {
        private Item[] items = new Item[]
        {
            new Item { id = 1, name = "banana", price = 1.99, eaches = true },
            new Item { id = 2, name = "steak", price = 12.99, eaches = false }
        };

        // GET: api/Items
        [ResponseType(typeof(IEnumerable<Item>))]
        public IEnumerable<Item> Get()
        {
            return items;
        }
        // GET: api/Items/5
        public IHttpActionResult Get(int id)
        {
            var product = items.FirstOrDefault((p) => p.id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
