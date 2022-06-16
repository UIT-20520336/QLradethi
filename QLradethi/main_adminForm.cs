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
    public partial class main_adminForm : Form
    {
        string adminID;
        SqlConnection sqlCon = null;
        string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        SqlCommand cmd;
        SqlDataAdapter adapter = new SqlDataAdapter();
        public main_adminForm()
        {
            InitializeComponent();
            sqlCon = new SqlConnection(strCon);
        }
        public main_adminForm(string adminID)
        {
            InitializeComponent();
            this.adminID = adminID;
            sqlCon = new SqlConnection(strCon);

        }
        public event EventHandler Thoat;

        private void main_adminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thoat(this, new EventArgs());
        }
        private void Frm_Thoat(object sender, EventArgs e)
        {
            this.Show();
        }
        void LoadData_main_adminForm()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT TENGIANGVIEN, EMAIL, SDT FROM GIANGVIEN WHERE MAGIANGVIEN='" + this.adminID + "'";
            cmd.Connection = sqlCon;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                username.Text = reader.GetString(0);
                magv_txtbox.Text = adminID;
                sdt_txtbox.Text = reader.GetString(2);
                email_txtbox.Text = reader.GetString(1);
            }
            sqlCon.Close();
        }

        private void main_adminForm_Load(object sender, EventArgs e)
        {
            LoadData_main_adminForm();
            
        }

        private void thongtingv_btn_Click(object sender, EventArgs e)
        {
            danhsachgv_Form frm = new danhsachgv_Form();
            frm.Thoat += Frm_Thoat;
            frm.Show();
            this.Hide();
        }

        private void thongtincaclop_btn_Click(object sender, EventArgs e)
        {
            danhsachlop_Form frm = new danhsachlop_Form();
            frm.Thoat += Frm_Thoat;
            frm.Show();
            this.Hide();
        }

        private void suaquydinh_btn_Click(object sender, EventArgs e)
        {
            suaquydinh_Form frm = new suaquydinh_Form();
            frm.Thoat += Frm_Thoat;
            frm.Show();
            this.Hide();
        }

        private void danhsachmonhoc_btn_Click(object sender, EventArgs e)
        {
            danhsachmonhoc_Form frm = new danhsachmonhoc_Form();
            frm.Thoat += Frm_Thoat;
            frm.Show();
            this.Hide();
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void edit_user_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            capnhatgv_Form frm = new capnhatgv_Form(adminID);
            frm.Thoat += Frm_Thoat;
            frm.Text = "Sửa thông tin cá nhân";
            frm.Show();
            this.Hide();
        }

        private void baocaonam_btn_Click(object sender, EventArgs e)
        {
            baocaonham_Form frm = new baocaonham_Form();
            frm.Thoat += Frm_Thoat;
            frm.Show();
            this.Hide();
        }
    }
}
