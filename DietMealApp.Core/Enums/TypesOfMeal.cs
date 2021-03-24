using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DietMealApp.Core.Enums
{
    public enum TypesOfMeal
    {
        [Display(Name = "-")]
        Brak = 0,
        [Display(Name="Śniadanie")]
        Breakfast = 1,
        [Display(Name = "II śniadanie")]
        Brunch = 2,
        [Display(Name = "Obiad")]
        Lunch = 3,
        [Display(Name = "Podwieczorek")]
        Tea = 4,
        [Display(Name = "Kolacja")]
        Dinner = 5
    }
}
