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
    public partial class clients : Form
    {
        public clients()
        {
            InitializeComponent();
        }
        DataTable dt=new DataTable();
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clients_Load(object sender, EventArgs e)
        {
            CustomerLabel.Text = "Customers";
            DatabaseFile db = new DatabaseFile();
            dt = db.CustomersGridData();
            CustomersdataGridView.DataSource = dt;
            CustomersdataGridView.Columns["DateTime"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            CustomersdataGridView.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            SearchTextBox.Focus();

        }

        private void CustomersdataGridView_DoubleClick(object sender, EventArgs e)
        {
            int index = CustomersdataGridView.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            string inv = CustomersdataGridView.Rows[index].Cells["Invoice_no"].Value.ToString();
            string name = CustomersdataGridView.Rows[index].Cells["Name"].Value.ToString();
            string date = CustomersdataGridView.Rows[index].Cells["DateTime"].Value.ToString();
            Orders order=new Orders();
            using(order)
            {
                order.inv = inv;
                order.name = name;
                order.date = date;
                order.labeling = "Customer's Order";
                order.invlabel = "Invoice No :";
                order.griddata = "invoice";
                order.ShowDialog();
            }
            
            
        }
        private static void messagebox(string message)
        {
            MessageForm form2 = new MessageForm();
            using (form2)
            {
                form2.errorlabel.Text = message;
                form2.ShowDialog();
            }
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;

            dv.RowFilter = "Name like '%" + SearchTextBox.Text + "%'";
        }
    }
}
