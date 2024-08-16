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
    public partial class Returns : Form
    {
        public Returns()
        {
            InitializeComponent();
        }
        DataTable dt=new DataTable();
        DataTable dtr = new DataTable();
        DataTable datat=new DataTable();
        string ridi;
        
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
           
        }

        private bool isvalid()
        {
            if (invTextBox.Text == string.Empty)
            {
                messagebox("Enter Invoice no");
                invTextBox.Focus();
                return false;
            }
            return true;
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

        private void Returns_Load(object sender, EventArgs e)
        {
           tabControl1.SelectedTab = tabControl1.TabPages[0];
           invTextBox.Focus();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void savebutton_Click_1(object sender, EventArgs e)
        {
            if (isvalid())
            {

                DatabaseFile db = new DatabaseFile();
                dt = db.Returns_Data(invTextBox.Text.ToUpper());
                datat = db.Returns_Data_name(invTextBox.Text.ToUpper());
                // data table se specific row ki value select karni ho to ye karen 
                DataRow[] dtr = datat.Select($"Invoice_no = '{invTextBox.Text.ToUpper()}'");

                if (dtr.Length > 0)
                {
                    userControl11.Hide();
                    int intval = int.Parse(invTextBox.Text.Substring(2, 6));
                    ridi = string.Format("R-{0:000000}", intval);
                    textBox1.Text = dtr[0]["Name"].ToString();
                    textBox2.Text = dtr[0]["DateTime"].ToString();
                    textBox3.Text = dtr[0]["Total_Bill"].ToString();
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView.DataSource = dt;

                    }
                    else
                    {
                        dataGridView.DataSource = null;
                    }
                }
                else
                {
                     userControl11.Show();
                    messagebox("not found");
                    dataGridView.DataSource = null;
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    invTextBox.Clear();
                    invTextBox.Focus();

                }

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            returnqty rt = new returnqty();
            using (rt)
            {
                rt.dt = dt;
                rt.inv = invTextBox.Text;
                rt.rid = ridi;
                rt.name = textBox1.Text;
                rt.ShowDialog();
            }
        }

        private void tab1_Click(object sender, EventArgs e)
        {
            invTextBox.Focus();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedTab == tabControl1.TabPages[1]) 
            {
                
                DatabaseFile db= new DatabaseFile();
                dtr = db.returnGridData();
                dataGridView1.DataSource = dtr;  
                textBox4.Focus();

            }
            if (tabControl1.SelectedTab == tabControl1.TabPages[0])
            {
                invTextBox.Focus();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dtr.DefaultView;
            dv.RowFilter = "Return_ID like '%" + textBox4.Text + "%'";
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int index = dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            string inv = dataGridView1.Rows[index].Cells["Invoice_no"].Value.ToString();
            string rid = dataGridView1.Rows[index].Cells["Return_ID"].Value.ToString();
            string name = dataGridView1.Rows[index].Cells["Name"].Value.ToString();
            string date = dataGridView1.Rows[index].Cells["DateTime"].Value.ToString();
            Orders order = new Orders();
            using (order)
            {
                order.inv = rid;
                order.name = name;
                order.date = date;
                order.labeling = "Returns Invoices";
                order.invlabel = "Return ID :";
                order.griddata = "returns";
                order.ShowDialog();
            }
        }
    }
}
