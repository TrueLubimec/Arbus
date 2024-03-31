using Arbus.Data;
using Arbus.Entities;
using MenuMaster.Api.Service.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbus.Servieces
{/// <summary>
/// Represents standart class to work with menu functions. 
/// Requieres list of objects and amount of dishes per page to display.
/// </summary>
    public class MenuMasterRepo : IMenuMasterRepo
    {

        public readonly IEnumerable<Dish> dishes;
        private readonly int perPage;

        public MenuMasterRepo(IEnumerable<Dish> dishes, int perPage)
        {
            this.dishes = dishes;
            this.perPage = perPage;
        }

        public Task<bool> IfInputDataIsCorrect()
        {
            if (!dishes.Any())
            {
                return Task.FromResult(false);
            }
            else if(perPage < 1) {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }
        
        /// <summary>
        /// Count the amount of dishes in the menu.
        /// </summary>
        /// <returns> Amount of dishes in the menu. </returns>
        /// <exception cref="Exception"></exception>
        public async Task<int> GetAmountOfDishes()
        {
            try
            {
                if (await IfInputDataIsCorrect() == false)
                {
                    throw new ArgumentException("Input data is invalid!");
                }
                var tDishes = dishes.ToList();
                return tDishes.Count;
            }
            catch(Exception ex)
            {
                // можно просто log реализовать, конечно
                throw new Exception($"Failed to run GetAmountOfDishes method:{ex.Message}");       }
        }

        /// <summary>
        /// Count overall amount of pages foe menu.
        /// </summary>
        /// <returns> Number of pages. </returns>
        /// <exception cref="Exception"></exception>
        public async Task<int> GetAmountOfPages()
        {
            try
            {
                if (await IfInputDataIsCorrect() == false)
                {
                    throw new ArgumentException("Input data is invalid!");
                }
                var tDishes = dishes.ToList();
                var length = tDishes.Count();
                decimal amountOfPages = (decimal)length / (decimal)perPage;
                amountOfPages = Math.Ceiling(amountOfPages);
                return Decimal.ToInt32(amountOfPages);
                
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to run GetAmountOfPages method:{ex.Message}");
            }
        }

        /// <summary>
        /// Count the amount of dishes on specified page.
        /// </summary>
        /// <param name="pageId"> Specifies exectly on what page to count.</param>
        /// <returns> Number of dishes on specified page.</returns>
        /// <exception cref="Exception"></exception>

        public async Task<int> GetAmountOfDishesOnPage(int pageId)
        {
            if (pageId < 1 || pageId > await GetAmountOfPages())
            {
                throw new Exception($"Failed to run GetDishesPages method: invalid pageId!");
            }
            try
            {
                if (await IfInputDataIsCorrect() == false)
                {
                    throw new ArgumentException("Input data is invalid!");
                }
                var tDishes = dishes.ToList();
                var length = tDishes.Count();
                var count = 0;
                for (var i = perPage * (pageId - 1);i < (perPage * pageId) && i < length; i++)
                {
                    count++;
                }
                return count;
            }
            catch(Exception ex)
            {
                throw new Exception($"Failed to run GetAmountOfDishesOnPage method:{ex.Message}");
            }
        }

        /// <summary>
        /// Collect all dishes on specified page.
        /// </summary>
        /// <param name="pageId"> Id of the page where to collect dishes. </param>
        /// <returns> List of dishes on exact page</returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<Dish>> GetDishesOnPage(int pageId)
        {
            if (pageId < 1 || pageId > await GetAmountOfPages())
            {
                throw new Exception($"Failed to run GetDishesPages method: invalid pageId!");
            }

            try
            {
                if (await IfInputDataIsCorrect() == false)
                {
                    throw new ArgumentException("Input data is invalid!");
                }
                List<Dish> returnDishes = new List<Dish>();
                var tDishes = dishes.ToList();
                var length = tDishes.Count();
                for (var i = perPage * (pageId - 1); i < (perPage * pageId) && i < length; i++)
                {
                    returnDishes.Add(tDishes[i]);
                }
                return returnDishes;

            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to run GetDishesPages method:{ex.Message}");
            }
        }

        /// <summary>
        /// Collects all first dishes that appears on every page.
        /// </summary>
        /// <returns>List of Dish.</returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<Dish>> GetAllFirstDishesOnPages()
        {
            try
            {
                if (await IfInputDataIsCorrect() == false)
                {
                    throw new ArgumentException("Input data is invalid!");
                }
                List<Dish> returnDishes = new List<Dish>();
                var tDishes = dishes.ToList();
                var length = tDishes.Count();
 
                for (var i = 0; i < length; i = i + perPage)
                {
                    returnDishes.Add(tDishes[i]);
                }
                return returnDishes;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to run GetAllFirstDishesOnPages method:{ex.Message}");

            }
        }
    }
}
