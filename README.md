# RestaurantMenuProject

Project consists with 5 folders:

- Interfases (here are the system of interfases for operations with files - IExpressionReader, IExpressionWriter and
IParser, also are interfaces for project items - ICurrency, IIngredientList, IPriceList and one interface for main 
program purpose - ICalculation);

- Files (here are: Course.txt file, which consists an information for currency course relatively of Polish Zloty,
Menu.txt file, which consists an information of dishes in the restaurant and its ingrediens, 
Prices.txt file which consists an information about price of each ingredient in Polish Zloty currency and
Result.txt file where the all calculation is writing);

- FileOperations (here are classes for reading from file, writing to file and parse information from file into
Dictionary<string, double> format);

- Servises (here are classes of the concrete realisation of interface system. Consists classes of project items:
Currency, IngredientList, PriceListWrapper, static class for printing: PrintDictionary, class Calculation and
client class StartCalculation);

- Diagrams (here are simple diagrams maded by VS).

Program make calculation the total amount of ptoducts in restaurant, its total cost in Polish Zloty or another currency
by user choice.