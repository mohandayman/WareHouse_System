using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WareHouse_Project.Person;

namespace WareHouse_Project
{
    public class SupplyPermission
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       public  DateTime Date { get; set; }
        [ForeignKey("category")]
        public  int  CategoryCode { get; set; }
        public virtual Category category { get; set; }
        [ForeignKey("wareHouse")]

        public String WareHousesName { get; set; }
        public virtual  WareHouse wareHouse { get; set; }
        public int Amount { get; set; }

        [ForeignKey("Vendor")]
        [Column(Order = 1)]
        public string VendorName { get; set; }

        [ForeignKey("Vendor")]
        [Column(Order = 2)] 
        public string VendorPhone { get; set; }

        public virtual Vendor Vendor { get; set; }

        public DateTime ProductionDate { get; set; }


        public DateTime ExpiratoinDate { get; set; }





    }
}
