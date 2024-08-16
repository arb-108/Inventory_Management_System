namespace Costco
{
    partial class Orders
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toplabel1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.InvoiceTextBox = new System.Windows.Forms.TextBox();
            this.bottomlabel2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NametextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.datetextBox = new System.Windows.Forms.TextBox();
            this.OrdersdataGridView = new System.Windows.Forms.DataGridView();
            this.Okbutton = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(890, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 588);
            this.panel1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Controls.Add(this.toplabel1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(890, 45);
            this.panel2.TabIndex = 16;
            // 
            // toplabel1
            // 
            this.toplabel1.AutoSize = true;
            this.toplabel1.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toplabel1.ForeColor = System.Drawing.Color.White;
            this.toplabel1.Location = new System.Drawing.Point(3, 5);
            this.toplabel1.Name = "toplabel1";
            this.toplabel1.Size = new System.Drawing.Size(197, 36);
            this.toplabel1.TabIndex = 17;
            this.toplabel1.Text = "Customer\'s Order";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(846, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(44, 30);
            this.button2.TabIndex = 17;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SteelBlue;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 583);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(890, 5);
            this.panel3.TabIndex = 15;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SteelBlue;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 45);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(5, 538);
            this.panel4.TabIndex = 12;
            // 
            // InvoiceTextBox
            // 
            this.InvoiceTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InvoiceTextBox.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InvoiceTextBox.Location = new System.Drawing.Point(190, 64);
            this.InvoiceTextBox.Name = "InvoiceTextBox";
            this.InvoiceTextBox.ReadOnly = true;
            this.InvoiceTextBox.Size = new System.Drawing.Size(242, 33);
            this.InvoiceTextBox.TabIndex = 17;
            // 
            // bottomlabel2
            // 
            this.bottomlabel2.AutoSize = true;
            this.bottomlabel2.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bottomlabel2.Location = new System.Drawing.Point(17, 67);
            this.bottomlabel2.Name = "bottomlabel2";
            this.bottomlabel2.Size = new System.Drawing.Size(109, 30);
            this.bottomlabel2.TabIndex = 18;
            this.bottomlabel2.Text = "Invoice No :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 30);
            this.label3.TabIndex = 18;
            this.label3.Text = "Customer\'s Name :";
            // 
            // NametextBox
            // 
            this.NametextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NametextBox.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NametextBox.Location = new System.Drawing.Point(190, 103);
            this.NametextBox.Name = "NametextBox";
            this.NametextBox.ReadOnly = true;
            this.NametextBox.Size = new System.Drawing.Size(242, 33);
            this.NametextBox.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 30);
            this.label4.TabIndex = 18;
            this.label4.Text = "Date :";
            // 
            // datetextBox
            // 
            this.datetextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.datetextBox.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datetextBox.Location = new System.Drawing.Point(190, 142);
            this.datetextBox.Name = "datetextBox";
            this.datetextBox.ReadOnly = true;
            this.datetextBox.Size = new System.Drawing.Size(242, 33);
            this.datetextBox.TabIndex = 17;
            // 
            // OrdersdataGridView
            // 
            this.OrdersdataGridView.AllowUserToAddRows = false;
            this.OrdersdataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.OrdersdataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.OrdersdataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OrdersdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrdersdataGridView.Location = new System.Drawing.Point(18, 194);
            this.OrdersdataGridView.Name = "OrdersdataGridView";
            this.OrdersdataGridView.ReadOnly = true;
            this.OrdersdataGridView.RowHeadersVisible = false;
            this.OrdersdataGridView.RowHeadersWidth = 51;
            this.OrdersdataGridView.RowTemplate.Height = 24;
            this.OrdersdataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.OrdersdataGridView.Size = new System.Drawing.Size(859, 333);
            this.OrdersdataGridView.TabIndex = 19;
            // 
            // Okbutton
            // 
            this.Okbutton.BackColor = System.Drawing.Color.RoyalBlue;
            this.Okbutton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Okbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Okbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Okbutton.ForeColor = System.Drawing.Color.White;
            this.Okbutton.Location = new System.Drawing.Point(789, 539);
            this.Okbutton.Name = "Okbutton";
            this.Okbutton.Size = new System.Drawing.Size(88, 35);
            this.Okbutton.TabIndex = 20;
            this.Okbutton.Text = "OK";
            this.Okbutton.UseVisualStyleBackColor = false;
            this.Okbutton.Click += new System.EventHandler(this.Okbutton_Click);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.Red;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.ForeColor = System.Drawing.Color.White;
            this.button12.Location = new System.Drawing.Point(692, 539);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(88, 35);
            this.button12.TabIndex = 21;
            this.button12.Text = "Close";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // Orders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 588);
            this.Controls.Add(this.Okbutton);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.OrdersdataGridView);
            this.Controls.Add(this.datetextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.NametextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.InvoiceTextBox);
            this.Controls.Add(this.bottomlabel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Orders";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Orders";
            this.Load += new System.EventHandler(this.Orders_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label toplabel1;
        private System.Windows.Forms.TextBox InvoiceTextBox;
        private System.Windows.Forms.Label bottomlabel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NametextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox datetextBox;
        private System.Windows.Forms.DataGridView OrdersdataGridView;
        private System.Windows.Forms.Button Okbutton;
        private System.Windows.Forms.Button button12;
    }
}