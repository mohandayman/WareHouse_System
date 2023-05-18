namespace WareHouse_Project
{
    partial class WareHouseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Add_WareHouse = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Update_WareHouse = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // Add_WareHouse
            // 
            this.Add_WareHouse.Location = new System.Drawing.Point(634, 48);
            this.Add_WareHouse.Name = "Add_WareHouse";
            this.Add_WareHouse.Size = new System.Drawing.Size(154, 38);
            this.Add_WareHouse.TabIndex = 1;
            this.Add_WareHouse.Text = "Add WareHouse";
            this.Add_WareHouse.UseVisualStyleBackColor = true;
            this.Add_WareHouse.Click += new System.EventHandler(this.Add_WareHouse_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(634, 172);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(154, 38);
            this.button3.TabIndex = 3;
            this.button3.Text = "Transfer Category";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Update_WareHouse
            // 
            this.Update_WareHouse.Location = new System.Drawing.Point(634, 109);
            this.Update_WareHouse.Name = "Update_WareHouse";
            this.Update_WareHouse.Size = new System.Drawing.Size(154, 38);
            this.Update_WareHouse.TabIndex = 4;
            this.Update_WareHouse.Text = "Update WareHouse";
            this.Update_WareHouse.UseVisualStyleBackColor = true;
            this.Update_WareHouse.Click += new System.EventHandler(this.Update_WareHouse_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 31);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(616, 371);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "WareHouse Name";
            this.columnHeader4.Width = 151;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "WareHouse Address";
            this.columnHeader5.Width = 150;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "WareHouse Manager";
            this.columnHeader6.Width = 176;
            // 
            // WareHouseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.Update_WareHouse);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Add_WareHouse);
            this.Name = "WareHouseForm";
            this.Text = "WareHouseForm";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Add_WareHouse;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button Update_WareHouse;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}