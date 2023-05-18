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
    public partial class CostumerForm : Form
    {
        CompunyDBContext c;
        public static Person.Customer SelctedCustomer;

        public CostumerForm()
        {
            InitializeComponent();
            c = new CompunyDBContext();
            AddCustomersToList();

        }

        void AddCustomersToList()
        {
            listView1.Items.Clear();
            foreach (Person.Customer item in c.customers)
            {

                ListViewItem listitem = new ListViewItem(item.Name.ToString());
                listitem.SubItems.Add(item.Phone);
                listitem.SubItems.Add(item.Fax.ToString());
                listitem.SubItems.Add(item.MobilePhone);
                listitem.SubItems.Add(item.Mail);
                listitem.SubItems.Add(item.Website);
                listView1.Items.Add(listitem);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Customerform = new AddCustomerForm();
            var result = Customerform.ShowDialog();
            if (result == DialogResult.OK)
            {
                AddCustomersToList();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            var slecteditems = listView1.SelectedItems;
            string name = "";
            string phone = string.Empty;

            foreach (ListViewItem item in slecteditems)
            {
                name = item.SubItems[0].Text;
                phone = item.SubItems[1].Text;

            }
            SelctedCustomer = c.customers.FirstOrDefault(c => c.Name == name && c.Phone == phone);
            if (SelctedCustomer != null)
            {
                var form = new UpdateCustomerForm();
                var res = form.ShowDialog();
                if (res == DialogResult.OK)
                {
                    c.SaveChanges();
                    AddCustomersToList();
                }
            }
            else
            {
                MessageBox.Show("Select An Item from The List");
            }
        }
    }
}
