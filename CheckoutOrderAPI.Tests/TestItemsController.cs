using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckoutOrderAPI.Controllers;
using CheckoutOrderAPI.Models;

namespace CheckoutOrderAPI.Tests
{
    [TestClass]
    public class TestItemsController
    {
        [TestMethod]
        public void GetAllItems_ShouldReturnAllItems()
        {
            var test = GetTestItems();

            var testController = new ItemsController();
            var result = testController.Get(1) as List<Item>;

            Assert.AreEqual(test.Count, result.Count);
        }

        private List<Item> GetTestItems()
        {
            var testItems = new List<Item>();
            testItems.Add(new Item { Id = 1, Name = "Demo1", Price = 1.99, Eaches = true });
            testItems.Add(new Item { Id = 2, Name = "Demo2", Price = 1.99, Eaches = true });
            testItems.Add(new Item { Id = 3, Name = "Demo3", Price = 1.99, Eaches = true });
            testItems.Add(new Item { Id = 4, Name = "Demo4", Price = 1.99, Eaches = true });
            testItems.Add(new Item { Id = 5, Name = "Demo5", Price = 1.99, Eaches = true });
            testItems.Add(new Item { Id = 6, Name = "Demo6", Price = 1.99, Eaches = true });
            testItems.Add(new Item { Id = 7, Name = "Demo7", Price = 1.99, Eaches = true });
            testItems.Add(new Item { Id = 8, Name = "Demo8", Price = 1.99, Eaches = true });
            testItems.Add(new Item { Id = 9, Name = "Demo9", Price = 1.99, Eaches = true });
            testItems.Add(new Item { Id = 10, Name = "Demo10", Price = 1.99, Eaches = true });
            testItems.Add(new Item { Id = 11, Name = "Demo11", Price = 1.99, Eaches = true });
            testItems.Add(new Item { Id = 12, Name = "Demo12", Price = 1.99, Eaches = true });

            return testItems;
        }
    }
}
