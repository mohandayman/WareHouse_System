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
    public partial class UpdateCategoryForm : Form
    {
        CompunyDBContext c;
        public UpdateCategoryForm()
        {
            InitializeComponent();
            textBox1.Text = CategoryForm.SelectedCategory.Code.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != ""  && textBox3.Text != "") 
            
            {
            c= new CompunyDBContext();
                CategoryForm.SelectedCategory.Name = textBox2.Text;
                CategoryForm.SelectedCategory.unit = textBox3.Text;
                c.SaveChanges();
                MessageBox.Show("Data Changed Succesfully");
                this.DialogResult = DialogResult.OK;
                this.Close ();
            
            }else
            {
                MessageBox.Show("Please Fill All The Data ");
            }
        }
    }
}
