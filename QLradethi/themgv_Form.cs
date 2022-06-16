using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace QLradethi
{
    public partial class themgv_Form : Form
    {
        public static string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        SqlConnection con = new SqlConnection(strCon);
        SqlConnection sqlCon = null;
        const string LOWER_CASE = "abcdefghijklmnopqursuvwxyz";
        const string UPPER_CASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string NUMBERS = "123456789";
        const string SPECIALS = @"!@£$%^&*()#€";
        public themgv_Form()
        {
            InitializeComponent();
            sqlCon = new SqlConnection(strCon);
        }
        public event EventHandler Thoat;

        private void danhsachgv_Form_FormClosed(object sender, FormClosedEventArgs e)
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
        private string gioitinhdachon()
        {
            string gt="";
            foreach (RadioButton item in gioitinh_panel.Controls)
            {
                if(item!=null)
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
        private void them_btn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(email_txtbox.Text))
            {
                string password_str = GeneratePassword();
                if (exedata("set dateformat dmy " + "insert into GIANGVIEN values('" + magv_txtbox.Text + "',N'" + hoten_txtbox.Text + "',N'" + gioitinhdachon() + "','" + ngaysinh_dtpicker.Text + "','" + sdt_txtbox.Text + "','" + email_txtbox.Text + "','" + 0 + "','" + password_str + "')") == true)
                {
                    //guimail("app.QLchamthi@gmail.com", email_txtbox.Text, "appQLchamthi1", magv_txtbox.Text, password_str);
                    guimail("20521867@gm.uit.edu.vn", email_txtbox.Text, "1491985500", magv_txtbox.Text, password_str);
                    MessageBox.Show("Thêm thành công!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm không thành công");
                }
            }
            else
            {
                MessageBox.Show("Phải thêm email!");
                email_txtbox.Focus();
            }
        }
        public string GeneratePassword()
        {
            char[] _password = new char[10];
            string charSet = "";
            System.Random _random = new Random();
            int counter;
            charSet += LOWER_CASE;
            charSet += UPPER_CASE;
            charSet += NUMBERS;
            charSet += SPECIALS;
            for (counter = 0; counter < 10; counter++)
            {
                _password[counter] = charSet[_random.Next(charSet.Length - 1)];
            }

            return string.Join(null, _password);
        }
        private void guimail(string sender, string receiver, string sender_password, string username_str, string password_str)
        {
            using (MailMessage mail = new MailMessage(sender, receiver, "TÀI KHOẢN APP", "Tên tài khoản: "+username_str+"\nMật khẩu của bạn là: "+password_str+""))
            {
                mail.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(sender, sender_password);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
        private void huy_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void themgv_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thoat(this, new EventArgs());
        }

        private void sdt_txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void sdt_txtbox_Leave(object sender, EventArgs e)
        {
            TextBox _sdt_txtbox = (TextBox)sender;
            if (!Regex.IsMatch(_sdt_txtbox.Text, @"^\d+$"))
            {
                _sdt_txtbox.Text = "";
            }
        }
    }
}
