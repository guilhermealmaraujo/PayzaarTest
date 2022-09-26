using PayzaarTest;

namespace PayzaarTest_UnitTests
{
    [TestClass]
    public class UnitTest
    {
        private void MatchingListOfProductsName(List<Product> expected, List<Product> result) 
        {
            if (expected.Count() != result.Count()) 
            {
                Assert.IsTrue(false);
            }

            for (int i = 0; i < expected.Count(); i++) 
            {
                Assert.AreEqual(expected[i].ProductName, result[i].ProductName);
            }
        }

        [TestMethod]
        public void ListingAvailableProductsNow_MockingDatetimeNow()
        {
            //Arrange
            ProductShop shopTest = new ProductShop();
            shopTest.SetMockingDateTimeNow(new DateTime(2022, 01, 01, 23, 00, 00));
            List<Product> expectedProdList1 = new List<Product>
            {
                new Product { ProductName = "Orange Juice", ProductType = "AllDay" },
                new Product { ProductName = "Sam Adams Seasonal", ProductType = "Limited", StartHour = 17, EndHour = 23 }
            };

            //Act
            List<Product> availableList1 = shopTest.ListAvailableProductsNow();


            //Assert
            Assert.AreEqual(availableList1.Count, 2);
            MatchingListOfProductsName(expectedProdList1, availableList1);


            //Arrange
            shopTest.SetMockingDateTimeNow(new DateTime(2022, 01, 01, 13, 00, 00));
            List<Product> expectedProdList2 = new List<Product>
            {
                new Product { ProductName = "Orange Juice", ProductType = "AllDay" },
                new Product { ProductName = "Steak & Chips", ProductType = "Limited", StartHour = 12, EndHour = 21 },
                new Product { ProductName = "Chicken Sandwich", ProductType = "Limited", StartHour = 11, EndHour = 19 },
            };

            //Act
            List<Product> availableList2 = shopTest.ListAvailableProductsNow();

            //Assert
            Assert.AreEqual(availableList2.Count, 3);
            MatchingListOfProductsName(expectedProdList2, availableList2);

        }

        [TestMethod]
        public void GettingListOfAllAvailableProducts() 
        {
            ProductShop shopTest = new ProductShop();
            List<Product> expectedAll = new List<Product>
            {
                new Product { ProductName = "Orange Juice", ProductType = "AllDay" },
                new Product { ProductName = "Breakfast Burrito", ProductType = "Limited", StartHour = 8, EndHour = 12 },
                new Product { ProductName = "Steak & Chips", ProductType = "Limited", StartHour = 12, EndHour = 21 },
                new Product { ProductName = "Chicken Sandwich", ProductType = "Limited", StartHour = 11, EndHour = 19 },
                new Product { ProductName = "Sam Adams Seasonal", ProductType = "Limited", StartHour = 17, EndHour = 23 }
            };


            List<Product> availableListOfAll = shopTest.GetListOfAllAvailableProducts();

            Assert.AreEqual(availableListOfAll.Count(), 5);
            MatchingListOfProductsName(expectedAll, availableListOfAll);
        }

        [TestMethod]
        public void AddingToListOfAllAvailableProducts()
        {
            ProductShop shopTest = new ProductShop();
            List<Product> expectedAll = new List<Product>
            {
                new Product { ProductName = "Orange Juice", ProductType = "AllDay" },
                new Product { ProductName = "Breakfast Burrito", ProductType = "Limited", StartHour = 8, EndHour = 12 },
                new Product { ProductName = "Steak & Chips", ProductType = "Limited", StartHour = 12, EndHour = 21 },
                new Product { ProductName = "Chicken Sandwich", ProductType = "Limited", StartHour = 11, EndHour = 19 },
                new Product { ProductName = "Sam Adams Seasonal", ProductType = "Limited", StartHour = 17, EndHour = 23 },
                new Product { ProductName = "Product A", ProductType = "Limited", StartHour = 20, EndHour = 21 }
            };

            shopTest.AddProduct(new Product { ProductName = "Product A", ProductType = "Limited", StartHour = 20, EndHour = 21 });
            List<Product> availableListOfAll = shopTest.GetListOfAllAvailableProducts();


            Assert.AreEqual(availableListOfAll.Count(), 6);
            MatchingListOfProductsName(expectedAll, availableListOfAll);
        }

        [TestMethod]
        public void RemovingProductListOfAllAvailableProducts()
        {
            ProductShop shopTest = new ProductShop();
            List<Product> expectedAll = new List<Product>
            {
                new Product { ProductName = "Orange Juice", ProductType = "AllDay" },
                new Product { ProductName = "Breakfast Burrito", ProductType = "Limited", StartHour = 8, EndHour = 12 },
                new Product { ProductName = "Steak & Chips", ProductType = "Limited", StartHour = 12, EndHour = 21 },
                new Product { ProductName = "Chicken Sandwich", ProductType = "Limited", StartHour = 11, EndHour = 19 },
            };

            bool removed = shopTest.RemoveProduct("Sam Adams Seasonal");
            List<Product> availableListOfAll = shopTest.GetListOfAllAvailableProducts();


            Assert.IsTrue(removed);
            MatchingListOfProductsName(expectedAll, availableListOfAll);
        }
    }
}