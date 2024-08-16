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
    public partial class SuppliersForm : Form
    {
        public SuppliersForm()
        {
            InitializeComponent();
        }
        DataTable dt=new DataTable();
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SuppliersForm_Load(object sender, EventArgs e)
        {
            Load_data_in_grid();
        }

        private void Load_data_in_grid()
        {
            DatabaseFile db = new DatabaseFile();
            dt = db.SupplierData();
            SupdataGridView.DataSource = dt;
            SupdataGridView.Columns["Address"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            SupdataGridView.Columns["Company_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = "Supplier_s_Name like '%" + SearchTextBox.Text + "%'";
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

        private void AddNewbutton_Click(object sender, EventArgs e)
        {
            AddSupplier sf= new AddSupplier();
            using(sf)
            {
                sf.ShowDialog();
            }
            SearchTextBox.Clear();
            SearchTextBox.Focus();
            Load_data_in_grid();

        }

        private void Deletebutton_Click(object sender, EventArgs e)
        {
            bool _valid = false;
            MessageForm fm = new MessageForm();
            using (fm)
            {
                fm.errorlabel.Text = "Do You Want to Remove this Supplier";
                if (fm.ShowDialog() == DialogResult.OK)
                {
                    _valid = true;
                }
            }
            if (_valid == true)
            {
                DatabaseFile db = new DatabaseFile();
                int index = SupdataGridView.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                string id = SupdataGridView.Rows[index].Cells["ID"].Value.ToString();
                db.deleteSupplier(id);
                dt = db.SupplierData();
                SupdataGridView.DataSource = dt;
                SearchTextBox.Clear();
                SearchTextBox.Focus();

            }
            else
            {
                SearchTextBox.Clear();
                SearchTextBox.Focus();
            }
        }
    }
}
