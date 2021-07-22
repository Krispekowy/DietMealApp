using DietMealApp.Core.Abstract;
using DietMealApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DietMealApp.Core.DTO
{
    public sealed class DietDayDTO : _BaseDTO
    {
        public DietDayDTO() : base() { }
        public static DietDayDTO DietDayEntityToDTO(DietDay entity)
        {
            if (entity != null)
            {
                var dto = new DietDayDTO()
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
        public int DietId { get; set; }
        [Required(ErrorMessage = "Wybierz posiłek na I śniadanie")]
        public int Breakfast { get; set; }
        [Required(ErrorMessage = "Wybierz posiłek na II śniadanie")]
        public int Brunch { get; set; }
        [Required(ErrorMessage = "Wybierz posiłek na obiad")]
        public int Lunch { get; set; }
        [Required(ErrorMessage = "Wybierz posiłek na podwieczorek")]
        public int Tea { get; set; }
        [Required(ErrorMessage = "Wybierz posiłek na kolację")]
        public int Dinner { get; set; }
        public float Kcal { get; set; }
        public List<DietDayMeals> DayDietMeals { get; set; }
    }
}
