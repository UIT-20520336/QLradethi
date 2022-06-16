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
    public partial class chamthi_Form : Form
    {
        string malop;
        public static string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        SqlConnection con = new SqlConnection(strCon);
        SqlConnection sqlCon = null;
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlCommand cmd;
        public chamthi_Form()
        {
            InitializeComponent();
            sqlCon = new SqlConnection(strCon);
        }
        public chamthi_Form(string malop)
        {
            InitializeComponent();
            this.malop = malop;
            sqlCon = new SqlConnection(strCon);
        }
        public event EventHandler Thoat;

        private void chamthi_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thoat(this, new EventArgs());
        }
        public Boolean exedata(string cmd)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            Boolean check = false;
            try
            {
                SqlCommand sc = new SqlCommand(cmd, con);
                sc.ExecuteNonQuery();
                check = true;
            }
            catch (Exception)
            {
                check = false;
            }
            con.Close();
            return check;
        }

        private void chamthi_Form_Load(object sender, EventArgs e)
        {
            Load_diemthi_nud();
            malop_txtbox.Text = malop;
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
                diemthi_nud.Value = Convert.ToDecimal(Sdr.GetValue(0).ToString());
            }
            sqlCon.Close();
            Sdr.Close();
            sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT GIATRI FROM THAMSO WHERE TENTHAMSO= 'DiemToiDa'";
            cmd.Connection = sqlCon; Sdr = cmd.ExecuteReader();
            while (Sdr.Read())
            {
                diemthi_nud.Maximum = Convert.ToDecimal(Sdr.GetValue(0).ToString());
            }
            Sdr.Close();
            sqlCon.Close();
        }

        private void them_btn_Click(object sender, EventArgs e)
        {
            if (exedata("set dateformat dmy " + "insert into CT_LOP values('" + malop_txtbox.Text + "','" + mssv_txtbox.Text + "',N'" + tensv_txtbox.Text + "', " + diemthi_nud.Value + " ,N'" + ghichu_rtb.Text + "')") == true)
            {
                MessageBox.Show("Thêm thành công!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm không thành công");
            }
        }

        private void huy_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
