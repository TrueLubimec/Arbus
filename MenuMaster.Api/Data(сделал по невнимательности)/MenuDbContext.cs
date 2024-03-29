using Arbus.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbus.Data
{      
    //
    // Я случайно сделал доступ к db, я позже прочитал фабулу и понял, что просто коллекция передается в метод
    //

    public class MenuDbContext : DbContext
    {
        public MenuDbContext(DbContextOptions<MenuDbContext> options, DbContextOptionsBuilder optionsBuilder) : base(options)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "MenuDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Dish>().HasData(new Dish
            {
                DishId = 1,
                DishName = "Matcha Coffee",
                DishDescriptions = "Matcha - green tea powder made from pulverized tea leaves, distinguishing it from loose-leaf tea."
            });

            modelBuilder.Entity<Dish>().HasData(new Dish
            {
                DishId = 2,
                DishName = "Matcha Coffe",
                DishDescriptions = "Latte - a milk coffee that boasts a silky layer of foam as a real highlight to the drink."
            });

            modelBuilder.Entity<Dish>().HasData(new Dish
            {
                DishId = 3,
                DishName = "Smoothie",
                DishDescriptions = "Smoothie - a thick blended beverage with shake like consistency, normally pureed in a blender " +
                                   "containing fruits and/or vegetables as well as an added liquid such as fruit juice, vegetable juice, milk, or even yogurt."
            });
        }
        public DbSet<Dish> Dishes { get; set; }
    }
}