using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using static WareHouse_Project.Person;
using System.Reflection.Emit;


namespace WareHouse_Project
{
    internal class CompunyDBContext : DbContext
    {
        public CompunyDBContext() : base("Data Source=DESKTOP-8TSELJH\\SQLSERVER2017;Initial Catalog=Compuny;Integrated Security=True;") { }
    public DbSet<WareHouse> wareHouses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet <SupplyPermission> supplyPermissions { get; set; }
        public DbSet<DismissalNotice> dismissalNotices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasKey(c => new { c.Name, c.Phone });
            modelBuilder.Entity<Vendor>()
              .HasKey(c => new { c.Name, c.Phone });



            // table supply 
          
        }
    }

}
