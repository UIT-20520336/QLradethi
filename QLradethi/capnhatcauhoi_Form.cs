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

namespace QLradethi
{
    public partial class capnhatcauhoi_Form : Form
    {
        string macauhoi;
        string magiangvien;
        public static string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        SqlConnection con = new SqlConnection(strCon);
        SqlConnection sqlCon = null;
        SqlCommand cmd;
        public capnhatcauhoi_Form()
        {
            InitializeComponent();
            sqlCon = new SqlConnection(strCon);
        }
        public capnhatcauhoi_Form(string macauhoi):this()
        {
            this.macauhoi = macauhoi;

        }
        public EventHandler Thoat;

        private void capnhatcauhoi_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thoat(this, new EventArgs());
        }

        private void capnhatcauhoi_Form_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand fill_cbo_dokho = new SqlCommand("SELECT * FROM DOKHO ", con);
            SqlCommand fill_cbo_monhoc = new SqlCommand("SELECT * FROM MONHOC", con);
            SqlDataAdapter da1 = new SqlDataAdapter(fill_cbo_dokho);
            SqlDataAdapter da2 = new SqlDataAdapter(fill_cbo_monhoc);
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();
            da1.Fill(ds1);
            da2.Fill(ds2);
            fill_cbo_dokho.ExecuteNonQuery();
            fill_cbo_monhoc.ExecuteNonQuery();
            con.Close();

            dokho_cbo.DisplayMember = "TENDOKHO";
            dokho_cbo.ValueMember = "MADOKHO";
            dokho_cbo.DataSource = ds1.Tables[0];

            monhoc_cbo.DisplayMember = "TENMONHOC";
            monhoc_cbo.ValueMember = "MAMONHOC";
            monhoc_cbo.DataSource = ds2.Tables[0];

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT MAMONHOC,MAGIANGVIEN,MADOKHO,NOIDUNG FROM CAUHOI WHERE MACAUHOI='" + macauhoi + "'";
            cmd.Connection = sqlCon;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                macauhoi_txtbox.Text = macauhoi;
                monhoc_cbo.SelectedValue = reader.GetString(0);
                magiangvien = reader.GetString(1);
                dokho_cbo.SelectedValue = reader.GetString(2);
                noidung_rtextbox.Text = reader.GetString(3);
            }
            sqlCon.Close();
            if(cauhoidasudung())
            {
                monhoc_cbo.Enabled = false;
                monhoc_cbo.BackColor = SystemColors.ActiveCaption;
            }
        }
        bool cauhoidasudung()//kiem tra xem cau hoi da su dung chua
        {
            int solandungcauhoi=0;
            sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM CT_DETHI WHERE MACAUHOI='"+macauhoi_txtbox.Text+"'";
            cmd.Connection = sqlCon;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                 solandungcauhoi= Convert.ToInt32(reader.GetValue(0).ToString());
            }
            sqlCon.Close();
            if (solandungcauhoi == 0)
            {
                return false;
            }
            else return true;
        }
        private void capnhat_btn_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật?", "Cập nhật dữ liệu", MessageBoxButtons.YesNo);
            if (Result == DialogResult.Yes)
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                cmd = sqlCon.CreateCommand();
                try
                {
                    cmd.CommandText = "update CAUHOI set MAMONHOC='" + monhoc_cbo.SelectedValue.ToString() + "',MADOKHO='" + dokho_cbo.SelectedValue.ToString() + "',NOIDUNG=N'" + noidung_rtextbox.Text + "'where MACAUHOI='" + macauhoi + "'";
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
            Close();
        }
    }
}
