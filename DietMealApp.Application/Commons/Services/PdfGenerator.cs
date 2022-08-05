using DietMealApp.Application.Commons.Services.FileManager;
using DietMealApp.Core.DTO.Menu;
using DietMealApp.Core.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Drawing;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace DietMealApp.Application.Commons.Services
{
    public class PdfGenerator : IPdfGenerator
    {
        private readonly IFileManager _fileManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PdfGenerator(IFileManager fileManager, IWebHostEnvironment webHostEnvironment)
        {
            _fileManager = fileManager;
            _webHostEnvironment = webHostEnvironment;

            if (string.IsNullOrWhiteSpace(_webHostEnvironment.WebRootPath))
            {
                _webHostEnvironment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            }
        }

        public MemoryStream CreateTablePDF<T>(List<T> listOfElements)
        {

            //Generate a new PDF document.
            PdfDocument doc = new PdfDocument();
            //Add a page.
            PdfPage page = doc.Pages.Add();
            //Create a PdfGrid.
            PdfGrid pdfGrid = new PdfGrid();
            Stream fontStream = File.OpenRead(Path.Combine(_webHostEnvironment.WebRootPath, "fonts/TanoheSans-Regular.ttf"));
            PdfTrueTypeFont tfont = new PdfTrueTypeFont(fontStream, 12, PdfFontStyle.Regular);

            //Add list to IEnumerable
            IEnumerable<T> dataTable = listOfElements;
            //Assign data source.
            pdfGrid.DataSource = dataTable;
            pdfGrid.Style.Font = tfont;
            //Draw grid to the page of PDF document.
            pdfGrid.Draw(page, new Syncfusion.Drawing.PointF(10, 10));
            //Write the PDF document to stream
            MemoryStream stream = new MemoryStream();
            doc.Save(stream);
            //If the position is not set to '0' then the PDF will be empty.
            stream.Position = 0;
            //Close the document.
            doc.Close(true);
            return stream;
        }

        public (MemoryStream, string) GenerateMenu(List<MenuDay> menu)
        {

            //Generate a new PDF document.
            PdfDocument doc = new PdfDocument();
            //Add a page.
            PdfPage page = doc.Pages.Add();
            //Create a PdfGrid.
            PdfGrid pdfGrid = new PdfGrid();
            Stream fontStream = File.OpenRead(Path.Combine(_webHostEnvironment.WebRootPath, "fonts/TanoheSans-Regular.ttf"));
            PdfTrueTypeFont tfont = new PdfTrueTypeFont(fontStream, 12, PdfFontStyle.Regular);

            //Add list to IEnumerable
            IEnumerable<MenuDay> dataTable = menu;
            //Assign data source.
            pdfGrid.DataSource = dataTable;
            pdfGrid.Headers.Clear();
            pdfGrid.Style.Font = tfont;
            //Draw grid to the page of PDF document.
            pdfGrid.Draw(page, new Syncfusion.Drawing.PointF(10, 10));
            //Write the PDF document to stream
            MemoryStream stream = new MemoryStream();
            doc.Save(stream);
            //If the position is not set to '0' then the PDF will be empty.
            stream.Position = 0;
            //Close the document.
            doc.Close(true);
            return (stream, "Menu.pdf");
        }

        public (MemoryStream, string, string) Generate()
        {
            //Initialize HTML converter with WebKit rendering engine
            HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

            WebKitConverterSettings settings = new WebKitConverterSettings();

            //Set WebKit path
            settings.WebKitPath = @"C:\Users\kris2\.nuget\packages\syncfusion.htmltopdfconverter.qtwebkit.net.core\20.1.0.59\lib\QtBinariesWindows\";

            //Disable JavaScript; By default - true
            settings.EnableJavaScript = true;
            settings.EnableHyperLink = false;
            settings.AdditionalDelay = 3000;
            settings.Cookies.Add("MealAppCookie", "CfDJ8GLoyb4h3UlCsI_z0ZVNoTzLCCufSms1s0G1WKjnx7kr9V9JBkpA0EPphlPlrXSJGuQfXSBBCyEJe01-kxZWbISes6rfDT87faXHcylVEg0eCmLBIlfk2MA1-fsljo-GYAJJ6FsxP9cacGb3w7q4luaTi7AT68BDwJT4od8HVR8kLcc8E6SiaTMWvOmCfNAeQ1oqx56qOOsQjLqBg0ofV1su2Pb3PTO3KiHV410QsVJ1KJTc_NIiVQuRq6UUjl_nZZ8aUvFZiZtL4BgTjhsF2J_TmjBYlp-l3LvYlPPmV-2NoM6pnlWZHYbZk2aFzzJEyTO5CdLVboRSOzhJON-bo8tsa3qv-I-fgr8XSubT6mdz5mXAhBb2eNNgwG63JbqN5RUt431GvOfMMG0r_ZoMu1ebTwjvClq_K-J4pfb1mh8rHa5oJI55DEdhRFk6M-Q2EJMN0IxtMTDMZt-_IoBksqaWkqMO0zA7OkPBLNxt1bI7fTh1tmQC4vMem4zMN5SMGTWF5Bc-qQTu1Jy50F7rFC_84rZotXf_B5jZlQJnc9nYbfv8BZWYJ8Mks_ThMnjOGR9lS-fHPtjmiNaRfOdJk5PBncKqfjDSjoll9DkccR5g9TsFMQ4kx38kv-MW7YwU2WiXhSLboEeYe-w-B9fwQ6MSqTs0QmdcaStSc-D43ETMcTJ2NfXkMtbPmjEG-_8vvgKUyZLpfJGNl1y-kg5MlYAnErHgYH5FZUQ0jp7cRWQB");
            //settings.Cookies.Add("CookieName2", " CookieValue2");

            //Assign WebKit settings to HTML converter
            htmlConverter.ConverterSettings = settings;

            //Convert URL to PDF
            PdfDocument document = htmlConverter.ConvertPartialHtml("http://localhost:50727/Shopping/Create/", "shoppingList");

            //Save the document into stream.
            MemoryStream stream = new MemoryStream();

            document.Save(stream);

            stream.Position = 0;

            //Close the document.
            document.Close(true);

            //Defining the ContentType for pdf file.
            string contentType = "application/pdf";

            //Define the file name.
            string fileName = "Sample.pdf";

            //Creates a FileContentResult object by using the file contents, content type, and file name.
            return (stream, contentType, fileName);
        }

        async void Save(Stream stream, string filename)

        {

            stream.Position = 0;

            FileSavePicker savePicker = new FileSavePicker();

            savePicker.DefaultFileExtension = ".pdf";

            savePicker.SuggestedFileName = "Sample";

            savePicker.FileTypeChoices.Add("Adobe PDF Document", new List<string>() { ".pdf" });

            StorageFile stFile = await savePicker.PickSaveFileAsync();

            if (stFile != null)

            {

                Windows.Storage.Streams.IRandomAccessStream fileStream = await stFile.OpenAsync(FileAccessMode.ReadWrite);

                Stream stream1 = fileStream.AsStreamForWrite();

                stream1.SetLength(0);

                stream1.Write((stream as MemoryStream).ToArray(), 0, (int)stream.Length);

                stream1.Flush();

                stream1.Dispose();

                fileStream.Dispose();

            }

        }

    }
}
