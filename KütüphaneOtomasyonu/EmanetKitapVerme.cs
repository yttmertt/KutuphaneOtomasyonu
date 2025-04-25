using System;
using System.CodeDom;
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
    public partial class EmanetKitapVerme : Form
    {
        public EmanetKitapVerme()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source= MERT.;Initial Catalog=KütüphaneOtomasyonu;Integrated Security=True");
        DataSet ds = new DataSet();
        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void EmanetKitapVerme_Load(object sender, EventArgs e)
        {
            sepetListele();
            kitappSayisi();
            //lblSepetSayisi.Text = (dataGridView1.Rows.Count-1).ToString();
        }
        private void sepetListele()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from tblSepet", con);
            da.Fill(ds, "tblSepet");
            dataGridView1.DataSource = ds.Tables["tblSepet"];
            con.Close();
        }
        private void btnEkle_Click(object sender, EventArgs e)//tamamlandı
        {
            
            SqlCommand cmd = new SqlCommand("insert into tblSepet(barkodNo, kitapAdi, yazar, yayinevi, sayfaSayisi, kitapSayisi, teslimTarihi, iadeTarihi) values(@barkodNo, @kitapAdi, @yazar, @yayinevi, @sayfaSayisi, @kitapSayisi, @teslimTarihi, @iadeTarihi)", con);

            if (txtBarkodNo.Text != ""&& txtKitapAd.Text != ""&& txtYazar.Text != ""&& txtYayinevi.Text != ""&& txtSayfaSayisi.Text != ""&& txtKitapSayisi.Text != ""&& dtpTeslim.Text != ""&& dtpIade.Text != "")
            { 
                con.Open();
                cmd.Parameters.AddWithValue("@barkodNo", txtBarkodNo.Text);
                cmd.Parameters.AddWithValue("kitapAdi", txtKitapAd.Text);
                cmd.Parameters.AddWithValue("yazar", txtYazar.Text);
                cmd.Parameters.AddWithValue("yayinevi", txtYayinevi.Text);
                cmd.Parameters.AddWithValue("sayfaSayisi", txtSayfaSayisi.Text);
                cmd.Parameters.AddWithValue("kitapSayisi", txtKitapSayisi.Text);
                cmd.Parameters.AddWithValue("@teslimTarihi", dtpTeslim.Value);
                cmd.Parameters.AddWithValue("@iadeTarihi", dtpIade.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                ds.Tables["tblSepet"].Clear();
                sepetListele();
                lblKayitKitapSayisi.Text = "";
                kitappSayisi();
                MessageBox.Show("Kitap kaydı yapıldı", "Ekleme işlemi");
                foreach (Control item in grpKitapBilgi.Controls)
                {
                    if (item is TextBox)
                    {
                        if (item != txtKitapSayisi)
                        {
                            item.Text = "";
                        }
                    }
                }
            }
            else MessageBox.Show("lütfen boş olan yerleri doldurun");
        }
        private void txtTcAra_TextChanged(object sender, EventArgs e)//tamamlandı
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblUye where tc like '" + txtTcAra.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtAdSoyad.Text = dr["adsoyad"].ToString();
                txtYas.Text = dr["yas"].ToString();
                txtTel.Text = dr["telefon"].ToString();
            }
            con.Close();

            con.Open();
            SqlCommand cmd2 = new SqlCommand("SELECT SUM(kitapSayisi) from tblEmanet WHERE tc=@tc", con);
            cmd2.Parameters.AddWithValue("@tc",txtTcAra.Text);
            lblKayitKitapSayisi.Text = cmd2.ExecuteScalar().ToString();
            con.Close();

            if (txtTcAra.Text == "")
            {
                foreach (Control item in grpUyeBilgi.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                        lblKitapSayisi.Text = "";
                    }   

                }
            }
        }
        private void kitappSayisi()//kaç kitap eklemek istersek
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select sum(kitapSayisi) from tblSepet", con);
            lblKitapSayisi.Text = cmd.ExecuteScalar().ToString();
            con.Close();
        }
        private void txtBarkodNo_TextChanged(object sender, EventArgs e)//tamamlandı
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblKitap where barkodNo like '" + txtBarkodNo.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtKitapAd.Text = dr["kitapAdi"].ToString();
                txtYazar.Text = dr["yazar"].ToString();
                txtYayinevi.Text = dr["yayinevi"].ToString();
                txtSayfaSayisi.Text = dr["sayfaSayisi"].ToString();
            }
            con.Close();

            if (txtBarkodNo.Text=="")
            {
                foreach (Control item in grpKitapBilgi.Controls)
                {
                    if (item is TextBox)
                    {
                        if (item != txtKitapSayisi)
                        {
                            item.Text = "";
                        }
                    }
                }
            }
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult sil = MessageBox.Show("Silmek istediğinize emin misiniz?", "Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (sil == DialogResult.Yes)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from tblSepet where barkodNo= '" + dataGridView1.CurrentRow.Cells["barkodNo"].Value.ToString() +"'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Silme Tamamlandı", "silme");
                ds.Tables["tblSepet"].Clear();
                sepetListele();
                lblKitapSayisi.Text = "";
                kitappSayisi();
            }
        }
        private void btnTeslimEt_Click(object sender, EventArgs e)
        {
            
            if (lblKitapSayisi.Text!="")
            {
                if (lblKayitKitapSayisi.Text==""&& int.Parse(lblKitapSayisi.Text)<=3|| lblKayitKitapSayisi.Text!="" && int.Parse(lblKayitKitapSayisi.Text)+int.Parse(lblKitapSayisi.Text)<=3)
                {
                    if (txtTcAra.Text!=""&&txtAdSoyad.Text!=""&&txtYas.Text!=""&&txtTel.Text!="")
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand("INSERT INTO tblEmanet(tc, adsoyad, yas,telefon,barkodNo,kitapAd,yazar,yayinevi,sayfaSayisi,kitapSayisi,teslimTarihi, iadeTarihi) values(@tc,@adsoyad,@yas,@telefon,@barkodNo,@kitapAd,@yazar,@yayinevi,@sayfaSayisi,@kitapSayisi,@teslimTarihi,@iadeTarihi)", con);
                            cmd.Parameters.AddWithValue("@tc", txtTcAra.Text);
                            cmd.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
                            cmd.Parameters.AddWithValue("@yas", txtYas.Text);
                            cmd.Parameters.AddWithValue("@telefon", txtTel.Text);
                            cmd.Parameters.AddWithValue("@barkodNo", dataGridView1.Rows[i].Cells["barkodNo"].Value.ToString());
                            cmd.Parameters.AddWithValue("@kitapAd", dataGridView1.Rows[i].Cells["kitapAdi"].Value.ToString());
                            cmd.Parameters.AddWithValue("@yazar", dataGridView1.Rows[i].Cells["yazar"].Value.ToString());
                            cmd.Parameters.AddWithValue("@yayinevi", dataGridView1.Rows[i].Cells["yayinevi"].Value.ToString());
                            cmd.Parameters.AddWithValue("@sayfaSayisi", dataGridView1.Rows[i].Cells["sayfaSayisi"].Value.ToString());
                            cmd.Parameters.AddWithValue("@kitapSayisi", dataGridView1.Rows[i].Cells["kitapSayisi"].Value.ToString());
                            cmd.Parameters.AddWithValue("@teslimTarihi", dataGridView1.Rows[i].Cells["teslimTarihi"].Value.ToString());
                            cmd.Parameters.AddWithValue("@iadeTarihi", dataGridView1.Rows[i].Cells["iadeTarihi"].Value.ToString());
                            cmd.ExecuteNonQuery();

                            SqlCommand cmd2 = new SqlCommand("update tblUye set oku_kitap_sayisi=oku_kitap_sayisi+'" + int.Parse(dataGridView1.Rows[i].Cells["kitapSayisi"].Value.ToString())+"' where tc='"+txtTcAra.Text+"'", con);
                            cmd2.ExecuteNonQuery();
                            SqlCommand cmd3 = new SqlCommand("update tblKitap set stokSayisi=stokSayisi - '" + int.Parse(dataGridView1.Rows[i].Cells["kitapSayisi"].Value.ToString()) + "' where barkodNo='" + dataGridView1.Rows[i].Cells["barkodNo"].Value.ToString() + "'", con);
                            cmd3.ExecuteNonQuery();
                            con.Close();
                        }
                        con.Open();
                        SqlCommand cmd4 = new SqlCommand("delete from tblSepet", con);
                        cmd4.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Kitap Emanet İşlemi Tamamlandı", "Tamamlandı");
                        ds.Tables["tblSepet"].Clear();
                        sepetListele();
                        txtTcAra.Text = "";
                        lblKitapSayisi.Text = "";
                        kitappSayisi();
                        lblKayitKitapSayisi.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Lütfen Üye Bilgilerini Kontrol Edin", "uyarı");
                    }
                }
                else
                {
                    MessageBox.Show("Üçten fazla kitap veremezsiniz","uyarı");
                }
            }
            else
            {
                MessageBox.Show("Lütfen sepete kitap ekleyin", "uyarı");
            }
            //--------------------En Çok Okunan Kitap--------------
            /*con.Open();
            SqlCommand cmdKontrol = new SqlCommand("select count(*) from tblOkunanKitap where barkodNo = @barkodNo",con);
            cmdKontrol.Parameters.AddWithValue("@barkodNo", lblBarkod.Text);
            int sayi = (int)cmdKontrol.ExecuteScalar();

            if (sayi > 0)
            {
                SqlCommand cmdGuncelle = new SqlCommand("update tblOkunanKitap set okunmaSayisi = okunmaSayisi + 1,sonOkunmaTarihi = getdate(),kitapAd=@kitapAd where barkodNo = @barkodNo ", con);
                cmdGuncelle.Parameters.AddWithValue("@barkodNo",lblBarkod.Text);
                cmdGuncelle.Parameters.AddWithValue("@kitapAd", lblKitap.Text);
                cmdGuncelle.ExecuteNonQuery();
            }
            else
            {
                SqlCommand cmdEkle = new SqlCommand("insert into tblOkunanKitap(kitapAd,barkodNo,okunmaSayisi,sonOkunmaTarihi) values(@kitapAd,@barkodNo,1,getdate())", con);
                cmdEkle.Parameters.AddWithValue("@barkodNo", lblBarkod.Text);
                cmdEkle.Parameters.AddWithValue("@kitapAd", lblKitap.Text);
                cmdEkle.ExecuteNonQuery();
            }
            con.Close();*/
            
        }
        
    }
}
