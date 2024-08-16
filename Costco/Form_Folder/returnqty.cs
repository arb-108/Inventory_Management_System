using Costco.Data_Files;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Costco
{
    public partial class returnqty : Form
    {
        public returnqty()
        {
            InitializeComponent();
        }
        public DataTable dt { get; set; }
        public string inv { get; set; }
        public string rid { get; set; }
        public string name { get; set; }

        bool check=false;

        List<returnsProducts> returns=new List<returnsProducts>();
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.ValueMember = "Qty";
            comboBox1.DisplayMember = "Product_name";
            comboBox1.DataSource = dt;
            comboBox1.SelectedIndex = 0;
            qtytextBox.Text= comboBox1.SelectedValue.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            qtytextBox.Text = comboBox1.SelectedValue.ToString();
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
            if (isvalid())
            {
                bool checking=false;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["Name"].Value.ToString() == comboBox1.Text)
                    {
                        row.Cells["Qty"].Value = int.Parse(row.Cells["Qty"].Value.ToString()) + int.Parse(returnqtytextBox.Text);
                        row.Cells["Total_Price"].Value = int.Parse(row.Cells["Qty"].Value.ToString()) * decimal.Parse(row.Cells["Price"].Value.ToString());

                        checking = true;
                    }
                }

                if(checking==false)
                {

                DataRow[] dtr = dt.Select($"Product_name = '{comboBox1.Text}'");
                returnsProducts ret = new returnsProducts()
                {
                    Name = comboBox1.Text,
                    Qty = int.Parse(returnqtytextBox.Text),
                    Price = decimal.Parse(dtr[0]["Price"].ToString()),
                    Total_Price = int.Parse(returnqtytextBox.Text) * decimal.Parse(dtr[0]["Price"].ToString())

                };
                returns.Add(ret);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = returns;
                }
                decimal total_of_returns=returns.Sum(x => x.Total_Price);
                TotalTextBox.Text = total_of_returns.ToString();
                returnqtytextBox.Clear();
                returnqtytextBox.Focus();
                CheckoutButton.Enabled = true;
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

        private bool isvalid()
        {
            if (returnqtytextBox.Text == string.Empty)
            {
                messagebox("Enter Returns Quantity");
                returnqtytextBox.Clear();
                returnqtytextBox.Focus();
                return false;

            }
            else
            {
                int integercheak;
                bool isnumeric = int.TryParse(returnqtytextBox.Text.Trim(), out integercheak);
                if (!isnumeric)
                {
                    messagebox("Please Enter Numeric Value");
                    returnqtytextBox.Clear();
                    returnqtytextBox.Focus();

                    return false;
                }
                else
                {
                    int ingrid = 0;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["Name"].Value.ToString() == comboBox1.Text)
                        {
                            ingrid = int.Parse(row.Cells["Qty"].Value.ToString());
                        }
                    }
                    int totalqty = ingrid + int.Parse(returnqtytextBox.Text);
                   if (totalqty> int.Parse(qtytextBox.Text))
                    {
                        messagebox("Return Qty exceed Purchase Qty");
                        returnqtytextBox.Clear();
                        returnqtytextBox.Focus();

                        return false;
                    }
                }
                
            }
            return true;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Costco Wholesale", new Font("Poppins", 26, FontStyle.Bold),
                Brushes.Black, 250, 70);
            e.Graphics.DrawString("0321-1153969 | CostcoWholesale@support.com", new Font("Arial", 10, FontStyle.Regular),
                Brushes.Black, 265, 110);
            e.Graphics.DrawString("Date : " + DateTime.Now.ToShortDateString(), new Font("Poppins", 10, FontStyle.Regular),
                Brushes.Black, 600, 180);
            e.Graphics.DrawString("Return No : " +rid.ToUpper(), new Font("Poppins", 10, FontStyle.Bold),
                Brushes.Black, 600, 210);
            e.Graphics.DrawString("Invoice No : " + inv.ToUpper(), new Font("Poppins", 10, FontStyle.Bold),
                Brushes.Black, 40, 180);
            e.Graphics.DrawString("Customer Name  : " + "", new Font("Poppins", 10, FontStyle.Regular),
                Brushes.Black, 40, 210);
            e.Graphics.DrawString("Bill Type  : " +"RETURNS", new Font("Poppins", 10, FontStyle.Bold),
                Brushes.Black, 40, 240);
            e.Graphics.DrawString("------------------------------------------------" +
                "---------------------------" +
                "", new Font("Poppins", 14, FontStyle.Regular),
                Brushes.Black, 35, 270);
            e.Graphics.DrawString("Item Name", new Font("Poppins", 10, FontStyle.Regular),
                Brushes.Black, 40, 285);
            e.Graphics.DrawString("Qty", new Font("Poppins", 10, FontStyle.Regular),
                Brushes.Black, 560, 285);
            e.Graphics.DrawString("Price", new Font("Poppins", 10, FontStyle.Regular),
                Brushes.Black, 620, 285);
            e.Graphics.DrawString("Total Price", new Font("Poppins", 10, FontStyle.Regular),
                Brushes.Black, 680, 285);
            e.Graphics.DrawString("------------------------------------------------" +
                "---------------------------" +
                "", new Font("Poppins", 14, FontStyle.Regular),
                Brushes.Black, 35, 300);
            int Ypos = 330;
            foreach (var i in returns)
            {
                e.Graphics.DrawString(i.Name.ToString(), new Font("Poppins", 10, FontStyle.Regular),
                Brushes.Black, 40, Ypos);
                e.Graphics.DrawString(i.Qty.ToString(), new Font("Poppins", 10, FontStyle.Regular),
                    Brushes.Black, 570, Ypos);
                e.Graphics.DrawString(i.Price.ToString(), new Font("Poppins", 10, FontStyle.Regular),
                    Brushes.Black, 630, Ypos);
                e.Graphics.DrawString(i.Total_Price.ToString(), new Font("Poppins", 10, FontStyle.Regular),
                    Brushes.Black, 690, Ypos);
                Ypos += 30;
            }
            Ypos += 20;
            e.Graphics.DrawString("------------------------------------------------" +
                "---------------------------" +
                "", new Font("Poppins", 14, FontStyle.Regular),
                Brushes.Black, 35, Ypos);
            e.Graphics.DrawString("Total Amount  :  Rs. " + TotalTextBox.Text
                , new Font("Poppins", 14, FontStyle.Bold),
                Brushes.Black, 500, Ypos += 30);
        }

        private void PreviewButton_Click(object sender, EventArgs e)
        {
            if (check == true)
            {

            if (returns.Count > 0)
            {
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
                //PreviewButton.Enabled= false;

            }
            }
            else
            {
                messagebox("Add Item to Cart-(Checkout First)");
                returnqtytextBox.Focus();
            }
        }

        private void CheckoutButton_Click(object sender, EventArgs e)
        {
            if(returns.Count > 0)
            {
                decimal total_decimal=decimal.Parse(TotalTextBox.Text);
                DatabaseFile db=new DatabaseFile();
                db.return_invoices(dataGridView1, inv.ToUpper(), rid.ToUpper());
                db.returns_customers(rid.ToUpper(), inv.ToUpper(), name, total_decimal);
                messagebox("Checkout Successfully");
                check=true;
                CheckoutButton.Enabled=false;

            }
            else
            {
                messagebox("Add Item to Cart");
                returnqtytextBox.Focus();
            }
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            bool done = false;
            if (check == true)
            {

                //printDocument1.Print();
                string invoices = rid.ToUpper();
                //string existingPathName = @"D:\PUCIT\Semester 4\Projects\Invoices\Returns";
                //string notExistingFileName = @"D:\PUCIT\Semester 4\Projects\Invoices\\Returns\" + invoices + ".pdf";
                string existingPathName = @"D:\PUCIT\Semester 4\Projects\Costco\Costco\Costco_Invoices\Returns";
                string notExistingFileName = @"D:\PUCIT\Semester 4\Projects\Costco\Costco\Costco_Invoices\Returns\" + invoices + ".pdf";
                if (Directory.Exists(existingPathName) && !File.Exists(notExistingFileName))
                {

                    printDocument1.PrinterSettings.PrinterName = "Microsoft Print to PDF";
                    printDocument1.PrinterSettings.PrintFileName = notExistingFileName;
                    printDocument1.PrinterSettings.PrintToFile = true;
                    // printDocument1.PrintPage += pdoc_PrintPage;
                    printDocument1.Print();
                    done = true;
                }
                check = false;
            }
            else
            {
                messagebox("Please First Checkout Then Preview");
                CheckoutButton.Focus();
            }
            if (done == true)
            {
                dataGridView1= null;
                TotalTextBox.Clear();
                this.Close();
            }
        }
    }
}
