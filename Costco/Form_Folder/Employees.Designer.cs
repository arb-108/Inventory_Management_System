namespace Costco
{
    partial class Employees
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.mainlabel = new System.Windows.Forms.Label();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.sublabel = new System.Windows.Forms.Label();
            this.InvdataGridView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.Deletebutton = new System.Windows.Forms.Button();
            this.AddNewbutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.InvdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 789);
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(5, 784);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1382, 5);
            this.panel2.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SteelBlue;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1382, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(5, 784);
            this.panel3.TabIndex = 12;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SteelBlue;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(5, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1377, 45);
            this.panel4.TabIndex = 13;
            // 
            // mainlabel
            // 
            this.mainlabel.AutoSize = true;
            this.mainlabel.BackColor = System.Drawing.Color.SteelBlue;
            this.mainlabel.Font = new System.Drawing.Font("Poppins", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainlabel.ForeColor = System.Drawing.Color.White;
            this.mainlabel.Location = new System.Drawing.Point(7, 3);
            this.mainlabel.Name = "mainlabel";
            this.mainlabel.Size = new System.Drawing.Size(147, 40);
            this.mainlabel.TabIndex = 21;
            this.mainlabel.Text = "Employees";
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SearchTextBox.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchTextBox.Location = new System.Drawing.Point(182, 65);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(208, 33);
            this.SearchTextBox.TabIndex = 16;
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // sublabel
            // 
            this.sublabel.AutoSize = true;
            this.sublabel.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sublabel.Location = new System.Drawing.Point(22, 68);
            this.sublabel.Name = "sublabel";
            this.sublabel.Size = new System.Drawing.Size(159, 30);
            this.sublabel.TabIndex = 22;
            this.sublabel.Text = "Employee Name :";
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
            this.InvdataGridView.Location = new System.Drawing.Point(27, 105);
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
            this.InvdataGridView.TabIndex = 19;
            this.InvdataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InvdataGridView_CellClick);
            this.InvdataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.InvdataGridView_CellFormatting_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1337, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 30);
            this.button1.TabIndex = 20;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Deletebutton
            // 
            this.Deletebutton.BackColor = System.Drawing.Color.DarkOrange;
            this.Deletebutton.Font = new System.Drawing.Font("Poppins", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Deletebutton.ForeColor = System.Drawing.Color.White;
            this.Deletebutton.Image = global::Costco.Properties.Resources.user_delete_2;
            this.Deletebutton.Location = new System.Drawing.Point(1163, 181);
            this.Deletebutton.Name = "Deletebutton";
            this.Deletebutton.Size = new System.Drawing.Size(211, 70);
            this.Deletebutton.TabIndex = 18;
            this.Deletebutton.Text = "Remove Employee";
            this.Deletebutton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Deletebutton.UseVisualStyleBackColor = false;
            this.Deletebutton.Click += new System.EventHandler(this.Deletebutton_Click);
            // 
            // AddNewbutton
            // 
            this.AddNewbutton.BackColor = System.Drawing.Color.DarkGreen;
            this.AddNewbutton.Font = new System.Drawing.Font("Poppins", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNewbutton.ForeColor = System.Drawing.Color.White;
            this.AddNewbutton.Image = global::Costco.Properties.Resources.user_new_31;
            this.AddNewbutton.Location = new System.Drawing.Point(1163, 102);
            this.AddNewbutton.Name = "AddNewbutton";
            this.AddNewbutton.Size = new System.Drawing.Size(211, 70);
            this.AddNewbutton.TabIndex = 17;
            this.AddNewbutton.Text = "Add New Employee";
            this.AddNewbutton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AddNewbutton.UseVisualStyleBackColor = false;
            this.AddNewbutton.Click += new System.EventHandler(this.AddNewbutton_Click);
            // 
            // Employees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1387, 789);
            this.Controls.Add(this.mainlabel);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.sublabel);
            this.Controls.Add(this.InvdataGridView);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Deletebutton);
            this.Controls.Add(this.AddNewbutton);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Employees";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employees";
            this.Load += new System.EventHandler(this.Employees_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InvdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label mainlabel;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Label sublabel;
        private System.Windows.Forms.DataGridView InvdataGridView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Deletebutton;
        private System.Windows.Forms.Button AddNewbutton;
    }
}