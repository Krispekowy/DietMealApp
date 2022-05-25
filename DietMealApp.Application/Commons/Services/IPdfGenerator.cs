using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Application.Commons.Services
{
    public interface IPdfGenerator
    {
        (byte[], string) Generate();
    }
}
