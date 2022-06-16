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
    public partial class baocaonham_Form : Form
    {
        SqlConnection sqlCon = null;
        string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        SqlCommand cmd;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        List<baocaomonhoc> danhsachmonhoc = new List<baocaomonhoc>();
        public baocaonham_Form()
        {
            InitializeComponent();
            sqlCon = new SqlConnection(strCon);
        }
        public event EventHandler Thoat;

        private void baocaonham_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thoat(this, new EventArgs());
        }
        void LoadData_baocaonam_Form()
        {
            nam_nud.Value = DateTime.Now.Year;
        }

        private void xem_btn_Click(object sender, EventArgs e)
        {
            nam_label.Text = nam_nud.Value.ToString();
            Load_tongso();
            Load_danhsachmonhoc();
            Load_baocao_dgv();

        }
        void Load_danhsachmonhoc()
        {
            danhsachmonhoc.Clear();
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT MAMONHOC FROM MONHOC";
            cmd.Connection = sqlCon;
            SqlDataReader Sdr = cmd.ExecuteReader();
            while (Sdr.Read())
            {
                baocaomonhoc bc;
                for(int i=0;i<Sdr.FieldCount;i++)
                {
                    bc = new baocaomonhoc() { mamonhoc = Sdr.GetString(i) };
                    danhsachmonhoc.Add(bc);
                }
            }
            Sdr.Close();
            sqlCon.Close();
            if (Convert.ToDecimal(tsbc_label.Text) != 0)
            {
                for (int i = 0; i < danhsachmonhoc.Count; i++)
                {
                    if (sqlCon.State == ConnectionState.Closed)
                        sqlCon.Open();

                    cmd = sqlCon.CreateCommand();
                    cmd.CommandText = "SELECT COUNT (*) FROM CT_LOP JOIN LOP ON CT_LOP.MALOP=LOP.MALOP WHERE MAMONHOC='" + danhsachmonhoc[i].mamonhoc + "' AND NAMHOC=" + nam_nud.Value + "";
                    cmd.Connection = sqlCon;
                    Sdr = cmd.ExecuteReader();
                    while (Sdr.Read())
                    {
                        decimal tylebaicham = Decimal.Round(Convert.ToDecimal(Sdr.GetValue(0).ToString()) / Convert.ToDecimal(tsbc_label.Text),2);
                        danhsachmonhoc[i].sobaicham = Sdr.GetValue(0).ToString();
                        danhsachmonhoc[i].tylebaicham = tylebaicham.ToString();
                    }
                    Sdr.Close();
                    sqlCon.Close();
                }
            }
            else
            {
                for (int i = 0; i < danhsachmonhoc.Count; i++)
                {
                    danhsachmonhoc[i].sobaicham = "0";
                    danhsachmonhoc[i].tylebaicham = "0";
                }
            }
            if (Convert.ToDecimal(tsdt_label.Text) != 0)
            {
                for (int i = 0; i < danhsachmonhoc.Count; i++)
                {
                    if (sqlCon.State == ConnectionState.Closed)
                        sqlCon.Open();

                    cmd = sqlCon.CreateCommand();
                    cmd.CommandText = "SELECT COUNT (*) FROM DETHI WHERE MAMONHOC='" + danhsachmonhoc[i].mamonhoc + "' AND NAMHOC=" + nam_nud.Value + "";
                    cmd.Connection = sqlCon;
                    Sdr = cmd.ExecuteReader();
                    while (Sdr.Read())
                    {
                        decimal tyledethi = Decimal.Round(Convert.ToDecimal(Sdr.GetValue(0).ToString()) / Convert.ToDecimal(tsdt_label.Text),2);
                        danhsachmonhoc[i].sodethi = Sdr.GetValue(0).ToString();
                        danhsachmonhoc[i].tyledethi = tyledethi.ToString();
                    }
                    Sdr.Close();
                    sqlCon.Close();
                }
            }
            else
            {
                for (int i = 0; i < danhsachmonhoc.Count; i++)
                {
                    danhsachmonhoc[i].sodethi = "0";
                    danhsachmonhoc[i].tyledethi = "0";
                }
            }
        }
        void Load_tongso()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT count(*) FROM CT_LOP JOIN LOP ON CT_LOP.MALOP=LOP.MALOP WHERE NAMHOC="+nam_nud.Value+"";
            cmd.Connection = sqlCon;
            SqlDataReader Sdr = cmd.ExecuteReader();
            while (Sdr.Read())
            {
                tsbc_label.Text=Sdr.GetValue(0).ToString();
                
            }
            Sdr.Close();
            sqlCon.Close();

            sqlCon.Open();

            cmd = sqlCon.CreateCommand();
            cmd.CommandText = "SELECT count(*) FROM DETHI WHERE NAMHOC=" + nam_nud.Value + "";
            cmd.Connection = sqlCon;
            Sdr = cmd.ExecuteReader();
            while (Sdr.Read())
            {
                tsdt_label.Text = Sdr.GetValue(0).ToString();

            }
            Sdr.Close();
            sqlCon.Close();
        }
        void Load_baocao_dgv()
        {
            baocao_dgv.DataSource = null;
            baocao_dgv.DataSource = danhsachmonhoc;
            baocao_dgv.Columns[0].HeaderText = "Mã môn học";
            baocao_dgv.Columns[1].HeaderText = "Số đề thi";
            baocao_dgv.Columns[2].HeaderText = "Tỷ lệ đề thi";
            baocao_dgv.Columns[3].HeaderText = "Số bài chấm";
            baocao_dgv.Columns[4].HeaderText = "Tỷ lệ bài chấm";
        }

        private void quaylai_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void baocaonham_Form_Load(object sender, EventArgs e)
        {
            LoadData_baocaonam_Form();
        }

        
    }
   }

    


