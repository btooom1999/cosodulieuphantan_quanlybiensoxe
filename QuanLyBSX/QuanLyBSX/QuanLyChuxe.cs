using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyBSX
{
    public partial class QuanLyChuXe : Form
    {

        public QuanLyChuXe()
        {
            InitializeComponent();
        }

        Dataprovider data = new Dataprovider();

        public void ketnoicsdl()
        {
            SqlDataAdapter da = data.getDa(Dangnhap.server, Dangnhap.taikhoan, Dangnhap.matkhau, "select * from tt_chuxe");
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            data.close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thêm?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                String cmnd = txtCMND.Text.Trim();
                String tenchuxe = txtChuXe.Text.Trim();
                String diachi = txtDiaChi.Text.Trim();
                String sdt = txtSDT.Text.Trim();
                String ngaycap = txtNgayCap.Text.Trim();
                String noicap = cbboxNoiCap.SelectedItem.ToString().Trim();
                String sql = "set dateformat dmy insert into tt_chuxe(SOCMND_CHUXE, TENCHUXE, DIACHI_CHUXE, SODT_CHUXE, NGAYCAP_CMND_CHUXE, NOICAP_CMND_CHUXE)" +
                 " values('"+cmnd+"', N'"+tenchuxe+"', N'"+diachi+"', '"+sdt+"', '"+ngaycap+"', N'"+noicap+"')";
                data.themxoasua(Dangnhap.server, Dangnhap.taikhoan, Dangnhap.matkhau, sql);
                ketnoicsdl();
            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn sửa?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                String cmnd = txtCMND.Text.Trim();
                String tenchuxe = txtChuXe.Text.Trim();
                String diachi = txtDiaChi.Text.Trim();
                String sdt = txtSDT.Text.Trim();
                String ngaycap = txtNgayCap.Text.Trim();
                String noicap = cbboxNoiCap.SelectedItem.ToString().Trim();
                String sql = "set dateformat dmy update tt_chuxe set tenchuxe = N'"+tenchuxe+"', diachi_chuxe = N'"+diachi+"', sodt_chuxe = '"+sdt+"', ngaycap_cmnd_chuxe = '"+ngaycap+"', noicap_cmnd_chuxe = N'"+noicap+"' where socmnd_chuxe = '"+cmnd+"'";
                data.themxoasua(Dangnhap.server, Dangnhap.taikhoan, Dangnhap.matkhau, sql);
                ketnoicsdl();
            }           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn đúng cột hoặc dòng để hiện thông tin", "Thông báo");
                return;
            }

            txtChuXe.Text = dataGridView1.Rows[e.RowIndex].Cells["TENCHUXE"].FormattedValue.ToString();
            txtCMND.Text = dataGridView1.Rows[e.RowIndex].Cells["SOCMND_CHUXE"].FormattedValue.ToString();
            txtDiaChi.Text = dataGridView1.Rows[e.RowIndex].Cells["DIACHI_CHUXE"].FormattedValue.ToString();
            txtNgayCap.Text = dataGridView1.Rows[e.RowIndex].Cells["NGAYCAP_CMND_CHUXE"].FormattedValue.ToString();
            cbboxNoiCap.Text = dataGridView1.Rows[e.RowIndex].Cells["NOICAP_CMND_CHUXE"].FormattedValue.ToString();
            txtSDT.Text = dataGridView1.Rows[e.RowIndex].Cells["SODT_CHUXE"].FormattedValue.ToString();           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xoá?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                String cmnd = txtCMND.Text.Trim();
                String sql = "delete from tt_chuxe where socmnd_chuxe = '"+cmnd+"'";
                data.themxoasua(Dangnhap.server, Dangnhap.taikhoan, Dangnhap.matkhau, sql);
                ketnoicsdl();
            }
        }

        public void loaddulieucombobox()
        {
            SqlDataAdapter da = data.getDa(Dangnhap.server, Dangnhap.taikhoan, Dangnhap.matkhau, "select distinct noicap_cmnd_chuxe from tt_chuxe");
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbboxNoiCap.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                cbboxNoiCap.Items.Add(row["NOICAP_CMND_CHUXE"].ToString().Trim());
            }
            data.close();
        }

        private void QuanLyChuXe_Load(object sender, EventArgs e)
        {
            ketnoicsdl();
            loaddulieucombobox();
            cbboxNoiCap.SelectedIndex = 0;
        }     
    }
}
