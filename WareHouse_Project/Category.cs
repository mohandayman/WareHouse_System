using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse_Project
{
    public class Category
    {
        [Key ]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Code { get; set; }
        [MaxLength(200),Required ]
        public string Name { get; set; }
        [MaxLength(50)]
        [Required]
        public string  unit { get; set; }

      
        public virtual ICollection<SupplyPermission> SupplyPermissions { get; set; }
    }
}
