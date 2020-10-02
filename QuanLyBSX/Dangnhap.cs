using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBSX
{
    public partial class Dangnhap : Form
    {
        Dataprovider data = new Dataprovider();
        public Dangnhap()
        {
            InitializeComponent();
        }

        public String nameserver()
        {
            if (cbboxChiNhanh.SelectedItem.ToString().Trim().Equals("TP. HCM"))
                return "DESKTOP-94L67MH";
            else if (cbboxChiNhanh.SelectedItem.ToString().Trim().Equals("Long An"))
                return "DESKTOP-94L67MH\\SERVER1PHANTAN";
            else
                return "DESKTOP-94L67MH\\SERVER2PHANTAN";
        }

        public static String server = "";
        public static String taikhoan = "";
        public static String matkhau = "";

        public void combobox()
        {
            cbboxChiNhanh.Items.Add("TP. HCM");
            cbboxChiNhanh.Items.Add("Long An");
            cbboxChiNhanh.Items.Add("Đồng Nai");
        }

        public Boolean kiemtratxt()
        {
            if (cbboxChiNhanh.SelectedIndex < 0 || txtMatKhau.Text.Equals("") || txtTaiKhoan.Text.Equals(""))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin để đăng nhập", "Thông báo");
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (kiemtratxt())
            {
                if (data.kiemtraketnoi(nameserver(), txtTaiKhoan.Text.Trim(), txtMatKhau.Text.Trim()))
                {
                    server = nameserver();
                    taikhoan = txtTaiKhoan.Text.Trim();
                    matkhau = txtMatKhau.Text.Trim();
                    Menu mn = new Menu();
                    mn.Show();
                    txtTaiKhoan.Text = "";
                    txtMatKhau.Text = "";
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đúng server, tài khoản, mật khẩu", "Thông báo");
                    return;
                }
            }
        }

        private void Dangnhap_Load(object sender, EventArgs e)
        {
            combobox();
            cbboxChiNhanh.SelectedIndex = 0;
        }


       
    }
}
