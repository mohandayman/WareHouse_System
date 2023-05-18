using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WareHouse_Project
{
    public partial class UpdateVendorForm : Form
    {
        CompunyDBContext c;
        public UpdateVendorForm()
        {
            InitializeComponent();
            c = new CompunyDBContext();
            textBox1.Text = VendorForm.SelctedVendor.Name;
            textBox2.Text = VendorForm.SelctedVendor.Phone;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" )

            {
              
                VendorForm.SelctedVendor.Fax =int.Parse( textBox3.Text);
                VendorForm.SelctedVendor.MobilePhone = textBox4.Text;
                VendorForm.SelctedVendor.Mail = textBox5.Text;
                VendorForm.SelctedVendor.Website =textBox6.Text;
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
