using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBSX
{
    public class Dataprovider
    {
        private SqlDataAdapter da;
        private SqlConnection cn;

        public SqlDataAdapter getDa(String server, String taikhoan, String matkhau, String sql)
        {
            String ketnoi = "Data Source=" + server + ";Initial Catalog=Quanly_Biensoxe;User ID=" + taikhoan + ";Password=" + matkhau + "";
            cn = new SqlConnection(ketnoi);
            cn.Open();
            SqlCommand cmd = new SqlCommand(sql, cn);
            da = new SqlDataAdapter(cmd);
            return da;
        }

        public void close()
        {
            this.cn.Close();
        }

        public Boolean kiemtraketnoi(String server, String taikhoan, String matkhau)
        {
            try
            {
                SqlConnection cn = new SqlConnection("Data Source=" + server + ";User ID=" + taikhoan + ";Password=" + matkhau + "");
                cn.Open();
                cn.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public void themxoasua(String server, String taikhoan, String matkhau, String sql)
        {
            String ketnoi = "Data Source=" + server + ";Initial Catalog=Quanly_Biensoxe;User ID=" + taikhoan + ";Password=" + matkhau + "";
            cn = new SqlConnection(ketnoi);
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            close();
        }
    }
}
