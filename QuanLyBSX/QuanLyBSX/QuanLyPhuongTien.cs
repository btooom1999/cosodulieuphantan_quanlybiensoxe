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
    public partial class QuanLyPhuongTien : Form
    {
        public QuanLyPhuongTien()
        {
            InitializeComponent();
        }

        Dataprovider data = new Dataprovider();

        public void ketnoicsdl()
        {
            SqlDataAdapter da = data.getDa(Dangnhap.server, Dangnhap.taikhoan, Dangnhap.matkhau, "select * from tt_phuongtien");
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            data.close();
        }

        private void QuanLyPhuongTien_Load(object sender, EventArgs e)
        {
            ketnoicsdl();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn đúng cột hoặc dòng để hiện thông tin", "Thông báo");
                return;
            }

            txtDungtich.Text = dataGridView1.Rows[e.RowIndex].Cells["DUNGTICH"].FormattedValue.ToString();
            txtLoaixe.Text = dataGridView1.Rows[e.RowIndex].Cells["LOAIXE"].FormattedValue.ToString();
            txtNamSX.Text = dataGridView1.Rows[e.RowIndex].Cells["NAMSANXUAT"].FormattedValue.ToString();
            txtNhanhieu.Text = dataGridView1.Rows[e.RowIndex].Cells["NHANHIEU"].FormattedValue.ToString();
            txtSokhung.Text = dataGridView1.Rows[e.RowIndex].Cells["SOKHUNG"].FormattedValue.ToString();
            txtSoloai.Text = dataGridView1.Rows[e.RowIndex].Cells["SOLOAI"].FormattedValue.ToString();
            txtSomay.Text = dataGridView1.Rows[e.RowIndex].Cells["SOMAY"].FormattedValue.ToString();
            txtMauXe.Text = dataGridView1.Rows[e.RowIndex].Cells["MAUXE"].FormattedValue.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thêm?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                String somay = txtSomay.Text.Trim();
                String sokhung = txtSokhung.Text.Trim();
                String nhanhieu = txtNhanhieu.Text.Trim();
                String soloai = txtSoloai.Text.Trim();
                String loaixe = txtLoaixe.Text.Trim();
                String mauxe = txtMauXe.Text.Trim();
                int namsanxuat = int.Parse(txtNamSX.Text.Trim());
                int dungtich = int.Parse(txtDungtich.Text.Trim());
                String sql = "insert into tt_phuongtien (somay, sokhung, nhanhieu, soloai, loaixe, mauxe, namsanxuat, dungtich)" +
                    " values ('"+somay+"', '"+sokhung+"', N'"+nhanhieu+"', N'"+soloai+"', N'"+loaixe+"', N'"+mauxe+"', "+namsanxuat+", "+dungtich+")";
                data.themxoasua(Dangnhap.server, Dangnhap.taikhoan, Dangnhap.matkhau, sql);
                ketnoicsdl();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xoá?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                String somay = txtSomay.Text.Trim();
                String sokhung = txtSokhung.Text.Trim();
                String sql = "delete from tt_phuongtien where somay = '"+somay+"' and sokhung = '"+sokhung+"'";
                data.themxoasua(Dangnhap.server, Dangnhap.taikhoan, Dangnhap.matkhau, sql);
                ketnoicsdl();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn sửa?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                String somay = txtSomay.Text.Trim();
                String sokhung = txtSokhung.Text.Trim();
                String nhanhieu = txtNhanhieu.Text.Trim();
                String soloai = txtSoloai.Text.Trim();
                String loaixe = txtLoaixe.Text.Trim();
                String mauxe = txtMauXe.Text.Trim();
                int namsanxuat = int.Parse(txtNamSX.Text.Trim());
                int dungtich = int.Parse(txtDungtich.Text.Trim());
                String sql = "update tt_phuongtien set nhanhieu = N'"+nhanhieu+"', soloai = N'"+soloai+"', loaixe = N'"+loaixe+"', mauxe = N'"+mauxe+"', namsanxuat = "+namsanxuat+", dungtich = "+dungtich+" where somay = '" + somay + "' and sokhung = '" + sokhung + "'";
                data.themxoasua(Dangnhap.server, Dangnhap.taikhoan, Dangnhap.matkhau, sql);
                ketnoicsdl();
            }
        }
    }
}
