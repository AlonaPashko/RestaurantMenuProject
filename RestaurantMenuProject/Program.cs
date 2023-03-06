using RestaurantMenuProject.FileOperations;
using RestaurantMenuProject.Interfaces;
using RestaurantMenuProject.Servises;
using System;



Console.WriteLine("HI there");

IngredientList ingrList = new IngredientList(@"..\\..\\..\\Files\\Menu.txt");
Console.WriteLine(ingrList);

//Parser make a dictionary and give it to IngredientList and to PriceList
//realisation of FileParser: how to parse into dictionary more generalised
