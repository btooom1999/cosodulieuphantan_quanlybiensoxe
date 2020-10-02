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
    public partial class QuanLyCanBo : Form
    {
        Dataprovider data = new Dataprovider();

        public QuanLyCanBo()
        {
            InitializeComponent();
        }

        public void ketnoicsdl()
        {
            SqlDataAdapter da = data.getDa(Dangnhap.server, Dangnhap.taikhoan, Dangnhap.matkhau, "select * from tt_canbo");
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            data.close();
        }

        public void themdulieuvaocombobox()
        {
            SqlDataAdapter da = data.getDa(Dangnhap.server, Dangnhap.taikhoan, Dangnhap.matkhau, "select * from phong_dangky");
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbboxDonVi.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                cbboxDonVi.Items.Add(row["tendonvi_dangky"]);
            }
            data.close();
        }

        public String madonvi(String dieukien)
        {
            SqlDataAdapter da = data.getDa(Dangnhap.server, Dangnhap.taikhoan, Dangnhap.matkhau, "select * from phong_dangky where tendonvi_dangky = N'" + dieukien + "'");
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                return row["madonvi_dangky"].ToString().Trim();
            }
            data.close();
            return "";
        }

        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thêm?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                String macb = txtMaCB.Text.Trim();
                String cmnd = txtCMND.Text.Trim();
                String diachicb = txtDiaChiCB.Text.Trim();
                String ngaycap = txtNgayCap.Text.Trim();
                String sdtcb = txtSDTCanbo.Text.Trim();
                String tencb = txtTenCB.Text.Trim();
                String madv = cbboxDonVi.Text;
                String noicap = txtNoiCap.Text.Trim();
                String sql = "set dateformat dmy insert into tt_canbo (macanbo, madonvi_dangky, socmnd_canbo, tencanbo, diachi_canbo, sodt_canbo, ngaycap_cmnd_canbo, noicap_cmnd_canbo)" +
                " values ('" + macb + "','" + madonvi(madv) + "', '" + cmnd + "', N'" + tencb + "',N'" + diachicb + "','" + sdtcb + "','" + ngaycap + "', N'" + noicap + "')";
                data.themxoasua(Dangnhap.server, Dangnhap.taikhoan, Dangnhap.matkhau, sql);
                ketnoicsdl();
            }
        }

        private void btnXoaPhong_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                String macb = txtMaCB.Text.Trim();
                String sql = "delete from tt_canbo where macanbo = '" + macb + "'";
                data.themxoasua(Dangnhap.server, Dangnhap.taikhoan, Dangnhap.matkhau, sql);
                ketnoicsdl();
            }
        }

        private void btnSuaPhong_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn sửa?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                String macb = txtMaCB.Text.Trim();
                String cmnd = txtCMND.Text.Trim();
                String diachicb = txtDiaChiCB.Text.Trim();
                String ngaycap = txtNgayCap.Text.Trim();
                String sdtcb = txtSDTCanbo.Text.Trim();
                String tencb = txtTenCB.Text.Trim();
                String madv = cbboxDonVi.Text;
                String noicap = txtNoiCap.Text.Trim();
                String sql = "update tt_canbo set madonvi_dangky = '" + madonvi(madv) + "', socmnd_canbo = '" + cmnd + "', tencanbo = N'" + tencb + "', diachi_canbo = N'" + diachicb + "', sodt_canbo = '" + sdtcb + "', ngaycap_cmnd_canbo = '" + ngaycap + "', noicap_cmnd_canbo = N'" + noicap + "' where macanbo = '" + macb + "'";
                data.themxoasua(Dangnhap.server, Dangnhap.taikhoan, Dangnhap.matkhau, sql);
                ketnoicsdl();
            }
        }

        private void QuanLyCanBo_Load(object sender, EventArgs e)
        {
            ketnoicsdl();
            themdulieuvaocombobox();
            cbboxDonVi.SelectedIndex = 0;
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn đúng cột hoặc dòng để hiện thông tin", "Thông báo");
                return;
            }

            txtMaCB.Text = dataGridView1.Rows[e.RowIndex].Cells["MACANBO"].FormattedValue.ToString().Trim();
            txtCMND.Text = dataGridView1.Rows[e.RowIndex].Cells["SOCMND_CANBO"].FormattedValue.ToString().Trim();
            txtDiaChiCB.Text = dataGridView1.Rows[e.RowIndex].Cells["DIACHI_CANBO"].FormattedValue.ToString().Trim();
            txtNgayCap.Text = dataGridView1.Rows[e.RowIndex].Cells["NGAYCAP_CMND_CANBO"].FormattedValue.ToString().Trim();
            txtSDTCanbo.Text = dataGridView1.Rows[e.RowIndex].Cells["SODT_CANBO"].FormattedValue.ToString().Trim();
            txtTenCB.Text = dataGridView1.Rows[e.RowIndex].Cells["TENCANBO"].FormattedValue.ToString().Trim();
            String madonvi = dataGridView1.Rows[e.RowIndex].Cells["MADONVI_DANGKY"].FormattedValue.ToString().Trim();
            if (madonvi.Equals("DVDK1"))
                cbboxDonVi.SelectedIndex = 0;
            else if (madonvi.Equals("DVDK2"))
                cbboxDonVi.SelectedIndex = 1;
            else
                cbboxDonVi.SelectedIndex = 2;
        }

        private void cbboxDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbboxDonVi.SelectedItem.ToString().Trim().Equals("Ðơn Vị Ðăng Ký Số 1"))
                txtNoiCap.Text = "CA TP.HCM";
            else if (cbboxDonVi.SelectedItem.ToString().Trim().Equals("Ðơn Vị Ðăng Ký Số 2"))
                txtNoiCap.Text = "CA Long An";
            else
                txtNoiCap.Text = "CA Đồng Nai";
        }
    } 
}
