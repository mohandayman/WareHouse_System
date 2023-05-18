using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using WareHouse_Project.Migrations;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WareHouse_Project
{
    public partial class AddSupplyPermissionForm : Form
    {
        CompunyDBContext c;
        public AddSupplyPermissionForm()
        {
            InitializeComponent();
            c = new CompunyDBContext();
            addVendorsToList();
            addWareHouseToList();
            addCategoriesToList();



        }

        void addVendorsToList()
        {
            comboBox5.Items.Clear();
           foreach(Person.Vendor v in c.Vendors)
            {
                comboBox5.Items.Add(v.Name);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (comboBox6.Text != "" && comboBox7.Text != "" && textBox3.Text != "" && comboBox5.Text != ""&& textBox6.Text != "" &&
                textBox7.Text != "") {

                try
                {

                    DateTime parsedproduction = new DateTime(int.Parse(textBox6.Text), int.Parse(comboBox2.Text), int.Parse(comboBox1.Text));
                    DateTime parsedExpirationDate = new DateTime(int.Parse(textBox7.Text), int.Parse(comboBox4.Text), int.Parse(comboBox3.Text));
                    var newSupplyPermission = new SupplyPermission()
                    {
                        Date = DateTime.Now,
                        WareHousesName = comboBox6.Text,
                        CategoryCode = c.Categories.FirstOrDefault(c => c.Name == comboBox7.Text).Code,
                        Amount = int.Parse(textBox3.Text),
                        VendorName = comboBox5.Text,
                        VendorPhone = c.Vendors.FirstOrDefault(c => c.Name == comboBox5.Text).Phone,
                        ProductionDate = parsedproduction,
                        ExpiratoinDate = parsedExpirationDate


                    };
                    c.supplyPermissions.Add(newSupplyPermission);
                    c.SaveChanges();
                    MessageBox.Show("Data Added SuccessFully");
                    this.DialogResult = DialogResult.OK;
                    this.Close();

                }
                catch(Exception ex) { MessageBox.Show("Enter Valid Data"); }
            }else
            {
                MessageBox.Show("Please Fill All Data");
            }
        }
        void addWareHouseToList()

        {
            comboBox5.Items.Clear();
            foreach (WareHouse w in c.wareHouses)
            {
                comboBox6.Items.Add(w.WareHouseName);
            }
        }
        void addCategoriesToList()

        {
            comboBox7.Items.Clear();
            foreach (Category ca in c.Categories)
            {
                comboBox6.Items.Add(ca.Name);
            }
        }
    }
}
