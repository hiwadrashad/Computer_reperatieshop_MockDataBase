using Computer_Reparatieshop_Mockdatabase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Computer_Reparatieshop_Mockdatabase.ApplicationDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {

        }
        public DbSet<AdminModel> adminModels { get; set; }
        public DbSet<ClientModel> ClientModels { get; set; }
        public DbSet<ModelBestelling> modelBestellings { get; set; }
        public DbSet<ModelReparatie> modelReparaties { get; set; }
        public DbSet<ModelStatus> modelStatuses { get; set; }
        public DbSet<ParentModel> parentModels { get; set; }
        public DbSet<PartModel> partModels { get; set; }
        public DbSet<WerknemerModel> werknemerModels { get; set; }


    }
}