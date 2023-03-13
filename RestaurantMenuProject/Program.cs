using RestaurantMenuProject.FileOperations;
using RestaurantMenuProject.Interfaces;
using RestaurantMenuProject.Servises;
using System;



Console.WriteLine("HI there");

StartCalculation start = new StartCalculation(@"..\\..\\..\\Files\\Course.txt", @"..\\..\\..\\Files\\Menu.txt",
    @"..\\..\\..\\Files\\Prices.txt");


FileWriter fileWriter = new FileWriter();
fileWriter.WriteExpression(start);


//result into file Result.txt












