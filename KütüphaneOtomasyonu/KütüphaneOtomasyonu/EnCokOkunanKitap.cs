using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KütüphaneOtomasyonu
{
    public partial class EnCokOkunanKitap : Form
    {
        public EnCokOkunanKitap()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source= MERT.;Initial Catalog=KütüphaneOtomasyonu;Integrated Security=True");
        private void EnCokOkunanGetir()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select kitapAd,barkodNo,okunmaSayisi,sonOkunmaTarihi from tblOkunanKitap order by okunmaSayisi desc", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void EnCokOkunanKitap_Load(object sender, EventArgs e)
        {
            EnCokOkunanGetir();
        }
    }
}
