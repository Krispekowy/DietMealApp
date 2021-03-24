using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DietMealApp.Core.Enums
{
    public enum ProductCategories
    {
        [Display(Name = "Mięsa i wędliny")]
        MiesoWedliny = 1,
        [Display(Name = "Ryby i owoce morza")]
        RybyOwoceMorza = 2,
        [Display(Name = "Pieczywo")]
        Pieczywo = 3,
        [Display(Name = "Nabiał")]
        Nabial = 4,
        [Display(Name = "Warzywa")]
        Warzywa = 5,
        [Display(Name = "Owoce")]
        Owoce = 6,
        [Display(Name = "Produkty suche")]
        ProduktySuche = 7,
        [Display(Name = "Konserwy")]
        Konserwy = 8,
        [Display(Name = "Mrożonki")]
        Mrozonki = 9,
        [Display(Name = "Inne")]
        Inne = 10
    }
}
