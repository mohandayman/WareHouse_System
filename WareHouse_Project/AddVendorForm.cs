using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WareHouse_Project.Person;

namespace WareHouse_Project
{
    public partial class AddVendorForm : Form
    {
        Vendor InsertedVendor;
        CompunyDBContext c;
        public AddVendorForm()
        {
            InitializeComponent();
            c = new CompunyDBContext();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != ""&& textBox5.Text != ""&& textBox6.Text != "")
            {
                var IsLocate = c.Vendors.FirstOrDefault(w => w.Name == textBox1.Text && w.Phone == textBox2.Text);
                if (IsLocate is null)
                {
                    InsertedVendor = new Vendor() { Name = textBox1.Text, Phone = textBox2.Text, Fax = int.Parse(textBox3.Text)  , MobilePhone = textBox4.Text
                        , Mail = textBox5.Text , Website = textBox6.Text};
                    c.Vendors.Add(InsertedVendor);
                    c.SaveChanges();
                    MessageBox.Show("The Data Inserted Succesfully");
                    this.DialogResult = DialogResult.OK;
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Duplicated Data");
                }
            }
            else
            {
                MessageBox.Show("Please Fill All The Data");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; this.Close();
        }
    }
}
