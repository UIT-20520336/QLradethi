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
    public partial class capnhatlop_Form : Form
    {
        string malop_str;
        public static string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        SqlConnection con = new SqlConnection(strCon);
        SqlConnection sqlCon = null;
        SqlCommand cmd;
        SqlDataAdapter adapter = new SqlDataAdapter();
        public capnhatlop_Form()
        {
            InitializeComponent();
            sqlCon = new SqlConnection(strCon);
        }
        public capnhatlop_Form(string malop_str)
        {
            InitializeComponent();
            this.malop_str = malop_str;
            sqlCon = new SqlConnection(strCon);
        }
        public event EventHandler Thoat;

        private void capnhatlop_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thoat(this, new EventArgs());
        }
        private void Load_capnhatlop_Form()
        {
            Load_mamonhoc_cbbox();
            Load_magv_cbbox();
            Load_namhoc_nud();
            Load_gvchamthi_cbbox();
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT MAMONHOC,MAGIANGVIEN,HOCKY,NAMHOC,MADETHI,MAGIANGVIENCHAMTHI FROM LOP WHERE MALOP='" + malop_str + "'";
            cmd.Connection = sqlCon;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                malop_txtbox.Text = malop_str;
                mamonhoc_cbbox.SelectedValue = reader.GetString(0);
                magv_cbbox.SelectedValue= reader.GetString(1);
                hocky_cbbox.Text = reader.GetValue(2).ToString();
                namhoc_nud.Value = Convert.ToInt32(reader.GetValue(3).ToString());
                madethi_cbbox.SelectedValue = reader.GetString(4);
                gvchamthi_cbbox.Text= reader.GetString(5);
            }
            sqlCon.Close();
            if (lopdachamdiem())
            {
                madethi_cbbox.Enabled = false;
                madethi_cbbox.BackColor = SystemColors.ActiveCaption;
                gvchamthi_cbbox.Enabled = false;
                gvchamthi_cbbox.BackColor = SystemColors.ActiveCaption;
            }
        }
        bool lopdachamdiem()//kiem tra xem lop da duoc cham diem chua
        {
            int sobaithi = 0;
            sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM CT_LOP WHERE MALOP='" + malop_txtbox.Text + "'";
            cmd.Connection = sqlCon;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                sobaithi = Convert.ToInt32(reader.GetValue(0).ToString());
            }
            sqlCon.Close();
            if (sobaithi == 0)
            {
                return false;
            }
            else return true;
        }
        private void Load_mamonhoc_cbbox()
        {
            con.Open();
            SqlCommand fill_cbo_monhoc = new SqlCommand("SELECT * FROM MONHOC", con);
            SqlDataAdapter da = new SqlDataAdapter(fill_cbo_monhoc);
            DataSet ds = new DataSet();
            da.Fill(ds);
            fill_cbo_monhoc.ExecuteNonQuery();
            con.Close();
            mamonhoc_cbbox.DisplayMember = "TENMONHOC";
            mamonhoc_cbbox.ValueMember = "MAMONHOC";
            mamonhoc_cbbox.DataSource = ds.Tables[0];
        }
        private void Load_magv_cbbox()
        {
            con.Open();
            SqlCommand fill_cbo_giangvien = new SqlCommand("SELECT * FROM GIANGVIEN WHERE LAADMIN=0", con);
            SqlDataAdapter da = new SqlDataAdapter(fill_cbo_giangvien);
            DataSet ds = new DataSet();
            da.Fill(ds);
            fill_cbo_giangvien.ExecuteNonQuery();
            con.Close();
            magv_cbbox.DisplayMember = "MAGIANGVIEN";
            magv_cbbox.ValueMember = "MAGIANGVIEN";
            magv_cbbox.DataSource = ds.Tables[0];
        }
        private void Load_namhoc_nud()
        {
            namhoc_nud.Value = DateTime.Now.Year;
        }
        
        private void Load_gvchamthi_cbbox()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT MAGIANGVIEN FROM GIANGVIEN";
            cmd.Connection = sqlCon;
            SqlDataReader Sdr = cmd.ExecuteReader();
            while (Sdr.Read())
            {
                for (int i = 0; i < Sdr.FieldCount; i++)
                {
                    gvchamthi_cbbox.Items.Add(Sdr.GetString(i));
                }
            }
            Sdr.Close();
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
                    cmd.CommandText = "update LOP set MAGIANGVIEN='" + magv_cbbox.Text + "',HOCKY='" + hocky_cbbox.Text + "',NAMHOC=" + namhoc_nud.Text + ",MADETHI='" + madethi_cbbox.Text + "',MAGIANGVIENCHAMTHI='" + gvchamthi_cbbox.Text + "'where MALOP='" + malop_str + "'";
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

        private void capnhatlop_Form_Load(object sender, EventArgs e)
        {
            Load_capnhatlop_Form();
        }

        private void mamonhoc_cbbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM DETHI WHERE MAMONHOC='" + mamonhoc_cbbox.SelectedValue.ToString() + "'", con);
            Int32 count = (Int32)comm.ExecuteScalar();
            con.Close();
            if (count > 0)
            {
                con.Open();
                SqlCommand fill_cbo_dethi = new SqlCommand("SELECT * FROM DETHI WHERE MAMONHOC='" + mamonhoc_cbbox.SelectedValue.ToString() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(fill_cbo_dethi);
                DataSet ds = new DataSet();
                da.Fill(ds);
                fill_cbo_dethi.ExecuteNonQuery();
                madethi_cbbox.DisplayMember = "MADETHI";
                madethi_cbbox.ValueMember = "MADETHI";
                madethi_cbbox.DataSource = ds.Tables[0];
                con.Close();
            }
            else
            {
                madethi_cbbox.DataSource = null;
            }
        }
    }
}
