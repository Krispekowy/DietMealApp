using DietMealApp.Core.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DietMealApp.Application.Commons.Services.FileManager
{
    public class FileManager : IFileManager
    {
        private readonly string _host;
        private readonly string _user;
        private readonly string _password;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly NetworkCredential _credential;

        public FileManager(string host, string user, string password, IWebHostEnvironment webHostEnvironment)
        {
            _host = host;
            _user = user;
            _password = password;
            _webHostEnvironment = webHostEnvironment;

            if (string.IsNullOrWhiteSpace(_webHostEnvironment.WebRootPath))
            {
                _webHostEnvironment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            }
            _credential = new NetworkCredential
            {
                UserName = _user,
                Password = _password
            };
        }

        public string GetFileFromFtp(string path)
        {
            return $"http://{_host}/{path}";
        }

        public async Task<string> SendFileToFtp(IFormFile file, string directoryTo)
        {
            try
            {
                return await UploadFileToFtp(file, directoryTo);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        private async Task<string> UploadFileToFtp(IFormFile file, string directoryTo)
        {
            string fileName = GenerateNewFileName(file.FileName);
            string fileFtpPath = $"ftp://{_host}/dietmealapp.cba.pl/{directoryTo}/{fileName}";
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(fileFtpPath);
            request.Credentials = _credential;
            request.Method = WebRequestMethods.Ftp.UploadFile;

            try
            {
                using Stream ftpStream = await request.GetRequestStreamAsync();
                file.CopyTo(ftpStream);
            }
            catch (Exception e)
            {

                throw;
            }
            return $"http://{_host}/{directoryTo}/{fileName}";
        }

        private string GenerateNewFileName(string fileName)
        {
            var extension = Path.GetExtension(fileName);
            fileName = Guid.NewGuid().ToString() + extension;
            return fileName;
        }

    }
}
