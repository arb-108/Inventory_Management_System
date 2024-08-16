using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Costco
{
    public partial class Add_Employee : Form
    {
        public Add_Employee()
        {
            InitializeComponent();
        }
        bool cancel_karu = false;
        bool check = false;

        private void button1_Click(object sender, EventArgs e)
        {
            cancel_karu=false;
            this.Close();
        }

        private void Save_button_Click(object sender, EventArgs e)
        {
            if (isvalid())
            {
                int id = int.Parse(IDBox.Text);
                string name=nameTextbox.Text;
                string job=jobTextbox.Text;
                string dept=cheakdepartment(deptcomboBox.Text);
                string phone=phonetextBox.Text;
                int salary=int.Parse(salarytextBox.Text);
                string hiredate=dateTimePicker.Text;
                string email=emailTextbox.Text;
                byte[] photo = savephoto();
                DatabaseFile db= new DatabaseFile();    
                db.addemp(id, name, job, dept, phone, salary, hiredate, email,photo);
                messagebox("ok ho gya");
                cancel_karu=false;
                this.Close();
            }
        }
        private byte[] savephoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }
        private bool isvalid()
        {
            bool value = true;
            if (nameTextbox.Text == string.Empty)
            {
                messagebox("Please Enter Name");
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
                    messagebox("Please Enter Name Correctly");
                    nameTextbox.Clear();
                    nameTextbox.Focus();
                    cancel_karu = true;
                    value = false;
                    return value;
                }
            }
            if (jobTextbox.Text == string.Empty)
            {
                messagebox("Please Enter Job Tilte");
                jobTextbox.Clear();
                jobTextbox.Focus();
                cancel_karu = true;
                value = false;
                return value;
            }
            else
            {
                int integercheak;
                bool isnumeric = int.TryParse(jobTextbox.Text.Trim(), out integercheak);
                if (isnumeric)
                {
                    messagebox("Please Enter Job Title Correctly");
                    jobTextbox.Clear();
                    jobTextbox.Focus();
                    cancel_karu = true;
                    value = false;
                    return value;
                }
            }
            if (deptcomboBox.SelectedIndex == 0)
            {
                messagebox("Please Select Department");
                deptcomboBox.Focus();
                value = false;
                cancel_karu = true;
                return value;

            }
            if(dateTimePicker.Text == string.Empty)
            {
                messagebox("Please Select Hire Date");
                dateTimePicker.Focus();
                value = false;
                cancel_karu = true;
                return value;
            }
            if (salarytextBox.Text == string.Empty)
            {
                messagebox("Please Enter Salary");
                salarytextBox.Clear();
                salarytextBox.Focus();
                value = false;
                cancel_karu = true;
                return value;
            }
            else
            {
                Int64 integercheak;
                bool isnumeric = long
                    .TryParse(salarytextBox.Text.Trim(), out integercheak);
                if (!isnumeric)
                {
                    messagebox("Please Enter Numeric Value");
                    salarytextBox.Clear();
                    salarytextBox.Focus();
                    value = false;
                    cancel_karu = true;
                    return value;
                }
            }
            if (emailTextbox.Text == string.Empty)
            {
                messagebox("Please Enter Email");
                emailTextbox.Clear();
                emailTextbox.Focus();
                cancel_karu = true;
                value = false;
                return value;
            }
            if (phonetextBox.Text == string.Empty)
            {
                messagebox("Please Enter  Phone Number");
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
                    cancel_karu = true;
                    return value;
                }
            }
            if (check == false)
            {
                messagebox("Please Select Picture");
                pictureBox1.Focus();
                value = false;
                cancel_karu = true;
                return value;
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

        private void button3_Click(object sender, EventArgs e)
        {
            cancel_karu=false;
            this.Close();
        }

        private void Add_Employee_Load(object sender, EventArgs e)
        {
            DatabaseFile db = new DatabaseFile();
            int id=int.Parse(db.Find_max_emp_id())+1;
            IDBox.Text=id.ToString();
            deptcomboBox.SelectedIndex = 0;
        }
        private string cheakdepartment(string department)
        {
            switch (department)
            {
                case "Administration":
                    return "10";
                case "Marketing":
                    return "100";
                case "Purchasing":
                    return "110";
                case "Human Resources":
                    return "20";
                case "Shipping":
                    return "30";
                case "IT":
                    return "40";
                case "Public Relations":
                    return "50";
                case "Sales":
                    return "60";
                case "Executive":
                    return "70";
                case "Finance":
                    return "90";
                default:
                    return "60";
            }
        }

        private void Add_Employee_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel=cancel_karu;
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select the Picture";
            ofd.Filter = "Image File (*.png;*.jpg;*.bmp;*.gif)|*.png;*.jpg;*.bmp;*.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
                check = true;
            }
            else
            {
                check = false;
            }
        }
    }
}
