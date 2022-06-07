using DietMealApp.Application.Commons.Services.FileManager;
using Microsoft.AspNetCore.Hosting;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Application.Commons.Services
{
    public class PdfGenerator : IPdfGenerator
    {
        private readonly IFileManager _fileManager;

        public PdfGenerator(IFileManager fileManager)
        {
            _fileManager = fileManager;
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
            PdfDocument document = htmlConverter.Convert("http://localhost:50727/Shopping/Create/");

            //Save the document into stream.
            MemoryStream stream = new MemoryStream();

            document.Save(stream);

            stream.Position = 0;

            //Close the document.
            document.Close(true);

            //Defining the ContentType for pdf file.
            string contentType = "application/pdf";

            //Define the file name.
            string fileName = " Sample.pdf";

            //Creates a FileContentResult object by using the file contents, content type, and file name.
            return (stream, contentType, fileName);
        }

    }
}
