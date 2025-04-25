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
    public partial class KitapEkle : Form
    {
        public KitapEkle()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source= MERT.;Initial Catalog=KütüphaneOtomasyonu;Integrated Security=True");

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)//tamamlandı
        {
            SqlCommand cmd = new SqlCommand("insert into tblKitap (barkodNo,kitapAdi,yazar,sayfaSayisi,yayinevi,turu,rafNo,stokSayisi,kayitTarihi,aciklama) values (@barkodNo,@kitapAdi,@yazar,@sayfaSayisi,@yayinevi,@turu,@rafNo,@stokSayisi,@kayitTarihi,@aciklama)", con);
            if (txtBarkod.Text != "" && txtKitapAd.Text != "" && txtYazar.Text != "" && txtSayfaSayisi.Text != "" && txtYayinEvi.Text != "" && cbTur.Text != "" && txtRaf.Text != "" && txtAciklama.Text != "")
            {
                con.Open();
                cmd.Parameters.AddWithValue("@barkodNo", txtBarkod.Text);
                cmd.Parameters.AddWithValue("@kitapAdi", txtKitapAd.Text);
                cmd.Parameters.AddWithValue("@yazar", txtYazar.Text);
                cmd.Parameters.AddWithValue("@sayfaSayisi", txtSayfaSayisi.Text);
                cmd.Parameters.AddWithValue("@yayinevi", txtYayinEvi.Text);
                cmd.Parameters.AddWithValue("@turu", cbTur.Text);
                cmd.Parameters.AddWithValue("@rafNo", txtRaf.Text);
                cmd.Parameters.AddWithValue("@stokSayisi", txtSayfaSayisi.Text);
                cmd.Parameters.AddWithValue("@kayitTarihi", DateTime.Now.ToShortDateString());
                cmd.Parameters.AddWithValue("@aciklama", txtAciklama.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Kitap kaydı yapıldı");

                foreach (Control item in this.Controls)//temizleme
                {
                    if (item is TextBox textBox)
                    {
                        textBox.Clear();
                    }
                    else if (item is ComboBox combo)
                    {
                        combo.Text = "Seçiniz";
                    }
                    else if (item is Panel || item is GroupBox)
                    {
                        foreach (Control innerControl in item.Controls)
                        {
                            if (innerControl is TextBox textBox1)
                            {
                                textBox1.Clear();
                            }
                            else if (innerControl is ComboBox comboBox1)
                            {
                                comboBox1.Text = "Seçiniz";
                            }
                        }
                    }
                }
            }
            else MessageBox.Show("Lütfen boş olan yerleri doldurunuz");
        }
    }
}
