using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse_Project
{
    public class WareHouse
    {
        [Key , MaxLength(200)]
        public string WareHouseName { get; set; }
        [Required]
        public  string   WareHouseAddress { get; set; }

        [Required]
        public string MangerName { get; set; }

        public virtual ICollection<SupplyPermission> SupplyPermissions { get; set; }





    }
}
