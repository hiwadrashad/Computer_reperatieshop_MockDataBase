using Computer_Reparatieshop_Mockdatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Computer_Reparatieshop_Mockdatabase.ViewModels
{
    public class RequestViewModel
    {
        public string Id { get; set; }
        public ModelClientRequest basemodel { get; set; }

        public HttpPostedFileBase StoredImage { get; set; }
    }
}