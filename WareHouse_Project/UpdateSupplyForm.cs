using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WareHouse_Project
{
    public partial class UpdateSupplyForm : Form
    {
        CompunyDBContext c;
        public UpdateSupplyForm()
        {
            InitializeComponent();
            c= new CompunyDBContext();
            textBox8.Text = SupplyPermissionForm.SelctedPermission.Id.ToString();
            addVendorsToList();
            addWareHouseToList();
            addCategoriesToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox6.Text != "" && textBox3.Text != "" && comboBox5.Text != ""  && textBox6.Text != ""&&textBox7.Text != "" && comboBox1.Text!=""
                 && comboBox2.Text != "" && comboBox3.Text != "" && comboBox4.Text != "")

            {
                DateTime parsedproduction = new DateTime(int.Parse(textBox6.Text), int.Parse(comboBox2.Text), int.Parse(comboBox1.Text));
                DateTime parsedExpirationDate = new DateTime(int.Parse(textBox7.Text), int.Parse(comboBox4.Text), int.Parse(comboBox3.Text));

                SupplyPermissionForm.SelctedPermission.WareHousesName = (comboBox6.Text);
                SupplyPermissionForm.SelctedPermission.CategoryCode = c.Categories.FirstOrDefault(c => c.Name == comboBox7.Text).Code;
                SupplyPermissionForm.SelctedPermission.Amount = int.Parse(textBox3.Text);
                SupplyPermissionForm.SelctedPermission.VendorName = comboBox5.Text;
                SupplyPermissionForm.SelctedPermission.VendorPhone = c.Vendors.FirstOrDefault(c => c.Name == comboBox5.Text).Phone;
                SupplyPermissionForm.SelctedPermission.ProductionDate = parsedproduction;
                SupplyPermissionForm.SelctedPermission.ExpiratoinDate = parsedExpirationDate;


                c.SaveChanges();
                MessageBox.Show("Data Changed Succesfully");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please Fill All The Data ");
            }
        }
            void addVendorsToList()

            {
                comboBox5.Items.Clear();
                foreach (Person.Vendor v in c.Vendors)
                {
                    comboBox5.Items.Add(v.Name);
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
