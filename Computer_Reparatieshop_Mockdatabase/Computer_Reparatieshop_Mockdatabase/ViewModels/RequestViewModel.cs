using Computer_Reparatieshop_Mockdatabase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Computer_Reparatieshop_Mockdatabase.ViewModels
{
    public class RequestViewModel
    {
        public string Id { get; set; }
        public ModelClientRequest basemodel { get; set; }

        [Display(Name = "opgeslagen foto")]
        public HttpPostedFileBase StoredImage { get; set; }


    }
}