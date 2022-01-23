using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.ViewModels.Identity
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Pole 'Obecne hasło' jest wymagane")]
        [DataType(DataType.Password)]
        [Display(Name = "Obecne hasło")]
        public string CurrentPassword { get; set; }
        [Required(ErrorMessage = "Pole 'Nowe hasło' jest wymagane")]
        [DataType(DataType.Password)]
        [Display(Name = "Nowe hasło")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Pole 'Powtórz nowe hasło' jest wymagane")]
        [DataType(DataType.Password)]
        [Display(Name = "Powtórz nowe hasło")]
        [Compare("NewPassword", ErrorMessage = "Wprowadzone hasła różnią się.")]
        public string ConfirmPassword { get; set; }
    }
}
