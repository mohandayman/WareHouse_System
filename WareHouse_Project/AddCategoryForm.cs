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
    
    public partial class AddCategoryForm : Form
    {
        CompunyDBContext c;
        Category InsertedCategory;
        public AddCategoryForm()
        {
            InitializeComponent();
            c = new CompunyDBContext();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                
                    InsertedCategory = new Category() { Name = textBox1.Text, unit = textBox2.Text};
                    c.Categories.Add(InsertedCategory);
                    c.SaveChanges();
                    MessageBox.Show("The Data Inserted Succesfully");
                    this.DialogResult = DialogResult.OK;
                    this.Close();

            }
            else
            {
                MessageBox.Show("Please Fill All The Data");
            }

        }
    }
    }

