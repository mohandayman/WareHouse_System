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
    public partial class AddCustomerForm : Form
    {
        CompunyDBContext c;
        Customer insertedCustomer;
        public AddCustomerForm()
        {
            InitializeComponent();
            c = new CompunyDBContext();

        }

        private void AddCustomerForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                var IsLocate = c.customers.FirstOrDefault(c => c.Name == textBox1.Text && c.Phone == textBox2.Text);
                if (IsLocate is null)
                {
                    insertedCustomer = new Customer()
                    {
                        Name = textBox1.Text,
                        Phone = textBox2.Text,
                        Fax = int.Parse(textBox3.Text),
                        MobilePhone = textBox4.Text
                        ,
                        Mail = textBox5.Text,
                        Website = textBox6.Text
                    };
                    c.customers.Add(insertedCustomer);
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
    }
}
