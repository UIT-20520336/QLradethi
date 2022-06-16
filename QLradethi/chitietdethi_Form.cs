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

    public partial class chitietdethi_Form : Form
    {
        string madethi;
        string magiangvien;
        int socauhoitoida;
        string macauhoi;
        public static string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        SqlConnection con = new SqlConnection(strCon);
        SqlConnection sqlCon = null;
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlCommand cmd;
        DataTable table = new DataTable();
        public chitietdethi_Form()
        {
            InitializeComponent();
            sqlCon = new SqlConnection(strCon);
        }
        public chitietdethi_Form(string madethi,string magiangvien) : this()
        {
            this.madethi = madethi;
            this.magiangvien = magiangvien;

        }
        public event EventHandler Thoat;

        private void chitietdethi_Form_FormClosed(object sender, FormClosedEventArgs e)
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

        
        void Loaddata_chitietdethi_Form()
        {
            madethi_txtbox.Text = madethi;
            Load_mamonhoc_txtbox();
            Load_thoiluong_nud();

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT MAMONHOC,THOILUONG, HOCKY, NAMHOC,NGAYTHI,MAGIANGVIEN FROM DETHI WHERE MADETHI= '" + madethi + "'";
            cmd.Connection = sqlCon;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                mamonhoc_txtbox.Text = reader.GetString(0);
                thoiluong_nud.Value = Convert.ToInt32(reader.GetValue(1).ToString());
                hocky_cbbox.Text= reader.GetValue(2).ToString();
                namhoc_nud.Value= Convert.ToInt32(reader.GetValue(3).ToString());
                ngaythi_dtpicker.Text = reader.GetValue(4).ToString();
                magiangvien_txtbox.Text= reader.GetValue(5).ToString();
            }
            sqlCon.Close();
            Load_socauhoitoida();
            Load_macauhoi_cbo();
            Load_chitiet_dgv();
            Khacmagv();
        }
        private void Khacmagv()
        {
            //chi co gv da tao moi duoc phep chinh sua de thi
            if (magiangvien != magiangvien_txtbox.Text)
            {
                thoiluong_nud.Enabled = false;
                hocky_cbbox.Enabled = false;
                namhoc_nud.Enabled = false;
                ngaythi_dtpicker.Enabled = false;
                macauhoi_cbo.Text = "";
                macauhoi_cbo.Enabled = false;
                dokho_txtbox.Text = "";
                dokho_txtbox.Enabled = false;
                noidung_rtxtbox.Text = "";
                noidung_rtxtbox.Enabled = false;
                themcauhoi_btn.Enabled = false;
                xoa_btn.Enabled = false;
                hoantat_btn.Enabled = false;
                huy_btn.Enabled = false;
            }
        }
        private void Load_mamonhoc_txtbox()
        {
            
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT MAMONHOC FROM DETHI WHERE MADETHI= '" + madethi + "'";
            cmd.Connection = sqlCon;
            SqlDataReader Sdr = cmd.ExecuteReader();
            while (Sdr.Read())
            {
                mamonhoc_txtbox.Text = Sdr.GetString(0);
            }
            Sdr.Close();
            sqlCon.Close();
            
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
                thoiluong_nud.Minimum = Convert.ToInt32(Sdr[0]); ;
            }
            sqlCon.Close();
            Sdr.Close();
            sqlCon.Open();
            cmd.CommandText = "SELECT GIATRI FROM THAMSO WHERE TENTHAMSO= 'ThoiLuongToiDa'";
            cmd.Connection = sqlCon; Sdr = cmd.ExecuteReader();
            while (Sdr.Read())
            {
                thoiluong_nud.Maximum = Convert.ToInt32(Sdr[0]); ;
            }
            sqlCon.Close();
            Sdr.Close();
            
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
        void Load_macauhoi_cbo()
        {
            con.Open();
            SqlCommand fill_cbo_cauhoi = new SqlCommand("SELECT * FROM CAUHOI WHERE MAMONHOC='" + mamonhoc_txtbox.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(fill_cbo_cauhoi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            fill_cbo_cauhoi.ExecuteNonQuery();
            con.Close();
            macauhoi_cbo.DisplayMember = "MACAUHOI";
            macauhoi_cbo.ValueMember = "MACAUHOI";
            macauhoi_cbo.DataSource = ds.Tables[0];
        }
        void Load_chitiet_dgv()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT CT_DETHI.MACAUHOI, MADOKHO, NOIDUNG FROM CT_DETHI JOIN CAUHOI ON CT_DETHI.MACAUHOI=CAUHOI.MACAUHOI WHERE MADETHI='" + madethi+"'";
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
        

        private void button1_Click(object sender, EventArgs e)
        {
            
                sqlCon.Open();
                string strquery = "SET DATEFORMAT DMY " + "update DETHI set THOILUONG='"+thoiluong_nud.Value.ToString()+"',HOCKY="+hocky_cbbox.Text+",NAMHOC='"+namhoc_nud.Value.ToString()+"',NGAYTHI='"+ngaythi_dtpicker.Text+"' WHERE MADETHI='"+madethi+"'";
                SqlCommand sqlCmd;
                sqlCmd = new SqlCommand(strquery, sqlCon);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
                if (chitiet_dgv.Rows[0] != null)
                {
                    sqlCon.Open();
                    strquery = "delete from CT_DETHI WHERE MADETHI='" + madethi + "'";
                    sqlCmd = new SqlCommand(strquery, sqlCon);
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                }

                for (int i = 0; i < chitiet_dgv.Rows.Count; i++)
                {
                    if (chitiet_dgv.Rows[i] != null)
                    {
                        sqlCon.Open();
                        strquery = "insert into CT_DETHI values('" + madethi_txtbox.Text + "','" + chitiet_dgv.Rows[i].Cells[0].Value.ToString() + "')";
                        sqlCmd = new SqlCommand(strquery, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        sqlCon.Close();
                    }
                }
                MessageBox.Show("Cập nhật đề thi thành công");
                this.Close();
            
        }

        private void chitiet_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.chitiet_dgv.Rows[e.RowIndex];
                macauhoi = row.Cells[0].Value.ToString();
            }
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

        private void xoa_btn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chitiet_dgv.RowCount; i++)
            {
                if (chitiet_dgv.Rows[i].Cells[0].Value.ToString() == chitiet_dgv.CurrentRow.Cells[0].Value.ToString())
                    chitiet_dgv.Rows.RemoveAt(i);
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
            else MessageBox.Show("Chỉ được chọn " + socauhoitoida + " câu hỏi trở xuống");
        }
        private bool kiemTraCauHoi(string chid)
        {
            for (int i = 0; i < chitiet_dgv.RowCount; i++)
            {
                if (chid == chitiet_dgv.Rows[i].Cells[0].Value.ToString())
                    return true;
            }
            return false;
        }

        private void huy_btn_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chitietdethi_Form_Load(object sender, EventArgs e)
        {
            Loaddata_chitietdethi_Form();
        }

        private void macauhoi_cbo_SelectedIndexChanged_1(object sender, EventArgs e)
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
    }
}
