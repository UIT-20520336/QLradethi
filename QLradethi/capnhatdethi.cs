using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLradethi
{
    public partial class themdethi_Form : Form
    {
        string madethi=null;
        public static string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        SqlConnection con = new SqlConnection(strCon);
        SqlConnection sqlCon = null;
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlCommand cmd;
        DataTable table = new DataTable();
        public themdethi_Form()
        {
            InitializeComponent();
            sqlCon = new SqlConnection(strCon);
        }
        public event EventHandler Thoat;

        private void themdethi_Form_FormClosed(object sender, FormClosedEventArgs e)
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

        private void huy_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void them_btn_Click(object sender, EventArgs e)
        {
            if (exedata("set dateformat dmy " + "insert into DETHI values('" + madethi_txtbox.Text + "','" + mamonhoc_txtbox.Text + "','" + magiangvien_txtbox.Text + "',' " + hocky_txtbox.Text + " ','" + namhoc_txtbox.Text + "','" + ngaythi_dtpicker.Text + "')") == true)
            {
                MessageBox.Show("Thêm thành công!");
                madethi = madethi_txtbox.Text;
            }
            else
            {
                MessageBox.Show("Thêm không thành công");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (madethi == null)
            {
                MessageBox.Show("Vui lòng thêm đề thi mới trước");
            }
            else
            {
                if (exedata("insert into CT_DETHI values('" + madethi + "','" + macauhoi_cbo.SelectedItem.ToString()  + "')") == true)
                {
                    MessageBox.Show("Thêm thành công!");
                    LoadData_chitietdethi_Form();
                }
                else
                {
                    MessageBox.Show("Thêm không thành công");
                }
            }
        }

        private void themdethi_Form_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand fill_cbo_cauhoi = new SqlCommand("SELECT * FROM DOKHO ", con);
            SqlDataAdapter da = new SqlDataAdapter(fill_cbo_cauhoi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            fill_cbo_cauhoi.ExecuteNonQuery();
            con.Close();

            macauhoi_cbo.DataSource = ds.Tables[0];
            macauhoi_cbo.DisplayMember = "MACAUHOI";
            macauhoi_cbo.ValueMember = "MACAUHOI";
        }

        private void macauhoi_cbo_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT MAMONHOC,MADOKHO,NOIDUNG FROM CAUHOI WHERE MACAUHOI='" + macauhoi_cbo.Text.ToString() + "'";
            cmd.Connection = sqlCon;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                monhoc_txtbox.Text = reader.GetString(0);
                dokho_txtbox.Text = reader.GetString(1);
                noidung_rtxtbox.Text = reader.GetString(2);
            }
            sqlCon.Close();
        }
        void LoadData_chitietdethi_Form()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT MADETHI, MACAUHOI FROM CT_DETHI";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            chitiet_dgv.DataSource = table;
            chitiet_dgv.Columns[0].HeaderText = "Mã Đề Thi";
            chitiet_dgv.Columns[0].Width = 240;
            chitiet_dgv.Columns[1].HeaderText = "Mã Giảng Viên";
            chitiet_dgv.Columns[1].Width = 240;
            sqlCon.Close();
        }
    }
}
