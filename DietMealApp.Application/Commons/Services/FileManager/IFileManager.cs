using DietMealApp.Core.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Application.Commons.Services.FileManager
{
    public interface IFileManager
    {
        Task<(string,string)> SendFileToFtp(IFormFile file, ImageType imageType);
        bool DeleteLocalFiles(string[] fullPaths);
    }
}
