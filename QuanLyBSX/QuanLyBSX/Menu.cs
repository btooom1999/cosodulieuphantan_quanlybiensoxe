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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnDangKyPhuongTien_Click(object sender, EventArgs e)
        {
            LapDonDangKy dk = new LapDonDangKy();
            dk.Show();
        }

        private void btnQuanLyCanBo_Click(object sender, EventArgs e)
        {
            QuanLyCanBo cb = new QuanLyCanBo();
            cb.Show();
        }

        private void btnQuanLyPhuongTien_Click(object sender, EventArgs e)
        {
            QuanLyPhuongTien pt = new QuanLyPhuongTien();
            pt.Show();
        }

        private void btnQuanLyChuXe_Click(object sender, EventArgs e)
        {
            QuanLyChuXe cx = new QuanLyChuXe();
            cx.Show();
        }

        
    }
}
