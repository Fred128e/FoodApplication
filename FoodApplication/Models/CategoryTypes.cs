using System;
using System.Collections.Generic;

namespace FoodApplication.Models
{
    public partial class CategoryTypes
    {
        public CategoryTypes()
        {
            FoodTable = new HashSet<FoodTable>();
        }

        public int Id { get; set; }
        public string CategoryType { get; set; }

        public ICollection<FoodTable> FoodTable { get; set; }
    }
}
