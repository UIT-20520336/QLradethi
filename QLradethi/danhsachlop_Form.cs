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
    public partial class danhsachlop_Form : Form
    {
        string lopdachon;
        SqlConnection sqlCon = null;
        string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        SqlCommand cmd;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public danhsachlop_Form()
        {
            InitializeComponent();
            sqlCon = new SqlConnection(strCon);
        }
        
        public event EventHandler Thoat;

        private void danhsachlop_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thoat(this, new EventArgs());
        }
         private void Frm_Thoat(object sender, EventArgs e)
        {
            this.Show();
            LoadData_danhsachlop_Form();
        }
        void LoadData_danhsachlop_Form()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT MALOP, MAMONHOC, MAGIANGVIEN, HOCKY, NAMHOC, MADETHI, MAGIANGVIENCHAMTHI FROM LOP";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            dsgv_dgv.DataSource = table;
            dsgv_dgv.Columns[0].HeaderText = "Mã lớp";
            dsgv_dgv.Columns[0].Width = 50;
            dsgv_dgv.Columns[1].HeaderText = "Môn học";
            dsgv_dgv.Columns[1].Width = 130;
            dsgv_dgv.Columns[2].HeaderText = "GV";
            dsgv_dgv.Columns[2].Width = 70;
            dsgv_dgv.Columns[3].HeaderText = "Học kỳ";
            dsgv_dgv.Columns[3].Width = 70;
            dsgv_dgv.Columns[4].HeaderText = "Năm học";
            dsgv_dgv.Columns[4].Width = 70;
            dsgv_dgv.Columns[5].HeaderText = "Mã đề thi";
            dsgv_dgv.Columns[5].Width = 170;
            dsgv_dgv.Columns[6].HeaderText = "GV chấm thi";
            dsgv_dgv.Columns[6].Width = 170;
            
            if (dsgv_dgv.Rows.Count >= 1)
            {
                DataGridViewRow row = this.dsgv_dgv.Rows[0];
                lopdachon = row.Cells[0].Value.ToString();
            }
            sqlCon.Close();
        }

        private void danhsachlop_Form_Load(object sender, EventArgs e)
        {
            LoadData_danhsachlop_Form();
        }

        private void them_btn_Click(object sender, EventArgs e)
        {
            themlop_Form frm = new themlop_Form();
            frm.Thoat += Frm_Thoat;
            frm.Show();
            this.Hide();
        }

        private void capnhat_btn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lopdachon))
            {
                capnhatlop_Form frm = new capnhatlop_Form(lopdachon);
                frm.Thoat += Frm_Thoat;
                frm.Show();
                this.Hide();
            }
        }
        bool lopdachamdiem()//kiem tra xem lop da duoc cham diem chua
        {
            int sobaithi = 0;
            sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM CT_LOP WHERE MALOP='" + lopdachon + "'";
            cmd.Connection = sqlCon;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                sobaithi = Convert.ToInt32(reader.GetValue(0).ToString());
            }
            sqlCon.Close();
            if (sobaithi == 0)
            {
                return false;
            }
            else return true;
        }
        private void xoa_btn_Click(object sender, EventArgs e)
        {
            if (!lopdachamdiem())
            {
                if (!string.IsNullOrEmpty(lopdachon))
                {
                    DialogResult Result = MessageBox.Show("Bạn có chắc chắn muốn xoá " + lopdachon + " ?", "Xoá lớp", MessageBoxButtons.YesNo);
                    if (Result == DialogResult.Yes)
                    {
                        if (sqlCon.State == ConnectionState.Closed)
                            sqlCon.Open();
                        cmd = sqlCon.CreateCommand();
                        try
                        {
                            cmd.CommandText = "DELETE FROM LOP WHERE MALOP='" + lopdachon + "'";
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Bạn đã chỉnh sửa thành công!");
                            LoadData_danhsachlop_Form();
                        }
                        catch (SqlException)
                        {
                            MessageBox.Show("Bạn đã chỉnh sửa không thành công");
                        }
                        sqlCon.Close();
                    }
                }
            }
            else MessageBox.Show("Lớp đã chấm điểm, bạn không thể xoá");
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
