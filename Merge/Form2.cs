using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Merge
{
    public partial class Form2 : Form

    {
        private readonly string fileName = "XMLFile1.xml";
        public Form2()
        {
            InitializeComponent();
        }



        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            string username = txtName.Text;
            string password = txtPass.Text;

            if (ktra(username, password))
            {
                Form1 form1 = new Form1();
                form1.Show();


            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại. Vui lòng kiểm tra tên đăng nhập và mật khẩu.");
            }
        }

        private bool ktra(string username, string password)
        {
            XDocument doc = XDocument.Load(fileName);

            var user = doc.Descendants("User")
                          .FirstOrDefault(u => u.Element("Username").Value == username &&
                                               u.Element("Password").Value == password);

            return user != null;
        }
    }
}
