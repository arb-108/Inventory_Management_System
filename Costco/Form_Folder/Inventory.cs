using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Costco
{
    public partial class Inventory : Form
    {
        public Inventory()
        {
            InitializeComponent();
        }
        
        DataTable dt = new DataTable();

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            DatabaseFile db= new DatabaseFile();
            dt = db.InventoryData();
            InvdataGridView.DataSource = dt;
            InvdataGridView.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            SearchTextBox.Clear();
            SearchTextBox.Focus();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = "Name like '%" + SearchTextBox.Text + "%'";
        }

        private void AddNewbutton_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            using (form3)
            {
                form3.ShowDialog();
                if(form3.DialogResult == DialogResult.OK)
                {
                    DatabaseFile db = new DatabaseFile();
                    dt = db.InventoryData();
                    InvdataGridView.DataSource = dt;
                    SearchTextBox.Focus();
                }
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            int index = InvdataGridView.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            UpdateForm upform = new UpdateForm();
            using (upform)
            {
                upform.Currentqty = int.Parse(InvdataGridView.Rows[index].Cells["Qty"].Value.ToString());
                upform.p_id = int.Parse(InvdataGridView.Rows[index].Cells["ID"].Value.ToString());
                upform.role = "stock";
                upform.name = InvdataGridView.Rows[index].Cells["Name"].Value.ToString();
                if (upform.ShowDialog() == DialogResult.OK)
                {
                    InvdataGridView.Rows[index].Cells["Qty"].Value = upform.Updatedqty;
                    //InvdataGridView.Rows[index].Cells["Total_Price"].Value = int.Parse(ProductDataGridView.Rows[index].Cells["Quantity"].Value.ToString()) * decimal.Parse(ProductDataGridView.Rows[index].Cells["Price"].Value.ToString())

                }
            }
        }

        private void Deletebutton_Click(object sender, EventArgs e)
        {
            bool _valid=false;
            MessageForm fm= new MessageForm();
            using (fm)
            {
                fm.errorlabel.Text = "Do You Want to delete this Product";
                if(fm.ShowDialog()== DialogResult.OK)
                {
                    _valid = true;
                }
            }
            if (_valid == true)
            {
                DatabaseFile db= new DatabaseFile();
                int index = InvdataGridView.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                int id=int.Parse(InvdataGridView.Rows[index].Cells["ID"].Value.ToString());
                db.deleteproduct(id);
                dt = db.InventoryData();
                InvdataGridView.DataSource = dt;
                SearchTextBox.Clear();
                SearchTextBox.Focus();

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
    }
}
