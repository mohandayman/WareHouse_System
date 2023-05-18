using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WareHouse_Project.Person;

namespace WareHouse_Project
{
    public partial class EntryForm : Form
    {
        CompunyDBContext c;
        public EntryForm()
        {
            InitializeComponent();
             c = new CompunyDBContext();
            var delete = c.wareHouses.ToList();

            c.wareHouses.RemoveRange(delete);
            var delete2 = c.Categories.ToList();

            c.Categories.RemoveRange(delete2);
            var delete3 = c.customers.ToList();

            c.customers.RemoveRange(delete3);
            c.SaveChanges();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new WareHouseForm();
           var result =  form.ShowDialog();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var form = new CategoryForm();
            var result = form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var form = new CostumerForm();
            var result = form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new VendorForm();
            var result = form.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var form = new SupplyPermissionForm();
            var result = form.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var form = new DismissalForm();
            var result = form.ShowDialog();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            var form = new TransferCategoriesForm();
            var result = form.ShowDialog();


        }
    }
}
