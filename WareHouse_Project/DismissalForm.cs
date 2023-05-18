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
    public partial class DismissalForm : Form
    {
        CompunyDBContext c;
        public static DismissalNotice SelectedDismissal;

        public DismissalForm()
        {
            InitializeComponent();
            c = new CompunyDBContext();
            AddDismissalToList();


        }
        public void AddDismissalToList()
        {

            listView1.Items.Clear();
            foreach (DismissalNotice item in c.dismissalNotices)
            {

                ListViewItem Vi = new ListViewItem(item.Id.ToString());
                Vi.SubItems.Add(item.WareHousesName);
                Vi.SubItems.Add(item.Date.ToString());
                Vi.SubItems.Add(item.CategoryCode.ToString());
                Vi.SubItems.Add(item.Amount.ToString());
                Vi.SubItems.Add(item.VendorName);
                Vi.SubItems.Add(item.VendorPhone);
               
                listView1.Items.Add(Vi);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new AddDismissalForm();
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                AddDismissalToList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var slecteditems = listView1.SelectedItems;
            int id = 0;

            foreach (ListViewItem item in slecteditems)
            {
                id = int.Parse(item.SubItems[0].Text);


            }
            SelectedDismissal = c.dismissalNotices.FirstOrDefault(c => c.Id == id);
            if (SelectedDismissal != null)
            {
                var form = new UpdateDismissalForm();
                var res = form.ShowDialog();
                if (res == DialogResult.OK)
                {
                    c.SaveChanges();
                    AddDismissalToList();
                }
            }
            else
            {
                MessageBox.Show("Select An Item from The List");
            }
        }
    }
    }

