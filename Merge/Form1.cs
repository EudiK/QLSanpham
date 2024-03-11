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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // String storeLap = "C:\\Users\\kindl\\source\\repos\\QLSanpham\\Merge\\XML";
        static String storePC = @"C:\Users\Admin\source\repos\merge\Merge\XML";
        XmlDocument hd_doc = new XmlDocument();
        XmlElement hd_root;
        //khanh
        string hd_fileName = storePC + @"\hoadon\hoadon.xml";
        //thai
        string QLSPFileName = storePC + @"\sanpham\sanpham.xml";
        //huy
        String fileName = storePC + @"\nhanvien\nhanvien.xml";
        //tuananh
        String khfileName = storePC + @"\khachhang\khachhang.xml";
        //quang
        string qfileName = storePC + @"\nhaphang\nhaphang.xml";
        //manh
        XmlDocument  kh_doc = new XmlDocument(), sp_doc = new XmlDocument();
        XmlElement  kh_root, sp_root;
        string
            kh_fileName = storePC + @"\khachhang\khachhang.xml"
        , sp_fileName = storePC + @"\sanpham\sanpham.xml";

        private void hd_them_Click(object sender, EventArgs e)
        {
            hd_doc.Load(QLSPFileName);
            hd_root = hd_doc.DocumentElement;

            XmlNodeList listsp = hd_root.SelectNodes("SanPham");

            foreach(XmlNode node in listsp)
            {
                if (node.SelectSingleNode("@MaHang").Value.ToString() == txt_hd_masp.Text)
                {
                    int row = hd_grid.RowCount;
                                hd_grid.Rows.Add();


                                hd_grid.Rows[row].Cells[0].Value = txt_hd_masp.Text;
                                hd_grid.Rows[row].Cells[1].Value = node.SelectSingleNode("TenHang").InnerText;
                                hd_grid.Rows[row].Cells[2].Value = txt_hd_sl.Text;
                    if (txt_hd_dg.Text == "")
                    {
                        hd_grid.Rows[row].Cells[3].Value = node.SelectSingleNode("DonGia").InnerText;
                    }
                    else
                    {
                        hd_grid.Rows[row].Cells[3].Value = txt_hd_dg.Text;
                    }
                                
                                hd_grid.Rows[row].Cells[4].Value = Double.Parse(txt_hd_sl.Text) * Double.Parse(node.SelectSingleNode("DonGia").InnerText);

                                Double tong = 0;
                                for (int i = 0; i <= row; i++)
                                {
                                    tong += double.Parse(hd_grid.Rows[i].Cells[4].Value.ToString());

                                }

                                txt_hd_tongtien.Text = tong.ToString();
                    txt_hd_noti.ForeColor = Color.Black;
                    txt_hd_noti.Text = "Thêm thành công!";

                    return;
                }
                
            }
            txt_hd_noti.ForeColor = Color.Red;
            txt_hd_noti.Text = "Không tồn tại sản phẩm!";


        }

        private void hd_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = hd_grid.CurrentCell.RowIndex;
            txt_hd_masp.Text = hd_grid.Rows[i].Cells[0].Value.ToString();
            txt_hd_tensp.Text = hd_grid.Rows[i].Cells[1].Value.ToString();
            txt_hd_sl.Text = hd_grid.Rows[i].Cells[2].Value.ToString();
            txt_hd_dg.Text = hd_grid.Rows[i].Cells[3].Value.ToString();
        }

        private void hd_sua_Click(object sender, EventArgs e)
        {
            int i = hd_grid.CurrentCell.RowIndex;
            hd_grid.Rows[i].Cells[0].Value = txt_hd_masp.Text;
            hd_grid.Rows[i].Cells[1].Value = txt_hd_tensp.Text;
            hd_grid.Rows[i].Cells[2].Value = txt_hd_sl.Text;
            hd_grid.Rows[i].Cells[3].Value = txt_hd_dg.Text;
            hd_grid.Rows[i].Cells[4].Value = Double.Parse(txt_hd_sl.Text) * Double.Parse(txt_hd_dg.Text);
        }

        private void hd_xoa_Click(object sender, EventArgs e)
        {
            int i = hd_grid.CurrentCell.RowIndex;
            hd_grid.Rows.RemoveAt(i);
        }

        private void hd_in_Click(object sender, EventArgs e)
        {
            if (hd_grid.RowCount == 0)
            {
                txt_hd_noti.ForeColor = Color.Red;
                txt_hd_noti.Text = "Không có sản phẩm trong giỏ hàng!";
                return;

            }

            hd_doc.Load(khfileName);
            hd_root = hd_doc.DocumentElement;

            XmlDocument spdoc = new XmlDocument();
            XmlElement spele;
            spdoc.Load(QLSPFileName);
            spele = spdoc.DocumentElement;

            XmlNodeList khList = hd_root.SelectNodes("KhachHang");
            foreach (XmlNode kh in khList)
            {
                if (txt_hd_kh.Text == kh.SelectSingleNode("@MaK").Value.ToString())
                {
                    hd_doc.Load(hd_fileName);
                    hd_root = hd_doc.DocumentElement;
                    string hoadon_next = "hd" + (hd_root.SelectNodes("hoadon").Count + 1).ToString();

                    XmlNode hoadon = hd_doc.CreateElement("hoadon");

                    XmlAttribute mahd = hd_doc.CreateAttribute("mahd");
                    mahd.Value = hoadon_next;
                    hoadon.Attributes.Append(mahd);

                    XmlNode khachhang = hd_doc.CreateElement("khachhang");
                    XmlAttribute makh = hd_doc.CreateAttribute("makh");
                    makh.Value = txt_hd_kh.Text;
                    khachhang.Attributes.Append(makh);

                    hoadon.AppendChild(khachhang);

                    int i = hd_grid.RowCount;

                    

                    

                    
                    for (int j = 0; j < i; j++)
                    {
                        XmlNode sanpham = hd_doc.CreateElement("sanpham");

                        XmlAttribute masp = hd_doc.CreateAttribute("masp");
                        masp.Value = hd_grid.Rows[j].Cells[0].Value.ToString();
                        sanpham.Attributes.Append(masp);

                        XmlNode nodeSp = spele.SelectSingleNode("SanPham[@MaHang='" + hd_grid.Rows[j].Cells[0].Value + "']");

                        XmlElement soluong_new = spdoc.CreateElement("SoLuong");
                        soluong_new.InnerText = (int.Parse(nodeSp.SelectSingleNode("SoLuong").InnerText) - int.Parse(hd_grid.Rows[j].Cells[2].Value.ToString())).ToString();
                        nodeSp.ReplaceChild(soluong_new, nodeSp.SelectSingleNode("SoLuong"));
                        spdoc.Save(QLSPFileName);

                        XmlElement tensp = hd_doc.CreateElement("tensp");
                        tensp.InnerText = hd_grid.Rows[j].Cells[1].Value.ToString();
                        sanpham.AppendChild(tensp);

                        XmlElement soluong = hd_doc.CreateElement("soluong");
                        soluong.InnerText = hd_grid.Rows[j].Cells[2].Value.ToString();
                        sanpham.AppendChild(soluong);

                        XmlElement dongia = hd_doc.CreateElement("dongia");
                        dongia.InnerText = hd_grid.Rows[j].Cells[3].Value.ToString();
                        sanpham.AppendChild(dongia);

                        hoadon.AppendChild(sanpham);


                    }


                    XmlElement ngaytao = hd_doc.CreateElement("ngaytao");
                    ngaytao.InnerText = DateTime.Now.ToString();
                    hoadon.AppendChild(ngaytao);

                    XmlElement tongtien = hd_doc.CreateElement("tongtien");
                    tongtien.InnerText = txt_hd_tongtien.Text;
                    hoadon.AppendChild(tongtien);

                    hd_root.AppendChild(hoadon);
                    hd_doc.Save(hd_fileName);
                    hd_grid.Rows.Clear();
                    return;
                }
                else if(txt_hd_kh.Text == "")
                {
                    hd_doc.Load(hd_fileName);
                    hd_root = hd_doc.DocumentElement;
                    string hoadon_next = "hd" + (hd_root.SelectNodes("hoadon").Count + 1).ToString();

                    XmlNode hoadon = hd_doc.CreateElement("hoadon");

                    XmlAttribute mahd = hd_doc.CreateAttribute("mahd");
                    mahd.Value = hoadon_next;
                    hoadon.Attributes.Append(mahd);

                    XmlNode khachhang = hd_doc.CreateElement("khachhang");
                    XmlAttribute makh = hd_doc.CreateAttribute("makh");
                    makh.Value = "none";
                    khachhang.Attributes.Append(makh);

                    hoadon.AppendChild(khachhang);

                    int i = hd_grid.RowCount;
                    for (int j = 0; j < i; j++)
                    {
                        XmlNode sanpham = hd_doc.CreateElement("sanpham");

                        XmlAttribute masp = hd_doc.CreateAttribute("masp");
                        masp.Value = hd_grid.Rows[j].Cells[0].Value.ToString();
                        sanpham.Attributes.Append(masp);

                        XmlNode nodeSp = spele.SelectSingleNode("SanPham[@MaHang='" + hd_grid.Rows[j].Cells[0].Value+"']");
                        if (nodeSp == null)
                        {
                            hd_grid.Rows.Add();
                            return;
                        }

                        XmlElement soluong_new = spdoc.CreateElement("SoLuong");
                        soluong_new.InnerText = (int.Parse(nodeSp.SelectSingleNode("SoLuong").InnerText) - int.Parse(hd_grid.Rows[j].Cells[2].Value.ToString())).ToString();
                        nodeSp.ReplaceChild(soluong_new, nodeSp.SelectSingleNode("SoLuong"));
                        spdoc.Save(QLSPFileName);

                        XmlElement tensp = hd_doc.CreateElement("tensp");
                        tensp.InnerText = hd_grid.Rows[j].Cells[1].Value.ToString();
                        sanpham.AppendChild(tensp);

                        XmlElement soluong = hd_doc.CreateElement("soluong");
                        soluong.InnerText = hd_grid.Rows[j].Cells[2].Value.ToString();
                        sanpham.AppendChild(soluong);

                        XmlElement dongia = hd_doc.CreateElement("dongia");
                        dongia.InnerText = hd_grid.Rows[j].Cells[3].Value.ToString();
                        sanpham.AppendChild(dongia);

                        hoadon.AppendChild(sanpham);


                    }


                    XmlElement ngaytao = hd_doc.CreateElement("ngaytao");
                    ngaytao.InnerText = DateTime.Now.ToString();
                    hoadon.AppendChild(ngaytao);

                    XmlElement tongtien = hd_doc.CreateElement("tongtien");
                    tongtien.InnerText = txt_hd_tongtien.Text;
                    hoadon.AppendChild(tongtien);

                    hd_root.AppendChild(hoadon);
                    hd_doc.Save(hd_fileName);
                    hd_grid.Rows.Clear();
                    return;
                }
            }
            txt_hd_noti.ForeColor = Color.Red;
            txt_hd_noti.Text = "Không tồn tại khách hàng!";

           

        }

        private void hienthidshoadon()
        {
            hd_grid_dshd.Rows.Clear();
            hd_doc.Load(hd_fileName);
            hd_root = hd_doc.DocumentElement;

            XmlNodeList ds = hd_root.SelectNodes("hoadon");


            int sd = 0;

            foreach (XmlNode item in ds)
            {


                hd_grid_dshd.Rows.Add();
                hd_grid_dshd.Rows[sd].Cells[0].Value = item.SelectSingleNode("@mahd").Value;
                hd_grid_dshd.Rows[sd].Cells[1].Value = item.SelectSingleNode("khachhang").SelectSingleNode("@makh").Value;
                hd_grid_dshd.Rows[sd].Cells[2].Value = item.SelectSingleNode("ngaytao").InnerText;
                hd_grid_dshd.Rows[sd].Cells[3].Value = item.SelectSingleNode("tongtien").InnerText;



                sd++;




            }
        }





        private void tabPage5_Click(object sender, EventArgs e)
        {

            hienthidshoadon();
        }

        private void hd_grid_dshd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int i = hd_grid_dshd.CurrentCell.RowIndex;

            string mahd = hd_grid_dshd.Rows[i].Cells[0].Value.ToString();

            hienthichitethoadon(mahd);
        }

        private void hienthichitethoadon(string mahd)
        {
            hd_grid_chitiet.Rows.Clear();
            hd_doc.Load(hd_fileName);
            hd_root = hd_doc.DocumentElement;
            XmlNode hoadonnode;

            hoadonnode = hd_root.SelectSingleNode("hoadon[@mahd='" + mahd + "']");
            XmlNodeList dssp;

            dssp = hoadonnode.SelectNodes("sanpham");



            int sd = 0;

            foreach (XmlNode item in dssp)
            {


                hd_grid_chitiet.Rows.Add();

                hd_grid_chitiet.Rows[sd].Cells[0].Value = item.SelectSingleNode("@masp").Value;
                hd_grid_chitiet.Rows[sd].Cells[1].Value = item.SelectSingleNode("tensp").InnerText;
                hd_grid_chitiet.Rows[sd].Cells[2].Value = item.SelectSingleNode("soluong").InnerText;
                hd_grid_chitiet.Rows[sd].Cells[3].Value = item.SelectSingleNode("dongia").InnerText;
                hd_grid_chitiet.Rows[sd].Cells[4].Value = (Double.Parse(item.SelectSingleNode("soluong").InnerText) + Double.Parse(item.SelectSingleNode("dongia").InnerText)).ToString();



                sd++;




            }
        }

        private void hd_grid_chitiet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = hd_grid_chitiet.CurrentCell.RowIndex;
            hd_masplb_label.Text = "Mã SP: " + hd_grid_chitiet.Rows[i].Cells[0].Value.ToString();
            hd_tensplb_label.Text = "Tên SP: " + hd_grid_chitiet.Rows[i].Cells[1].Value.ToString();
            txt_hd_soluongql.Text = hd_grid_chitiet.Rows[i].Cells[3].Value.ToString();
            txt_hd_dongiaql.Text = hd_grid_chitiet.Rows[i].Cells[3].Value.ToString();
        }

        private void hd_xoaspbtn_Click(object sender, EventArgs e)
        {
            hd_doc.Load(hd_fileName);
            hd_root = hd_doc.DocumentElement;

            int i = hd_grid_dshd.CurrentCell.RowIndex;
            int j = hd_grid_chitiet.CurrentCell.RowIndex;

            XmlNode nodeDel = hd_root.SelectSingleNode("hoadon[@mahd='" + hd_grid_dshd.Rows[i].Cells[0].Value + "']").
                SelectSingleNode("sanpham[@masp='" + hd_grid_chitiet.Rows[j].Cells[0].Value + "']");
            if (nodeDel != null)
            {
                hd_root.SelectSingleNode("hoadon[@mahd='" + hd_grid_dshd.Rows[i].Cells[0].Value + "']").RemoveChild(nodeDel);
                hd_doc.Save(hd_fileName);
            }

            hd_grid_chitiet.Rows.Clear();
            hienthichitethoadon(hd_grid_dshd.Rows[i].Cells[0].Value.ToString());

        }

        private void hd_timkiembtn_Click(object sender, EventArgs e)
        {
            hd_doc.Load(hd_fileName);
            hd_root = hd_doc.DocumentElement;
            hd_grid_dshd.Rows.Clear();
            if (hd_rbhoadon.Checked)
            {
                XmlNode nodeFind = hd_root.SelectSingleNode("hoadon[@mahd='" + txt_hd_timkiem.Text + "']");

                hd_grid_dshd.Rows.Add();
                hd_grid_dshd.Rows[0].Cells[0].Value = nodeFind.SelectSingleNode("@mahd").Value;
                hd_grid_dshd.Rows[0].Cells[1].Value = nodeFind.SelectSingleNode("khachhang").SelectSingleNode("@makh").Value;
                hd_grid_dshd.Rows[0].Cells[2].Value = nodeFind.SelectSingleNode("ngaytao").InnerText;
                hd_grid_dshd.Rows[0].Cells[3].Value = nodeFind.SelectSingleNode("tongtien").InnerText;
            }
            else if (hd_rbkh.Checked)
            {
                XmlNodeList nodeHoaDon = hd_root.SelectNodes("hoadon");
                int sd = 0;

                foreach (XmlNode xmlNode in nodeHoaDon)
                {
                    XmlNode node = xmlNode.SelectSingleNode("khachhang[@makh='" + txt_hd_timkiem.Text + "']");
                    if (node != null)
                    {
                        hd_grid_dshd.Rows.Add();
                        hd_grid_dshd.Rows[sd].Cells[0].Value = xmlNode.SelectSingleNode("@mahd").Value;
                        hd_grid_dshd.Rows[sd].Cells[1].Value = xmlNode.SelectSingleNode("khachhang").SelectSingleNode("@makh").Value;
                        hd_grid_dshd.Rows[sd].Cells[2].Value = xmlNode.SelectSingleNode("ngaytao").InnerText;
                        hd_grid_dshd.Rows[sd].Cells[3].Value = xmlNode.SelectSingleNode("tongtien").InnerText;
                        sd++;
                    }
                }


            }
        }

        private void hd_updatebtn_Click(object sender, EventArgs e)
        {
            hd_doc.Load(hd_fileName);
            hd_root = hd_doc.DocumentElement;

            int i = hd_grid_dshd.CurrentCell.RowIndex;
            int j = hd_grid_chitiet.CurrentCell.RowIndex;

            XmlNode nodeUpdate = hd_root.SelectSingleNode("hoadon[@mahd='" + hd_grid_dshd.Rows[i].Cells[0].Value + "']").
                SelectSingleNode("sanpham[@masp='" + hd_grid_chitiet.Rows[j].Cells[0].Value + "']");
            if (nodeUpdate != null)
            {
                XmlNode sanpham = hd_doc.CreateElement("sanpham");

                XmlAttribute masp = hd_doc.CreateAttribute("masp");
                masp.Value = hd_grid_chitiet.Rows[j].Cells[0].Value.ToString();
                sanpham.Attributes.Append(masp);


                XmlElement tensp = hd_doc.CreateElement("tensp");
                tensp.InnerText = hd_grid_chitiet.Rows[j].Cells[1].Value.ToString();
                sanpham.AppendChild(tensp);

                XmlElement soluong = hd_doc.CreateElement("soluong");
                soluong.InnerText = txt_hd_soluongql.Text;
                sanpham.AppendChild(soluong);

                XmlElement dongia = hd_doc.CreateElement("dongia");
                dongia.InnerText = txt_hd_dongiaql.Text;
                sanpham.AppendChild(dongia);

               


                hd_root.SelectSingleNode("hoadon[@mahd='" + hd_grid_dshd.Rows[i].Cells[0].Value + "']").ReplaceChild(sanpham,nodeUpdate);

                

                hd_doc.Save(hd_fileName);
            }

            hd_grid_chitiet.Rows.Clear();
            hienthichitethoadon(hd_grid_dshd.Rows[i].Cells[0].Value.ToString());

            double tonntien_new = 0;
            
                for (int z=0; z< hd_grid_chitiet.Rows.Count-1; z++ )
                {
                    tonntien_new += Double.Parse(hd_grid_chitiet.Rows[z].Cells[4].Value.ToString());
                }

            XmlElement tongtien = hd_doc.CreateElement("tongtien");
            tongtien.InnerText = tonntien_new.ToString();
            hd_root.SelectSingleNode("hoadon[@mahd='" + hd_grid_dshd.Rows[i].Cells[0].Value + "']").ReplaceChild(tongtien, 
                hd_root.SelectSingleNode("hoadon[@mahd='" + hd_grid_dshd.Rows[i].Cells[0].Value + "']").SelectSingleNode("tongtien"));
            hd_doc.Save(hd_fileName);

            hd_grid_dshd.Rows.Clear();
            hienthidshoadon();
        }

        //thai---------------------------------------------------------------------------------------------

        public void QLSPHienThi(DataGridView QLSPdgv)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root;
            

            doc.Load(QLSPFileName);
            root = doc.DocumentElement;

            XmlNodeList sp = root.SelectNodes("SanPham");
            int sd = 0;

            foreach (XmlNode item in sp)
            {
                QLSPdgv.Rows.Add();
                QLSPdgv.Rows[sd].Cells[0].Value = item.SelectSingleNode("@MaHang").Value;
                QLSPdgv.Rows[sd].Cells[1].Value = item.SelectSingleNode("TenHang").InnerText;
                QLSPdgv.Rows[sd].Cells[2].Value = item.SelectSingleNode("SoLuong").InnerText;
                QLSPdgv.Rows[sd].Cells[3].Value = item.SelectSingleNode("DonGia").InnerText;
                sd++;
            }
        }
        private void tabPage2_Click(object sender, EventArgs e)
        {
            QLSPHienThi(QLSPdgv);
        }

        private void QLSPbtnThem_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root;
            

            doc.Load(QLSPFileName);
            root = doc.DocumentElement;

            XmlNode sanpham = doc.CreateElement("SanPham");

            XmlAttribute mahang = doc.CreateAttribute("MaHang");
            mahang.Value = QLSPedtMaHang.Text;
            sanpham.Attributes.Append(mahang);

            XmlElement tenhang = doc.CreateElement("TenHang");
            tenhang.InnerText = QLSPedtTenHang.Text;
            sanpham.AppendChild(tenhang);

            XmlElement soluong = doc.CreateElement("SoLuong");
            soluong.InnerText = QLSPedtSoLuong.Text;
            sanpham.AppendChild(soluong);

            XmlElement dongia = doc.CreateElement("DonGia");
            dongia.InnerText = QLSPedtDonGia.Text;
            sanpham.AppendChild(dongia);

            root.AppendChild(sanpham);
            doc.Save(QLSPFileName);
            QLSPHienThi(QLSPdgv);
        }

        private void QLSPbtnSua_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root;
            

            doc.Load(QLSPFileName);
            root = doc.DocumentElement;
            XmlNode sanPhamCu = root.SelectSingleNode("SanPham[@MaHang ='" + QLSPedtMaHang.Text + "']");

            if (sanPhamCu != null)
            {
                XmlNode sanPhamSuaMoi = doc.CreateElement("SanPham");

                XmlAttribute mahang = doc.CreateAttribute("MaHang");
                mahang.Value = QLSPedtMaHang.Text;
                sanPhamSuaMoi.Attributes.Append(mahang);

                XmlElement tenhang = doc.CreateElement("TenHang");
                tenhang.InnerText = QLSPedtTenHang.Text;
                sanPhamSuaMoi.AppendChild(tenhang);

                XmlElement soluong = doc.CreateElement("SoLuong");
                soluong.InnerText = QLSPedtSoLuong.Text;
                sanPhamSuaMoi.AppendChild(soluong);

                XmlElement dongia = doc.CreateElement("DonGia");
                dongia.InnerText = QLSPedtDonGia.Text;
                sanPhamSuaMoi.AppendChild(dongia);

                root.ReplaceChild(sanPhamSuaMoi, sanPhamCu);
                doc.Save(QLSPFileName);
                QLSPHienThi(QLSPdgv);
            }
        }

        private void QLSPbtnXoa_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root;
            

            doc.Load(QLSPFileName);
            root = doc.DocumentElement;

            XmlNode sanPhamCanXoa = root.SelectSingleNode("SanPham[@MaHang ='" + QLSPedtMaHang.Text + "']");
            if (sanPhamCanXoa != null)
            {
                root.RemoveChild(sanPhamCanXoa);
                doc.Save(QLSPFileName);
            }
            QLSPdgv.Rows.Clear();
            QLSPHienThi(QLSPdgv);
        }

        private void QLSPdgv_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int t = QLSPdgv.CurrentRow.Index;
            QLSPedtMaHang.Text = QLSPdgv.Rows[t].Cells[0].Value.ToString();
            QLSPedtTenHang.Text = QLSPdgv.Rows[t].Cells[1].Value.ToString();
            QLSPedtSoLuong.Text = QLSPdgv.Rows[t].Cells[2].Value.ToString();
            QLSPedtDonGia.Text = QLSPdgv.Rows[t].Cells[3].Value.ToString();
        }

        private void QLSPbtnTimKiem_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root;
            

            doc.Load(QLSPFileName);
            root = doc.DocumentElement;

            QLSPdgv.Rows.Clear();
            XmlNode sanPhamCanTim = root.SelectSingleNode("SanPham[@MaHang ='" + QLSPedtTimKiem.Text.Trim() + "']");
            if (sanPhamCanTim != null)
            {
                QLSPdgv.Rows.Add();
                QLSPdgv.Rows[0].Cells[0].Value = sanPhamCanTim.SelectSingleNode("@MaHang").Value;
                QLSPdgv.Rows[0].Cells[1].Value = sanPhamCanTim.SelectSingleNode("TenHang").InnerText;
                QLSPdgv.Rows[0].Cells[2].Value = sanPhamCanTim.SelectSingleNode("SoLuong").InnerText;
                QLSPdgv.Rows[0].Cells[3].Value = sanPhamCanTim.SelectSingleNode("DonGia").InnerText;
            }
        }

        //tuananh=======================================================================================

        private void dataGridViewKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int t = dataGridViewKH.CurrentCell.RowIndex;
            txtMaKhach.Text = dataGridViewKH.Rows[t].Cells[0].Value.ToString();
            txtTenKH.Text = dataGridViewKH.Rows[t].Cells[1].Value.ToString();
            txtSDT.Text = dataGridViewKH.Rows[t].Cells[2].Value.ToString();
            txtDiaChi.Text = dataGridViewKH.Rows[t].Cells[3].Value.ToString();
        }


        XmlDocument xmlDoc = new XmlDocument();
        XmlElement root;
        private void tabPage4_Click(object sender, EventArgs e)
        {
            HienThi(dataGridViewKH);
        }

        
        public void HienThi(DataGridView dataGridViewKH)
        {
            xmlDoc.Load(khfileName);//load tep xml
            root = xmlDoc.DocumentElement;//xac dinh node goc
            XmlNodeList ds = root.SelectNodes("KhachHang");
            int sd = 0;
            foreach (XmlNode item in ds)
            {
                dataGridViewKH.Rows.Add();
                dataGridViewKH.Rows[sd].Cells[0].Value = item.SelectSingleNode("@MaK").Value;
                dataGridViewKH.Rows[sd].Cells[1].Value = item.SelectSingleNode("tenKhach").InnerText;
                dataGridViewKH.Rows[sd].Cells[2].Value = item.SelectSingleNode("SDT").InnerText;
                dataGridViewKH.Rows[sd].Cells[3].Value = item.SelectSingleNode("diaChi").InnerText;
                sd++;
            }
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            xmlDoc.Load(khfileName);//load tep xml
            root = xmlDoc.DocumentElement;//xac dinh node goc
            // Kiểm tra tên khách hàng
            if (string.IsNullOrWhiteSpace(txtTenKH.Text) || !char.IsUpper(txtTenKH.Text[0]))
            {
                MessageBox.Show("Thêm không thành công. Tên khách hàng không được rỗng và phải bắt đầu bằng chữ hoa.");
                return;
            }

            // Kiểm tra số điện thoại
            if (txtSDT.Text.Length != 10 || txtSDT.Text[0] != '0' || !txtSDT.Text.All(char.IsDigit))
            {
                MessageBox.Show("Thêm không thành công. Số điện thoại phải có 10 chữ số và bắt đầu bằng số 0.");
                return;
            }

            // Kiểm tra địa chỉ
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text) || !char.IsUpper(txtDiaChi.Text[0]))
            {
                MessageBox.Show("Thêm không thành công. Địa chỉ không được rỗng và phải bắt đầu bằng chữ hoa.");
                return;
            }
            XmlNode khachhang = xmlDoc.CreateElement("KhachHang");

            XmlAttribute masach = xmlDoc.CreateAttribute("MaK");
            masach.Value = txtMaKhach.Text;
            khachhang.Attributes.Append(masach);

            XmlElement tenKhach = xmlDoc.CreateElement("tenKhach");
            tenKhach.InnerText = txtTenKH.Text;
            khachhang.AppendChild(tenKhach);

            XmlElement sdt = xmlDoc.CreateElement("SDT");
            sdt.InnerText = txtSDT.Text;
            khachhang.AppendChild(sdt);

            XmlElement diachi = xmlDoc.CreateElement("diaChi");
            diachi.InnerText = txtDiaChi.Text;
            khachhang.AppendChild(diachi);

            root.AppendChild(khachhang);
            xmlDoc.Save(khfileName);
            HienThi(dataGridViewKH);
        }
        private void View_MouseClick(object sender, MouseEventArgs e)
        {
            int t = dataGridViewKH.CurrentCell.RowIndex;
            txtMaKhach.Text = dataGridViewKH.Rows[t].Cells[0].Value.ToString();
            txtTenKH.Text = dataGridViewKH.Rows[t].Cells[1].Value.ToString();
            txtSDT.Text = dataGridViewKH.Rows[t].Cells[2].Value.ToString();
            txtDiaChi.Text = dataGridViewKH.Rows[t].Cells[3].Value.ToString();
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            xmlDoc.Load(khfileName);// load tệp xml
            root = xmlDoc.DocumentElement;// xác định node gốc
            //láy vị trí cần sửa theo mã sách cũ đưa vào

            XmlNode khachCu = root.SelectSingleNode("KhachHang[@MaK ='" + txtMaKhach.Text + "']");

            if (khachCu != null)
            {

                XmlNode khachSuaMoi = xmlDoc.CreateElement("KhachHang");

                XmlAttribute makhach = xmlDoc.CreateAttribute("MaK");
                makhach.InnerText = txtMaKhach.Text;//gán giá trị cho mã sách
                khachSuaMoi.Attributes.Append(makhach);

                XmlElement tensach = xmlDoc.CreateElement("tenKhach");
                tensach.InnerText = txtTenKH.Text;
                khachSuaMoi.AppendChild(tensach);

                XmlElement soluong = xmlDoc.CreateElement("SDT");
                soluong.InnerText = txtSDT.Text;
                khachSuaMoi.AppendChild(soluong);

                XmlElement dongia = xmlDoc.CreateElement("diaChi");
                dongia.InnerText = txtDiaChi.Text;
                khachSuaMoi.AppendChild(dongia);


                root.ReplaceChild(khachSuaMoi, khachCu);
                xmlDoc.Save(khfileName);//lưu lại
                HienThi(dataGridViewKH);

            }
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            xmlDoc.Load(khfileName);// load tệp xml

            root = xmlDoc.DocumentElement;// xác định node gốc

            XmlNode khachCanXoa = root.SelectSingleNode("KhachHang[@MaK ='" + txtMaKhach.Text + "']");
            if (khachCanXoa != null)
            {
                root.RemoveChild(khachCanXoa);
                xmlDoc.Save(khfileName);
            }
            dataGridViewKH.Rows.Clear();
            HienThi(dataGridViewKH);
        }

        private void btnTimKiemKH_Click(object sender, EventArgs e)
        {
            dataGridViewKH.Rows.Clear();
            XmlNode khachCanTim = root.SelectSingleNode("KhachHang[@MaK ='" + txtMaKhach.Text.Trim() + "']");
            XmlNode tenKCanTim = root.SelectSingleNode("KhachHang[tenKhach ='" + txtTenKH.Text.Trim() + "']");
            if (khachCanTim != null)
            {
                dataGridViewKH.Rows[0].Cells[0].Value = khachCanTim.SelectSingleNode("@MaK").InnerText;
                dataGridViewKH.Rows[0].Cells[1].Value = khachCanTim.SelectSingleNode("tenKhach").InnerText;
                dataGridViewKH.Rows[0].Cells[2].Value = khachCanTim.SelectSingleNode("SDT").InnerText;
                dataGridViewKH.Rows[0].Cells[3].Value = khachCanTim.SelectSingleNode("diaChi").InnerText;
            }
            if (tenKCanTim != null)
            {
                dataGridViewKH.Rows[0].Cells[0].Value = tenKCanTim.SelectSingleNode("@MaK").InnerText;
                dataGridViewKH.Rows[0].Cells[1].Value = tenKCanTim.SelectSingleNode("tenKhach").InnerText;
                dataGridViewKH.Rows[0].Cells[2].Value = tenKCanTim.SelectSingleNode("SDT").InnerText;
                dataGridViewKH.Rows[0].Cells[3].Value = tenKCanTim.SelectSingleNode("diaChi").InnerText;
            }
        }

        //HUY ===========================================================================================================

        XmlDocument doc = new XmlDocument();
        XmlElement root_nv;
       


        public void Hienthi(DataGridView dgv)
        {
            doc.Load(fileName);
            root_nv = doc.DocumentElement;
            XmlNodeList dsnv = root_nv.SelectNodes("Nhanvien");
            int index = 0;
            foreach (XmlNode xn in dsnv)
            {
                dgv.Rows.Add();
                dgv.Rows[index].Cells[0].Value = xn.SelectSingleNode("@MaNV").Value;
                dgv.Rows[index].Cells[1].Value = xn.SelectSingleNode("Hoten").InnerText;
                dgv.Rows[index].Cells[2].Value = xn.SelectSingleNode("Diachi").InnerText;
                dgv.Rows[index].Cells[3].Value = xn.SelectSingleNode("Gioitinh").InnerText;
                dgv.Rows[index].Cells[4].Value = xn.SelectSingleNode("Namsinh").InnerText;
                dgv.Rows[index].Cells[5].Value = xn.SelectSingleNode("Sdt").InnerText;
                index++;
            }
        }
      
        private void btn_themnv_Click(object sender, EventArgs e)
        {
            doc.Load(fileName);
            root_nv = doc.DocumentElement;
            XmlNode nhanvien = doc.CreateElement("Nhanvien");

            XmlAttribute Manv = doc.CreateAttribute("MaNV");
            Manv.Value = txtManv.Text;
            nhanvien.Attributes.Append(Manv);

            XmlElement hoten = doc.CreateElement("Hoten");
            hoten.InnerText = txtHotennv.Text;
            nhanvien.AppendChild(hoten);

            XmlElement diachi = doc.CreateElement("Diachi");
            diachi.InnerText = txtDiachinv.Text;
            nhanvien.AppendChild(diachi);

            XmlElement gioitinh = doc.CreateElement("Gioitinh");
            gioitinh.InnerText = txtGioitinhnv.Text;
            nhanvien.AppendChild(gioitinh);

            XmlElement namsinh = doc.CreateElement("Namsinh");
            namsinh.InnerText = txtNamsinhnv.Text;
            nhanvien.AppendChild(namsinh);

            XmlElement sdt = doc.CreateElement("Sdt");
            sdt.InnerText = txtSdtnv.Text;
            nhanvien.AppendChild(sdt);

            root_nv.AppendChild(nhanvien);
            doc.Save(fileName);
            nv_dataGridView1.Rows.Clear();
            Hienthi(nv_dataGridView1);
        }



        private void Form1_Load_1(object sender, EventArgs e)
        {
            Hienthi(nv_dataGridView1);
        }

        private void nv_dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            int id = nv_dataGridView1.CurrentRow.Index;
            txtManv.Text = nv_dataGridView1.Rows[id].Cells[0].Value.ToString();
            txtHotennv.Text = nv_dataGridView1.Rows[id].Cells[1].Value.ToString();
            txtDiachinv.Text = nv_dataGridView1.Rows[id].Cells[2].Value.ToString();
            txtGioitinhnv.Text = nv_dataGridView1.Rows[id].Cells[3].Value.ToString();
            txtNamsinhnv.Text = nv_dataGridView1.Rows[id].Cells[4].Value.ToString();
            txtSdtnv.Text = nv_dataGridView1.Rows[id].Cells[5].Value.ToString();
        }

        private void btn_suanv_Click(object sender, EventArgs e)
        {
            doc.Load(fileName);
            root_nv = doc.DocumentElement;
            XmlNode nhanviencu = root_nv.SelectSingleNode("Nhanvien[@MaNV='" + txtManv.Text + "']");
            if (nhanviencu != null)
            {

                XmlNode nhanvienmoi = doc.CreateElement("Nhanvien");
                XmlAttribute Manv = doc.CreateAttribute("MaNV");
                Manv.Value = txtManv.Text;
                nhanvienmoi.Attributes.Append(Manv);

                XmlElement hoten = doc.CreateElement("Hoten");
                hoten.InnerText = txtHotennv.Text;
                nhanvienmoi.AppendChild(hoten);

                XmlElement diachi = doc.CreateElement("Diachi");
                diachi.InnerText = txtDiachinv.Text;
                nhanvienmoi.AppendChild(diachi);

                XmlElement gioitinh = doc.CreateElement("Gioitinh");
                gioitinh.InnerText = txtGioitinhnv.Text;
                nhanvienmoi.AppendChild(gioitinh);

                XmlElement namsinh = doc.CreateElement("Namsinh");
                namsinh.InnerText = txtNamsinhnv.Text;
                nhanvienmoi.AppendChild(namsinh);

                XmlElement sdt = doc.CreateElement("Sdt");
                sdt.InnerText = txtSdtnv.Text;
                nhanvienmoi.AppendChild(sdt);

                root_nv.ReplaceChild(nhanvienmoi, nhanviencu);
                doc.Save(fileName);
                nv_dataGridView1.Rows.Clear();
                Hienthi(nv_dataGridView1);
            }
            else MessageBox.Show("ko co");

        }

        private void btn_xoanv_Click(object sender, EventArgs e)
        {
            doc.Load(fileName);
            root_nv = doc.DocumentElement;
            XmlNode nhanvien = root_nv.SelectSingleNode("Nhanvien[@MaNV='" + txtManv.Text + "']");
            if (nhanvien != null)
            {
                root_nv.RemoveChild(nhanvien);
                doc.Save(fileName); nv_dataGridView1.Rows.Clear(); Hienthi(nv_dataGridView1);
                MessageBox.Show("Xoa thanh cong");

            }
            else
            {
                MessageBox.Show("Khong tim thay");
            }
        }

        private void tabPage7_Click(object sender, EventArgs e)
        {
            Hienthi(nv_dataGridView1);
        }

        //Quang=======================================================================================
        
        XmlElement QLSP3;
        

        private void tabPage3_Click(object sender, EventArgs e)
        {

            HienThi3(dgv);

        }
        public void HienThi3(DataGridView dgv)
        {
            doc.Load(qfileName);
            QLSP3 = doc.DocumentElement;
            XmlNodeList ds = QLSP3.SelectNodes("SP3");
            int sd = 0;
            foreach (XmlNode node in ds)
            {
                dgv.Rows.Add();
                dgv.Rows[sd].Cells[0].Value = node.SelectSingleNode("maSP3").InnerText;
                dgv.Rows[sd].Cells[1].Value = node.SelectSingleNode("tenSP3").InnerText;
                dgv.Rows[sd].Cells[2].Value = node.SelectSingleNode("SL3").InnerText;
                dgv.Rows[sd].Cells[3].Value = node.SelectSingleNode("DG3").InnerText;
                sd++;
            }
        }

       

        private void dgv_MouseClick(object sender, MouseEventArgs e)
        {
            int i = dgv.CurrentCell.RowIndex;
            txtMaSP3.Text = dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
            txtTenSP3.Text = dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
            txtSL3.Text = dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
            txtDonGia.Text = dgv.Rows[i].Cells[3].Value?.ToString() ?? "";
        }

        private void btTK3_Click(object sender, EventArgs e)
        {
            if (txtTK3.Text == "") MessageBox.Show("Vui lòng nhập thứ bạn muốn tìm");
            else if (rdoMH3.Checked)
            {
                dgv.Rows.Clear();
                XmlNode TK3 = QLSP3.SelectSingleNode("SP3[maSP3 ='" + txtTK3.Text.Trim().ToLower() + "']");
                if (TK3 != null)
                {
                    // dgv.Rows.Add();//thêm một dòng mới
                    //đưa dữ liệu vào dòng vừa tạo
                    dgv.Rows[0].Cells[0].Value = TK3.SelectSingleNode("maSP3").InnerText;
                    dgv.Rows[0].Cells[1].Value = TK3.SelectSingleNode("tenSP3").InnerText;
                    dgv.Rows[0].Cells[2].Value = TK3.SelectSingleNode("SL3").InnerText;
                    dgv.Rows[0].Cells[3].Value = TK3.SelectSingleNode("DG3").InnerText;
                }
                else { MessageBox.Show("không có thứ bạn muốn tìm "); }

            }
            else if (rdoTH3.Checked)
            {
                dgv.Rows.Clear();
                string searchText = txtTK3.Text.Trim().ToLower(); // Chuyển về chữ thường

                // Sử dụng XPath chính xác để tìm kiếm
                XmlNode TK31 = QLSP3.SelectSingleNode($"SP3[translate(tenSP3, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') = '{searchText}']");

                if (TK31 != null)
                {
                    dgv.Rows.Add();
                    dgv.Rows[0].Cells[0].Value = TK31.SelectSingleNode("maSP3").InnerText;
                    dgv.Rows[0].Cells[1].Value = TK31.SelectSingleNode("tenSP3").InnerText;
                    dgv.Rows[0].Cells[2].Value = TK31.SelectSingleNode("SL3").InnerText;
                    dgv.Rows[0].Cells[3].Value = TK31.SelectSingleNode("DG3").InnerText;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm bạn muốn tìm.");
                }
            }

            else
            {
                MessageBox.Show("Vui lòng chọn Mã hàng hoặc Tên Hàng");
            }
        }

        private void btXong3_Click(object sender, EventArgs e)
        {
            doc.Load(qfileName);// load tệp xml
            QLSP3 = doc.DocumentElement;

            string maSP = txtMaSP3.Text.Trim();
            string soLuongThem = txtSLT3.Text.Trim();
            XmlNode SPNode = QLSP3.SelectSingleNode($"//SP3[maSP3='{maSP}']");
            if (SPNode != null)
            {
                // Nếu mã sản phẩm đã tồn tại, cộng số lượng mới vào số lượng hiện có
                int soLuongHienCo = int.Parse(SPNode.SelectSingleNode("SL3").InnerText);
                int soLuongMoi = int.Parse(soLuongThem);
                int tongSoLuong = soLuongHienCo + soLuongMoi;
                SPNode.SelectSingleNode("SL3").InnerText = tongSoLuong.ToString();
                doc.Save(qfileName);//lưu dữ liệu
                HienThi3(dgv);
            }
            else
            {
                // Nếu mã sản phẩm chưa tồn tại, thêm sản phẩm mới vào tập tin XML
                XmlNode SP3 = doc.CreateElement("SP3");
                XmlElement maSP3 = doc.CreateElement("maSP3");
                maSP3.InnerText = txtMaSP3.Text;//gán giá trị trên ô textbox txtMS cho node mã sách
                SP3.AppendChild(maSP3);// gán node masach là node con của node sach

                XmlElement tenSP3 = doc.CreateElement("tenSP3");// tạo 1 element node ten sach
                tenSP3.InnerText = txtTenSP3.Text;// gán giá trị trên ô textbox txttenS cho node tensach
                SP3.AppendChild(tenSP3);//gán node ténach là node con của node sach

                XmlElement SL3 = doc.CreateElement("SL3");
                SL3.InnerText = txtSL3.Text;
                SP3.AppendChild(SL3);

                XmlElement DG3 = doc.CreateElement("DG3");
                DG3.InnerText = txtDonGia.Text;
                SP3.AppendChild(DG3);

                //sau khi tạo xong node sach, thì thêm sach vào gốc root
                QLSP3.AppendChild(SP3);
                doc.Save(qfileName);//lưu dữ liệu
                HienThi3(dgv);


            }
        }

        

        

        private void tabPage1_Click(object sender, EventArgs e)
        {
            txt_hd_noti.Text = "";
            txt_hd_noti.ForeColor = Color.Black;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        




        //manh======================================================================
        private void btnTK_DoanhThu_Click(object sender, EventArgs e)
        {
            lbTK_content.Text = "Doanh thu theo ngày";
            List<(DateTime, int)> DoanhThu = new List<(DateTime, int)>();

            hd_doc.Load(hd_fileName);
            hd_root = hd_doc.DocumentElement;
            XmlNodeList DSHoaDon = hd_root.SelectNodes("hoadon");

            int n = DSHoaDon.Count;
            int j = 0;
            DoanhThu.Add((DateTime.Parse(DSHoaDon[0].SelectSingleNode("ngaytao").InnerText).Date, 0));

            for (int i = 0; i < n; i++)
            {
                DateTime currentDate = DateTime.Parse(DSHoaDon[i].SelectSingleNode("ngaytao").InnerText);
                int tongtien = int.Parse(DSHoaDon[i].SelectSingleNode("tongtien").InnerText.ToString());
                if (DoanhThu[j].Item1 != currentDate.Date)
                {
                    j++;
                    DoanhThu.Add((currentDate.Date, 0));
                }
                DoanhThu[j] = (currentDate.Date, tongtien + DoanhThu[j].Item2);
            }

            DataTable tb = new DataTable();
            tb.Columns.Add("Ngày");
            tb.Columns.Add("Doanh thu");

            for (int i = 0; i <= j; i++)
            {
                DataRow row = tb.NewRow();
                row["Ngày"] = DoanhThu[i].Item1;
                row["Doanh thu"] = DoanhThu[i].Item2;
                tb.Rows.Add(row);
            }
            dgvTK.DataSource = tb;
        }
        private void btnTK_KhachMuaNhieu_Click(object sender, EventArgs e)
        {
            lbTK_content.Text = "Khách hàng mua nhiều trong tháng " + DateTime.Now.Month;
            Dictionary<String, int> KhachPaid = new Dictionary<string, int>();

            kh_doc.Load(kh_fileName);
            kh_root = kh_doc.DocumentElement;
            XmlNodeList DSKH = kh_root.SelectNodes("KhachHang");

            hd_doc.Load(hd_fileName);
            hd_root = hd_doc.DocumentElement;
            XmlNodeList DSHoaDon = hd_root.SelectNodes("hoadon");

            int n = DSHoaDon.Count;

            for (int i = 0; i < n; i++)
            {
                if (DateTime.Parse(DSHoaDon[i].SelectSingleNode("ngaytao").InnerText).Month == DateTime.Now.Month)
                {
                    String maK = DSHoaDon[i].SelectSingleNode("khachhang").SelectSingleNode("@makh").Value;
                    int tongtien = int.Parse(DSHoaDon[i].SelectSingleNode("tongtien").InnerText);
                    if (KhachPaid.ContainsKey(maK))
                    {
                        KhachPaid[maK] += tongtien;
                    }
                    else
                    {
                        KhachPaid.Add(maK, tongtien);
                    }
                }

            }

            DataTable tb = new DataTable();
            tb.Columns.Add("Mã khách");
            tb.Columns.Add("Tên khách");
            tb.Columns.Add("Địa chỉ");
            tb.Columns.Add("SDT");
            tb.Columns.Add("Tổng tiền");
            foreach (var item in KhachPaid.OrderByDescending(kv => kv.Value).ToDictionary(kv => kv.Key, kv => kv.Value))
            {
                DataRow row = tb.NewRow();
                row["Mã khách"] = item.Key;
                row["Tổng tiền"] = item.Value;
                foreach (XmlNode KH in DSKH)
                {
                    if (KH.SelectSingleNode("@MaK").Value.ToLower() == item.Key.ToLower())
                    {
                        row["Tên khách"] = KH.SelectSingleNode("tenKhach").InnerText;
                        row["Địa chỉ"] = KH.SelectSingleNode("diaChi").InnerText;
                        row["SDT"] = KH.SelectSingleNode("SDT").InnerText;
                    }
                }
                tb.Rows.Add(row);
            }

            dgvTK.DataSource = tb;
        }

        private void btnTK_HangBanCHay_Click(object sender, EventArgs e)
        {
            lbTK_content.Text = "Hàng bán chạy";
            Dictionary<String, int> SLHangBan = new Dictionary<string, int>();

            sp_doc.Load(sp_fileName);
            sp_root = sp_doc.DocumentElement;
            XmlNodeList DSSP = sp_root.SelectNodes("SanPham");

            hd_doc.Load(hd_fileName);
            hd_root = hd_doc.DocumentElement;
            XmlNodeList DSHoaDon = hd_root.SelectNodes("hoadon");

            foreach (XmlNode HoaDon in DSHoaDon)
            {
                if (DateTime.Parse(HoaDon.SelectSingleNode("ngaytao").InnerText).Month == DateTime.Now.Month)
                {
                    XmlNodeList SPs = HoaDon.SelectNodes("sanpham");
                    foreach (XmlNode SP in SPs)
                    {
                        String maSP = SP.SelectSingleNode("@masp").Value;
                        int SLsp = int.Parse(SP.SelectSingleNode("soluong").InnerText);
                        if (SLHangBan.ContainsKey(maSP))
                        {
                            SLHangBan[maSP] += SLsp;
                        }
                        else SLHangBan.Add(maSP, SLsp);
                    }
                }
            }


            DataTable tb = new DataTable();
            tb.Columns.Add("Mã SP");
            tb.Columns.Add("Tên SP");
            tb.Columns.Add("Giá");
            tb.Columns.Add("SL đã bán");

            foreach (var item in SLHangBan.OrderByDescending(kv => kv.Value).ToDictionary(kv => kv.Key, kv => kv.Value))
            {
                DataRow row = tb.NewRow();
                row["Mã SP"] = item.Key;
                row["SL đã bán"] = item.Value;
                foreach (XmlNode sp in DSSP)
                {
                    if (sp.SelectSingleNode("@MaHang").Value == item.Key)
                    {
                        row["Tên SP"] = sp.SelectSingleNode("TenHang").InnerText;
                        row["Giá"] = sp.SelectSingleNode("DonGia").InnerText;
                    }
                }
                tb.Rows.Add(row);
            }
            dgvTK.DataSource = tb;

        }
    }
}
