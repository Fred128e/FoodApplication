﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodApplication.Models
{
    public partial class FoodTable
    {
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
