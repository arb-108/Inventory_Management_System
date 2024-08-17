using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Costco
{
    public partial class Costco_Login : Form
    {
        public Costco_Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            alertlabel.Hide();
            forgotlabel.Hide();
            usertextBox.Text = "Enter your Username";
            usertextBox.ForeColor = System.Drawing.Color.Gray;

            usertextBox.Enter += RemovePlaceholder;
            usertextBox.Leave += SetPlaceholder;
            passtextBox.Text = "Enter your Password";
            passtextBox.ForeColor = System.Drawing.Color.Gray;
            passtextBox.Enter += RemovePlaceholder2;
            passtextBox.Leave += SetPlaceholder2;
        }
        private void RemovePlaceholder(object sender, EventArgs e)
        {
            if (usertextBox.Text == "Enter your Username")
            {
                usertextBox.Text = "";
                usertextBox.ForeColor = System.Drawing.Color.Black;
            }
        }
        private void RemovePlaceholder2(object sender, EventArgs e)
        {
            if (passtextBox.Text == "Enter your Password")
            {
                passtextBox.Text = "";
                passtextBox.PasswordChar = '*';
                passtextBox.ForeColor = System.Drawing.Color.Black;
            }
        }
        private void SetPlaceholder2(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(passtextBox.Text))
            {
                passtextBox.PasswordChar = '\0';
                passtextBox.Text = "Enter your Password";
                passtextBox.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void SetPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usertextBox.Text))
            {
                usertextBox.Text = "Enter your Username";
                usertextBox.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //alertlabel.Show();
            if (isvalid())
            {
                DatabaseFile db= new DatabaseFile();
                bool check= db.check_login(usertextBox.Text,passtextBox.Text);
                if (!check)
                {
                    MainDashboard mainDashboard = new MainDashboard();
                    mainDashboard.username = usertextBox.Text;
                     mainDashboard.Show();
                      this.Hide();
                    
                }
                else
                {
                    alertlabel.Text = "Invalid Username";
                    alertlabel.Show();
                    forgotlabel.Show();
                    usertextBox.Text = "Enter your Username";
                    usertextBox.ForeColor = System.Drawing.Color.Gray;
                    passtextBox.Text = "Enter your Password";
                    passtextBox.PasswordChar= '\0';
                    passtextBox.ForeColor = System.Drawing.Color.Gray;

                    

                }
            }
        }

        private bool isvalid()
        {
            if(usertextBox.Text== "Enter your Username" || usertextBox.Text == string.Empty)
            {
                alertlabel.Text = "Enter Username";
                alertlabel.Show();
                return false;
                
            }
            if(passtextBox.Text == "Enter your Password" || passtextBox.Text == string.Empty)
            {
                alertlabel.Text = "Enter Password";
                alertlabel.Show();
                return false;
            }
            return true;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            using (form)
            {
                form.forgot = "outerpass";
                form.ShowDialog();
                if(form.DialogResult == DialogResult.OK)
                {
                    alertlabel.Hide();
                    forgotlabel.Hide();
                }
            }
        }
    }
}
