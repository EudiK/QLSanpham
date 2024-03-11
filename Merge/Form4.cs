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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {

            // Đường dẫn đến tệp XML chứa thông tin tài khoản
            string xmlFilePath = "C:\\Users\\kindl\\source\\repos\\QLSanpham\\Merge\\XML\\nhanvien\\nhanvien.xml";

            // Tên người dùng và mật khẩu từ các trường nhập liệu trên giao diện
            string username = txtTaiKhoan.Text;
            string password = txtMatKhau.Text;

            // Tạo một đối tượng XmlDocument để đọc dữ liệu từ tệp XML
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(xmlFilePath);

                // Lấy danh sách các phần tử <TaiKhoan> từ tệp XML
                XmlNodeList accountNodes = xmlDoc.SelectNodes("nhanvien");

                // Kiểm tra thông tin tài khoản và mật khẩu
                foreach (XmlNode node in accountNodes)
                {
                    XmlNode usernameNode = node.SelectSingleNode("taikhoan");
                    XmlNode passwordNode = node.SelectSingleNode("matkhau");

                    if (usernameNode.InnerText == username && passwordNode.InnerText == password)
                    {
                        // Nếu thông tin tài khoản và mật khẩu hợp lệ, đóng form hiện tại và thoát khỏi phương thức
                        this.Hide();
                        Form1 form1 = new Form1();
                        form1.Show();
                        return;
                    }
                }

                // Nếu không tìm thấy tài khoản hoặc mật khẩu không chính xác, hiển thị thông báo lỗi
                MessageBox.Show("Tên người dùng hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc tệp XML: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
