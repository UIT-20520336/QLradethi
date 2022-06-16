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
    public partial class danhsachcauhoi_Form : Form
    {
        string gvID;
        string cauhoidachon;
        string gvdachon;
        SqlConnection sqlCon = null;
        string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        SqlCommand cmd;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public danhsachcauhoi_Form()
        {
            InitializeComponent();
            sqlCon = new SqlConnection(strCon);
        }
        public danhsachcauhoi_Form(string gvID): this()
        {
            this.gvID = gvID;
        }
        public EventHandler Thoat;
        private void danhsachcauhoi_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thoat(this, new EventArgs());
        }

        private void Frm_Thoat(object sender, EventArgs e)
        {
            this.Show();
            LoadData_danhsachcauhoi_Form();
        }
        void LoadData_danhsachcauhoi_Form()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT MACAUHOI, MAMONHOC, MAGIANGVIEN, MADOKHO, NOIDUNG FROM CAUHOI";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            dsch_dgv.DataSource = table;
            dsch_dgv.Columns[0].HeaderText = "Mã Câu Hỏi";
            dsch_dgv.Columns[0].Width = 70;
            dsch_dgv.Columns[1].HeaderText = "Mã Môn Học";
            dsch_dgv.Columns[1].Width = 70;
            dsch_dgv.Columns[2].HeaderText = "Mã Giảng Viên";
            dsch_dgv.Columns[2].Width = 70;
            dsch_dgv.Columns[3].HeaderText = "Mã Độ Khó";
            dsch_dgv.Columns[3].Width = 70;
            dsch_dgv.Columns[4].HeaderText = "Nội dung";
            dsch_dgv.Columns[4].Width = 280;
            if(dsch_dgv.Rows.Count >= 1)
            {
                DataGridViewRow row = this.dsch_dgv.Rows[0];
                cauhoidachon = row.Cells[0].Value.ToString();
            }
            sqlCon.Close();
        }

        private void quaylai_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dsch_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dsch_dgv.Rows[e.RowIndex];
                cauhoidachon = row.Cells[0].Value.ToString();
                gvdachon = row.Cells[2].Value.ToString();
            }

        }

        private void danhsachcauhoi_Form_Load(object sender, EventArgs e)
        {
            LoadData_danhsachcauhoi_Form();
        }

        private void them_btn_Click(object sender, EventArgs e)
        {
            themcauhoi_Form frm = new themcauhoi_Form(gvID);
            frm.Thoat += Frm_Thoat;
            frm.Show();
            this.Hide();
            LoadData_danhsachcauhoi_Form();
        }
        bool cauhoidasudung()//kiem tra xem cau hoi da su dung chua
        {
            int solandungcauhoi = 0;
            sqlCon.Open();
            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM CT_DETHI WHERE MACAUHOI='" + cauhoidachon + "'";
            cmd.Connection = sqlCon;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                solandungcauhoi = Convert.ToInt32(reader.GetValue(0).ToString());
            }
            sqlCon.Close();
            if (solandungcauhoi == 0)
            {
                return false;
            }
            else return true;
        }
        private void xoa_btn_Click(object sender, EventArgs e)
        {
            if (!cauhoidasudung())
            {

                if ((!string.IsNullOrEmpty(cauhoidachon)) && (gvdachon == gvID))
                {
                    DialogResult Result = MessageBox.Show("Bạn có chắc chắn muốn xoá câu hỏi " + cauhoidachon + " ?", "Xoá câu hỏi", MessageBoxButtons.YesNo);
                    if (Result == DialogResult.Yes)
                    {
                        if (sqlCon.State == ConnectionState.Closed)
                            sqlCon.Open();
                        cmd = sqlCon.CreateCommand();
                        try
                        {
                            cmd.CommandText = "DELETE FROM CAUHOI WHERE MACAUHOI='" + cauhoidachon + "'";
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Bạn đã chỉnh sửa thành công!");
                            LoadData_danhsachcauhoi_Form();
                        }
                        catch (SqlException)
                        {
                            MessageBox.Show("Bạn đã chỉnh sửa không thành công");
                        }
                        sqlCon.Close();
                    }
                }
            }
            else
                MessageBox.Show("Câu hỏi đã được sử dụng");
        }

        private void capnhat_btn_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(cauhoidachon)) && (gvdachon == gvID))
            {
                capnhatcauhoi_Form frm = new capnhatcauhoi_Form(cauhoidachon);
                frm.Thoat += Frm_Thoat;
                frm.Show();
                this.Hide();
            }
            else if ((!string.IsNullOrEmpty(cauhoidachon)) && (gvdachon != gvID))
            {
                capnhatcauhoi_Form frm = new capnhatcauhoi_Form(cauhoidachon);
                frm.Enabled = false;
                frm.Thoat += Frm_Thoat;
                frm.Show();
                this.Hide();
            }
        }
    }
}
