using System;
using System.Collections.Generic;

namespace FoodApplication.Models
{
    public partial class MealTypes
    {
        public MealTypes()
        {
            FoodTable = new HashSet<FoodTable>();
        }

        public int Id { get; set; }
        public string MealType { get; set; }

        public ICollection<FoodTable> FoodTable { get; set; }
    }
}
