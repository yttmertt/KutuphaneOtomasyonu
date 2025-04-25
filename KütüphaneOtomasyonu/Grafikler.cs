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
using System.Windows.Forms.DataVisualization.Charting;

namespace KütüphaneOtomasyonu
{
    public partial class Grafikler : Form
    {
        public Grafikler()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source= MERT.;Initial Catalog=KütüphaneOtomasyonu;Integrated Security=True");
        private void Grafikler_Load(object sender, EventArgs e)
        {
            /*con.Open();
            SqlCommand cmd = new SqlCommand("select adsoyad,oku_kitap_sayisi from tblUye", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                chart1.Series["Okunan Kitap Sayısı"].Points.AddXY(dr["adsoyad"].ToString(), dr["oku_kitap_sayisi"].ToString());
            }
            con.Close();
            chart1.Series["Okunan Kitap Sayısı"].Color = Color.Orange;*/
        }

        private void btnFiltre_Click(object sender, EventArgs e)
        {
            if (cbFiltre.Text!="")
            {
                string filtre = cbFiltre.SelectedItem.ToString();
                foreach (var series in chart1.Series)
                {
                    series.Points.Clear();
                }
                con.Open();
                if (filtre == "En Çok Kitap Okuyan Üyeler")
                {
                    if (!chart1.Series.IsUniqueName("Okunan Kitap Sayısı"))
                        chart1.Series.Remove(chart1.Series["Okunan Kitap Sayısı"]);
                    chart1.Series.Add("Okunan Kitap Sayısı");

                    SqlCommand cmd = new SqlCommand("select adsoyad,oku_kitap_sayisi from tblUye", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        chart1.Series["Okunan Kitap Sayısı"].Points.AddXY(dr["adsoyad"].ToString(), dr["oku_kitap_sayisi"].ToString());
                    }
                    dr.Close();
                    chart1.Series["Toplam Ceza Sayısı"].Enabled = false;
                    chart1.Series["Okunan Kitap Sayısı"].Color = Color.Orange;

                }
                else if (filtre == "En Çok Cezası Olan Üyeler")
                {
                    if (!chart1.Series.IsUniqueName("Toplam Ceza Sayısı"))
                        chart1.Series.Remove(chart1.Series["Toplam Ceza Sayısı"]);
                    chart1.Series.Add("Toplam Ceza Sayısı");

                    chart1.Series["Toplam Ceza Sayısı"].Points.Clear();
                    SqlCommand cmd = new SqlCommand("select adsoyad,toplamCeza from tblUye", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        chart1.Series["Toplam Ceza Sayısı"].Points.AddXY(dr["adsoyad"].ToString(), dr["toplamCeza"].ToString());
                    }
                    dr.Close();
                    chart1.Series["Okunan Kitap Sayısı"].Enabled = false;
                    chart1.Series["Toplam Ceza Sayısı"].Color = Color.Red;
                }
                con.Close();
            }
            else MessageBox.Show("Lütfen Grafikte Gösterilmesini İstediğiniz Veriyi Seçiniz","UYARI");

        }
    }
}
