using DietMealApp.Core.Abstract;
using DietMealApp.Core.Entities;
using Foolproof;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.DTO
{
    public sealed class AppUserDTO : _BaseDTO
    {
        public AppUserDTO() : base() { }
        public AppUserDTO(AppUser user) : base()
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            UserName = user.UserName;
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
            ImagePath = user.ImagePath;
            HasUserAdminRights = user.HasUserAdminRights;
            AllowEmailNotification = user.AllowEmailNotification;
            AllowReceivingTradeInformations = user.AllowReceivingTradeInformations;
            AllowProccesingMarketingInformations = user.AllowProccesingMarketingInformations;
            AllowNewsletter = user.AllowNewsletter;
            AcceptedRegulations = user.AcceptedRegulations;
            ReadInformationClause = user.ReadInformationClause;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Display(Name = "Nazwa użytkownika")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Potwierdź hasło")]
        [Compare("Password", ErrorMessage = "Hasła nie są takie same")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Zapamiętaj mnie")]
        public bool RememberMe { get; set; }
        public string PhoneNumber { get; set; }
        public string ImagePath { get; set; }
        public bool HasUserAdminRights { get; set; }
        public bool AllowEmailNotification { get; set; }
        public bool AllowReceivingTradeInformations { get; set; }
        public bool AllowProccesingMarketingInformations { get; set; }
        public bool AllowNewsletter { get; set; }
        public bool AcceptedRegulations { get; set; }
        public bool ReadInformationClause { get; set; }

    }
}
