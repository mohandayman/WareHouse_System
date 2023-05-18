using Microsoft.EntityFrameworkCore;
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
    public partial class SupplyPermissionForm : Form
    {
        CompunyDBContext c;
        public static SupplyPermission SelctedPermission;

        public SupplyPermissionForm()
        {
            InitializeComponent();
            c = new CompunyDBContext();
            AddPermissionsToList();
            SelctedPermission = new SupplyPermission();



        }


      public void   AddPermissionsToList() { 
        
        listView1.Items.Clear();
            foreach (SupplyPermission item in c.supplyPermissions)
            {
               
                ListViewItem Vi = new ListViewItem(item.Id.ToString());
                Vi.SubItems.Add(item.WareHousesName);
                Vi.SubItems.Add(item.Date.ToString());
                Vi.SubItems.Add(item.CategoryCode.ToString());
                Vi.SubItems.Add(item.Amount.ToString());
                Vi.SubItems.Add(item.VendorName);
                Vi.SubItems.Add(item.VendorPhone);
                Vi.SubItems.Add(item.ProductionDate.ToString());
                Vi.SubItems.Add(item.ExpiratoinDate.ToString());
                listView1.Items.Add(Vi);
            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new AddSupplyPermissionForm();
            var result = form.ShowDialog();
            if(result == DialogResult.OK)
            {
                AddPermissionsToList();
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            var slecteditems = listView1.SelectedItems;
            int id = 0;

            foreach (ListViewItem item in slecteditems)
            {
                id =int.Parse( item.SubItems[0].Text);
            

            }
            SelctedPermission = c.supplyPermissions.FirstOrDefault(c => c.Id ==id);
            if (SelctedPermission != null)
            {
                var form = new UpdateSupplyForm();
                var res = form.ShowDialog();
                if (res == DialogResult.OK)
                {
                    c.SaveChanges();
                    AddPermissionsToList();
                }
            }
            else
            {
                MessageBox.Show("Select An Item from The List");
            }
        }
    }
}
