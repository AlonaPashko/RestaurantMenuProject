using RestaurantMenuProject.FileOperations;
using RestaurantMenuProject.Interfaces;
using RestaurantMenuProject.Servises;
using System;



Console.WriteLine("HI there");

Calculation calc1 = new Calculation(@"..\\..\\..\\Files\\Menu.txt", @"..\\..\\..\\Files\\Prices.txt");

Console.WriteLine(calc1.PrintTotalCost());






