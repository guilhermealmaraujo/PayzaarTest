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
            ProductStorage storageTest = new ProductStorage();
            storageTest.SetMockingDateTimeNow(new DateTime(2022, 01, 01, 23, 00, 00));
            List<Product> expectedProdList1 = new List<Product>
            {
                new Product { ProductName = "Orange Juice", ProductType = "AllDay" },
                new Product { ProductName = "Sam Adams Seasonal", ProductType = "Limited", StartHour = 17, EndHour = 23 }
            };

            //Act
            List<Product> availableList1 = storageTest.ListAvailableProductsNow();


            //Assert
            Assert.AreEqual(availableList1.Count, 2);
            MatchingListOfProductsName(expectedProdList1, availableList1);


            //Arrange
            storageTest.SetMockingDateTimeNow(new DateTime(2022, 01, 01, 13, 00, 00));
            List<Product> expectedProdList2 = new List<Product>
            {
                new Product { ProductName = "Orange Juice", ProductType = "AllDay" },
                new Product { ProductName = "Steak & Chips", ProductType = "Limited", StartHour = 12, EndHour = 21 },
                new Product { ProductName = "Chicken Sandwich", ProductType = "Limited", StartHour = 11, EndHour = 19 },
            };

            //Act
            List<Product> availableList2 = storageTest.ListAvailableProductsNow();

            //Assert
            Assert.AreEqual(availableList2.Count, 3);
            MatchingListOfProductsName(expectedProdList2, availableList2);

        }

        [TestMethod]
        public void GettingListOfAllAvailableProducts() 
        {
            ProductStorage storageTest = new ProductStorage();
            List<Product> expectedAll = new List<Product>
            {
                new Product { ProductName = "Orange Juice", ProductType = "AllDay" },
                new Product { ProductName = "Breakfast Burrito", ProductType = "Limited", StartHour = 8, EndHour = 12 },
                new Product { ProductName = "Steak & Chips", ProductType = "Limited", StartHour = 12, EndHour = 21 },
                new Product { ProductName = "Chicken Sandwich", ProductType = "Limited", StartHour = 11, EndHour = 19 },
                new Product { ProductName = "Sam Adams Seasonal", ProductType = "Limited", StartHour = 17, EndHour = 23 }
            };


            List<Product> availableListOfAll = storageTest.GetListOfAllAvailableProducts();

            Assert.AreEqual(availableListOfAll.Count(), 5);
            MatchingListOfProductsName(expectedAll, availableListOfAll);
        }

        [TestMethod]
        public void AddingToListOfAllAvailableProducts()
        {
            ProductStorage storageTest = new ProductStorage();
            List<Product> expectedAll = new List<Product>
            {
                new Product { ProductName = "Orange Juice", ProductType = "AllDay" },
                new Product { ProductName = "Breakfast Burrito", ProductType = "Limited", StartHour = 8, EndHour = 12 },
                new Product { ProductName = "Steak & Chips", ProductType = "Limited", StartHour = 12, EndHour = 21 },
                new Product { ProductName = "Chicken Sandwich", ProductType = "Limited", StartHour = 11, EndHour = 19 },
                new Product { ProductName = "Sam Adams Seasonal", ProductType = "Limited", StartHour = 17, EndHour = 23 },
                new Product { ProductName = "Product A", ProductType = "Limited", StartHour = 20, EndHour = 21 }
            };

            bool added = storageTest.AddProduct(new Product { ProductName = "Product A", ProductType = "Limited", StartHour = 20, EndHour = 21 });
            List<Product> availableListOfAll = storageTest.GetListOfAllAvailableProducts();


            Assert.AreEqual(availableListOfAll.Count(), 6);
            Assert.IsTrue(added);
            MatchingListOfProductsName(expectedAll, availableListOfAll);
        }

        [TestMethod]
        public void RemovingProductListOfAllAvailableProducts()
        {
            ProductStorage storageTest = new ProductStorage();
            List<Product> expectedAll = new List<Product>
            {
                new Product { ProductName = "Orange Juice", ProductType = "AllDay" },
                new Product { ProductName = "Breakfast Burrito", ProductType = "Limited", StartHour = 8, EndHour = 12 },
                new Product { ProductName = "Steak & Chips", ProductType = "Limited", StartHour = 12, EndHour = 21 },
                new Product { ProductName = "Chicken Sandwich", ProductType = "Limited", StartHour = 11, EndHour = 19 },
            };

            bool removed = storageTest.RemoveProduct("Sam Adams Seasonal");
            List<Product> availableListOfAll = storageTest.GetListOfAllAvailableProducts();


            Assert.IsTrue(removed);
            Assert.AreEqual(availableListOfAll.Count(), 4);
            MatchingListOfProductsName(expectedAll, availableListOfAll);
        }
    }
}