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
    public partial class WareHouseForm : Form
    {
        CompunyDBContext c;
        public static WareHouse UpdatedWareHouse;
        public WareHouseForm()
        {
            InitializeComponent();
            c = new CompunyDBContext();
            AddWareHousesToList();
        }

        private void Add_WareHouse_Click(object sender, EventArgs e)
        {
            var warehouseform = new AddWareHouseForm();
            var result =  warehouseform.ShowDialog();
            if (result == DialogResult.OK)
            {
                AddWareHousesToList();
            }
        }

        void AddWareHousesToList()
        {
            listView1.Items.Clear();
            foreach (WareHouse item in c.wareHouses)
            {
                ListViewItem listitem = new ListViewItem(item.WareHouseName);
               
                listitem.SubItems.Add(item.WareHouseAddress);
                listitem.SubItems.Add(item.MangerName);
                listView1.Items.Add(listitem);
            }
        }

      

        private void Update_WareHouse_Click(object sender, EventArgs e)
        {
            var items = listView1.SelectedItems;
            string selectedName ="";
           foreach (ListViewItem item in items)
            {
              selectedName = item.SubItems[0].Text;

            }
          UpdatedWareHouse =  c.wareHouses.FirstOrDefault(w => w.WareHouseName == selectedName);
            if (UpdatedWareHouse != null)
            {

                var form = new UpdateWareHouse();
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    c.SaveChanges();
                    AddWareHousesToList();
                }
            }
            else
            {
                MessageBox.Show("Please select An Item To Be updated");
            }
        }
    }
}
