﻿using FoodApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApplication.ViewModels
{
    public class FoodViewModel
    {
        public int Id { get; set; }
        public string FoodName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfConsumption { get; set; }
        public double Amount { get; set; }
        public int? MealTypeId { get; set; }
        public int? CategoryId { get; set; }
        public List<FoodTable> Food { get; set; }

        public CategoryTypes Category { get; set; }
        public MealTypes MealType { get; set; }
    }
}
