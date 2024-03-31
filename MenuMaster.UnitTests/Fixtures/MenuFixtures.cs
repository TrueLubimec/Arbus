using Arbus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuMaster.UnitTests.Fixtures
{
    public static class MenuFixtures
    {
        public static List<Dish> GetTestDishesEmpty() => new()
        {};
        public static List<Dish> GetTestDishes() => new()
        {
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

        public static List<Dish> GetTestDishes2() => new()
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

    }
}
