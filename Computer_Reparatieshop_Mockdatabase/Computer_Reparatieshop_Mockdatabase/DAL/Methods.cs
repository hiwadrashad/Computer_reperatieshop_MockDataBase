using Computer_Reparatieshop_Mockdatabase.SingletonData;
using Computer_Reparatieshop_Mockdatabase.ViewModels;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Web;

namespace Computer_Reparatieshop_Mockdatabase.DAL
{
    public class Parent
    {
        public virtual void ExecutePrinting(string id)
        { }

        public virtual OverviewViewmodel CountStatus()
        {
            OverviewViewmodel overview = new OverviewViewmodel();
            return overview; 
        }

        public virtual string ConvertHttpPostfilebaseto64bytearray(string id)
        {
            return "Parent Structure";
        }



    }

    public interface Iprinting
    {
      void ExecutePrinting(string id);
    }

    public interface IOverview
    {
        OverviewViewmodel CountStatus();
    }

    public interface IImageprocessing
    {
        string ConvertHttpPostfilebaseto64bytearray(string id);
    }

    public class Factory
    {
        public Print print = new Print();

        public Overview overview = new Overview();

        public ImageProcessing imageProcessing = new ImageProcessing();
    
    }
    public class Print : Parent, Iprinting
    {

       
        public override void ExecutePrinting(string id)
        {
            var modeltoprint = Singleton.StoreReparationDone.items.Where(x => x.id == id).FirstOrDefault();
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("host.pdf", FileMode.Create));
            doc.Open();
            string storestring1 = "Klant: " + modeltoprint.basemodel.Klant + "@" + "omchrijving: " + modeltoprint.basemodel.Omschrijving + "@" + "Prijs arbeid: " + modeltoprint.basemodel.PrijsArbeid + "@" + "Prijs producten: " + modeltoprint.basemodel.PrijsProducten + "@" + "Reperateur: " + modeltoprint.basemodel.Reparateur + "@" + "Totaal Prijs" + modeltoprint.basemodel.Totaal + "@" + "Onderelen: " + modeltoprint.onderdelen;
            string addnewlines1 = storestring1.Replace("@", Environment.NewLine);
            Paragraph paragraph = new Paragraph(addnewlines1);
            paragraph.IndentationRight = 100;
            paragraph.IndentationLeft = 100;
            doc.Add(paragraph);
            doc.Close();
            var pathpdffile = Path.GetFullPath("host.pdf");
            PdfDocument pdfDocument = new PdfDocument();
            PrintDocument print = new PrintDocument();
            ProcessStartInfo info = new ProcessStartInfo(pathpdffile);
            info.FileName = pathpdffile;
            Process.Start(info);
          
        }
    }

    public class Overview : Parent, IOverview
    {
        public override OverviewViewmodel CountStatus()
        {
            OverviewViewmodel countbar = new OverviewViewmodel();
            foreach (var item in SingletonData.Singleton.StoreReparationInProgress.ReturnList().Where(x => x.status.Value == "in afwachting"))
            {
                countbar.aantalinafwachting = countbar.aantalinafwachting + 1;
            }
            foreach (var item in SingletonData.Singleton.StoreReparationInProgress.ReturnList().Where(x => x.status.Value == "wachten op onderdelen"))
            {
                countbar.aantalwachtoponderdelen = countbar.aantalwachtoponderdelen + 1;
            }
            foreach (var item in SingletonData.Singleton.StoreReparationInProgress.ReturnList().Where(x => x.status.Value == "in behandeling"))
            {
                countbar.aantalinbehandeling = countbar.aantalinbehandeling + 1;
            }
            foreach (var item in SingletonData.Singleton.StoreReparationInProgress.ReturnList().Where(x => x.status.Value == "klaar"))
            {
                countbar.aantaalklaar = countbar.aantaalklaar + 1;
            }

            return countbar;
        }
    
    }

    public class ImageProcessing : Parent, IImageprocessing
    {
        public override string ConvertHttpPostfilebaseto64bytearray(string id)
        {
            var model = Singleton.StoreClientRequest.GetItem(id);
            MemoryStream target = new MemoryStream();
            model.StoredImage.InputStream.CopyTo(target);
            byte[] data = target.ToArray();
            var base64 = Convert.ToBase64String(data);
            var imgSrc = String.Format("data:image/gif;base64,{0}", base64);
            return imgSrc;
        }
    }
}