/*
* TODO:
*	- refactor, find all the issues you can and fix them
*	- change the code to follow clean architecture principles
*	- apply design patterns where you think it is required
*	- do not change the output
*	- make sure the refactored code is testable (you are allowed to write a test or two as a PoC)
*	- add comments, highlighting what you changed and what was the reason for change
*/
using PayzaarTest;

ProductShop shopA = new ProductShop();

if (shopA.ListAvailableProductsNow().Count() == 0)
    Console.WriteLine("There are no products available at this time of day");
else
    shopA.DisplayAvailableProducts();

Console.ReadKey();
