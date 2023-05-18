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
    public partial class UpdateCustomerForm : Form
    {
        CompunyDBContext c;

        public UpdateCustomerForm()
        {
            InitializeComponent();
            c = new CompunyDBContext();
            textBox1.Text = CostumerForm.SelctedCustomer.Name;
            textBox2.Text = CostumerForm.SelctedCustomer.Phone;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")

            {

                CostumerForm.SelctedCustomer.Fax = int.Parse(textBox3.Text);
                CostumerForm.SelctedCustomer.MobilePhone = textBox4.Text;
                CostumerForm.SelctedCustomer.Mail = textBox5.Text;
                CostumerForm.SelctedCustomer.Website = textBox6.Text;
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
