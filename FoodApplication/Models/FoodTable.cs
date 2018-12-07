using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodApplication.Models
{
    public partial class FoodTable
    {
        //public FoodTable(int id, string foodName, DateTime dateOfConsumption, double amount, int mealTypeId, int categoryId)
        //{
        //    Id = id;
        //    FoodName = foodName;
        //    DateOfConsumption = dateOfConsumption;
        //    Amount = amount;
        //    MealTypeId = mealTypeId;
        //    CategoryId = categoryId;
            
        //}

        public int Id { get; set; }
        public string FoodName { get; set; }

        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        public DateTime DateOfConsumption { get; set; }
        public double Amount { get; set; }
        public int? MealTypeId { get; set; }
        public int? CategoryId { get; set; }

        public CategoryTypes Category { get; set; }
        public MealTypes MealType { get; set; }  
    }
}
