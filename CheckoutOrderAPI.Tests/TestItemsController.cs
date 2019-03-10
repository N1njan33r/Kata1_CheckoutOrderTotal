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
        public void ScanItemWithWeightAtMarkdown_ShouldReturnTotal()
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
        public void ScanItemWithEachesAtMarkdown_ShouldReturnTotal()
        {
            Receipt.Clear();
            //Arrange
            var testItems = GetTestItems();
            var controller = new ItemsController(testItems);

            //Act
            var result = controller.ScanItemWithMarkdown(5, 999, 0.99) as OkNegotiatedContentResult<double>;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0.99, result.Content);
        }

        [TestMethod]
        public void ScanItemBuyNGetMAtX_ShouldReturnTotal()
        {
            Receipt.Clear();
            //Arrange
            var testItems = GetTestItems();
            var controller = new ItemsController(testItems);

            //Act
            // This will add a total of 5 items to Receipt
            for (int i = 4; i > 0; i--)
            {
                controller.ScanItem(5);
            }
            var result = controller.ScanItemBuyNGetMAtX(5, 1.00, 2, 50, 2) as OkNegotiatedContentResult<double>;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(7.96, result.Content);
        }

        [TestMethod]
        public void ScanItemWithSetPriceForQty_ShouldReturnTotal()
        {
            Receipt.Clear();
            //Arrange
            var testItems = GetTestItems();
            var controller = new ItemsController(testItems);

            //Act
            // This will add a total of 5 items to Receipt
            for (int i = 4; i > 0; i--)
            {
                controller.ScanItem(5);
            }
            var result = controller.ScanItemWithSetPriceForQty(5, 1.00, 2, 2.00) as OkNegotiatedContentResult<double>;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(5.99, result.Content);
        }

        [TestMethod]
        public void ScanItemBuyNGetMAtXWithLimit_ShouldReturnTotal()
        {
            Receipt.Clear();
            //Arrange
            var testItems = GetTestItems();
            var controller = new ItemsController(testItems);

            //Act
            // This will add a total of 8 items to Receipt
            for (int i = 7; i > 0; i--)
            {
                controller.ScanItem(5);
            }
            var result = controller.ScanItemBuyNGetMAtXWithLimit(5, 1.00, 2, 50, 2, 1) as OkNegotiatedContentResult<double>;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(13.93, result.Content);
        }

        [TestMethod]
        public void ScanItemWithSetPriceForQtyWithLimit_ShouldReturnTotal()
        {
            Receipt.Clear();
            //Arrange
            var testItems = GetTestItems();
            var controller = new ItemsController(testItems);

            //Act
            // This will add a total of 8 items to Receipt
            for (int i = 7; i > 0; i--)
            {
                controller.ScanItem(5);
            }
            var result = controller.ScanItemWithSetPriceForQtyWithLimit(5, 1.00, 2, 2.00, 1) as OkNegotiatedContentResult<double>;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(13.94, result.Content);
        }

        [TestMethod]
        public void AddItemThenRemoveItem_ShouldReturnZero()
        {
            Receipt.Clear();
            //Arrange
            var testItems = GetTestItems();
            var controller = new ItemsController(testItems);

            //Act
            var result = controller.ScanItem(8) as OkNegotiatedContentResult<double>;
            result = controller.RemoveItem(8) as OkNegotiatedContentResult<double>;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0.00, result.Content);
        }

        #endregion

        private List<Item> GetTestItems()
        {
            var testItems = new List<Item>();
            testItems.Add(new Item { Id = 1, Name = "chicken", Price = 2.99, Eaches = false });
            testItems.Add(new Item { Id = 2, Name = "beef", Price = 5.49, Eaches = false });
            testItems.Add(new Item { Id = 3, Name = "pork", Price = 1.99, Eaches = false });
            testItems.Add(new Item { Id = 4, Name = "shrimp", Price = 5.99, Eaches = false });
            testItems.Add(new Item { Id = 5, Name = "eggs", Price = 1.99, Eaches = true });
            testItems.Add(new Item { Id = 6, Name = "butter", Price = 3.19, Eaches = true });
            testItems.Add(new Item { Id = 7, Name = "cheese", Price = 5.99, Eaches = true });
            testItems.Add(new Item { Id = 8, Name = "milk", Price = 4.59, Eaches = true });
            testItems.Add(new Item { Id = 9, Name = "apples", Price = 0.99, Eaches = false });
            testItems.Add(new Item { Id = 10, Name = "bananas", Price = 0.39, Eaches = false });
            testItems.Add(new Item { Id = 11, Name = "lemons", Price = 0.69, Eaches = true });
            testItems.Add(new Item { Id = 12, Name = "limes", Price = 0.50, Eaches = true });

            return testItems;
        }
    }
}
