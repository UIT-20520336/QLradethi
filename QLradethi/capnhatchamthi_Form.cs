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
    public partial class capnhatchamthi_Form : Form
    {
        string malop;
        string masosv;
        public static string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        SqlConnection con = new SqlConnection(strCon);
        SqlConnection sqlCon = null;
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlCommand cmd;
        public capnhatchamthi_Form()
        {
            InitializeComponent();
        }
        public capnhatchamthi_Form(string malop, string masosv)
        {
            InitializeComponent();
            this.malop = malop;
            this.masosv = masosv;
            sqlCon = new SqlConnection(strCon);
        }
        public event EventHandler Thoat;

        private void capnhatchamthi_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thoat(this, new EventArgs());
            
        }
        
        private void capnhatchamthi_Form_Load(object sender, EventArgs e)
        {
            Load_capnhatchamthi_Form();
            Load_diemthi_nud();
        }
        private void Load_capnhatchamthi_Form()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT TENSINHVIEN,DIEMTHI,GHICHU FROM CT_LOP WHERE MALOP='" + malop + "'AND MSSV='" + masosv + "'";
            cmd.Connection = sqlCon;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                malop_txtbox.Text = malop;
                mssv_txtbox.Text = masosv;
                tensv_txtbox.Text = reader.GetString(0);
                diemthi_nud.Value = Convert.ToDecimal(reader.GetValue(1).ToString());
                ghichu_rtb.Text = reader.GetString(2);
            }
            sqlCon.Close();
        }
        void Load_diemthi_nud()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT GIATRI FROM THAMSO WHERE TENTHAMSO= 'DiemToiThieu'";
            cmd.Connection = sqlCon;
            SqlDataReader Sdr = cmd.ExecuteReader();
            while (Sdr.Read())
            {
                diemthi_nud.Minimum = Convert.ToDecimal(Sdr.GetValue(0).ToString());
            }
            Sdr.Close();
            sqlCon.Close();
            sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT GIATRI FROM THAMSO WHERE TENTHAMSO= 'DiemToiDa'";
            cmd.Connection = sqlCon; 
            Sdr = cmd.ExecuteReader();
            while (Sdr.Read())
            {
                diemthi_nud.Maximum = Convert.ToDecimal(Sdr.GetValue(0).ToString());
            }
            Sdr.Close();
            sqlCon.Close();
        }

        private void capnhat_btn_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Bạn có chắc chắn muốn sửa?", "Sửa dữ liệu", MessageBoxButtons.YesNo);
            if (Result == DialogResult.Yes)
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                cmd = sqlCon.CreateCommand();
                try
                {
                    cmd.CommandText = "set dateformat dmy " + "update CT_LOP set TENSINHVIEN=N'" + tensv_txtbox.Text + "',DIEMTHI=" + diemthi_nud.Value + ",GHICHU=N'" + ghichu_rtb.Text +  "'where MALOP='" + malop + "' AND MSSV='"+masosv+"'";
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
    }
}
