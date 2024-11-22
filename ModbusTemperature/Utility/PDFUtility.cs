using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusTemperature.Utility
{
    public static class PDFUtility
    {
        public static void ImageToPdf(string sourceImgPath, string saveFileName)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                string savePdfPath = System.IO.Path.Combine(AppContext.BaseDirectory, saveFileName);
                var pdfWriter = new PdfWriter(ms);
                var pdfDoc = new PdfDocument(pdfWriter);
                var doc = new Document(pdfDoc);
                ImageData imgData = ImageDataFactory.Create(sourceImgPath);
                iText.Layout.Element.Image img = new iText.Layout.Element.Image(imgData);
                doc.Add(img);
                doc.Close();
                byte[] pdfRes = ms.ToArray();
                File.WriteAllBytes(savePdfPath, pdfRes);
            }
        }
        public static void MasterModelToPDF(string[] sourceImgPaths, string saveFileName)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                string savePdfPath = System.IO.Path.Combine(AppContext.BaseDirectory, saveFileName);
                var pdfWriter = new PdfWriter(ms);
                var pdfDoc = new PdfDocument(pdfWriter);
                var doc = new Document(pdfDoc);
                foreach (var sourceImgPath in sourceImgPaths)
                {
                    ImageData imgData = ImageDataFactory.Create(sourceImgPath);
                    iText.Layout.Element.Image img = new iText.Layout.Element.Image(imgData);
                    doc.Add(img);
                }
                doc.Close();
                byte[] pdfRes = ms.ToArray();
                File.WriteAllBytes(savePdfPath, pdfRes);
            }
        }
    }
}