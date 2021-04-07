using DietMealApp.Core.Abstract;
using DietMealApp.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.Entities
{
    public sealed class AppUser : _User
    {
        public AppUser() : base()
        {
        }

        public void UpdateByDTO(AppUserDTO dto)
        {
            FirstName = dto.FirstName;
            LastName = dto.LastName;
            HasUserAdminRights = dto.HasUserAdminRights;
            AllowReceivingTradeInformations = dto.AllowReceivingTradeInformations;
            AllowProccesingMarketingInformations = dto.AllowProccesingMarketingInformations;
            AllowNewsletter = dto.AllowNewsletter;
            AcceptedRegulations = dto.AcceptedRegulations;
            ReadInformationClause = dto.ReadInformationClause;
        }

        //Dostępy do etapów
        public string ImagePath { get; set; }
        public bool HasUserAdminRights { get; set; }
        public bool AllowEmailNotification { get; set; }
        //Warunki i zasady
        public bool AllowReceivingTradeInformations { get; set; }
        public bool AllowProccesingMarketingInformations { get; set; }
        public bool AllowNewsletter { get; set; }
        public bool AcceptedRegulations { get; set; }
        public bool ReadInformationClause { get; set; }
    }
}
