using DietMealApp.Core.Intersections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.DTO.Days
{
    public sealed class DayFormDTO
    {
        public string UserId { get; set; }
        [Required(ErrorMessage = "Pole nazwa dnia jest wymagane")]
        [DisplayName("Nazwa dnia")]
        [MinLength(3, ErrorMessage = "Nazwa musi mieć co najmniej 3 znaki")]
        [MaxLength(50, ErrorMessage = "Nazwa może mieć maksymalnie 50 znaków")]
        public string Name { get; set; }
        public float Kcal { get; set; }
        public List<MealMenuItemDTO> MealMenu { get; set; }
    }
}
