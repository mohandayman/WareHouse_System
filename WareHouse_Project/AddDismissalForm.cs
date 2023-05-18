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
    
    public partial class AddDismissalForm : Form
    {
        CompunyDBContext c;
        public AddDismissalForm()
        {
            InitializeComponent();
            c = new CompunyDBContext();
            AddVendorToLIst();
            addWareHouseToList();
            addCategoriesToList();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && textBox1.Text != "" && comboBox3.Text != "" && comboBox2.Text != "")
            {
                try
                {
                    var newDismissalNotice = new DismissalNotice()
                    {
                        Date = DateTime.Now,
                        WareHousesName = comboBox1.Text,
                        CategoryCode = c.Categories.FirstOrDefault(c => c.Name == comboBox2.Text).Code,
                        Amount = -1 * int.Parse(textBox1.Text),
                        VendorName = comboBox3.Text,
                        VendorPhone = c.Vendors.FirstOrDefault(c => c.Name == comboBox3.Text).Phone,
                    };
                    c.dismissalNotices.Add(newDismissalNotice);
                    c.SaveChanges();
                    MessageBox.Show("Data Added SuccessFully");
                    this.DialogResult = DialogResult.OK;
                    this.Close();

                }
                catch (Exception ex) { MessageBox.Show("Enter Valid Data"); }
            }
            else
            {
                MessageBox.Show("Please Fill All Data");
            }
        }

        void AddVendorToLIst()

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

    }
}
