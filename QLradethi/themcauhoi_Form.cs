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
    public partial class themcauhoi_Form : Form
    {
        string gvID;
        public static string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        SqlConnection con = new SqlConnection(strCon);
        SqlConnection sqlCon = null;
        public themcauhoi_Form()
        {
            InitializeComponent();
            sqlCon = new SqlConnection(strCon);
        }
        public themcauhoi_Form(string gvID) : this()
        {
            this.gvID = gvID;
        }
        public event EventHandler Thoat;

        private void themcauhoi_Form_FormClosed(object sender, FormClosedEventArgs e)
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

        private void them_btn_Click(object sender, EventArgs e)
        {
            if (exedata("insert into CAUHOI values('" + macauhoi_txtbox.Text + "','" + monhoc_cbo.SelectedValue.ToString()  +"','" + this.gvID + "','" + dokho_cbo.SelectedValue.ToString() + "',N'" + noidung_rtxtbox.Text + "')") == true)
            {
                MessageBox.Show("Thêm thành công!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm không thành công");
            }
        }

        private void themcauhoi_Form_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand fill_cbo_dokho = new SqlCommand("SELECT * FROM DOKHO ", con);
            SqlCommand fill_cbo_monhoc = new SqlCommand("SELECT * FROM MONHOC", con);
            SqlDataAdapter da1 = new SqlDataAdapter(fill_cbo_dokho);
            SqlDataAdapter da2 = new SqlDataAdapter(fill_cbo_monhoc);
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();
            da1.Fill(ds1);
            da2.Fill(ds2);
            fill_cbo_dokho.ExecuteNonQuery();
            fill_cbo_monhoc.ExecuteNonQuery();
            con.Close();

            dokho_cbo.DisplayMember = "TENDOKHO";
            dokho_cbo.ValueMember = "MADOKHO";
            dokho_cbo.DataSource = ds1.Tables[0];

            monhoc_cbo.DisplayMember = "TENMONHOC";
            monhoc_cbo.ValueMember = "MAMONHOC";
            monhoc_cbo.DataSource = ds2.Tables[0];
        }

        private void huy_btn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
