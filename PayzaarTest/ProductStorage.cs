namespace PayzaarTest
{
    public class ProductStorage
    {
        private List<Product> ProductsAvailable;
        private DateTime? PUNow;

        public ProductStorage()
        {
            ProductsAvailable = ListAllProducts();
            PUNow = null;
        }

        public List<Product> GetListOfAllAvailableProducts()
        {
            return ProductsAvailable.ToList();
        }

        public bool AddProduct(Product prod)
        {
            int currentCount = ProductsAvailable.Count();

            ProductsAvailable.Add(prod);

            if (ProductsAvailable.Count() == currentCount + 1)
                return true;
            else
                return false;
        }

        public bool RemoveProduct(string productName)
        {
            int index = ProductsAvailable.FindIndex(x => x.ProductName.Contains(productName));

            if (ProductsAvailable.Count() == 0)
                return false;

            if (index != -1)
            {
                ProductsAvailable.RemoveAt(index);
                return true;
            }
            else
            {
                return false;
            }
        }

        private List<Product> ListAllProducts()
        {
            return new List<Product>
            {
                new Product { ProductName = "Orange Juice", ProductType = "AllDay" },
                new Product { ProductName = "Breakfast Burrito", ProductType = "Limited", StartHour = 8, EndHour = 12 },
                new Product { ProductName = "Steak & Chips", ProductType = "Limited", StartHour = 12, EndHour = 21 },
                new Product { ProductName = "Chicken Sandwich", ProductType = "Limited", StartHour = 11, EndHour = 19 },
                new Product { ProductName = "Sam Adams Seasonal", ProductType = "Limited", StartHour = 17, EndHour = 23 }
            };
        }

        public List<Product> ListAvailableProductsNow()
        {
            List<Product> availableProductsNow = new List<Product>();

            DateTime dateTimeNow = PUNow?? DateTime.Now;

            foreach (var product in ProductsAvailable)
            {
                if (product.ProductType == "AllDay" || (product.StartHour <= dateTimeNow.Hour && product.EndHour >= dateTimeNow.Hour))
                {
                    availableProductsNow.Add(new Product
                    {
                        ProductName = product.ProductName,
                        ProductType = product.ProductType,
                        StartHour = product.StartHour,
                        EndHour = product.EndHour
                    });
                }
            }

            return availableProductsNow;
        }

        public void DisplayAvailableProducts()
        {
            Console.WriteLine("Products available current time of day:");

            foreach (var pan in ListAvailableProductsNow())
            {
                string displayName = pan.ProductName;

                if (pan.ProductType == "AllDay")
                    Console.WriteLine(pan.ProductName);
                else
                {
                    displayName += " (" + pan.StartHour + ":00" + "-" + pan.EndHour + ":00" + ")";
                    Console.WriteLine(displayName);
                }
            }
        }

        public void SetMockingDateTimeNow(DateTime now)
        {
            PUNow = now;
        }

        public void UnSetMockingDateTimeNow()
        {
            PUNow = null;
        }
    }
}
