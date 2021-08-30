using DietMealApp.Core.Abstract;
using DietMealApp.Core.Entities;
using DietMealApp.Core.Intersections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DietMealApp.Core.DTO
{
    public sealed class DayDTO : _BaseDTO
    {
        public DayDTO() : base() { }
        public static DayDTO DietDayEntityToDTO(Day entity)
        {
            if (entity != null)
            {
                var dto = new DayDTO()
                {
                    Id = entity.Id,
                    Kcal = entity.Kcal
                };
                return dto;
            }
            return null;
        }

        [Required(ErrorMessage = "Pole nazwa dnia jest wymagane")]
        [DisplayName("Nazwa dnia")]
        [MinLength(3, ErrorMessage = "Nazwa musi mieć co najmniej 3 znaki")]
        [MaxLength(50, ErrorMessage = "Nazwa może mieć maksymalnie 50 znaków")]
        public string Name { get; set; }
        public float Kcal { get; set; }
        public ICollection<DayMeals> DayMeals { get; set; }
        public ICollection<DietDay> DietDays { get; set; }
    }
}
