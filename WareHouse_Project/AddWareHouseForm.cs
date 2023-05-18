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
    public partial class AddWareHouseForm : Form
    {
        WareHouse InsertedWareHouse;
        CompunyDBContext c;
        public AddWareHouseForm()
        {
            InitializeComponent();
           c = new CompunyDBContext();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                var IsLocate = c.wareHouses.FirstOrDefault(w => w.WareHouseName == textBox1.Text);
                if (IsLocate is null)
                {
                    InsertedWareHouse = new WareHouse() {WareHouseName = textBox1.Text , WareHouseAddress = textBox2.Text, MangerName = textBox3.Text };
                    c.wareHouses.Add(InsertedWareHouse);
                    c.SaveChanges();
                    MessageBox.Show("The Data Inserted Succesfully");
                    this.DialogResult = DialogResult.OK;
                    this.Close();

                } else
                {
                    MessageBox.Show("The Data You Have Write Inserted Before");
                }
            }
            else
            {
                MessageBox.Show("Please Fill All The Data");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult= DialogResult.Cancel;
        }
    }
}
