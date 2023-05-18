using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WareHouse_Project
{
   public abstract class Person
    {
        [Key]
        [Column(Order = 1)]
        public string Name { get; set; }
        [Key]
        [Column(Order = 2)]

        public string Phone { get; set; }
        [Required]
            public int Fax { get; set; }

            public string MobilePhone { get; set; }
            public string Mail { get; set; }
            public string Website { get; set; }
     
        public Person() { }
        public Person(string Name , String phone , int Fax )
        {
            this.Name = Name;
            this.Phone = phone;
            this.Fax = Fax;

        }
        public Person(string Name, String phone, int Fax  , string mobilephone  , string mail , String website)
        {
            this.Name = Name;
            this.Phone = phone;
            this.Fax = Fax;
            this.MobilePhone = mobilephone;
            this.Mail = mail;   
            this.Website = website;

        }
     
        public class Customer : Person
        {
          public  Customer() :base() { }
            public Customer(string Name, String phone, int Fax) :base(Name , phone , Fax) { }
            public Customer(string Name, String phone, int Fax, string mobilephone, string mail, String website) 
                : base(Name, phone, Fax, mobilephone  , mail , website) { }


        }
        public class Vendor : Person
        {
           public Vendor() { }
            public Vendor(string Name, String phone, int Fax) : base(Name, phone, Fax) { }
            public Vendor(string Name, String phone, int Fax, string mobilephone, string mail, String website)
                : base(Name, phone, Fax, mobilephone, mail, website) { }


        }


    }
}
