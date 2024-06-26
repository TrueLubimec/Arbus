﻿using Arbus.Entities;
using Arbus.Servieces;
using MenuMaster.Api.Service.Contracts;
using Microsoft.Extensions.DependencyInjection;




//var services = new ServiceCollection(); 
//services.AddDbContext<MenuDbContext>();



internal class Program
{
    private static void Main(string[] args)
    {
        var services = new ServiceCollection();
        services.AddScoped<IMenuMasterRepo, MenuMasterRepo>();

        var menu = new List<Dish>
        {
            new Dish
            {
                DishId = 0,
                DishName = "Red Bull",
                DishDescriptions = "Energizer"
            },
            new Dish
            {
                DishId = 1,
                DishName = "Smoothie",
                DishDescriptions = "Beverage"
            },
            new Dish
            {
                DishId = 2,
                DishName = "Eskimo",
                DishDescriptions = "Ice Cream"
            },
            new Dish
            {
                DishId = 3,
                DishName = "Gin",
                DishDescriptions = "Distilled alcochol"
            },
            new Dish
            {
                DishId = 4,
                DishName = "Latte",
                DishDescriptions = "Another coffee"
            },
            new Dish
            {
                DishId = 5,
                DishName = "Americano",
                DishDescriptions = "Another one"
            },
            new Dish
            {
                DishId = 6,
                DishName = "Water",
                DishDescriptions = "H2O"
            },
            new Dish
            {
                DishId = 7,
                DishName = "Vodka",
                DishDescriptions = "Alcochol"
            },
            new Dish
            {
                DishId = 8,
                DishName = "Burn",
                DishDescriptions = "Liquid gold"
            }

        };
        var menu2 = new List<Dish>{
            new Dish
            {
                DishId = 0,
                DishName = "Matcha",
                DishDescriptions = "Coffee"
            },
            new Dish
            {
                DishId = 1,
                DishName = "Smoothie",
                DishDescriptions = "Beverage"
            },
            new Dish
            {
                DishId = 2,
                DishName = "Gin",
                DishDescriptions = "Distilled alcochol"
            },
            new Dish
            {
                DishId = 3,
                DishName = "Eskimo",
                DishDescriptions = "ice cream"
            },
            new Dish
            {
                DishId = 4,
                DishName = "Latte",
                DishDescriptions = "Another coffee"
            }
        };
        var emptyMenu = new List<Dish>();
        var menuMasterService = new MenuMasterRepo(emptyMenu, 3);

        var stuff = menuMasterService.GetAmountOfDishes();
        Console.WriteLine(stuff);
    }
}