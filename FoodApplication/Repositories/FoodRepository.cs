using FoodApplication.Interfaces;
using FoodApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApplication
{
    public class FoodRepository:IFoodInterface
    {
        private readonly MyFoodDbContext _foodContext;
        FoodRepository(MyFoodDbContext foodContext)
        {
            _foodContext = foodContext;

        }
        public IEnumerable<FoodTable> GetAllFood()
        {
            return _foodContext.FoodTable;
        }

        public FoodTable GetFood(int id)
        {
            return _foodContext.FoodTable.FirstOrDefault(f => f.Id == id);
        }
    }
}
