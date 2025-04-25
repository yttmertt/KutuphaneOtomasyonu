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
    public partial class Sıralama : Form
    {
        public Sıralama()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source= MERT.;Initial Catalog=KütüphaneOtomasyonu;Integrated Security=True");
        DataSet ds = new DataSet();
        private void btnOkunanKitap_Click(object sender, EventArgs e)
        {
            ds.Tables.Clear();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from tblUye order by oku_kitap_sayisi desc", con);
            da.Fill(ds, "tblUye");
            dataGridView1.DataSource = ds.Tables["tblUye"];
            con.Close();
            maxbook.Text = "";
            minbook.Text = "";
            maxbook.Text = ds.Tables["tblUye"].Rows[0]["adsoyad"].ToString() + " = ";
            maxbook.Text += ds.Tables["tblUye"].Rows[0]["oku_kitap_sayisi"].ToString();
            minbook.Text = ds.Tables["tblUye"].Rows[dataGridView1.Rows.Count - 2]["adsoyad"].ToString() + " = ";
            minbook.Text += ds.Tables["tblUye"].Rows[dataGridView1.Rows.Count - 2]["oku_kitap_sayisi"].ToString();
        }
        private void btnCezaSayisi_Click(object sender, EventArgs e)
        {
            ds.Tables.Clear();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from tblUye order by toplamCeza desc", con);
            da.Fill(ds, "tblUye");
            dataGridView1.DataSource = ds.Tables["tblUye"];
            con.Close();
            maxCeza.Text = "";
            minCeza.Text = "";
            maxCeza.Text = ds.Tables["tblUye"].Rows[0]["adsoyad"].ToString() + " = ";
            maxCeza.Text += ds.Tables["tblUye"].Rows[0]["toplamCeza"].ToString();
            minCeza.Text = ds.Tables["tblUye"].Rows[dataGridView1.Rows.Count - 2]["adsoyad"].ToString() + " = ";
            minCeza.Text += ds.Tables["tblUye"].Rows[dataGridView1.Rows.Count - 2]["toplamCeza"].ToString();
        }
        private void btnEnCokOkunanKitap_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select kitapAd,barkodNo,okunmaSayisi,sonOkunmaTarihi from tblOkunanKitap order by okunmaSayisi desc", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void btnSon1AydaOkunan_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tblOkumaDetay WHERE CONVERT(datetime, okumaBitis, 104) >= DATEADD(month, -1, GETDATE())", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
    }
}
