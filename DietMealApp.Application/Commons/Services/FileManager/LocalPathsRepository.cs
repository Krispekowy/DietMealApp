using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Application.Commons.Services.FileManager
{
    internal static class LocalPathsRepository
    {
        internal static readonly string LocalGlobalFull = "objects/global/full";
        internal static readonly string LocalGlobal150x150 = "objects/global/150x150";

        internal static readonly string LocalProductFull = "objects/products/full";
        internal static readonly string LocalProduct150x150 = "objects/products/150x150";

        internal static readonly string LocalMealFull = "objects/meals/full";
        internal static readonly string LocalMeal150x150 = "objects/meals/150x150";
    }
}
