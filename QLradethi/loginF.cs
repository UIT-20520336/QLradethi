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
using System.Configuration;


namespace QLradethi
{
    public partial class loginF : Form
    {
        string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        SqlConnection sqlCon = null;
        public loginF()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            // tạo ra đối tượng thực thi truy vấn.
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select MAGIANGVIEN,MATKHAU,LAADMIN from GIANGVIEN where MAGIANGVIEN = '" + txt_UserName.Text + "'";
            // gửi truy vấn tới kết nối.
            sqlCmd.Connection = sqlCon;
            // nhận kết quả
            SqlDataReader reader = sqlCmd.ExecuteReader();
            string passwd = "";
            int laAdmin=0;
            if (reader.Read())
            {
                passwd = reader.GetString(1);
                laAdmin = reader.GetByte(2);
                // kiểm tra passwd
                if (passwd == txt_pwd.Text)
                {
                    if (laAdmin == 1)
                    {
                        main_adminForm frm = new main_adminForm(reader.GetString(0));
                        frm.Thoat += Frm_Thoat;
                        frm.Show();
                        this.Hide();
                        if (chkNhopass.Checked == false)
                        {
                            txt_UserName.Clear();
                            txt_pwd.Clear();

                        }
                    }
                    else
                    {
                        main_giaovienFrom frm = new main_giaovienFrom(reader.GetString(0));
                        frm.Thoat += Frm_Thoat;
                        frm.Show();
                        this.Hide();
                        if (chkNhopass.Checked == false)
                        {
                            txt_UserName.Clear();
                            txt_pwd.Clear();

                        }
                    }
                }
                else
                {
                    MessageBox.Show("username hoặc passwd không đúng.");
                }
            }
            


            sqlCon.Close();
        }
        private void Frm_Thoat(object sender, EventArgs e)
        {
            this.Show();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
