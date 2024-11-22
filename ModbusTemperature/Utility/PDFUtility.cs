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
            int _i = 2;
            string[] fileNames = saveFileName.Split("/");
            while (File.Exists(saveFileName))
            {
                saveFileName = fileNames[fileNames.Length-1] + "-" + _i + ".pdf";
                _i = _i + 1;
            }
            using (MemoryStream ms = new MemoryStream())
            {
                string savePdfPath = saveFileName;
                var pdfWriter = new PdfWriter(ms);
                var pdfDoc = new PdfDocument(pdfWriter);
                ImageData _imgData = ImageDataFactory.Create(sourceImgPaths[0]);
                iText.Layout.Element.Image _img = new iText.Layout.Element.Image(_imgData);
                var doc = new Document(pdfDoc, new iText.Kernel.Geom.PageSize(_img.GetImageWidth(),_img.GetImageHeight()));
                for (int i=0;i<sourceImgPaths.Length;i++)
                {
                    ImageData imgData = ImageDataFactory.Create(sourceImgPaths[i]);
                    iText.Layout.Element.Image img = new iText.Layout.Element.Image(imgData);
                    pdfDoc.AddNewPage(new iText.Kernel.Geom.PageSize(img.GetImageWidth(), img.GetImageHeight()));
                    img.SetFixedPosition(i + 1, 0, 0);
                    //                    img.SetRotationAngle(270);
                    doc.Add(img);
                }
                doc.Close();
                byte[] pdfRes = ms.ToArray();
                File.WriteAllBytes(savePdfPath, pdfRes);
            }
        }
    }
}