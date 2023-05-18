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
    public partial class VendorForm : Form
    {
       CompunyDBContext c;
      public static   Person.Vendor SelctedVendor;

        public VendorForm()
        {
            InitializeComponent();
            c = new CompunyDBContext();
            AddVendorsToList();
            SelctedVendor = new Person.Vendor();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Vendorform = new AddVendorForm();
            var result = Vendorform.ShowDialog();
            if (result == DialogResult.OK)
            {
                AddVendorsToList();
            }

        }
        void AddVendorsToList()
        {
            listView1.Items.Clear();
            foreach (Person.Vendor item in c.Vendors)
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
            SelctedVendor = c.Vendors.FirstOrDefault(c => c.Name == name && c.Phone == phone);
            if (SelctedVendor != null)
            {
                var form = new UpdateVendorForm();
                var res = form.ShowDialog();
                if (res == DialogResult.OK)
                {
                    c.SaveChanges();
                    AddVendorsToList();
                }
            }
            else
            {
                MessageBox.Show("Select An Item from The List");
            }
        }
    }
    }
