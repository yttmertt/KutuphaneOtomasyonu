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

namespace KütüphaneOtomasyonu
{
    public partial class GelişmişAramaFiltreleme : Form
    {
        public GelişmişAramaFiltreleme()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source= MERT.;Initial Catalog=KütüphaneOtomasyonu;Integrated Security=True");
        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            string filtre = cbFiltre.SelectedItem.ToString();
            string arama = txtAra.Text.Trim();
            string sorgu = "select * from tblEmanet where 1=1";
            con.Open();
            if (!string.IsNullOrEmpty(arama))
            {
                sorgu += "and kitapAd like '%" + arama + "%'";
            }
            if (filtre == "Bugün Teslim Edilmesi Gerekenler")
            {
                sorgu += "and CAST(getdate() AS DATE) = CAST(iadeTarihi AS DATE)";
            }
            if (filtre== "Geç Kalmış")
            {
                sorgu += "and CAST(getdate() AS DATE) > CAST(iadeTarihi AS DATE)";
            }
            if (filtre == "İade Vakti Yaklaşan")
            {
                sorgu += "and iadeTarihi > CAST(getdate() AS DATE) and iadeTarihi <= DATEADD(day, 1, CAST(getdate() AS DATE))";
            }
            SqlDataAdapter da = new SqlDataAdapter(sorgu,con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtAra.Clear();
            cbFiltre.SelectedIndex = -1;
            btnFiltrele.PerformClick();
        }
        private void GelişmişAramaFiltreleme_Load(object sender, EventArgs e)
        {
            cbFiltre.SelectedIndex = 0;
        }
    }
}
