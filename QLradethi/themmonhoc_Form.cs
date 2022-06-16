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
    public partial class themmonhoc_Form : Form
    {
        public static string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["stringDatabase"].ConnectionString;
        SqlConnection con = new SqlConnection(strCon);
        SqlConnection sqlCon = null;
        public themmonhoc_Form()
        {
            InitializeComponent();
            sqlCon = new SqlConnection(strCon);
        }
        public event EventHandler Thoat;

        private void themmonhoc_Form_FormClosed(object sender, FormClosedEventArgs e)
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
            if (exedata("insert into MONHOC values('" + mamonhoc_txtbox.Text + "',N'" + tenmonhoc_txtbox.Text + "')") == true)
            {
                MessageBox.Show("Thêm thành công!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm không thành công");
            }
        }

        private void huy_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void themmonhoc_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
