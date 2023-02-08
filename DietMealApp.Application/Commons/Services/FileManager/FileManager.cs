
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using DietMealApp.Core.Enums;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

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
        public async Task<(string, string)> SendFileToFtp(IFormFile file, ImageType imageType)
        {
            switch (imageType)
            {
                case ImageType.Product:
                    return await UploadFile(file, LocalPathsRepository.LocalProductFull, FtpPathsRepository.FtpProductFull, LocalPathsRepository.LocalProduct150x150, FtpPathsRepository.FtpProduct150x150);
                case ImageType.Meal:
                    return await UploadFile(file, LocalPathsRepository.LocalMealFull, FtpPathsRepository.FtpMealFull, LocalPathsRepository.LocalMeal150x150, FtpPathsRepository.FtpMeal150x150);
                default:
                    return await UploadFile(file, LocalPathsRepository.LocalGlobalFull, FtpPathsRepository.FtpGlobalFull, LocalPathsRepository.LocalGlobal150x150, FtpPathsRepository.FtpGlobal150x150);
            }
        }

        public async Task<string> SendFileToFtp(MemoryStream file)
        {
            return await UploadFile(file, LocalPathsRepository.LocalShoppingList, FtpPathsRepository.FtpShoppingLists);
        }
        public string SaveFile(string directoryFrom, string ftpDirectoryTo, string fileName)
        {
            try
            {
                var ftpFilePath = UploadFileToFtp(directoryFrom, ftpDirectoryTo, fileName);
                return ftpFilePath;
            }
            catch (Exception e)
            {
                return "";
            }
            finally
            {
                DeleteLocalFile(Path.Combine(directoryFrom, fileName));
            }
        }

        public bool DeleteLocalFiles(string[] fullPaths)
        {
            try
            {
                foreach (string fullPath in fullPaths)
                {
                    if (File.Exists(fullPath))
                    {
                        File.Delete(fullPath);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private async Task<(string, string)> UploadFile(IFormFile file, string localFullPath, string ftpFullPath, string local150x150path, string ftp150x150path)
        {
            string fileName = GenerateNewFileName(file.FileName);

            var localPath = await UploadFileLocal(file, Path.Combine(_webHostEnvironment.WebRootPath, localFullPath), fileName);

            var ftpPath = UploadFileToFtp(localPath, ftpFullPath, fileName);

            var localPathResizedImg = Path.Combine(_webHostEnvironment.WebRootPath, local150x150path);
            CheckIfLocationExists(localPathResizedImg);

            var localFullPathResizedImg = ResizeImage(localPath, Path.Combine(localPathResizedImg, fileName), 150, 150);

            var ftpResizedPath = UploadFileToFtp(localFullPathResizedImg, ftp150x150path, fileName);

            DeleteLocalFiles(new string[] { localPath, localFullPathResizedImg });

            return (ftpPath, ftpResizedPath);
        }

        private async Task<string> UploadFile(MemoryStream file, string localFullPath, string ftpFullPath)
        {
            string fileName = "Test.pdf";

            var localPath = await UploadFileLocal(file, Path.Combine(_webHostEnvironment.WebRootPath, localFullPath), fileName);
            CheckIfLocationExists(localPath);

            var ftpPath = UploadFileToFtp(localPath, ftpFullPath, fileName);

            DeleteLocalFiles(new string[] { localPath });

            return ftpPath;
        }

        private void CheckIfLocationExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private string UploadFileToFtp(string dirFrom, string dirTo, string fileName)
        {
            string to = $"ftp://{_host}/dietmealapp.cba.pl/{dirTo}/{fileName}";

            try
            {
                using (var client = new WebClient())
                {
                    client.Credentials = _credential;
                    client.UploadFile(to, WebRequestMethods.Ftp.UploadFile, dirFrom);
                }
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
            return $"http://{_host}/{dirTo}/{fileName}";
        }

        //private async Task<string> ResizedFileToFtp(Image img, string directoryTo)
        //{
        //    string fileName = GenerateNewFileName(img.);
        //    string fileFtpPath = $"ftp://{_host}/dietmealapp.cba.pl/{directoryTo}/{fileName}";
        //    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(fileFtpPath);
        //    request.Credentials = _credential;
        //    request.Method = WebRequestMethods.Ftp.UploadFile;

        //    try
        //    {
        //        using Stream ftpStream = await request.GetRequestStreamAsync();
        //        file.CopyTo(ftpStream);
        //    }
        //    catch (Exception e)
        //    {

        //        throw;
        //    }
        //    return $"http://{_host}/{directoryTo}/{fileName}";
        //}

        public string GenerateNewFileName(string fileName)
        {
            var extension = Path.GetExtension(fileName);
            fileName = Guid.NewGuid().ToString() + extension;
            return fileName;
        }

        private string ResizeImage(string directoryFrom, string pathTo, int width, int height)
        {
            var image = Image.Load(directoryFrom);
            image.Mutate(c => c.Resize(width, height));
            image.Save(pathTo);
            return pathTo;
        }

        private string ResizeImage(Image image, string pathTo, int width, int height)
        {
            image.Mutate(c => c.Resize(width, height));
            image.Save(pathTo);
            return pathTo;
        }

        private async Task<string> UploadFileLocal(IFormFile file, string directoryTo, string fileName)
        {
            var fullFilePath = Path.Combine(directoryTo, fileName);

            if (!Directory.Exists(directoryTo))
            {
                Directory.CreateDirectory(directoryTo);
            }

            try
            {
                using (var fileStream = new FileStream(fullFilePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                return $"{e.Message}";
            }
            return fullFilePath;
        }

        private async Task<string> UploadFileLocal(MemoryStream file, string directoryTo, string fileName)
        {
            var fullFilePath = Path.Combine(directoryTo, fileName);

            if (!Directory.Exists(directoryTo))
            {
                Directory.CreateDirectory(directoryTo);
            }

            try
            {
                using (var fileStream = new FileStream(fullFilePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                return $"{e.Message}";
            }
            return fullFilePath;
        }

        private bool DeleteLocalFile(string fullPath)
        {
            try
            {
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}