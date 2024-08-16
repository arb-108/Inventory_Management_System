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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        bool form_close=false;
        private void button1_Click(object sender, EventArgs e)
        {
            form_close = false;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            form_close=false;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isvalid())
            {
                int id = int.Parse(IDBox.Text);
                string category=CategorycomboBox.Text;
                string name =nameTextbox.Text;
                decimal price = decimal.Parse(Pricetextbox.Text);
                int qty=int.Parse(quantityTextbox.Text);

                DatabaseFile db= new DatabaseFile();
                db.AddProduct(id, category, name, price, qty);
                messagebox("Succesfully Add New Product");
                form_close = false;

            }
            else
            {
                form_close=true;
            }
        }

        private bool isvalid()
        {
            bool value = true;
            if (IDBox.Text == string.Empty)
            {
                messagebox("Enter Product ID");
                IDBox.Focus();
                return false;
            }
            else
            {
                int integercheak;
                bool isnumeric = int.TryParse(IDBox.Text.Trim(), out integercheak);
                if (!isnumeric)
                {
                    messagebox("Please Enter Numeric Value");
                    IDBox.Clear();
                    IDBox.Focus();
                    value = false;
                    return value;
                }
                else
                {
                    bool check;
                    DatabaseFile db=new DatabaseFile();
                    check=db.verifyId(int.Parse(IDBox.Text.Trim()));
                    if (check == false)
                    {
                        messagebox("This ID Already Exist");
                        IDBox.Clear();
                        IDBox.Focus();
                        value = false;
                        return value;
                    }
                }
                
            }
            if (CategorycomboBox.SelectedIndex == 0)
            {
                messagebox("Please Select Category");
                CategorycomboBox.Focus();
                value = false;
                return value;
            }
            if(nameTextbox.Text == string.Empty)
            {
                messagebox("Please Enter Product Name");
                nameTextbox.Clear();
                nameTextbox.Focus();
                value = false;
                return value;
            }
            if(Pricetextbox.Text == string.Empty)
            {
                messagebox("Please Enter Price");
                Pricetextbox.Clear();
                Pricetextbox.Focus();
                value = false;
                return value;
            }
            else
            {
                int integercheak;
                bool isnumeric = int.TryParse(Pricetextbox.Text.Trim(), out integercheak);
                if (!isnumeric)
                {
                    messagebox("Please Enter Numeric Value");
                    Pricetextbox.Clear();
                    Pricetextbox.Focus();
                    value = false;
                    return value;
                }
            }
            if(quantityTextbox.Text == string.Empty)
            {
                messagebox("Please Enter Quantity");
                quantityTextbox.Clear();
                quantityTextbox.Focus();
                value = false;
                return value;
            }
            else
            {
                int integercheak;
                bool isnumeric = int.TryParse(quantityTextbox.Text.Trim(), out integercheak);
                if (!isnumeric)
                {
                    messagebox("Please Enter Numeric Value");
                    quantityTextbox.Clear();
                    quantityTextbox.Focus();
                    value = false;
                    return value;
                }
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

        private void Form3_Load(object sender, EventArgs e)
        {
            IDBox.Focus();
            CategorycomboBox.SelectedIndex = 0;
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel=form_close;
        }
    }
}
