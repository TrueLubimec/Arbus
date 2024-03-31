using Arbus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuMaster.Api.Service.Contracts
{
    public interface IMenuMasterRepo
    {
        Task<int> GetAmountOfDishes();
        Task<IEnumerable<Dish>> GetAllFirstDishesOnPages();
        Task<int> GetAmountOfDishesOnPage(int pageId);
        Task<int> GetAmountOfPages();
        Task<IEnumerable<Dish>> GetDishesOnPage(int pageId);
    }
}
