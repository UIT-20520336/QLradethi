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
    public partial class capnhatgv_Form : Form
    {
        string magiangvien;
        public static string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        SqlConnection con = new SqlConnection(strCon);
        SqlConnection sqlCon = null;
        SqlCommand cmd;
        public capnhatgv_Form()
        {
            InitializeComponent();
            sqlCon = new SqlConnection(strCon);
        }
        public capnhatgv_Form(string magiangvien)
        {
            InitializeComponent();
            sqlCon = new SqlConnection(strCon);
            this.magiangvien = magiangvien;
        }
        public event EventHandler Thoat;

        private void capnhatgv_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thoat(this, new EventArgs());
        }
        private void check_Gioitinh(string gt)
        {
            foreach (RadioButton item in gioitinh_panel.Controls)
            {
                if (item.Text == gt)
                {
                    item.Checked = true;
                    break;
                }
            }
        }
        private void Load_capnhatgv_Form()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT TENGIANGVIEN,GIOITINH,NGAYSINH,SDT,EMAIL FROM GIANGVIEN WHERE MAGIANGVIEN='" + magiangvien + "'";
            cmd.Connection = sqlCon;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                magv_txtbox.Text = magiangvien;
                hoten_txtbox.Text = reader.GetString(0);
                check_Gioitinh(reader.GetString(1));
                ngaysinh_dtpicker.Value = reader.GetDateTime(2);
                sdt_txtbox.Text = reader.GetString(3);
                email_txtbox.Text = reader.GetString(4);
            }
            sqlCon.Close();
        }
        private string gioitinhdachon()
        {
            string gt = "";
            foreach (RadioButton item in gioitinh_panel.Controls)
            {
                if (item != null)
                {
                    if (item.Checked)
                    {
                        gt = item.Text;
                        break;
                    }
                }
            }
            return gt;
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
                    cmd.CommandText = "set dateformat dmy " + "update GIANGVIEN set TENGIANGVIEN=N'" + hoten_txtbox.Text + "',GIOITINH=N'" + gioitinhdachon() + "',NGAYSINH='" + ngaysinh_dtpicker.Text + "',SDT='" + sdt_txtbox.Text + "',EMAIL='" + email_txtbox.Text +"'where MAGIANGVIEN='" + magiangvien + "'";
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

        private void capnhatgv_Form_Load(object sender, EventArgs e)
        {
            Load_capnhatgv_Form();
        }
    }
}
