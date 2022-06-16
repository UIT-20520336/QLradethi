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
    public partial class capnhatmonhoc_Form : Form
    {
        string mamonhoc;
        public static string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        SqlConnection con = new SqlConnection(strCon);
        SqlConnection sqlCon = null;
        SqlCommand cmd;
        public capnhatmonhoc_Form()
        {
            InitializeComponent();
            sqlCon = new SqlConnection(strCon);
        }
        public capnhatmonhoc_Form(string mamonhoc)
        {
            InitializeComponent();
            sqlCon = new SqlConnection(strCon);
            this.mamonhoc = mamonhoc;
        }
        public event EventHandler Thoat;

        private void capnhatmonhoc_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thoat(this, new EventArgs());
        }
        private void Load_capnhatgv_Form()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT TENMONHOC FROM MONHOC WHERE MAMONHOC='" + mamonhoc + "'";
            cmd.Connection = sqlCon;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                mamonhoc_txtbox.Text = mamonhoc;
                tenmonhoc_txtbox.Text = reader.GetString(0);
            }
            sqlCon.Close();
        }

        private void capnhatmonhoc_Form_Load(object sender, EventArgs e)
        {
            Load_capnhatgv_Form();
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
                    cmd.CommandText ="update MONHOC set TENMONHOC=N'" + tenmonhoc_txtbox.Text + "'where MAMONHOC='" + mamonhoc + "'";
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
