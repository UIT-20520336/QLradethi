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
    public partial class themlop_Form : Form
    {
        public static string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        SqlConnection con = new SqlConnection(strCon);
        SqlConnection sqlCon = null;
        SqlCommand cmd;
        SqlDataAdapter adapter = new SqlDataAdapter();
        
        public themlop_Form()
        {
            InitializeComponent();
            sqlCon = new SqlConnection(strCon);
        }
        public event EventHandler Thoat;

        private void themlop_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thoat(this, new EventArgs());
        }
        private void Load_themlop_Form()
        {
            Load_mamonhoc_cbbox();
            Load_magv_cbbox();
            Load_namhoc_nud();
            Load_gvchamthi_cbbox();
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
            con.Open();
            SqlCommand fill_cbo_giangvien = new SqlCommand("SELECT * FROM GIANGVIEN WHERE LAADMIN=0", con);
            SqlDataAdapter da = new SqlDataAdapter(fill_cbo_giangvien);
            DataSet ds = new DataSet();
            da.Fill(ds);
            fill_cbo_giangvien.ExecuteNonQuery();
            con.Close();
            gvchamthi_cbbox.DisplayMember = "MAGIANGVIEN";
            gvchamthi_cbbox.ValueMember = "MAGIANGVIEN";
            gvchamthi_cbbox.DataSource = ds.Tables[0];
        }
        private void themlop_Form_Load(object sender, EventArgs e)
        {
            Load_themlop_Form();
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
        private void them_btn_Click(object sender, EventArgs e)
        {
            if (exedata("set dateformat dmy " + "insert into LOP values('" + malop_txtbox.Text + "','" + mamonhoc_cbbox.SelectedValue.ToString() + "','" + magv_cbbox.Text + "','" + hocky_cbbox.Text + "','" + namhoc_nud.Text + "','" + madethi_cbbox.Text + "','" + gvchamthi_cbbox.Text + "')") == true)
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
