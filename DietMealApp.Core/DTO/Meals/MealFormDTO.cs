﻿using DietMealApp.Core.Abstract;
using DietMealApp.Core.DTO.Products;
using DietMealApp.Core.Entities;
using DietMealApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.DTO.Meals
{
    public class MealFormDTO : _BaseDTO
    {
        public string UserId { get; set; }
        [Required(ErrorMessage = "Pole typ posiłku jest wymagane")]
        public TypesOfMeal TypeOfMeal { get; set; }
        [Required(ErrorMessage = "Pole nazwa posiłku jest wymagane")]
        [MinLength(5, ErrorMessage = "Nazwa posiłku musi składać się z minimum 5 znaków")]
        [MaxLength(50, ErrorMessage = "Nazwa posiłku może składać się z maksimum 50 znaków")]
        public string MealName { get; set; }
        [MaxLength(1000, ErrorMessage = "Maksymalna długość opisu to 1000 znaków")]
        public string Description { get; set; }
        public int Kcal { get; set; } = 0;
        public IEnumerable<ProductDTO> Products { get; set; }
        public List<MealProduct> MealProducts { get; set; }
    }
}
