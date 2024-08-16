namespace Costco
{
    partial class Inventory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mainlabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.InvdataGridView = new System.Windows.Forms.DataGridView();
            this.sublabel = new System.Windows.Forms.Label();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.Deletebutton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.AddNewbutton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InvdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.mainlabel);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1387, 45);
            this.panel1.TabIndex = 7;
            // 
            // mainlabel
            // 
            this.mainlabel.AutoSize = true;
            this.mainlabel.Font = new System.Drawing.Font("Poppins", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainlabel.ForeColor = System.Drawing.Color.White;
            this.mainlabel.Location = new System.Drawing.Point(-1, 3);
            this.mainlabel.Name = "mainlabel";
            this.mainlabel.Size = new System.Drawing.Size(134, 40);
            this.mainlabel.TabIndex = 5;
            this.mainlabel.Text = "Inventory";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1338, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 30);
            this.button1.TabIndex = 4;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1382, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(5, 744);
            this.panel2.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SteelBlue;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 784);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1382, 5);
            this.panel3.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SteelBlue;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 45);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(5, 739);
            this.panel4.TabIndex = 6;
            // 
            // InvdataGridView
            // 
            this.InvdataGridView.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.InvdataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.InvdataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.InvdataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.InvdataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InvdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InvdataGridView.Location = new System.Drawing.Point(19, 105);
            this.InvdataGridView.Name = "InvdataGridView";
            this.InvdataGridView.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InvdataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.InvdataGridView.RowHeadersVisible = false;
            this.InvdataGridView.RowHeadersWidth = 51;
            this.InvdataGridView.RowTemplate.Height = 24;
            this.InvdataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.InvdataGridView.Size = new System.Drawing.Size(1114, 663);
            this.InvdataGridView.TabIndex = 4;
            // 
            // sublabel
            // 
            this.sublabel.AutoSize = true;
            this.sublabel.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sublabel.Location = new System.Drawing.Point(14, 68);
            this.sublabel.Name = "sublabel";
            this.sublabel.Size = new System.Drawing.Size(142, 30);
            this.sublabel.TabIndex = 5;
            this.sublabel.Text = "Product Name :";
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SearchTextBox.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchTextBox.Location = new System.Drawing.Point(155, 65);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(208, 33);
            this.SearchTextBox.TabIndex = 0;
            this.SearchTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Deletebutton
            // 
            this.Deletebutton.BackColor = System.Drawing.Color.Red;
            this.Deletebutton.Font = new System.Drawing.Font("Poppins", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Deletebutton.ForeColor = System.Drawing.Color.White;
            this.Deletebutton.Image = global::Costco.Properties.Resources.delete;
            this.Deletebutton.Location = new System.Drawing.Point(1155, 288);
            this.Deletebutton.Name = "Deletebutton";
            this.Deletebutton.Size = new System.Drawing.Size(211, 70);
            this.Deletebutton.TabIndex = 3;
            this.Deletebutton.Text = "Remove Product";
            this.Deletebutton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Deletebutton.UseVisualStyleBackColor = false;
            this.Deletebutton.Click += new System.EventHandler(this.Deletebutton_Click);
            // 
            // updateButton
            // 
            this.updateButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.updateButton.Font = new System.Drawing.Font("Poppins", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateButton.ForeColor = System.Drawing.Color.White;
            this.updateButton.Image = global::Costco.Properties.Resources.arrows__1_;
            this.updateButton.Location = new System.Drawing.Point(1155, 195);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(211, 70);
            this.updateButton.TabIndex = 2;
            this.updateButton.Text = "Update Stock";
            this.updateButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.updateButton.UseVisualStyleBackColor = false;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // AddNewbutton
            // 
            this.AddNewbutton.BackColor = System.Drawing.Color.LimeGreen;
            this.AddNewbutton.Font = new System.Drawing.Font("Poppins", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNewbutton.ForeColor = System.Drawing.Color.White;
            this.AddNewbutton.Image = global::Costco.Properties.Resources.add;
            this.AddNewbutton.Location = new System.Drawing.Point(1155, 102);
            this.AddNewbutton.Name = "AddNewbutton";
            this.AddNewbutton.Size = new System.Drawing.Size(211, 70);
            this.AddNewbutton.TabIndex = 1;
            this.AddNewbutton.Text = "Add New Product";
            this.AddNewbutton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AddNewbutton.UseVisualStyleBackColor = false;
            this.AddNewbutton.Click += new System.EventHandler(this.AddNewbutton_Click);
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1387, 789);
            this.Controls.Add(this.Deletebutton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.AddNewbutton);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.sublabel);
            this.Controls.Add(this.InvdataGridView);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Inventory";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Inventory";
            this.Load += new System.EventHandler(this.Inventory_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InvdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label mainlabel;
        private System.Windows.Forms.DataGridView InvdataGridView;
        private System.Windows.Forms.Label sublabel;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Button AddNewbutton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button Deletebutton;
    }
}