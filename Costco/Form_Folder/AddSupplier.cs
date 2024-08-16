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
    public partial class AddSupplier : Form
    {
        public AddSupplier()
        {
            InitializeComponent();
        }
        bool cancel_karu= false;
        string SupplierId;
        private void button1_Click(object sender, EventArgs e)
        {
            cancel_karu = false;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cancel_karu=false;
            this.Close();
        }

        private void Save_button_Click(object sender, EventArgs e)
        {
            if (isvalid())
            {
                String id=IDBox.Text;
                String company=CompanytextBox.Text; 
                String name=nameTextbox.Text;
                String category=categorytextbox.Text;
                String email=emailTextbox.Text;
                String phone=phonetextBox.Text;
                String address=addresstextBox.Text;
                DatabaseFile db=new DatabaseFile();
                db.AddSupplier(id,company,name,category,email,phone,address);
                cancel_karu=false ;
                this.Close();
            }

        }
        private bool isvalid()
        {
            bool value = true;
            if (emailTextbox.Text == string.Empty)
            {
                messagebox("Please Enter Email");
                emailTextbox.Clear();
                emailTextbox.Focus();
                cancel_karu = true;
                value = false;
                return value;
            }
            if (categorytextbox.Text == string.Empty)
            {
                messagebox("Please Enter Category");
                categorytextbox.Clear();
                categorytextbox.Focus();
                value = false;
                cancel_karu = true;
                return value;
            }
            else
            {
                int integercheak;
                bool isnumeric = int.TryParse(categorytextbox.Text.Trim(), out integercheak);
                if (isnumeric)
                {
                    messagebox("Please Enter Category Correctly");
                    categorytextbox.Clear();
                    categorytextbox.Focus();
                    cancel_karu=true;
                    value = false;
                    return value;
                }
            }
            if (nameTextbox.Text == string.Empty)
            {
                messagebox("Please Enter Category");
                nameTextbox.Clear();
                nameTextbox.Focus();
                cancel_karu = true;
                value = false;
                return value;
            }
            else
            {
                int integercheak;
                bool isnumeric = int.TryParse(nameTextbox.Text.Trim(), out integercheak);
                if (isnumeric)
                {
                    messagebox("Please Enter Category Correctly");
                    nameTextbox.Clear();
                    nameTextbox.Focus();
                    cancel_karu=true;
                    value = false;
                    return value;
                }
            }
            if (CompanytextBox.Text == string.Empty)
            {
                messagebox("Please Enter Company Name");
                CompanytextBox.Clear();
                CompanytextBox.Focus();
                cancel_karu = true;
                value = false;
                return value;
            }
            if (addresstextBox.Text == string.Empty)
            {
                messagebox("Please Enter Company Address");
                addresstextBox.Clear();
                addresstextBox.Focus();
                cancel_karu=true;
                value = false;
                return value;
            }
            if (phonetextBox.Text == string.Empty)
            {
                messagebox("Please Enter Company Phone Number");
                phonetextBox.Clear();
                phonetextBox.Focus();
                value = false;
                cancel_karu = true;
                return value;
            }
            else
            {
                Int64 integercheak;
                bool isnumeric = long
                    .TryParse(phonetextBox.Text.Trim(), out integercheak);
                if (!isnumeric)
                {
                    messagebox("Please Enter Numeric Value");
                    phonetextBox.Clear();
                    phonetextBox.Focus();
                    value = false;
                    cancel_karu=true;
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

        private void AddSupplier_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = cancel_karu;
        }

        private void AddSupplier_Load(object sender, EventArgs e)
        {
            DatabaseFile db= new DatabaseFile();
            SupplierId = db.FindSupplierID();
            int intval = int.Parse(SupplierId.Substring(2, 4));
            intval++;
            IDBox.Text = string.Format("S-{0:0000}", intval);
            CompanytextBox.Focus();
        }
    }
}
