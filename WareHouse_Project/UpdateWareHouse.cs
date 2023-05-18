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
    public partial class UpdateWareHouse : Form
    {
        CompunyDBContext c;
        public UpdateWareHouse()
        {
            InitializeComponent();
            c= new CompunyDBContext();
            textBox1.Text = WareHouseForm.UpdatedWareHouse.WareHouseName;
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if( textBox2.Text != "" && textBox3.Text != "" ){
           
                    WareHouseForm.UpdatedWareHouse.WareHouseAddress = textBox2.Text;
                    WareHouseForm.UpdatedWareHouse.MangerName = textBox3.Text;
                    MessageBox.Show("Update Succesfully");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
              
            }
            else
            {
                MessageBox.Show("Fill  Data !!");

            }

        }
    }
}
