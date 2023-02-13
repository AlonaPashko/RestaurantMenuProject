using RestaurantMenuProject.FileOperations;
using RestaurantMenuProject.Interfaces;
using RestaurantMenuProject.Servises;

Menu productStorage = new Menu();

FileReader fileReader = new FileReader();
List<string> productNames = fileReader.ReadExpression();


productStorage.Products = productStorage.MakeDictionaryFromList(productNames);

Console.WriteLine(productStorage);
 
//total price for each product

