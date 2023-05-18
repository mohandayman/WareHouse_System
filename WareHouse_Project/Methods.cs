using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using WareHouse_Project.Migrations;

namespace WareHouse_Project
{
   
    public static class Methods
    {
        public static void SupplyOrder(int CategoryCode, String warehouseName, int amount, string vendorName , string vendorphone  , DateTime ExpiratoinDate, DateTime ProductionDate )
        {
            CompunyDBContext c = new CompunyDBContext();
            SupplyPermission s = new SupplyPermission()
            {
                VendorName = vendorName,
                CategoryCode = CategoryCode,
                WareHousesName = warehouseName,
                Amount = amount,
                Date = DateTime.Now,
                VendorPhone = vendorphone,
                ExpiratoinDate = ExpiratoinDate, 
                ProductionDate = ProductionDate 
            };
            c.supplyPermissions.Add( s );
            c.SaveChanges();



        }
        public static void DismissalOrder(int CategoryCode, String warehouseName, int amount, string VendorName, string VendorPhone)
        {
            CompunyDBContext c = new CompunyDBContext();
            DismissalNotice s = new DismissalNotice()
            {
                VendorName = VendorName,
                Date = DateTime.Now,
                CategoryCode = CategoryCode,
                WareHousesName = warehouseName,
                Amount = -1 * amount,
                VendorPhone = VendorPhone
            };
            c.dismissalNotices.Add(s);
            c.SaveChanges();


        }
    }
}
