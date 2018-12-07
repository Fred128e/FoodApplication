using FoodApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApplication.Interfaces
{
    public interface IFoodInterface
    {
        IEnumerable<FoodTable> GetAllFood();
        FoodTable GetFood(int id);

    }
}
