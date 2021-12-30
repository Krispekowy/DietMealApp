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
        Task<string> SendFileToFtp(IFormFile file, string ftpPath);
        string GetFileFromFtp(string fileName);
    }
}
