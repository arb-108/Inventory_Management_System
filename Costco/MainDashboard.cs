using Costco.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Costco
{
    public partial class MainDashboard : Form
    {
        public MainDashboard()
        {
            InitializeComponent();
        }
        List<products> shoppingCart = new List<products>();
        bool checkout_bool = false;
        Rectangle _normalWindowBounds;
        public string username { get; set; }
        bool _isMaximized = true;
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // When the window is not maximized, store its normal bounds
            if (this.WindowState == FormWindowState.Normal)
            {
                _normalWindowBounds = this.Bounds;
            }

            // Check if the form is maximized
            if (this.WindowState == FormWindowState.Maximized)
            {
                // Get the working area of the screen (excluding taskbar)
                Rectangle workingArea = Screen.GetWorkingArea(this);

                // Adjust the form size to fit within the working area
                this.MaximumSize = workingArea.Size;
                this.Location = workingArea.Location;
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                // Reset the maximum size and restore the original size and position
                this.MaximumSize = Size.Empty;
                this.Bounds = _normalWindowBounds;
            }
        }

        // Optional: Handle the form's state change to ensure size is maintained when restored from minimized
        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);

            // When restoring from minimized, ensure the window bounds are reset
            if (this.WindowState == FormWindowState.Normal)
            {
                this.Bounds = _normalWindowBounds;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            DataTable dt = new DataTable();
            DatabaseFile db= new DatabaseFile();
            dt = db.comboboxData();
            DataRow dr2 = dt.NewRow();
            dr2[0] = 0;
            dr2[1] = "";
            dt.Rows.InsertAt(dr2, 0);
            ProductComboBox.ValueMember = "ID";
            ProductComboBox.DisplayMember= "Name";
            ProductComboBox.DataSource = dt;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timetext.Text=DateTime.Now.ToString("hh:mm:ss");
            label2.Text = DateTime.Now.ToString("tt");
            datetext.Text=DateTime.Now.ToShortDateString();
            
        }

        private void timetext_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void datetext_Click(object sender, EventArgs e)
        {

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

        private void ProductComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexvalue = int.Parse(ProductComboBox.SelectedValue.ToString());
            if (indexvalue>0)
            {
                DatabaseFile db = new DatabaseFile();
                decimal price = db.FindPrice(indexvalue);
                PriceTextBox.Text = price.ToString();
            }
            else
            {
                PriceTextBox.Text = "";
            }
            
        }

        private void ProductComboBox_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) 
            {
                
                if (ProductComboBox.Text != "")
                {
                    int integercheak;
                    bool isnumeric = int.TryParse(ProductComboBox.Text.Trim(), out integercheak);
                    if (isnumeric)
                    {
                        messagebox("Please Enter Alphabet");
                        ProductComboBox.Focus();
                        ProductComboBox.SelectedIndex = 0;
                        QtyTextBox.Clear();
                    }
                    else
                    {
                        this.SelectNextControl(ProductComboBox, true, true, true, true);
                    }
                }
            }
            
        }

        private void QtyTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddCartbutton.PerformClick();
                ProductComboBox.Focus();
            }
        }

        private void AddCartbutton_Click(object sender, EventArgs e)
        {
            //messagebox("Please Enter Quantity!!!");
            if (isvalid())
            {
                bool checking = false;
                bool qtycheak = false;
                //cheaking duplications in grid 
                foreach (DataGridViewRow row in ProductDataGridView.Rows)
                {
                    if (int.Parse(row.Cells["ID"].Value.ToString()) == int.Parse(ProductComboBox.SelectedValue.ToString()))
                    {
                        DatabaseFile db = new DatabaseFile();
                        int id = int.Parse(ProductComboBox.SelectedValue.ToString());
                        int qty = db.FindQty(id) - int.Parse(row.Cells["Quantity"].Value.ToString());
                        if (int.Parse(QtyTextBox.Text) > qty)
                        {
                            if (qty == 0)
                            {
                                string msg = "Limited Stock !!! ( Not Available )";
                                messagebox(msg);
                                
                            }
                            else
                            {
                            string msg = "Limited Stock !!! (Only " + qty.ToString() + " Items Left)";
                            messagebox(msg);
                                QtyTextBox.Clear();
                                QtyTextBox.Focus();
                                qtycheak = true;
                            }
                            
                        }
                        else
                        {

                        row.Cells["Quantity"].Value = int.Parse(row.Cells["Quantity"].Value.ToString())+int.Parse(QtyTextBox.Text);
                        row.Cells["Total_Price"].Value = int.Parse(row.Cells["Quantity"].Value.ToString()) * decimal.Parse(row.Cells["Price"].Value.ToString());
                        }
                        
                            checking = true;break;
                        
                    }
                }
                if (checking == false)
                {
                    products items = new products()
                    {
                        ID = int.Parse(ProductComboBox.SelectedValue.ToString()),
                        Product_Name = ProductComboBox.Text,
                        Quantity = int.Parse(QtyTextBox.Text),
                        Price = decimal.Parse(PriceTextBox.Text),
                        Total_Price = int.Parse(QtyTextBox.Text) * decimal.Parse(PriceTextBox.Text)
                    };
                    shoppingCart.Add(items);
                    ProductDataGridView.DataSource = null;
                    if (shoppingCart.Count == 1)
                    {
                        DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                        column.DataPropertyName = "Sr_no";
                        column.Name = "Sr_no";
                        ProductDataGridView.Columns.Add(column);
                        PreviewButton.Enabled = true;
                    }
                    ProductDataGridView.DataSource = shoppingCart;
                    ProductDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    ProductDataGridView.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    if (shoppingCart.Count == 1)
                    {
                        string invoiceId;
                        DatabaseFile db = new DatabaseFile();
                        invoiceId = db.FindInvoice_number();
                        int intval = int.Parse(invoiceId.Substring(2, 6));
                        intval++;
                        InvoiceTextBox.Text = string.Format("C-{0:000000}", intval);
                    }
                }
                
                decimal preTotal=shoppingCart.Sum(x => x.Total_Price);
                PreTotalTextBox.Text = preTotal.ToString();
                SaleTaxTextBox.Text = "16";
                decimal totalAmount = decimal.Round(preTotal + (preTotal / 100) * 16,2);
                TotalTextBox.Text=totalAmount.ToString();

                int index= ProductDataGridView.Rows.Count-1;
                ProductDataGridView.CurrentCell = ProductDataGridView.Rows[index].Cells[2];
                if (qtycheak == false)
                {
                    ProductComboBox.SelectedIndex = 0;
                    QtyTextBox.Clear();
                    ProductComboBox.Focus();
                }
                
            }
            
        }

        private bool isvalid()
        {
            bool value =true;
            if(ProductComboBox.SelectedIndex == 0)
            {
                messagebox("Select Product");
                ProductComboBox.Focus();
                value = false;
                return value;
            }
            if (ProductComboBox.SelectedValue == null)
            {
                messagebox("Select Product");
                ProductComboBox.SelectedIndex=0;
                ProductComboBox.Focus();
                value = false;
                return value;
            }
            if (QtyTextBox.Text == "")
            {
                messagebox("Select Quantity");
                QtyTextBox.Focus();
                value = false;
                return value;
            }
            else
            {
                int integercheak;
                bool isnumeric=int.TryParse(QtyTextBox.Text.Trim(), out integercheak);
                if(!isnumeric)
                {
                    messagebox("Please Enter Numeric Value");
                    QtyTextBox.Clear();
                    QtyTextBox.Focus();
                    value = false;
                    return value;
                }
                else
                {
                    DatabaseFile db= new DatabaseFile();
                    int id = int.Parse(ProductComboBox.SelectedValue.ToString());
                    int qty = db.FindQty(id);
                    if (int.Parse(QtyTextBox.Text) > qty)
                    {
                        string msg = "Limited Stock !!! (Only " + qty.ToString() + " Items Left)";
                        messagebox(msg);
                        QtyTextBox.Clear();
                        QtyTextBox.Focus();
                        value = false;
                        return value;
                    }
                       
                    
                }
            }
            if (ProductComboBox.Text != "")
            {
                int integercheak;
                bool isnumeric = int.TryParse(ProductComboBox.Text.Trim(), out integercheak);
                if (isnumeric)
                {
                    messagebox("Please Enter Alphabet");
                    ProductComboBox.Focus();
                    ProductComboBox.SelectedIndex = 0;
                    QtyTextBox.Clear();
                    value = false;
                    return value;
                }
            }

            return value;
        }

        private void ClearCartButton_Click(object sender, EventArgs e)
        {
            if (shoppingCart.Count > 0)
            {
                ProductDataGridView.DataSource = null;
                ProductDataGridView.Columns.Remove("Sr_no");
                shoppingCart.Clear();
                ProductComboBox.Focus();
                ProductComboBox.SelectedIndex = 0;
                InvoiceTextBox.Clear();
            }
            ProductComboBox.Focus();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (shoppingCart.Count > 0)
            {
                int itemindex = ProductDataGridView.CurrentCell.RowIndex;
                shoppingCart.RemoveAt(itemindex);
                ProductDataGridView.DataSource = null;
                ProductDataGridView.DataSource = shoppingCart;
                ProductDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                ProductDataGridView.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                decimal preTotal = shoppingCart.Sum(x => x.Total_Price);
                PreTotalTextBox.Text = preTotal.ToString();
                SaleTaxTextBox.Text = "16";
                decimal totalAmount = decimal.Round(preTotal + (preTotal / 100) * 16, 2);
                TotalTextBox.Text = totalAmount.ToString();
                ProductComboBox.Focus();
                if (shoppingCart.Count == 0)
                {
                    InvoiceTextBox.Clear();
                    ProductDataGridView.DataSource = null;
                    ProductDataGridView.Columns.Remove("Sr_no");
                }
            }
        }

        private void UpdateQtyButton_Click(object sender, EventArgs e)
        {
            if (shoppingCart.Count > 0)
            {
                //find index of selected row
                int index = ProductDataGridView.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                UpdateForm upform = new UpdateForm();
                using (upform)
                {
                    upform.Currentqty = int.Parse(ProductDataGridView.Rows[index].Cells["Quantity"].Value.ToString());
                    upform.p_id = int.Parse(ProductDataGridView.Rows[index].Cells["ID"].Value.ToString());
                    upform.role = "cart";
                    upform.name = ProductDataGridView.Rows[index].Cells["Product_Name"].Value.ToString();
                    if (upform.ShowDialog() == DialogResult.OK)
                    {
                        ProductDataGridView.Rows[index].Cells["Quantity"].Value = upform.Updatedqty;
                        ProductDataGridView.Rows[index].Cells["Total_Price"].Value = int.Parse(ProductDataGridView.Rows[index].Cells["Quantity"].Value.ToString()) * decimal.Parse(ProductDataGridView.Rows[index].Cells["Price"].Value.ToString());
                        decimal preTotal = shoppingCart.Sum(x => x.Total_Price);
                        PreTotalTextBox.Text = preTotal.ToString();
                        SaleTaxTextBox.Text = "16";
                        decimal totalAmount = decimal.Round(preTotal + (preTotal / 100) * 16, 2);
                        TotalTextBox.Text = totalAmount.ToString();
                        ProductComboBox.Focus();
                    }
                }
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void CheckoutButton_Click(object sender, EventArgs e)
        {
            if (isvalided())
            {
                string name=CustomerTextBox.Text;
                string phone=PhoneTextBox.Text;
                string address=AddressTextBox.Text; 
                string dis=disTextBox.Text;
                string inv=InvoiceTextBox.Text;
                string pre=PreTotalTextBox.Text;
                string tax=SaleTaxTextBox.Text;
                decimal total=decimal.Parse(TotalTextBox.Text);
                DatabaseFile db= new DatabaseFile();
                db.orders(ProductDataGridView,InvoiceTextBox.Text);
                db.customers(name, phone, address, inv, dis,pre, tax,total);
                messagebox("Checkout Successfully");
                CheckoutButton.Enabled = false;
                //PreviewButton.Enabled=true;


                checkout_bool =true;
            }
        }

        private bool isvalided()
        {
            bool value = true;
            if (shoppingCart.Count < 1)
            {
                messagebox("Please Add item to Cart");
                ProductComboBox.Focus();
                return false;
            }
            if(CustomerTextBox.Text==string.Empty)
            {
                messagebox("Please Enter Customer Name");
                CustomerTextBox.Focus();
                return false;
            }
            else
            {
                int integercheak;
                bool isnumeric = int.TryParse(CustomerTextBox.Text.Trim(), out integercheak);
                if (isnumeric)
                {
                    messagebox("Please Enter Alphabet");
                    CustomerTextBox.Clear();
                    CustomerTextBox.Focus(); 
                    value = false;
                    return value;
                }
            }
            if(PhoneTextBox.Text==string.Empty)
            {
                messagebox("Please Enter Customer Phone Number");
                PhoneTextBox.Focus();
                return false;
            }
            else
            {
                Int64 integercheak;
                bool isnumeric = long.TryParse(PhoneTextBox.Text.Trim(), out integercheak);
                if (!isnumeric)
                {
                    messagebox("Please Enter Number Correctly");
                    PhoneTextBox.Clear();
                    PhoneTextBox.Focus();
                    value = false;
                    return value;
                }
            }
            return value;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            e.Graphics.DrawString("Costco Wholesale", new Font("Poppins", 26, FontStyle.Bold),
                Brushes.Black, 250, 70);
            e.Graphics.DrawString("0321-1153969 | CostcoWholesale@support.com", new Font("Arial", 10, FontStyle.Regular),
                Brushes.Black, 265, 110);
            e.Graphics.DrawString("Date : "+DateTime.Now.ToShortDateString(),new Font("Poppins",10,FontStyle.Regular),
                Brushes.Black,600,180);
            e.Graphics.DrawString("Invoice No : "+InvoiceTextBox.Text, new Font("Poppins", 10, FontStyle.Bold),
                Brushes.Black, 40,180);
            e.Graphics.DrawString("Customer Name  : " + CustomerTextBox.Text, new Font("Poppins", 10, FontStyle.Regular),
                Brushes.Black, 40, 210);
            e.Graphics.DrawString("Phone No  : " + PhoneTextBox.Text, new Font("Poppins", 10, FontStyle.Regular),
                Brushes.Black, 40, 240);
            e.Graphics.DrawString("------------------------------------------------" +
                "---------------------------" +
                "", new Font("Poppins", 14, FontStyle.Regular),
                Brushes.Black, 35, 270);
            e.Graphics.DrawString("ID", new Font("Poppins", 10, FontStyle.Regular),
                Brushes.Black, 40, 285);
            e.Graphics.DrawString("Item Name", new Font("Poppins", 10, FontStyle.Regular),
                Brushes.Black, 90, 285);
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
            foreach(var i in shoppingCart)
            {
                e.Graphics.DrawString(i.ID.ToString(), new Font("Poppins", 10, FontStyle.Regular),
                Brushes.Black, 40, Ypos);
                e.Graphics.DrawString(i.Product_Name, new Font("Poppins", 10, FontStyle.Regular),
                    Brushes.Black, 90, Ypos);
                e.Graphics.DrawString(i.Quantity.ToString(), new Font("Poppins", 10, FontStyle.Regular),
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
            e.Graphics.DrawString("Total Amount :   "+PreTotalTextBox.Text, new Font("Poppins", 12, FontStyle.Regular),
                Brushes.Black, 500, Ypos+=30);
            e.Graphics.DrawString("Sales Tax (16 %) : "+SaleTaxTextBox.Text, new Font("Poppins", 12, FontStyle.Regular),
                Brushes.Black, 500, Ypos +=30);
            e.Graphics.DrawString("Total Amount  :  Rs. "+TotalTextBox.Text
                , new Font("Poppins", 14, FontStyle.Bold),
                Brushes.Black, 500, Ypos+=30);
        }

        private void PreviewButton_Click(object sender, EventArgs e)
        {
            if (checkout_bool == true)
            {

            if(shoppingCart.Count > 0)
            {
                printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.ShowDialog();
                //PreviewButton.Enabled= false;
                
            }
            else
            {
                messagebox("Add Item to Cart");
                ProductComboBox.Focus();
            }
            }
            else
            {
                messagebox("Please First Checkout Then Preview");
                CheckoutButton.Focus();
                
            }
            
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            bool done=false;
            if (checkout_bool == true)
            {

                //printDocument1.Print();
                string invoices=InvoiceTextBox.Text;
                //string existingPathName = @"D:\PUCIT\Semester 4\Projects\Invoices";
                //string notExistingFileName = @"D:\PUCIT\Semester 4\Projects\Invoices\"+invoices+".pdf";
                string existingPathName = @"D:\PUCIT\Semester 4\Projects\Costco\Costco\Costco_Invoices";
                string notExistingFileName = @"D:\PUCIT\Semester 4\Projects\Costco\Costco\Costco_Invoices\" + invoices+".pdf";

                if (Directory.Exists(existingPathName) && !File.Exists(notExistingFileName))
                {

                    printDocument1.PrinterSettings.PrinterName = "Microsoft Print to PDF";
                    printDocument1.PrinterSettings.PrintFileName = notExistingFileName;
                    printDocument1.PrinterSettings.PrintToFile = true;
                   // printDocument1.PrintPage += pdoc_PrintPage;
                    printDocument1.Print();
                    done = true;
                }
                checkout_bool = false;
            }
            else
            {
                messagebox("Please First Checkout Then Preview");
                CheckoutButton.Focus();
            }
            if (done == true)
            {
                ProductComboBox.SelectedIndex = 0;
                ProductComboBox.Focus();
                QtyTextBox.Clear();
                CustomerTextBox.Clear();
                PhoneTextBox.Clear();
                AddressTextBox.Clear();
                disTextBox.Clear();
                ProductDataGridView.DataSource = null;
                ProductDataGridView.Columns.Remove("Sr_no");
                InvoiceTextBox.Clear();
                shoppingCart.Clear();
                PreTotalTextBox.Clear();
                SaleTaxTextBox.Clear();
                TotalTextBox.Clear();
                CheckoutButton.Enabled=true;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Inventory inventory = new Inventory();
            using (inventory)
            {
            inventory.ShowDialog();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            clients customers=new clients();
            using (customers)
            {
                customers.ShowDialog();
            }
        }

        private void ProductDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {

            ProductDataGridView.Rows[e.RowIndex].Cells["Sr_no"].Value = e.RowIndex+1;
            }catch (Exception ex)
            {
                messagebox("error");
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            SuppliersForm form = new SuppliersForm();
            
            using (form)
            {
                
                form.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState= FormWindowState.Minimized;
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            Employees employees = new Employees();
            using (employees)
            {
                employees.ShowDialog();
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Returns rn = new Returns();
            using (rn)
            {
                rn.ShowDialog();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Costco_Login form1 = new Costco_Login();
            using (form1)
            {

                form1.ShowDialog();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            using (form)
            {
                form.user = username;
                form.ShowDialog();
            }
        }
    }
}
