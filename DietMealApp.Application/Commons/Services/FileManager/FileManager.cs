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

namespace DietMealApp.Application.Commons.Services.FileManager
{
    public class FileManager : IFileManager
    {
        private readonly string _host;
        private readonly string _user;
        private readonly string _password;
        private readonly string _port;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly NetworkCredential _credential;

        public FileManager(string host, string user, string password, string port, IWebHostEnvironment webHostEnvironment)
        {
            _host = host;
            _user = user;
            _password = password;
            _port = port;
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

        public string UploadFileToFtp()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Credentials = _credential;
                    client.UploadFile("ftp://127.0.0.1:21/testfile.txt", "D:\\Repozytoria\\DietMealApp\\DietMealApp\\testfile.txt");
                }

                return "OKI";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                if (e.InnerException != null)
                {
                    Console.WriteLine(e.InnerException);
                }
                return "";
            }
        }
    }
}
