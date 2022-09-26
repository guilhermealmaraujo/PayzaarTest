/*
* TODO:
*	- refactor, find all the issues you can and fix them
*	- change the code to follow clean architecture principles
*	- apply design patterns where you think it is required
*	- do not change the output
*	- make sure the refactored code is testable (you are allowed to write a test or two as a PoC)
*	- add comments, highlighting what you changed and what was the reason for change
*/


if (ProductUtils.ListAvailableProductsNow().Count() == 0)
    Console.WriteLine("There are no products available at this time of day");
else
    ProductUtils.DisplayAvailableProducts();

Console.ReadKey();

public class Product
{
    public string ProductName;
    public string ProductType;
    public int StartHour, EndHour;
}

public static class ProductUtils
{
    private static List<Product> ProductsAvailable;

    static ProductUtils()
    {
        ProductsAvailable = ListAllProducts();
    }

    public static List<Product> GetListOfAllAvailableProducts() 
    {
        return ProductsAvailable.ToList();
    }

    public static bool AddProduct(Product prod) 
    {
        int currentCount = ProductsAvailable.Count();

        ProductsAvailable.Add(prod);

        if (ProductsAvailable.Count() == currentCount + 1)
            return true;
        else
            return false;
    }

    public static bool RemoveProduct(string productName)
    {
        int index = ProductsAvailable.FindIndex(x => x.ProductName.Contains(productName));

        if(ProductsAvailable.Count() == 0)
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

    private static List<Product> ListAllProducts()
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

    public static List<Product> ListAvailableProductsNow()
    {
        List<Product> availableProductsNow = new List<Product>();

        foreach (var product in ProductsAvailable)
        {
            if (product.ProductType == "AllDay" || (product.StartHour <= DateTime.Now.Hour && product.EndHour >= DateTime.Now.Hour))
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

    public static void DisplayAvailableProducts()
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
}
