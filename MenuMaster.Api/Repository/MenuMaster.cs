using Arbus.Data;
using Arbus.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbus.Servieces
{
    internal class MenuMaster
    {
        private readonly ILogger<MenuMaster> logger;
        public readonly IEnumerable<Dish> dishes;
        private readonly int amoountOnPage;

        public MenuMaster(IEnumerable<Dish> dishes, int amoountOnPage)
        {
            this.dishes = dishes;
            this.amoountOnPage = amoountOnPage;
        }
        
        //  НЕ ЗАБУДЬ ДОБАВИТЬ КОММЕНТЫ
        //  КИДАТЬ ИСКЛЮЧЕНИЯ
        //  ВАЛИДНОСТЬ (id и так далее)
        public async Task<int> GetAmountOfDishes()
        {
            try
            {
                if (dishes != null)
                {
                    var tDishes = dishes.ToList();
                    return tDishes.Count;
                }
                else
                {
                    throw new Exception($"Failed to run GetAmountOfDishes method: list is empty");
                }
            }
            catch(Exception ex)
            {
                // можно просто log реализовать, конечно
                throw new Exception($"Failed to run GetAmountOfDishes method:{ex.Message}");       }
        }
        public async Task<IEnumerable<Dish>> GetAllFirstDishesOnPages()
        {
            try
            {
                if (dishes.Any())
                {
                    List<Dish> returnDishes = new List<Dish>();
                    var tDishes = dishes.ToList();
                    var length = tDishes.Count();
                    var perPage = length / amoountOnPage;

                    for (var i = 0; i < perPage; i = i + perPage)
                    {
                        returnDishes.Add(tDishes[i]);
                    }
                    return returnDishes;
                }
                else
                {
                    throw new Exception($"Failed to run GetAllFirstDishesOnPages method: list is empty");
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"Failed to run GetAllFirstDishesOnPages method:{ex.Message}");
                
            }
        }

        public async Task<int> GetAmountOfDishesOnPage(int pageId)
        {
            try
            {
                if (dishes.Any())
                {
                    var tDishes = dishes.ToList();
                    var length = tDishes.Count();
                    var perPage = length / amoountOnPage;
                    var count = 0;
                    // i может получиться < 0, если входной < 1
                    for (var i = perPage * (pageId - 1);i < (perPage * pageId); i++)
                    {
                        count++;
                    }
                    return count;
                }
                else
                {
                    throw new Exception($"Failed to run GetAmountOfDishesOnPage method: list is empty");
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"Failed to run GetAmountOfDishesOnPage method:{ex.Message}");
            }
        }

        public async Task<int> GetAmountOfPages()
        {
            try
            {
                if (dishes.Any())
                {
                    var tDishes = dishes.ToList();
                    var length = tDishes.Count();
                    
                    decimal amountOfPages = (length / amoountOnPage);
                    amountOfPages = Math.Ceiling(amountOfPages);
                    return Decimal.ToInt32(amountOfPages);
                }
                else
                {
                    throw new Exception($"Failed to run GetAmountOfPages method: list is empty");
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"Failed to run GetAmountOfPages method:{ex.Message}");
            }
        }
        public async Task<IEnumerable<Dish>> GetDishesOnPage(int pageId)
        {
            try
            {
                if (dishes.Any())
                {
                    List<Dish> returnDishes = new List<Dish>();
                    var tDishes = dishes.ToList();
                    var length = tDishes.Count();
                    var perPage = length / amoountOnPage;
                    var count = 0;
                    // i может получиться < 0, если входной < 1
                    for (var i = perPage * (pageId - 1); i < (perPage * pageId); i++)
                    {
                        returnDishes.Add(tDishes[i]);
                    }
                    return returnDishes;
                }
                else
                {
                    throw new Exception($"Failed to run GetDishesPages method: list is empty");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to run GetDishesPages method:{ex.Message}");
            }
        }
    }
}
