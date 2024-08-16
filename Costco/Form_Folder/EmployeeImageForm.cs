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
    public partial class EmployeeImageForm : Form
    {
        public EmployeeImageForm()
        {
            InitializeComponent();
        }
        public byte[] image { get; set; }
        public string EmpName { get; set; }
        public string EmpId { get; set; }
        private void EmployeeImageForm_Load(object sender, EventArgs e)
        {
            pictureBox1.Image=getphoto(image);
            idtextBox.Text=EmpId;
            nametextBox.Text=EmpName;
        }
        private Image getphoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
