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
        { };
        public static List<Dish> GetTestDishes(int id)
        {
            switch (id)
            {
                case 0:
                    return new()
                    {
                        new Dish
                        {
                            DishId = 0,
                            DishName = "Juice",
                            DishDescriptions ="Juicy"
                        }
                    };
                case 1:
                    return new()
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
                case 2:
                    return new()
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
                        },
                        new Dish
                        {
                            DishId = 5,
                            DishName = "test2",
                            DishDescriptions = "desc for test2"
                        }

                    };
                case 3:
                    return new()
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
                        },
                        new Dish
                        {
                            DishId = 5,
                            DishName = "test2",
                            DishDescriptions = "desc for test"
                        },
                        new Dish
                        {
                            DishId = 6,
                            DishName = "test3",
                            DishDescriptions = "desc for test"
                        },
                        new Dish
                        {
                            DishId = 7,
                            DishName = "test4",
                            DishDescriptions = "desc for test"
                        },
                        new Dish
                        {
                            DishId = 8,
                            DishName = "test5",
                            DishDescriptions = "desc for test"
                        },
                        new Dish
                        {
                            DishId = 9,
                            DishName = "test6",
                            DishDescriptions = "desc for test"
                        },
                        new Dish
                        {
                            DishId = 10,
                            DishName = "test7",
                            DishDescriptions = "desc for test"
                        }
                    };
                default:
                    return new() {
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

    }
}
