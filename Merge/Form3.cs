using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Merge
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private const string filePath = "C:\\Users\\FPT\\source\\repos\\XML_BTL\\XML_BTL\\XML\\TaiKhoan\\TaiKhoan.xml";
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string taiKhoan = txtThemTK.Text;
            string matKhau = txtThemMK.Text;
            string xacNhanMatKhau = txtXacNhanMK.Text;

            // Kiểm tra điều kiện đăng ký
            if (taiKhoan.Length < 6 || matKhau.Length < 6)
            {
                MessageBox.Show("Tài khoản và mật khẩu phải dài hơn 6 kí tự.");
                return;
            }
            else if (matKhau != xacNhanMatKhau)
            {
                MessageBox.Show("Xác nhận mật khẩu không khớp.");
                return;
            }
            else if (!KiemTraTonTaiTaiKhoan(taiKhoan))
            {
                MessageBox.Show("Tài khoản đã tồn tại. Vui lòng chọn tài khoản khác.");
                return;
            }
            else
            {

                // Thêm tài khoản mới vào tệp XML
                ThemTaiKhoanVaoXML(taiKhoan, matKhau);

                // Hiển thị form 2 và đóng form 3
                Form2 form2 = new Form2();
                form2.Show();
                this.Close();
            }
        }
        public static bool KiemTraTonTaiTaiKhoan(string taiKhoan)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);

            XmlNodeList accountNodes = xmlDoc.SelectNodes("/QLTK/TaiKhoan");

            foreach (XmlNode node in accountNodes)
            {
                XmlNode usernameNode = node.SelectSingleNode("taikhoan");
                if (usernameNode.InnerText == taiKhoan)
                {
                    // Nếu tìm thấy tài khoản trùng, trả về false
                    return false;
                }
            }
            return true;
        }

        public static void ThemTaiKhoanVaoXML(string taiKhoan, string matKhau)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);

            XmlNode userNode = xmlDoc.CreateElement("TaiKhoan");

            XmlNode usernameNode = xmlDoc.CreateElement("taikhoan");
            usernameNode.InnerText = taiKhoan;

            XmlNode passwordNode = xmlDoc.CreateElement("matkhau");
            passwordNode.InnerText = matKhau;

            userNode.AppendChild(usernameNode);
            userNode.AppendChild(passwordNode);

            xmlDoc.DocumentElement.AppendChild(userNode);

            // Lưu thay đổi vào tệp XML
            xmlDoc.Save(filePath);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
