using DietMealApp.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Application.Commons.Services
{
    public  interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
