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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string user { get; set; }
        public string forgot { get; set; }
        bool cancel_karo=false;
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (forgot == "outerpass")
            {
                userTextbox.ReadOnly=false;
                userTextbox.Focus();

            }
            else
            {

            userTextbox.Text= user;
            }
            alertlabel.Hide();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cancel_karo = false;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cancel_karo=false ;
            this.Close();
        }

        private void Save_button_Click(object sender, EventArgs e)
        {
            if (isvalid())
            {
                if (!check_old())
                {
                    //match ho gya e
                    DatabaseFile db= new DatabaseFile();
                    db.change_old_pass(userTextbox.Text,oldpasstextBox.Text,newpasstextBox.Text);
                    messagebox("Change Password Successfully");
                    cancel_karo = false;
                }
                else
                {
                    cancel_karo=true;
                    alertlabel.Text = "Old Password not Match";
                    alertlabel.Show();
                    oldpasstextBox.Clear();
                    newpasstextBox.Clear();
                    confirmtextBox.Clear();
                    oldpasstextBox.Focus();
                    //nahi hoya match
                   
                }
            }
        }

        private bool isvalid()
        {
            if (oldpasstextBox.Text == string.Empty)
            {
                messagebox("Enter Old Password");
                cancel_karo=true;
                oldpasstextBox.Focus();
                return false;
            }
            if(newpasstextBox.Text== string.Empty) 
            {
                messagebox("Enter New Password");
                cancel_karo = true;
                newpasstextBox.Focus();
                return false;
            }
            if(confirmtextBox.Text == string.Empty)
            {
                messagebox("Enter Confirm Password");
                cancel_karo = true;
                confirmtextBox.Focus();
                return false;
            }
            if(confirmtextBox.Text!=newpasstextBox.Text) 
            {
                alertlabel.Text = "Confirm Password not Match";
                alertlabel.Show();
                confirmtextBox.Clear();
                confirmtextBox.Focus();
                cancel_karo = true;
                return false;
            }
            return true;
        }

        private bool check_old()
        {
            //false matlab hai
            DatabaseFile db=new DatabaseFile();
            bool check_pass = db.check_change_pass(userTextbox.Text, oldpasstextBox.Text);
            return check_pass;
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = cancel_karo;
        }
    }
}
