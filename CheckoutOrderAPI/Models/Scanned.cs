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
            Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).LineTotal = item.Price * Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).Quantity;
        }
        public Scanned(Item item, double weight)
        {
            if (!Receipt.ScannedItems.Any(x => x.Item.Id == item.Id))
            {
                Item = item;
                Quantity = 1;
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
            LineTotal = item.Price * Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).Weight;
        }
        public Scanned(Item item, double weight, double markdown)
        {
            if (!Receipt.ScannedItems.Any(x => x.Item.Id == item.Id))
            {
                Item = item;
                Quantity = 1;
                Weight = weight;
                Receipt.ScannedItems.Add(this);
            }
            else
            {
                var obj = Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id);
                if (obj != null)
                {
                    if (item.Eaches)
                    {
                        obj.Quantity++;
                    }
                    else
                    {
                        obj.Weight += Weight;
                    }
                }
            }

            if (item.Eaches)
            {
                if (markdown < item.Price)
                    Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).LineTotal = markdown * Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).Quantity;
                else
                    Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).LineTotal = item.Price * Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).Quantity;
            }
            else
            {
                if (markdown < item.Price)
                    Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).LineTotal = markdown * Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).Weight;
                else
                    Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).LineTotal = item.Price * Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).Weight;
            }
        }
        public Scanned(Item item, double weight, int requiredQty, double percentOff, int discountedQty)
        {
            if (!Receipt.ScannedItems.Any(x => x.Item.Id == item.Id))
            {
                Item = item;
                Quantity = 1;
                Weight = 1.00;
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

            var qty = Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).Quantity;

            
            while (qty >= requiredQty + discountedQty)
            {
                if (qty % requiredQty <= discountedQty && qty % requiredQty > 0)
                {
                    Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).LineTotal = (item.Price * requiredQty) + (item.Price * (percentOff / 100) * discountedQty);
                    qty -= requiredQty + discountedQty;
                }
                else
                {
                    qty--;
                }
            }

            Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).LineTotal += item.Price * qty;
        }
        public Scanned(Item item, double weight, int requiredQty, double setPrice)
        {
            Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).LineTotal = 0;
            if (!Receipt.ScannedItems.Any(x => x.Item.Id == item.Id))
            {
                Item = item;
                Quantity = 1;
                Weight = 1.00;
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

            var qty = Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).Quantity;

            while (qty >= requiredQty)
            {
                Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).LineTotal += setPrice;
                qty -= requiredQty;
            }

            Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).LineTotal += item.Price * qty;
        }
        public Scanned(Item item, double weight, int requiredQty, double percentOff, int discountedQty, int limit)
        {
            Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).LineTotal = 0;

            if (!Receipt.ScannedItems.Any(x => x.Item.Id == item.Id))
            {
                Item = item;
                Quantity = 1;
                Weight = 1.00;
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

            var qty = Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).Quantity;
            int i = 0;

            while (qty >= requiredQty + discountedQty && i < limit)
            {
                if (qty % requiredQty <= discountedQty && qty > requiredQty)
                {
                    Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).LineTotal = (item.Price * requiredQty) + (item.Price * (percentOff / 100) * discountedQty);
                    qty -= requiredQty + discountedQty;
                    i++;
                }
                else
                {
                    qty--;
                }
            }

            Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).LineTotal += item.Price * qty;
        }
        public Scanned(Item item, double weight, int requiredQty, double setPrice, int limit, bool setLimit)
        {
            Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).LineTotal = 0;
            if (!Receipt.ScannedItems.Any(x => x.Item.Id == item.Id))
            {
                Item = item;
                Quantity = 1;
                Weight = 1.00;
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

            var qty = Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).Quantity;
            int i = 0;

            while (qty >= requiredQty && i < limit)
            {
                Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).LineTotal += setPrice;
                qty -= requiredQty;
                i++;
            }

            Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).LineTotal += item.Price * qty;
        }

        public Scanned() { }
        public void Remove(Item item)
        {
            if (!Receipt.ScannedItems.Any(x => x.Item.Id == item.Id))
            {
                Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).LineTotal = 0;
                return;
            }
            else
            {
                var obj = Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id);
                if (obj != null)
                {
                    obj.Quantity--;
                }
            }
            Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).LineTotal = item.Price * Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).Quantity;
        }
        public void Remove(Item item, double weight)
        {
            if (!Receipt.ScannedItems.Any(x => x.Item.Id == item.Id))
            {
                Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).LineTotal = 0;
                return;
            }
            else
            {
                var obj = Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id);
                if (obj != null)
                {
                    obj.Weight -= Weight;
                }
            }
            LineTotal = item.Price * Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).Weight;
        }
        public void Remove(Item item, double weight, double markdown)
        {
            if (!Receipt.ScannedItems.Any(x => x.Item.Id == item.Id))
            {
                Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).LineTotal = 0;
                return;
            }
            else
            {
                var obj = Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id);
                if (obj != null)
                {
                    if (item.Eaches)
                    {
                        obj.Quantity--;
                    }
                    else
                    {
                        obj.Weight -= Weight;
                    }
                }
            }

            if (item.Eaches)
            {
                if (markdown < item.Price)
                    Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).LineTotal = markdown * Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).Quantity;
                else
                    Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).LineTotal = item.Price * Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).Quantity;
            }
            else
            {
                if (markdown < item.Price)
                    Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).LineTotal = markdown * Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).Weight;
                else
                    Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).LineTotal = item.Price * Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).Weight;
            }
        }
        public void Remove(Item item, double weight, int requiredQty, double percentOff, int discountedQty)
        {
            if (!Receipt.ScannedItems.Any(x => x.Item.Id == item.Id))
            {
                Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).LineTotal = 0;
                return;
            }
            else
            {
                var obj = Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id);
                if (obj != null)
                {
                    obj.Quantity--;
                }
            }

            var qty = Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).Quantity;


            while (qty >= requiredQty + discountedQty)
            {
                if (qty % requiredQty <= discountedQty && qty % requiredQty > 0)
                {
                    Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).LineTotal = (item.Price * requiredQty) + (item.Price * (percentOff / 100) * discountedQty);
                    qty -= requiredQty + discountedQty;
                }
                else
                {
                    qty--;
                }
            }

            Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).LineTotal += item.Price * qty;
        }
        public void Remove(Item item, double weight, int requiredQty, double setPrice)
        {
            Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).LineTotal = 0;
            if (!Receipt.ScannedItems.Any(x => x.Item.Id == item.Id))
            {
                Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).LineTotal = 0;
                return;
            }
            else
            {
                var obj = Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id);
                if (obj != null)
                {
                    obj.Quantity--;
                }
            }

            var qty = Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).Quantity;

            while (qty >= requiredQty)
            {
                Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).LineTotal += setPrice;
                qty -= requiredQty;
            }

            Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).LineTotal += item.Price * qty;
        }
        public void Remove(Item item, double weight, int requiredQty, double percentOff, int discountedQty, int limit)
        {
            Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).LineTotal = 0;

            if (!Receipt.ScannedItems.Any(x => x.Item.Id == item.Id))
            {
                Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).LineTotal = 0;
                return;
            }
            else
            {
                var obj = Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id);
                if (obj != null)
                {
                    obj.Quantity--;
                }
            }

            var qty = Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).Quantity;
            int i = 0;

            while (qty >= requiredQty + discountedQty && i < limit)
            {
                if (qty % requiredQty <= discountedQty && qty > requiredQty)
                {
                    Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).LineTotal = (item.Price * requiredQty) + (item.Price * (percentOff / 100) * discountedQty);
                    qty -= requiredQty + discountedQty;
                    i++;
                }
                else
                {
                    qty--;
                }
            }

            Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).LineTotal += item.Price * qty;
        }
        public void Remove(Item item, double weight, int requiredQty, double setPrice, int limit, bool setLimit)
        {
            Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).LineTotal = 0;
            if (!Receipt.ScannedItems.Any(x => x.Item.Id == item.Id))
            {
                Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).LineTotal = 0;
                return;
            }
            else
            {
                var obj = Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id);
                if (obj != null)
                {
                    obj.Quantity--;
                }
            }

            var qty = Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).Quantity;
            int i = 0;

            while (qty >= requiredQty && i < limit)
            {
                Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).LineTotal += setPrice;
                qty -= requiredQty;
                i++;
            }

            Receipt.ScannedItems.FirstOrDefault(x => x.Item.Id == item.Id).LineTotal += item.Price * qty;
        }

    }
}