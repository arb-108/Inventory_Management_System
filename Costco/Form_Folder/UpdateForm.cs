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
    public partial class UpdateForm : Form
    {
        public UpdateForm()
        {
            InitializeComponent();
        }
        public int Currentqty { get; set; }
        public int Updatedqty { get; set; }
        public int p_id { get; set; }
        public string name { get; set; }
        bool form_closet = false;
        public string role { get; set; }

        int qty;

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            ItemNameTextBox.Text = name;
            QtyTextBox.Text=Currentqty.ToString();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (isvalide())
            {
                Updatedqty = int.Parse(QtyTextBox.Text);
                form_closet=false;
                
            }
            else
            {
                form_closet= true;
            }
        }

        private bool isvalide()
        {
            DatabaseFile db = new DatabaseFile();
            int id = p_id;
            
            if (role == "cart")
            {
             qty = db.FindQty(id);
            }
            
            if (QtyTextBox.Text == string.Empty)
            {
                messagebox("Enter Quantity Correctly !!!");
                QtyTextBox.Clear();
                QtyTextBox.Focus();
                form_closet = true;
                return false;
            }
            else
            {
                int integercheak;
                bool isnumeric = int.TryParse(QtyTextBox.Text.Trim(), out integercheak);
                if (isnumeric)
                {
                    
                    if (int.Parse(QtyTextBox.Text) > qty && role=="cart")
                    {
                        string msg = "Limited Stock !!! (Only " + qty.ToString() + " Items Left)";
                        messagebox(msg);
                        QtyTextBox.Clear();
                        QtyTextBox.Focus();
                        form_closet = true;
                        return false;
                    }
                    if (role == "stock")
                    {
                        int qty1=int.Parse(QtyTextBox.Text.Trim());
                        db.Editqty(id, qty1);
                    }
                }
                else
                {
                    messagebox("Please Enter Nummeric Value");
                    QtyTextBox.Clear();
                    QtyTextBox.Focus();
                    form_closet = true;
                    return false;
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

        private void UpdateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel=form_closet;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            form_closet=false;
            this.Close();
        }
    }
}
