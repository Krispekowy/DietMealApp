using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DietMealApp.Core.Enums
{
    public enum Unit
    {
        [Display(Name = "-")]
        brak = 0,
        [Display(Name = "g")]
        gram = 1,
        [Display(Name = "ml")]
        mililitr = 2
        //[Display(Name = "szt")]
        //sztuka = 3,
        //[Display(Name = "łyżka")]
        //lyzka = 4,
        //[Display(Name = "łyżeczka")]
        //lyzeczka = 5,
        //[Display(Name = "szklanka")]
        //szklanka = 6
    }
}
