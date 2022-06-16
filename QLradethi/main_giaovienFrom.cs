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
    public partial class main_giaovienFrom : Form
    {
        string gvID;
        SqlConnection sqlCon = null;
        string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        SqlCommand cmd;
        SqlDataAdapter adapter = new SqlDataAdapter();
        public main_giaovienFrom()
        {
            InitializeComponent();
            sqlCon = new SqlConnection(strCon);
        }
        public main_giaovienFrom(string gvID)
        {
            InitializeComponent();
            this.gvID = gvID;
            sqlCon = new SqlConnection(strCon);
        }
        public event EventHandler Thoat;
        private void main_giaovienFrom_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thoat(this, new EventArgs());
        }
        private void Frm_Thoat(object sender, EventArgs e)
        {
            this.Show();
        }
        void LoadData_main_giaovienForm()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT TENGIANGVIEN, EMAIL, SDT FROM GIANGVIEN WHERE MAGIANGVIEN='" + this.gvID + "'";
            cmd.Connection = sqlCon;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                username.Text = reader.GetString(0);
                magv_txtbox.Text = gvID;
                sdt_txtbox.Text = reader.GetString(2);
                email_txtbox.Text = reader.GetString(1);
            }
            sqlCon.Close();
        }

        private void danhsachcauhoi_btn_Click(object sender, EventArgs e)
        {
            danhsachcauhoi_Form frm = new danhsachcauhoi_Form(gvID);
            frm.Thoat += Frm_Thoat;
            frm.Show();
            this.Hide();

        }

        private void danhsachdethi_btn_Click(object sender, EventArgs e)
        {
            danhsachdethi_Form frm = new danhsachdethi_Form(gvID);
            frm.Thoat += Frm_Thoat;
            frm.Show();
            this.Hide();
        }

        private void danhsachlop_btn_Click(object sender, EventArgs e)
        {
            danhsachlopGV_Form frm = new danhsachlopGV_Form(gvID);
            frm.Thoat += Frm_Thoat;
            frm.Show();
            this.Hide();
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void main_giaovienFrom_Load(object sender, EventArgs e)
        {
            LoadData_main_giaovienForm();
        }

        private void edit_user_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            capnhatgv_Form frm = new capnhatgv_Form(gvID);
            frm.Thoat += Frm_Thoat;
            frm.Text = "Sửa thông tin cá nhân";
            frm.Show();
            this.Hide();
        }

        private void baocaonam_btn_Click(object sender, EventArgs e)
        {
            baocaonamGV_Form frm = new baocaonamGV_Form(gvID);
            frm.Thoat += Frm_Thoat;
            frm.Show();
            this.Hide();
        }
    }
}
