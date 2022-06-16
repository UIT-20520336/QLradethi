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
    public partial class danhsachgv_Form : Form
    {
        string gvdachon;
        SqlConnection sqlCon = null;
        string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        SqlCommand cmd;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public danhsachgv_Form()
        {
            InitializeComponent();
            sqlCon = new SqlConnection(strCon);
        }
        public event EventHandler Thoat;

        private void danhsachgv_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thoat(this, new EventArgs());
        }
        private void Frm_Thoat(object sender, EventArgs e)
        {
            this.Show();
            LoadData_danhsachgv_Form();
        }
        void LoadData_danhsachgv_Form()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT MAGIANGVIEN, TENGIANGVIEN, GIOITINH, NGAYSINH, SDT, EMAIL FROM GIANGVIEN WHERE LAADMIN=0";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            dsgv_dgv.DataSource = table;
            dsgv_dgv.Columns[0].HeaderText = "Mã Gv";
            dsgv_dgv.Columns[0].Width = 50;
            dsgv_dgv.Columns[1].HeaderText = "Họ và tên";
            dsgv_dgv.Columns[1].Width = 130;
            dsgv_dgv.Columns[2].HeaderText = "Giới tính";
            dsgv_dgv.Columns[2].Width = 70;
            dsgv_dgv.Columns[3].HeaderText = "Ngày sinh";
            dsgv_dgv.Columns[3].Width = 70;
            dsgv_dgv.Columns[4].HeaderText = "Số điện thoại";
            dsgv_dgv.Columns[4].Width = 70;
            dsgv_dgv.Columns[5].HeaderText = "Email";
            dsgv_dgv.Columns[5].Width = 170;
            if (dsgv_dgv.Rows.Count > 1)
            {
                DataGridViewRow row = this.dsgv_dgv.Rows[0];
                gvdachon = row.Cells[0].Value.ToString();
            }
            sqlCon.Close();
        }
     
        private void danhsachgv_Form_Load(object sender, EventArgs e)
        {
            LoadData_danhsachgv_Form();
        }

        private void them_btn_Click(object sender, EventArgs e)
        {
            themgv_Form frm = new themgv_Form();
            frm.Thoat += Frm_Thoat;
            frm.Show();
            this.Hide();
        }

        private void capnhat_btn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(gvdachon))
            {
                capnhatgv_Form frm = new capnhatgv_Form(gvdachon);
                frm.Thoat += Frm_Thoat;
                frm.Show();
                this.Hide();
            }
        }

        private void dsgv_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dsgv_dgv.Rows[e.RowIndex];
                gvdachon = row.Cells[0].Value.ToString();
            }
        }

        private void xoa_btn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(gvdachon))
            {
                DialogResult Result = MessageBox.Show("Bạn có chắc chắn muốn xoá " + gvdachon + " ?", "Xoá giảng viên", MessageBoxButtons.YesNo);
                if (Result == DialogResult.Yes)
                {
                    if (sqlCon.State == ConnectionState.Closed)
                        sqlCon.Open();
                    cmd = sqlCon.CreateCommand();
                    try
                    {
                        cmd.CommandText = "DELETE FROM GIANGVIEN WHERE MAGIANGVIEN='" + gvdachon + "'";
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Bạn đã chỉnh sửa thành công!");
                        LoadData_danhsachgv_Form();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Bạn đã chỉnh sửa không thành công");
                    }
                    sqlCon.Close();
                }
            }
        }

        private void quaylai_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
