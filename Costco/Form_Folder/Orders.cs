using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Costco
{
    public partial class Orders : Form
    {
        public Orders()
        {
            InitializeComponent();
        }
        public string inv { get; set; }
        public string name { get; set; }
        public string date { get; set; }
        public string labeling { get; set; }
        public string griddata { get; set; }
        public string invlabel { get; set; }
        DataTable dt=new DataTable();

        private void Orders_Load(object sender, EventArgs e)
        {
            toplabel1.Text=labeling;
            bottomlabel2.Text=invlabel;
            InvoiceTextBox.Text = inv;
            NametextBox.Text = name;
            datetextBox.Text = date;
            
            if(InvoiceTextBox.Text!=string.Empty)
            {
                DatabaseFile db= new DatabaseFile();
                if (griddata == "invoice")
                {
                dt =db.invoice_order(InvoiceTextBox.Text);
                    OrdersdataGridView.DataSource = dt;
                    OrdersdataGridView.Columns["Product_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                else
                {
                 dt = db.Returns_invoice_order(InvoiceTextBox.Text);
                    OrdersdataGridView.DataSource = dt;
                }
                

            }
        }

        private void Okbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
