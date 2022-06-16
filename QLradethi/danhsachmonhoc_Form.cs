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
    public partial class danhsachmonhoc_Form : Form
    {
        string monhocdachon;
        SqlConnection sqlCon = null;
        string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        SqlCommand cmd;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public danhsachmonhoc_Form()
        {
            InitializeComponent();
            sqlCon = new SqlConnection(strCon);
        }
        public event EventHandler Thoat;

        private void danhsachmonhoc_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thoat(this, new EventArgs());
        }
        private void Frm_Thoat(object sender, EventArgs e)
        {
            this.Show();
            LoadData_danhsachmh_Form();
        }
        void LoadData_danhsachmh_Form()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT MAMONHOC, TENMONHOC FROM MONHOC";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            dsmh_dgv.DataSource = table;
            dsmh_dgv.Columns[0].HeaderText = "Mã môn học";
            dsmh_dgv.Columns[0].Width = 50;
            dsmh_dgv.Columns[1].HeaderText = "Tên môn học";
            dsmh_dgv.Columns[1].Width = 130;
            if (dsmh_dgv.Rows.Count >= 1)
            {
                DataGridViewRow row = this.dsmh_dgv.Rows[0];
                monhocdachon = row.Cells[0].Value.ToString();
            }
            sqlCon.Close();
        }

        private void danhsachmonhoc_Form_Load(object sender, EventArgs e)
        {
            LoadData_danhsachmh_Form();
        }

        private void them_btn_Click(object sender, EventArgs e)
        {
            themmonhoc_Form frm = new themmonhoc_Form();
            frm.Thoat += Frm_Thoat;
            frm.Show();
            this.Hide();
        }

        private void capnhat_btn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(monhocdachon))
            {
                capnhatmonhoc_Form frm = new capnhatmonhoc_Form(monhocdachon);
                frm.Thoat += Frm_Thoat;
                frm.Show();
                this.Hide();
            }
        }
       
        private void xoa_btn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(monhocdachon))
            {
                DialogResult Result = MessageBox.Show("Bạn có chắc chắn muốn xoá " + monhocdachon + " ?", "Xoá lớp", MessageBoxButtons.YesNo);
                if (Result == DialogResult.Yes)
                {
                    if (sqlCon.State == ConnectionState.Closed)
                        sqlCon.Open();
                    cmd = sqlCon.CreateCommand();
                    try
                    {
                        cmd.CommandText = "DELETE FROM MONHOC WHERE MAMONHOC='" + monhocdachon + "'";
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Bạn đã chỉnh sửa thành công!");
                        LoadData_danhsachmh_Form();
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

        private void dsmh_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dsmh_dgv.Rows[e.RowIndex];
                monhocdachon = row.Cells[0].Value.ToString();
            }
        }
    }
}
