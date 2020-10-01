using Computer_Reparatieshop_Mockdatabase.DAL;
using Computer_Reparatieshop_Mockdatabase.SingletonData;
using Computer_Reparatieshop_Mockdatabase.ViewModels;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Computer_Reparatieshop_Mockdatabase.Controllers
{
    public class DoneController : Controller
    {
        // GET: Done
        public ActionResult Index()
        {
            if (SingletonData.Singleton.StoreReparationDoneInitialized == false)
            {
                SingletonData.Singleton.StoreReparationDone = new MockDataServiceReparationDone();
                SingletonData.Singleton.StoreReparationDoneInitialized = true;
            }

            foreach (var item in SingletonData.Singleton.StoreReparationDone.ReturnList())
            {
                item.basemodel.Totaal = item.basemodel.PrijsArbeid + item.basemodel.PrijsProducten;
            }
            return View(SingletonData.Singleton.StoreReparationDone.ReturnList());
        }

        // GET: Done/Details/5

        public ActionResult Print(string id)
        {
      

            var modeltoprint = Singleton.StoreReparationDone.items.Where(x => x.id == id).FirstOrDefault();
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("host.pdf", FileMode.Create));
            doc.Open();
            string storestring1 ="Klant: " + modeltoprint.basemodel.Klant + "@" + "omchrijving: " + modeltoprint.basemodel.Omschrijving + "@" + "Prijs arbeid: " + modeltoprint.basemodel.PrijsArbeid + "@"+ "Prijs producten: " +  modeltoprint.basemodel.PrijsProducten + "@" + "Reperateur: " + modeltoprint.basemodel.Reparateur + "@" +"Totaal Prijs" + modeltoprint.basemodel.Totaal + "@" +"Onderelen: "+modeltoprint.onderdelen;
            string addnewlines1 = storestring1.Replace("@", Environment.NewLine);
            Paragraph paragraph = new Paragraph(addnewlines1);
            paragraph.IndentationRight = 100;
            paragraph.IndentationLeft = 100;
            doc.Add(paragraph);
            doc.Close();
            var pathpdffile = Path.GetFullPath("host.pdf");
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo()
            {
                CreateNoWindow = false,
                Verb = "print",
                FileName = pathpdffile

            };
            p.Start();

            return RedirectToAction("Index");
        }
        public ActionResult Details(string id)
        {
            if (SingletonData.Singleton.StoreReparationDoneInitialized == false)
            {
                SingletonData.Singleton.StoreReparationDone = new MockDataServiceReparationDone();
                SingletonData.Singleton.StoreReparationDoneInitialized = true;
            }

            foreach (var item in SingletonData.Singleton.StoreReparationDone.ReturnList())
            {
                item.basemodel.Totaal = item.basemodel.PrijsArbeid + item.basemodel.PrijsProducten;
            }
            return View(SingletonData.Singleton.StoreReparationDone.items.Where(x => x.id == id).FirstOrDefault());
        }

        // GET: Done/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Done/Create
        [HttpPost]
        public ActionResult Create(DoneViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                if (SingletonData.Singleton.StoreReparationDoneInitialized == false)
                {
                    SingletonData.Singleton.StoreReparationDone = new MockDataServiceReparationDone();
                    SingletonData.Singleton.StoreReparationDoneInitialized = true;
                }

                foreach (var item in SingletonData.Singleton.StoreReparationDone.ReturnList())
                {
                    item.basemodel.Totaal = item.basemodel.PrijsArbeid + item.basemodel.PrijsProducten;
                }

                SingletonData.Singleton.StoreReparationDone.AddItem(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
