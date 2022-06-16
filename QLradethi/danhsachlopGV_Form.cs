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
    public partial class danhsachlopGV_Form : Form
    {
        string lopdachon;
        string magiangvien;
        SqlConnection sqlCon = null;
        string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        SqlCommand cmd;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public danhsachlopGV_Form()
        {
            InitializeComponent();
        }
        public danhsachlopGV_Form(string magiangvien)
        {
            InitializeComponent();
            this.magiangvien = magiangvien;
            sqlCon = new SqlConnection(strCon);
        }
        public event EventHandler Thoat;

        private void danhsachlopGV_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thoat(this, new EventArgs());
        }
        private void Frm_Thoat(object sender, EventArgs e)
        {
            this.Show();
        }
        void LoadData_danhsachlopGV_Form()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT MALOP, MAMONHOC, HOCKY, NAMHOC, MADETHI, MAGIANGVIENCHAMTHI,MAGIANGVIEN FROM LOP";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            dsgv_dgv.DataSource = table;
            dsgv_dgv.Columns[0].HeaderText = "Mã lớp";
            dsgv_dgv.Columns[0].Width = 50;
            dsgv_dgv.Columns[1].HeaderText = "Môn học";
            dsgv_dgv.Columns[1].Width = 130;
            dsgv_dgv.Columns[2].HeaderText = "Học kỳ";
            dsgv_dgv.Columns[2].Width = 70;
            dsgv_dgv.Columns[3].HeaderText = "Năm học";
            dsgv_dgv.Columns[3].Width = 70;
            dsgv_dgv.Columns[4].HeaderText = "Mã đề thi";
            dsgv_dgv.Columns[4].Width = 170;
            dsgv_dgv.Columns[5].HeaderText = "GV chấm thi";
            dsgv_dgv.Columns[5].Width = 170;
            dsgv_dgv.Columns[6].HeaderText = "GV giảng dạy";
            dsgv_dgv.Columns[6].Width = 170;
            if (dsgv_dgv.Rows.Count >= 1)
            {
                DataGridViewRow row = this.dsgv_dgv.Rows[0];
                lopdachon = row.Cells[0].Value.ToString();
            }
            sqlCon.Close();
        }

        private void danhsachlopGV_Form_Load(object sender, EventArgs e)
        {
            LoadData_danhsachlopGV_Form();
        }

        private void danhsachbaicham_btn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lopdachon))
            {
                danhsachbaicham_Form frm = new danhsachbaicham_Form(lopdachon,magiangvien);
                frm.Thoat += Frm_Thoat;
                frm.Show();
                this.Hide();
            }
        }

        private void quaylai_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dsgv_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dsgv_dgv.Rows[e.RowIndex];
                lopdachon = row.Cells[0].Value.ToString();
            }
        }
    }
}
