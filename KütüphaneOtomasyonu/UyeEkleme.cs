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
    public partial class UyeEkleme : Form
    {
        public UyeEkleme()
        {
            InitializeComponent();
        }
        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        SqlConnection con = new SqlConnection("Data Source= MERT.;Initial Catalog=KütüphaneOtomasyonu;Integrated Security=True");
        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into tblUye(tc,adsoyad,yas,cinsiyet,telefon,adres,email,oku_kitap_sayisi,toplamCeza) values (@tc,@adsoyad,@yas,@cinsiyet,@telefon,@adres,@email,@oku_kitap_sayisi,@toplamCeza)", con);
            if (txtTc.Text != "" && txtAdSoyad.Text != "" && txtYas.Text != "" && cbCinsiyet.Text != "" && txtTel.Text != "" && txtAdres.Text != "" && txtEmail.Text != "" && txtOkunanKitap.Text != "" && txtCeza.Text != "")
            {
                con.Open();
                cmd.Parameters.AddWithValue("@tc", txtTc.Text);
                cmd.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
                cmd.Parameters.AddWithValue("@yas", txtYas.Text);
                cmd.Parameters.AddWithValue("@cinsiyet", cbCinsiyet.Text);
                cmd.Parameters.AddWithValue("@telefon", txtTel.Text);
                cmd.Parameters.AddWithValue("@adres", txtAdres.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@oku_kitap_sayisi", txtOkunanKitap.Text);
                cmd.Parameters.AddWithValue("@toplamCeza", txtCeza.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Üye kaydı yapıldı");

                foreach (Control item in Controls)
                {
                    if (item is TextBox)
                    {
                        if (item != txtOkunanKitap)
                        {
                            item.Text = "";
                        }
                    }
                }
            }
            else MessageBox.Show("Lütfen boş olan yerleri doldurunuz");
        }
    }
}
