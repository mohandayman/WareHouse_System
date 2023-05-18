using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WareHouse_Project
{
    public partial class TransferCategoriesForm : Form
    {
        CompunyDBContext c;

        public TransferCategoriesForm()
        {
            InitializeComponent();
               c=new CompunyDBContext();
            addVendorsToList();
            addWareHouseToList();
            addCategoriesToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            DateTime parsedproduction = new DateTime(int.Parse(textBox6.Text), int.Parse(comboBox2.Text), int.Parse(comboBox1.Text));
            DateTime parsedExpirationDate = new DateTime(int.Parse(textBox7.Text), int.Parse(comboBox3.Text), int.Parse(comboBox4.Text));


            Methods.DismissalOrder(c.Categories.FirstOrDefault(c=>c.Name == comboBox7.Text).Code,comboBox6.Text,
               int.Parse(textBox3.Text), comboBox5.Text,c.Vendors.FirstOrDefault(c=>c.Name== comboBox5.Text).Phone);//from

            Methods.SupplyOrder(c.Categories.FirstOrDefault(c => c.Name == comboBox7.Text).Code, comboBox8.Text,
             int.Parse(textBox3.Text), comboBox5.Text, c.Vendors.FirstOrDefault(c => c.Name == comboBox5.Text).Phone, 
             parsedExpirationDate, parsedproduction);  //To

            MessageBox.Show("Successfully");

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
            comboBox6.Items.Clear();
            comboBox8.Items.Clear();
            
            foreach (WareHouse w in c.wareHouses)
            {
                comboBox6.Items.Add(w.WareHouseName);
                comboBox8.Items.Add(w.WareHouseName);
            }
        }
        void addCategoriesToList()

        {
            comboBox7.Items.Clear();
            foreach (Category ca in c.Categories)
            {
                comboBox7.Items.Add(ca.Name);
            }
        }
    }
}
