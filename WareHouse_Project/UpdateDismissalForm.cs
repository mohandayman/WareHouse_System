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
    public partial class UpdateDismissalForm : Form
    {
        CompunyDBContext c;

        public UpdateDismissalForm()
        {
            InitializeComponent();
            c = new CompunyDBContext();
            textBox1.Text = DismissalForm.SelectedDismissal.Id.ToString();
            addCutomersToList();
            addWareHouseToList();
            addCategoriesToList();
        }

       
        void addCutomersToList()

        {
            comboBox3.Items.Clear();
            foreach (Person.Vendor v in c.Vendors)
            {
                comboBox3.Items.Add(v.Name);
            }
        }
        void addWareHouseToList()

        {
            comboBox1.Items.Clear();
            foreach (WareHouse w in c.wareHouses)
            {
                comboBox1.Items.Add(w.WareHouseName);
            }
        }
        void addCategoriesToList()

        {
            comboBox2.Items.Clear();
            foreach (Category ca in c.Categories)
            {
                comboBox2.Items.Add(ca.Name);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && textBox2.Text != "" && comboBox3.Text != "" && comboBox2.Text != "")

            {
                DismissalForm.SelectedDismissal.WareHousesName = (comboBox1.Text);
                DismissalForm.SelectedDismissal.CategoryCode = c.Categories.FirstOrDefault(c => c.Name == comboBox2.Text).Code;
                DismissalForm.SelectedDismissal.Amount = int.Parse(textBox2.Text);
                DismissalForm.SelectedDismissal.VendorName = comboBox3.Text;
                DismissalForm.SelectedDismissal.VendorPhone = c.Vendors.FirstOrDefault(c => c.Name == comboBox3.Text).Phone;
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
    }
}
