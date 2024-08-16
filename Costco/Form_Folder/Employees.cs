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
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
        }
        DataTable dt=new DataTable();
        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = "Name like '%" + SearchTextBox.Text + "%'";
        }

        private void Employees_Load(object sender, EventArgs e)
        {
            loadEmpData();
        }

        private void loadEmpData()
        {
            DatabaseFile db = new DatabaseFile();
            dt = db.Emp_Data();
            InvdataGridView.DataSource = dt;
            InvdataGridView.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            InvdataGridView.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            InvdataGridView.Columns["Phone"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            SearchTextBox.Clear();
            SearchTextBox.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddNewbutton_Click(object sender, EventArgs e)
        {
            Add_Employee form = new Add_Employee();
            using(form)
            {
                form.ShowDialog();
            }
            loadEmpData();

        }

        private void Deletebutton_Click(object sender, EventArgs e)
        {
            bool _valid = false;
            MessageForm fm = new MessageForm();
            using (fm)
            {
                fm.errorlabel.Text = "Do You Want to delete this Employee";
                if (fm.ShowDialog() == DialogResult.OK)
                {
                    _valid = true;
                }
            }
            if (_valid == true)
            {
                DatabaseFile db = new DatabaseFile();
                int index = InvdataGridView.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                int id = int.Parse(InvdataGridView.Rows[index].Cells["ID"].Value.ToString());
                db.deleteemp(id);
                loadEmpData();

            }
        }

        //photo size adjust karne k liye
        private void InvdataGridView_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            InvdataGridView.Columns["Image"].Width = 70;
            for (int i = 0; i < InvdataGridView.Columns.Count; i++)
            {
                if (InvdataGridView.Columns[i] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)InvdataGridView.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                }


            }
        }

        private void InvdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10 && InvdataGridView.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow dr = InvdataGridView.SelectedRows[0];

                // Get the cell value and cast it to an Image if it's of type Image
                // Assuming the cell value at index 3 is an Image type
                if (dr.Cells[10].Value is byte[])
                {
                    byte[] imageBytes = (byte[])dr.Cells[10].Value;
                    string id = dr.Cells[0].Value.ToString();
                    string name = dr.Cells[1].Value.ToString();
                    EmployeeImageForm form = new EmployeeImageForm();
                    using (form)
                    {
                        form.image = imageBytes;
                        form.EmpId = id;
                        form.EmpName = name;
                        form.ShowDialog();
                    }



                }
                else
                {
                    // Handle the case where the cell value is not an image
                    MessageBox.Show("The selected cell does not contain an image.");
                }
            }
        }
    }
}
