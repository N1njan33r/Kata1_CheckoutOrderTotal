using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckoutOrderAPI.Controllers;
using CheckoutOrderAPI.Models;
using System.Web.Http.Results;

namespace CheckoutOrderAPI.Tests
{
    [TestClass]
    public class TestItemsController
    {
        [TestMethod]
        public void GetAllItems_ShouldReturnAllItems()
        {
            //Arrange
            var testItems = GetTestItems();
            var controller = new ItemsController(testItems);

            //Act
            var result = controller.GetAllItems() as List<Item>;

            //Assert
            Assert.AreEqual(testItems.Count, result.Count);
        }

        #region API Tests
        [TestMethod]
        public void ScanItem_ShouldReturnTotal()
        {
            Receipt.Clear();
            //Arrange
            var testItems = GetTestItems();
            var controller = new ItemsController(testItems);

            //Act
            var result = controller.ScanItem(4) as OkNegotiatedContentResult<double>;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(testItems[3].Price, result.Content);
        }

        [TestMethod]
        public void ScanItem_ShouldNotFindItem()
        {
            //Arrange
            var controller = new ItemsController(GetTestItems());

            //Act
            var result = controller.ScanItem(999);

            //Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void ScanItemEnterWeight_ShouldReturnTotal()
        {
            Receipt.Clear();
            //Arrange
            var testItems = GetTestItems();
            var controller = new ItemsController(testItems);

            //Act
            var result = controller.ScanItemEnterWeight(1, 1.5) as OkNegotiatedContentResult<double>;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(Math.Round(testItems[0].Price * 1.5, 2), result.Content);
        }

        [TestMethod]
        public void ScanItemWithMarkdown_ShouldReturnTotal()
        {
            Receipt.Clear();
            //Arrange
            var testItems = GetTestItems();
            var controller = new ItemsController(testItems);

            //Act
            var result = controller.ScanItemWithMarkdown(1, 2.00, 0.99) as OkNegotiatedContentResult<double>;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1.98, result.Content);
        }

        [TestMethod]


        #endregion



        private List<Item> GetTestItems()
        {
            var testItems = new List<Item>();
            testItems.Add(new Item { Id = 1, Name = "Demo1", Price = 2.99, Eaches = false });
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
