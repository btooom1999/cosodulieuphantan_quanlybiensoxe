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
    public partial class LapDonDangKy : Form
    {
        
        public LapDonDangKy()
        {
            InitializeComponent();
        }

        Dataprovider data = new Dataprovider();

        public void ketnoicsdl()
        {
            SqlDataAdapter da = data.getDa(Dangnhap.server, Dangnhap.taikhoan, Dangnhap.matkhau, "select * from don_dangky");
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            data.close();
        }

        public void loaddulieucombobox()
        {
            SqlDataAdapter da = data.getDa(Dangnhap.server, Dangnhap.taikhoan, Dangnhap.matkhau, "select * from tt_canbo");
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbboxTenCanBo.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                cbboxTenCanBo.Items.Add(row["tencanbo"]);
            }
            data.close();
        }

        public String timtencanbo(String dieukien)
        {
            SqlDataAdapter da = data.getDa(Dangnhap.server, Dangnhap.taikhoan, Dangnhap.matkhau, "select * from tt_canbo where macanbo = '" + dieukien + "'");
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                return row["tencanbo"].ToString().Trim();
            }
            data.close();
            return "";
        }

        public String macanbo() {
            SqlDataAdapter da = data.getDa(Dangnhap.server, Dangnhap.taikhoan, Dangnhap.matkhau, "select * from tt_canbo where tencanbo = N'" + cbboxTenCanBo.SelectedItem.ToString().Trim() + "'");
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                return row["macanbo"].ToString().Trim();
            }
            data.close();
            return "";
        }

        private void LapDonDangKy_Load(object sender, EventArgs e)
        {
            ketnoicsdl();
            loaddulieucombobox();
            cbboxTenCanBo.SelectedIndex = 0;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex + 2 >= dataGridView2.RowCount)
            {
                MessageBox.Show("Vui lòng chọn đúng dòng để hiện thông tin", "Thông báo");
                return;
            }

            txtBiensocu.Text = dataGridView2.Rows[e.RowIndex].Cells["BIENSO_CU"].FormattedValue.ToString().Trim();
            txtBiensomoi.Text = dataGridView2.Rows[e.RowIndex].Cells["BIENSO_MOI"].FormattedValue.ToString().Trim();
            txtCMNDChuxe.Text = dataGridView2.Rows[e.RowIndex].Cells["SOCMND_CHUXE"].FormattedValue.ToString().Trim();
            txtLoaiDK.Text = dataGridView2.Rows[e.RowIndex].Cells["LOAIDANGKY"].FormattedValue.ToString().Trim();
            txtLydoDKY.Text = dataGridView2.Rows[e.RowIndex].Cells["LYDODANGKY"].FormattedValue.ToString().Trim();
            String macanbo = dataGridView2.Rows[e.RowIndex].Cells["MACANBO"].FormattedValue.ToString().Trim();
            cbboxTenCanBo.Text = timtencanbo(macanbo);
            String ngaydk = dataGridView2.Rows[e.RowIndex].Cells["NGAYDANGKY"].FormattedValue.ToString().Trim();
            String converngaydk = Convert.ToDateTime(ngaydk).ToString("dd-MM-yyyy");
            txtNgayDK.Value = DateTime.ParseExact(converngaydk, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            txtSoMay.Text = dataGridView2.Rows[e.RowIndex].Cells["SOMAY"].FormattedValue.ToString().Trim();
            txtSoKhung.Text = dataGridView2.Rows[e.RowIndex].Cells["SOKHUNG"].FormattedValue.ToString().Trim();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thêm?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                String bienso_moi = txtBiensomoi.Text.Trim();
                String socmnd_chuxe = txtCMNDChuxe.Text.Trim();
                String somay = txtSoMay.Text.Trim();
                String sokhung = txtSoKhung.Text.Trim();
                String lydodangky = txtLydoDKY.Text.Trim();
                String ngaydangky = txtNgayDK.Text.Trim();
                String bienso_cu = txtBiensocu.Text.Trim();
                String loaidangky = txtLoaiDK.Text.Trim();
                String sql = "set dateformat dmy insert into don_dangky (bienso_moi, macanbo, socmnd_chuxe, somay, sokhung, lydodangky, ngaydangky, bienso_cu, loaidangky)" +
                    " values ('"+bienso_moi+"', '"+macanbo().Trim()+"', '"+socmnd_chuxe+"', '"+somay+"', '"+sokhung+"', N'"+lydodangky+"', '"+ngaydangky+"', '"+bienso_cu+"', N'"+bienso_moi+"')";
                data.themxoasua(Dangnhap.server, Dangnhap.taikhoan, Dangnhap.matkhau, sql);
                ketnoicsdl();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                String bienso_moi = txtBiensomoi.Text.Trim();
                String sql = "delete from don_dangky where bienso_moi = '"+bienso_moi+"'";
                data.themxoasua(Dangnhap.server, Dangnhap.taikhoan, Dangnhap.matkhau, sql);
                ketnoicsdl();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn sửa?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                String bienso_moi = txtBiensomoi.Text.Trim();
                String socmnd_chuxe = txtCMNDChuxe.Text.Trim();
                String somay = txtSoMay.Text.Trim();
                String sokhung = txtSoKhung.Text.Trim();
                String lydodangky = txtLydoDKY.Text.Trim();
                String ngaydangky = txtNgayDK.Text.Trim();
                String bienso_cu = txtBiensocu.Text.Trim();
                String loaidangky = txtLoaiDK.Text.Trim();
                String sql = "set dateformat dmy update don_dangky set macanbo = '"+macanbo()+"', socmnd_chuxe = '"+socmnd_chuxe+"', somay = '"+somay+"', sokhung = '"+sokhung+"', lydodangky = N'"+lydodangky+"', ngaydangky = '"+ngaydangky+"', bienso_cu = '"+bienso_cu+"', loaidangky = N'"+loaidangky+"' where bienso_moi = '"+bienso_moi+"'";
                data.themxoasua(Dangnhap.server, Dangnhap.taikhoan, Dangnhap.matkhau, sql);
                ketnoicsdl();
            }
        }            
    }
}
