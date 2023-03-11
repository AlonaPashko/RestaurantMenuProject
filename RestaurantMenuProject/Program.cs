using RestaurantMenuProject.FileOperations;
using RestaurantMenuProject.Interfaces;
using RestaurantMenuProject.Servises;
using System;



Console.WriteLine("HI there");

StartCalculation start = new StartCalculation(@"..\\..\\..\\Files\\Course.txt", @"..\\..\\..\\Files\\Menu.txt",
    @"..\\..\\..\\Files\\Prices.txt");

Console.WriteLine(start);












