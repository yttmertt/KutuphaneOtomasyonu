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
    public partial class EmanetKitapListele : Form
    {
        public EmanetKitapListele()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source= MERT.;Initial Catalog=KütüphaneOtomasyonu;Integrated Security=True");
        DataSet ds = new DataSet();

        private void EmanetListele()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from tblEmanet", con);
            da.Fill(ds, "tblEmanet");
            dataGridView1.DataSource = ds.Tables["tblEmanet"];
            con.Close();
        }

        private void EmanetKitapListele_Load(object sender, EventArgs e)
        {
            cbfiltre.Text = "Seçiniz";
        }

        private void cbfiltre_SelectedIndexChanged(object sender, EventArgs e)
        {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();

            if (ds.Tables.Contains("tblEmanet")) ds.Tables["tblEmanet"].Clear();

            if (cbfiltre.SelectedIndex==0)//tüm kitaplar
            {
                EmanetListele();
            }
            else if (cbfiltre.SelectedIndex==1)//geç kalan kitaplar
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from tblEmanet where CAST(iadeTarihi AS DATE) < CAST(GETDATE() AS DATE)", con);
                da.Fill(ds, "tblEmanet");
                dataGridView1.DataSource = ds.Tables["tblEmanet"];
                con.Close();
            }
            else if (cbfiltre.SelectedIndex==2)//iade vakti dolmamış olan kitaplar
            {

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from tblEmanet where CAST(iadeTarihi AS DATE) >= CAST(GETDATE() AS DATE)", con);
                da.Fill(ds, "tblEmanet");
                dataGridView1.DataSource = ds.Tables["tblEmanet"];
                con.Close();
            }
        }

        
    }
}
