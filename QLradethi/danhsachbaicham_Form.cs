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
    public partial class danhsachbaicham_Form : Form
    {
        string baichamdachon;
        string magiangvien;
        string malop;
        SqlConnection sqlCon = null;
        string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        SqlCommand cmd;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public danhsachbaicham_Form()
        {
            InitializeComponent();
        }
        public danhsachbaicham_Form(string malop, string magiangvien)
        {
            InitializeComponent();
            this.malop = malop;
            this.magiangvien = magiangvien;
            sqlCon = new SqlConnection(strCon);
        }
        public event EventHandler Thoat;

        private void danhsachbaicham_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thoat(this, new EventArgs());
        }
        private void Frm_Thoat(object sender, EventArgs e)
        {
            this.Show();
            LoadData_danhsachbaichamForm();
        }
        void LoadData_danhsachbaichamForm()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT MSSV, TENSINHVIEN, DIEMTHI,GHICHU FROM CT_LOP WHERE MALOP='"+malop+"'";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            dsgv_dgv.DataSource = table;
            dsgv_dgv.Columns[0].HeaderText = "MSSV";
            dsgv_dgv.Columns[0].Width = 170;
            dsgv_dgv.Columns[1].HeaderText = "Tên sinh viên";
            dsgv_dgv.Columns[1].Width = 200;
            dsgv_dgv.Columns[2].HeaderText = "Điểm thi";
            dsgv_dgv.Columns[2].Width = 70;
            dsgv_dgv.Columns[3].HeaderText = "Ghi chú";
            dsgv_dgv.Columns[3].Width = 70;

            if (dsgv_dgv.Rows.Count >= 1)
            {
                DataGridViewRow row = this.dsgv_dgv.Rows[0];
                baichamdachon = row.Cells[0].Value.ToString();
            }
            sqlCon.Close();
            
        }

        private void danhsachbaicham_Form_Load(object sender, EventArgs e)
        {
            LoadData_danhsachbaichamForm();
            tenlop.Text = malop;
            Khacgv();
        }
        void Khacgv()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT TENGIANGVIEN,MAGIANGVIENCHAMTHI,TENMONHOC FROM LOP JOIN MONHOC ON LOP.MAMONHOC=MONHOC.MAMONHOC JOIN GIANGVIEN ON LOP.MAGIANGVIEN=GIANGVIEN.MAGIANGVIEN WHERE MALOP='"+malop+"'";
            cmd.Connection = sqlCon;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                tengv_label.Text = reader.GetString(0);
                if (magiangvien==reader.GetString(1))
                {
                    chamthi_btn.Enabled = false;
                    capnhat_btn.Enabled = false;
                    xoa_btn.Enabled = false;
                    quaylai_btn.Enabled = false;
                }
                tenmonthi_lb.Text = reader.GetString(2);
            }
            sqlCon.Close();
        }
        private void chamthi_btn_Click(object sender, EventArgs e)
        {
            chamthi_Form frm = new chamthi_Form(malop);
            frm.Thoat += Frm_Thoat;
            frm.Show();
            this.Hide();
        }

        private void capnhat_btn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(baichamdachon))
            {
                capnhatchamthi_Form frm = new capnhatchamthi_Form(malop, baichamdachon);
                frm.Thoat += Frm_Thoat;
                frm.Show();
                this.Hide();
            }
            
        }

        private void xoa_btn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(baichamdachon))
            {
                DialogResult Result = MessageBox.Show("Bạn có chắc chắn muốn xoá " + baichamdachon + " ?", "Xoá bài chấm", MessageBoxButtons.YesNo);
                if (Result == DialogResult.Yes)
                {
                    if (sqlCon.State == ConnectionState.Closed)
                        sqlCon.Open();
                    cmd = sqlCon.CreateCommand();
                    try
                    {
                        cmd.CommandText = "DELETE FROM CT_LOP WHERE MSSV='" + baichamdachon + "'";
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Bạn đã chỉnh sửa thành công!");
                        LoadData_danhsachbaichamForm();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Bạn đã chỉnh sửa không thành công");
                    }
                    sqlCon.Close();
                }
            }
        }

        private void dsgv_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dsgv_dgv.Rows[e.RowIndex];
                baichamdachon = row.Cells[0].Value.ToString();
            }
        }

        private void quaylai_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
