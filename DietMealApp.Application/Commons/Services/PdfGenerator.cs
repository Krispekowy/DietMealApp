using DietMealApp.Application.Commons.Services.FileManager;
using Microsoft.AspNetCore.Hosting;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
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
        public (byte[], string) Generate()
        {
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Lista Zakupów";

            for(int p=0; p<1; p++)
            {
                // Page options
                PdfPage page = document.AddPage();
                page.Height = 842;
                page.Width = 590;

                // Get an XGraphics object for drawing
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Text format
                XStringFormat format = new XStringFormat();
                format.LineAlignment = XLineAlignment.Near;
                format.Alignment = XStringAlignment.Near;
                var tf = new XTextFormatter(gfx);
                XFont fontParagraph = new XFont("Verdana", 8, XFontStyle.Regular);

                // Row elements
                int el1_width = 80;
                int el2_width = 380;

                // page structure options
                double lineHeight = 20;
                int marginLeft = 20;
                int marginTop = 20;

                int el_height = 30;
                int rect_height = 17;

                int interLine_X_1 = 2;
                int interLine_X_2 = 2 * interLine_X_1;

                int offSetX_1 = el1_width;
                int offSetX_2 = el1_width + el2_width;

                XSolidBrush rect_style1 = new XSolidBrush(XColors.LightGray);
                XSolidBrush rect_style2 = new XSolidBrush(XColors.DarkGreen);
                XSolidBrush rect_style3 = new XSolidBrush(XColors.Red);

                for (int i = 0; i < 10; i++)
                {
                    double dist_Y = lineHeight * (i + 1);
                    double dist_Y2 = dist_Y - 2;

                    // header della G
                    if (i == 0)
                    {
                        gfx.DrawRectangle(rect_style2, marginLeft, marginTop, page.Width - 2 * marginLeft, rect_height);

                        tf.DrawString("column1", fontParagraph, XBrushes.White,
                                      new XRect(marginLeft, marginTop, el1_width, el_height), format);

                        tf.DrawString("column2", fontParagraph, XBrushes.White,
                                      new XRect(marginLeft + offSetX_1 + interLine_X_1, marginTop, el2_width, el_height), format);

                        tf.DrawString("column3", fontParagraph, XBrushes.White,
                                      new XRect(marginLeft + offSetX_2 + 2 * interLine_X_2, marginTop, el1_width, el_height), format);

                        // stampo il primo elemento insieme all'header
                        gfx.DrawRectangle(rect_style1, marginLeft, dist_Y2 + marginTop, el1_width, rect_height);
                        tf.DrawString("text1", fontParagraph, XBrushes.Black,
                                      new XRect(marginLeft, dist_Y + marginTop, el1_width, el_height), format);

                        //ELEMENT 2 - BIG 380
                        gfx.DrawRectangle(rect_style1, marginLeft + offSetX_1 + interLine_X_1, dist_Y2 + marginTop, el2_width, rect_height);
                        tf.DrawString(
                            "text2",
                            fontParagraph,
                            XBrushes.Black,
                            new XRect(marginLeft + offSetX_1 + interLine_X_1, dist_Y + marginTop, el2_width, el_height),
                            format);


                        //ELEMENT 3 - SMALL 80

                        gfx.DrawRectangle(rect_style1, marginLeft + offSetX_2 + interLine_X_2, dist_Y2 + marginTop, el1_width, rect_height);
                        tf.DrawString(
                            "text3",
                            fontParagraph,
                            XBrushes.Black,
                            new XRect(marginLeft + offSetX_2 + 2 * interLine_X_2, dist_Y + marginTop, el1_width, el_height),
                            format);


                    }
                    else
                    {

                        //if (i % 2 == 1)
                        //{
                        //  graph.DrawRectangle(TextBackgroundBrush, marginLeft, lineY - 2 + marginTop, pdfPage.Width - marginLeft - marginRight, lineHeight - 2);
                        //}

                        //ELEMENT 1 - SMALL 80
                        gfx.DrawRectangle(rect_style1, marginLeft, marginTop + dist_Y2, el1_width, rect_height);
                        tf.DrawString(

                            "text1",
                            fontParagraph,
                            XBrushes.Black,
                            new XRect(marginLeft, marginTop + dist_Y, el1_width, el_height),
                            format);

                        //ELEMENT 2 - BIG 380
                        gfx.DrawRectangle(rect_style1, marginLeft + offSetX_1 + interLine_X_1, dist_Y2 + marginTop, el2_width, rect_height);
                        tf.DrawString(
                            "text2",
                            fontParagraph,
                            XBrushes.Black,
                            new XRect(marginLeft + offSetX_1 + interLine_X_1, marginTop + dist_Y, el2_width, el_height),
                            format);


                        //ELEMENT 3 - SMALL 80

                        gfx.DrawRectangle(rect_style1, marginLeft + offSetX_2 + interLine_X_2, dist_Y2 + marginTop, el1_width, rect_height);
                        tf.DrawString(
                            "text3",
                            fontParagraph,
                            XBrushes.Black,
                            new XRect(marginLeft + offSetX_2 + 2 * interLine_X_2, marginTop + dist_Y, el1_width, el_height),
                            format);

                    }

                }


            }

            // Save the document...
            var rootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var path = Path.Combine(rootPath, LocalPathsRepository.LocalShoppingList);
            const string filename = "Lista.pdf";
            var fullPath = Path.Combine(path, filename);
            document.Save(fullPath);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
            _fileManager.DeleteLocalFiles(new string[] { fullPath });
            return (fileBytes, filename);
        }

    }
}
