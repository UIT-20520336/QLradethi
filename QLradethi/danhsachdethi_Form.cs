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
    public partial class danhsachdethi_Form : Form
    {
        string gvID;
        string dethidachon;
        string gvdachon;
        SqlConnection sqlCon = null;
        string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        SqlCommand cmd;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public danhsachdethi_Form()
        {
            InitializeComponent();
            sqlCon = new SqlConnection(strCon);
        }
        public danhsachdethi_Form(string gvID)
        {
            InitializeComponent();
            this.gvID = gvID;
            sqlCon = new SqlConnection(strCon);
        }
        public EventHandler Thoat;

        private void danhsachdethi_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thoat(this, new EventArgs());
        }
        private void Frm_Thoat(object sender, EventArgs e)
        {
            this.Show();
            LoadData_danhsachdethi_Form();
        }
        void LoadData_danhsachdethi_Form()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT MADETHI, MAGIANGVIEN, MAMONHOC, THOILUONG, HOCKY, NAMHOC, NGAYTHI FROM DETHI";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            dsdt_dgv.DataSource = table;
            dsdt_dgv.Columns[0].HeaderText = "Mã Đề Thi";
            dsdt_dgv.Columns[0].Width = 70;
            dsdt_dgv.Columns[1].HeaderText = "Mã Giảng Viên";
            dsdt_dgv.Columns[1].Width = 70;
            dsdt_dgv.Columns[2].HeaderText = "Mã Môn Học";
            dsdt_dgv.Columns[2].Width = 70;
            dsdt_dgv.Columns[3].HeaderText = "Thời Lượng";
            dsdt_dgv.Columns[3].Width = 70;
            dsdt_dgv.Columns[4].HeaderText = "Học Kỳ";
            dsdt_dgv.Columns[4].Width = 70;
            dsdt_dgv.Columns[5].HeaderText = "Năm học";
            dsdt_dgv.Columns[5].Width = 70;
            dsdt_dgv.Columns[6].HeaderText = "Ngày Thi";
            dsdt_dgv.Columns[6].Width = 140;
            if (dsdt_dgv.Rows.Count >= 1)
            {
                DataGridViewRow row = this.dsdt_dgv.Rows[0];
                dethidachon = row.Cells[0].Value.ToString();
            }
            sqlCon.Close();
        }

        private void danhsachdethi_Form_Load(object sender, EventArgs e)
        {
            LoadData_danhsachdethi_Form();
        }

       

        private void quaylai_btn_Click(object sender, EventArgs e)
        {
            Close();
        }
        bool dethidacolop()
        {
            int solop = 0;
            sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM LOP WHERE MADETHI='" + dethidachon + "'";
            cmd.Connection = sqlCon;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                solop = Convert.ToInt32(reader.GetValue(0).ToString());
            }
            sqlCon.Close();
            if (solop == 0)
            {
                return false;
            }
            else return true;
        }
        private void xoa_btn_Click(object sender, EventArgs e)
        {
            if (!dethidacolop())
            {
                if ((!string.IsNullOrEmpty(dethidachon)) && (gvdachon == gvID))
                {
                    DialogResult Result = MessageBox.Show("Bạn có chắc chắn muốn xoá đề thi " + dethidachon + " ?", "Xoá câu hỏi", MessageBoxButtons.YesNo);
                    if (Result == DialogResult.Yes)
                    {
                        if (sqlCon.State == ConnectionState.Closed)
                            sqlCon.Open();
                        cmd = sqlCon.CreateCommand();
                        try
                        {
                            cmd.CommandText = "DELETE FROM CT_DETHI WHERE MADETHI='" + dethidachon + "'";
                            cmd.CommandText += "DELETE FROM DETHI WHERE MADETHI='" + dethidachon + "'";
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Bạn đã chỉnh sửa thành công!");
                            LoadData_danhsachdethi_Form();
                        }
                        catch (SqlException)
                        {
                            MessageBox.Show("Bạn đã chỉnh sửa không thành công");
                        }
                        sqlCon.Close();
                    }
                }
            }
            else MessageBox.Show("Đề thi đã có lớp, không thể xoá");
        }

        private void them_btn_Click(object sender, EventArgs e)
        {
            themdethi_Form frm = new themdethi_Form(gvID);
            frm.Thoat += Frm_Thoat;
            frm.Show();
            this.Hide();
        }

        private void capnhat_btn_Click(object sender, EventArgs e)
        {
            // if ((!string.IsNullOrEmpty(dethidachon))&&(gvdachon==gvID))
            if (!string.IsNullOrEmpty(dethidachon))
             {
                chitietdethi_Form frm = new chitietdethi_Form(dethidachon, gvID);
                frm.Thoat += Frm_Thoat;
                frm.Show();
                this.Hide();
            }
           
        }

        private void dsdt_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dsdt_dgv.Rows[e.RowIndex];
                dethidachon = row.Cells[0].Value.ToString();
                gvdachon= row.Cells[1].Value.ToString();
            }
        }

        private void tim_btn_Click(object sender, EventArgs e)
        {
            (dsdt_dgv.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            if (string.IsNullOrEmpty(tim_txtbox.Text))
            {
                MessageBox.Show("Vui lòng nhập nội dung cần tìm.");
                tim_txtbox.Focus();
                return;
            }
            if (mientim_cbbox.Text == "Chưa chọn")
            {
                MessageBox.Show("Vui lòng chọn trường cần tìm");
                mientim_cbbox.Focus();
                return;
            }
            switch (mientim_cbbox.Text)
            {
                case "Mã đề thi":
                    {

                        (dsdt_dgv.DataSource as DataTable).DefaultView.RowFilter = string.Format("[MADETHI] ='{0}'", tim_txtbox.Text);
                        break;
                    }
                case "Thời lượng":
                    {
                        if (loc_cbbox.Text == "Lọc")
                        {
                            MessageBox.Show("Vui lòng chọn miền lương cần lọc");
                            loc_cbbox.Focus();
                        }
                        else
                        {
                            if (decimal.TryParse(tim_txtbox.Text, out decimal result))
                            {
                                if (loc_cbbox.SelectedIndex.Equals(0))
                                    (dsdt_dgv.DataSource as DataTable).DefaultView.RowFilter = string.Format(" THOILUONG = '{0}'", Convert.ToInt32(tim_txtbox.Text));
                                else if (loc_cbbox.SelectedIndex.Equals(1))
                                    (dsdt_dgv.DataSource as DataTable).DefaultView.RowFilter = string.Format("THOILUONG > '{0}'", Convert.ToInt32(tim_txtbox.Text));
                                else if (loc_cbbox.SelectedIndex.Equals(2))
                                    (dsdt_dgv.DataSource as DataTable).DefaultView.RowFilter = string.Format(" THOILUONG < '{0}'", Convert.ToInt32(tim_txtbox.Text));
                            }
                            else
                            {
                                MessageBox.Show("vui lòng nhập thời lượng");
                                tim_txtbox.Focus();
                            }
                        }
                        break;
                    }
                case "Ngày thi":
                    {
                        try
                        {
                            (dsdt_dgv.DataSource as DataTable).DefaultView.RowFilter = string.Format("[NGAYTHI]='{0}' ", tim_txtbox.Text);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Bạn không nhập đúng format ngày");
                            tim_txtbox.Focus();
                        }
                        break;
                    }

            }
            }

        private void mientim_cbbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mientim_cbbox.Text == "Thời lượng")
            {
                loc_cbbox.Visible = true;
            }
            else
            {
                loc_cbbox.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (dsdt_dgv.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
        }
    }
}
