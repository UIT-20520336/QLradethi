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
        string magiangvien;
        string madethi=null;
        int socauhoitoida;
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
        public themdethi_Form(string magiangvien)
        {
            InitializeComponent();
            this.magiangvien = magiangvien;
            table.Columns.Add("CHID", typeof(string));
            table.Columns.Add("DOKHO", typeof(string));
            table.Columns.Add("NOIDUNG", typeof(string));
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
            if (madethi_txtbox.Text == string.Empty)
            {
                MessageBox.Show("Chưa có mã đề thi");
                return;
            }
            /*else if (chitiet_dgv.RowCount==0)
            {
                MessageBox.Show("Chưa chọn câu hỏi");
                return;
            }*/
            else
            {
                sqlCon.Open();
                string strquery = "SET DATEFORMAT DMY "+"insert into DETHI values('" +madethi_txtbox.Text+"','"+magiangvien_txtbox.Text+"','"+mamonhoc_cbbox.SelectedValue.ToString()+"','"+thoiluong_nud.Value.ToString()+"','"+hocky_cbbox.Text+"','"+namhoc_nud.Value.ToString()+"','"+ngaythi_dtpicker.Text+ "')";
                SqlCommand sqlCmd;
                sqlCmd = new SqlCommand(strquery, sqlCon);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
                for (int i = 0; i < chitiet_dgv.Rows.Count; i++)
                {
                    if (chitiet_dgv.Rows[i] != null)
                    {
                        sqlCon.Open();
                        strquery = "insert into CT_DETHI values('" + madethi_txtbox.Text + "','" + chitiet_dgv.Rows[i].Cells["CHID"].Value.ToString() + "')";
                        sqlCmd = new SqlCommand(strquery, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        sqlCon.Close();
                    }
                }
                MessageBox.Show("Tạo đề thi thành công");
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (chitiet_dgv.RowCount < socauhoitoida)
            {
                if (macauhoi_cbo.Text != string.Empty)
                {
                    if (!kiemTraCauHoi(macauhoi_cbo.Text))
                        table.Rows.Add(macauhoi_cbo.Text, dokho_txtbox.Text, noidung_rtxtbox.Text);
                    else MessageBox.Show("Đã có câu hỏi này");
                }

                else MessageBox.Show("Chưa chọn câu hỏi");
                chitiet_dgv.DataSource = table;
            }
            else MessageBox.Show("Chỉ được chọn "+socauhoitoida+" câu hỏi trở xuống");
        }
        private bool kiemTraCauHoi(string chid)
        {
            for (int i = 0; i < chitiet_dgv.RowCount; i++)
            {
                if (chid == chitiet_dgv.Rows[i].Cells["CHID"].Value.ToString())
                    return true;
            }
            return false;
        }

        private void themdethi_Form_Load(object sender, EventArgs e)
        {
            magiangvien_txtbox.Text = magiangvien;
            Load_socauhoitoida();
            Load_mamonhoc_cbbox();
            Load_thoiluong_nud();
            namhoc_nud.Value = DateTime.Now.Year;
            Load_chitiet_dgv();
        }
        private void Load_chitiet_dgv()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT CT_DETHI.MACAUHOI, MADOKHO, NOIDUNG FROM CT_DETHI JOIN CAUHOI ON CT_DETHI.MACAUHOI= CAUHOI.MACAUHOI WHERE MADETHI='" + madethi+"'";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            chitiet_dgv.DataSource = table;
            chitiet_dgv.Columns[0].HeaderText = "Mã câu hỏi";
            chitiet_dgv.Columns[0].Width = 240;
            chitiet_dgv.Columns[1].HeaderText = "Độ khó";
            chitiet_dgv.Columns[1].Width = 240;
            chitiet_dgv.Columns[2].HeaderText = "Nội dung";
            chitiet_dgv.Columns[2].Width = 240;
            sqlCon.Close();
            
        }
        private void Load_socauhoitoida()
        {
            //số câu hỏi tối đa
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT GIATRI FROM THAMSO WHERE TENTHAMSO='SoCauHoiToiDa'";
            cmd.Connection = sqlCon;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                socauhoitoida = Convert.ToInt32(reader.GetValue(0).ToString());
            }
            sqlCon.Close();
            sqlCon.Open();
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
        private void Load_thoiluong_nud()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT GIATRI FROM THAMSO WHERE TENTHAMSO= 'ThoiLuongToiThieu'";
            cmd.Connection = sqlCon;
            SqlDataReader Sdr = cmd.ExecuteReader();
            while (Sdr.Read())
            {
                thoiluong_nud.Minimum= Convert.ToInt32(Sdr[0]);
                thoiluong_nud.Value = Convert.ToInt32(Sdr[0]);
            }
            sqlCon.Close();
            Sdr.Close();
            sqlCon.Open();
            cmd.CommandText = "SELECT GIATRI FROM THAMSO WHERE TENTHAMSO= 'ThoiLuongToiDa'";
            cmd.Connection = sqlCon;
            Sdr = cmd.ExecuteReader();
            while (Sdr.Read())
            {
                thoiluong_nud.Maximum = Convert.ToInt32(Sdr[0]);
            }
            Sdr.Close();
            sqlCon.Close();
        }
        private void macauhoi_cbo_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT MADOKHO,NOIDUNG FROM CAUHOI WHERE MACAUHOI='" + macauhoi_cbo.Text.ToString() + "'";
            cmd.Connection = sqlCon;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                dokho_txtbox.Text = reader.GetString(0);
                noidung_rtxtbox.Text = reader.GetString(1);
            }
            sqlCon.Close();
        }

        private void mamonhoc_cbbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_chitiet_dgv();
            con.Open();
            SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM CAUHOI WHERE MAMONHOC='"+mamonhoc_cbbox.SelectedValue.ToString()+"'", con);
            Int32 count = (Int32)comm.ExecuteScalar();
            con.Close();
            if (count > 0)
            {
                con.Open();
                SqlCommand fill_cbo_cauhoi = new SqlCommand("SELECT * FROM CAUHOI WHERE MAMONHOC='" + mamonhoc_cbbox.SelectedValue.ToString() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(fill_cbo_cauhoi);
                DataSet ds = new DataSet();
                da.Fill(ds);
                fill_cbo_cauhoi.ExecuteNonQuery();
                macauhoi_cbo.DisplayMember = "MACAUHOI";
                macauhoi_cbo.ValueMember = "MACAUHOI";
                macauhoi_cbo.DataSource = ds.Tables[0];
                con.Close();
            }
            else
            {
                macauhoi_cbo.DataSource = null;
            }
            
        }

        private void xoacauhoi_btn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chitiet_dgv.RowCount; i++)
            {
                if (chitiet_dgv.Rows[i].Cells[0].Value.ToString() == chitiet_dgv.CurrentRow.Cells[0].Value.ToString())
                    chitiet_dgv.Rows.RemoveAt(i);
            }
        }
    }
}
