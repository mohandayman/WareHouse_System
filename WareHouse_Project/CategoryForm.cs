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
    public partial class CategoryForm : Form
    {
        CompunyDBContext c;
      public static  Category SelectedCategory;
        public CategoryForm()
        {
            InitializeComponent();
            c = new CompunyDBContext ();
            AddCatigoriesToList();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            var warehouseform = new AddCategoryForm();
            var result = warehouseform.ShowDialog();
            if (result == DialogResult.OK)
            {
                AddCatigoriesToList();
            }

        }
        void AddCatigoriesToList()
        {
            listView1.Items.Clear();
            foreach (Category item in c.Categories)
            {
                ListViewItem listitem = new ListViewItem(item.Code.ToString());
                listitem.SubItems.Add(item.Name);
                listitem.SubItems.Add(item.unit);
                listView1.Items.Add(listitem);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var slecteditems = listView1.SelectedItems;
            int? code = 0;
            foreach(ListViewItem item in slecteditems)
            {
                code = int.Parse(item.SubItems[0].Text);   
            }
            SelectedCategory = c.Categories.FirstOrDefault(c => c.Code == code);
            if(SelectedCategory != null)
            {
                var form = new UpdateCategoryForm();
                var res = form.ShowDialog();
                if (res == DialogResult.OK)
                {
                    AddCatigoriesToList();
                }
            }
            else
            {
                MessageBox.Show("Select An Item from The List");
            }
        }
    }
}

