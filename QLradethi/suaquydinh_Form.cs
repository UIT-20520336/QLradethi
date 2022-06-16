using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLradethi
{
    public partial class suaquydinh_Form : Form
    {
        public static string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        SqlConnection con = new SqlConnection(strCon);
        SqlConnection sqlCon = null;
        SqlCommand cmd;
        public suaquydinh_Form()
        {
            InitializeComponent();
            sqlCon = new SqlConnection(strCon);
        }
        public event EventHandler Thoat;

        private void suaquydinh_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thoat(this, new EventArgs());
        }
        private void Load_suaquydinh_Form()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT GIATRI FROM THAMSO WHERE TENTHAMSO='ThoiLuongToiThieu'";
            cmd.Connection = sqlCon;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                thoiluongtoithieu_nud.Value = Convert.ToInt32(reader.GetValue(0).ToString());
            }
            sqlCon.Close();
            sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT MIN(THOILUONG) FROM DETHI";
            cmd.Connection = sqlCon;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                thoiluongtoithieu_nud.Maximum = Convert.ToInt32(reader.GetValue(0).ToString());
            }
            sqlCon.Close();

            sqlCon.Open();
            cmd.CommandText = "SELECT GIATRI FROM THAMSO WHERE TENTHAMSO='ThoiLuongToiDa'";
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                thoiluongtoida_nud.Value = Convert.ToInt32(reader.GetValue(0).ToString());
            }
            sqlCon.Close();
            sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT MAX(THOILUONG) FROM DETHI";
            cmd.Connection = sqlCon;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                thoiluongtoida_nud.Minimum = Convert.ToInt32(reader.GetValue(0).ToString());
            }
            sqlCon.Close();

            sqlCon.Open();
            cmd.CommandText = "SELECT GIATRI FROM THAMSO WHERE TENTHAMSO='DiemToiThieu'";
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                
                diemtoithieu_nud.Value = Convert.ToInt32(reader.GetValue(0).ToString());
            }
            sqlCon.Close();
            sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT MIN(DIEMTHI) FROM CT_LOP";
            cmd.Connection = sqlCon;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Decimal giatri = Convert.ToDecimal(reader.GetValue(0).ToString());
                if(giatri-(int)giatri>0)
                { giatri = giatri - 1; }
                diemtoithieu_nud.Maximum = (int)giatri;
            }
            sqlCon.Close();

            sqlCon.Open();
            cmd.CommandText = "SELECT GIATRI FROM THAMSO WHERE TENTHAMSO='DiemToiDa'";
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                diemtoida_nud.Value = Convert.ToInt32(reader.GetValue(0).ToString());
            }
            sqlCon.Close();
            sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT MAX(DIEMTHI) FROM CT_LOP";
            cmd.Connection = sqlCon;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Decimal giatri = Convert.ToDecimal(reader.GetValue(0).ToString());
                if (giatri - (int)giatri > 0)
                { giatri = giatri + 1; }
                diemtoida_nud.Minimum = (int)giatri;
            }
            sqlCon.Close();

            sqlCon.Open();
            cmd.CommandText = "SELECT GIATRI FROM THAMSO WHERE TENTHAMSO='SoCauHoiToiDa'";
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                socauhoitoida_nud.Value = Convert.ToInt32(reader.GetValue(0).ToString());
            }
            sqlCon.Close();
            sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT TOP(1) COUNT(*) AS socauhoi FROM CT_DETHI GROUP BY MADETHI ORDER BY socauhoi DESC";
            cmd.Connection = sqlCon;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                socauhoitoida_nud.Minimum = Convert.ToInt32(reader.GetValue(0).ToString());
            }
            sqlCon.Close();
        }

        private void sua_btn_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Bạn có chắc chắn muốn sửa?", "Sửa dữ liệu", MessageBoxButtons.YesNo);
            if (Result == DialogResult.Yes)
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                cmd = sqlCon.CreateCommand();
                try
                {
                    cmd.CommandText = "update THAMSO set GIATRI='" + thoiluongtoithieu_nud.Text + "'where TENTHAMSO='ThoiLuongToiThieu'";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "update THAMSO set GIATRI='" + thoiluongtoida_nud.Text + "'where TENTHAMSO='ThoiLuongToiDa'";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "update THAMSO set GIATRI='" + diemtoithieu_nud.Text + "'where TENTHAMSO='DiemToiThieu'";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "update THAMSO set GIATRI='" + diemtoida_nud.Text + "'where TENTHAMSO='DiemToiDa'";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "update THAMSO set GIATRI='" + socauhoitoida_nud.Text + "'where TENTHAMSO='SoCauHoiToiDa'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bạn đã chỉnh sửa thành công!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Bạn đã chỉnh sửa không thành công");
                }
                sqlCon.Close();
            }
        }

        private void huy_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void suaquydinh_Form_Load(object sender, EventArgs e)
        {
            Load_suaquydinh_Form();
        }
    }
}
