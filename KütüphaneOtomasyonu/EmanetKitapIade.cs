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
    public partial class EmanetKitapIade : Form
    {
        public EmanetKitapIade()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source= MERT.;Initial Catalog=KütüphaneOtomasyonu;Integrated Security=True");
        DataSet ds = new DataSet();
        private void EmanetKitapIade_Load(object sender, EventArgs e)
        {
            EmanetListele();
        }
        private void EmanetListele()//tamamlandı
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from tblEmanet", con);
            da.Fill(ds, "tblEmanet");
            dataGridView1.DataSource = ds.Tables["tblEmanet"];
            con.Close();
        }
        private void btnIptal_Click(object sender, EventArgs e)//tamamlandı
        {
            this.Close();
        }
        private void txtTcSirala_TextChanged(object sender, EventArgs e)//tamamlandı
        {
            ds.Tables["tblEmanet"].Clear();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from tblEmanet where tc like '%" + txtTcSirala.Text + "%'", con);
            da.Fill(ds, "tblEmanet");
            con.Close();
            if (txtTcSirala.Text == "")
            {
                ds.Tables["tblEmanet"].Clear();
                EmanetListele();
            }
        }
        private void txtBarkodSirala_TextChanged(object sender, EventArgs e)//tamamlandı
        {
            ds.Tables["tblEmanet"].Clear();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from tblEmanet where barkodNo like '%" + txtBarkodSirala.Text + "%'", con);
            da.Fill(ds, "tblEmanet");
            con.Close();
            if (txtBarkodSirala.Text == "")
            {
                ds.Tables["tblEmanet"].Clear();
                EmanetListele();
            }
        }
        private void btnTeslimAl_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from tblEmanet where tc=@tc and barkodNo=@barkodNo", con);
            cmd.Parameters.AddWithValue("@tc", lblTc.Text);
            cmd.Parameters.AddWithValue("@barkodNo", lblBarkod.Text);
            cmd.ExecuteNonQuery();
            SqlCommand cmd2 = new SqlCommand("update tblKitap set stokSayisi=stokSayisi+'" + dataGridView1.CurrentRow.Cells["kitapSayisi"].Value.ToString() + "' where barkodNo=@barkodNo", con);
            cmd2.Parameters.AddWithValue("@barkodNo", lblBarkod.Text);
            cmd2.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kitaplar iade edildi");
            ds.Tables["tblEmanet"].Clear();
            EmanetListele();

            DateTime iadeTarihi = Convert.ToDateTime(lblIade.Text);
            DateTime bugun = DateTime.Now;

            int gecikmeGun = (bugun - iadeTarihi).Days;
            decimal ceza = 0;
            if (gecikmeGun > 0)//geç teslim okunan kitap arttı
            {
                ceza = gecikmeGun * 10;

                // tblEmanet güncelle
                con.Open();
                SqlCommand cmd3 = new SqlCommand("update tblEmanet set teslimEdildiMi = 1 where barkodNo=@barkodNo and tc=@tc", con);
                cmd3.Parameters.AddWithValue("@tc", lblTc.Text);
                cmd3.Parameters.AddWithValue("@barkodNo", lblBarkod.Text);
                cmd3.ExecuteNonQuery();
                con.Close();

                // TC ile tblUye tablosuna ceza ekle
                con.Open();
                SqlCommand cmdUye = new SqlCommand("UPDATE tblUye SET toplamCeza = toplamCeza + @ceza WHERE tc=@tc", con);
                cmdUye.Parameters.AddWithValue("@ceza", ceza);
                cmdUye.Parameters.AddWithValue("@tc", lblTc.Text);
                cmdUye.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Teslim alındı. Ceza:" + lblCeza.Text + "TL");

                con.Open();
                SqlCommand kitap = new SqlCommand("update tblUye set oku_kitap_sayisi =oku_kitap_sayisi+'" + dataGridView1.CurrentRow.Cells["kitapSayisi"].Value.ToString() + "' where tc=@tc", con);
                kitap.Parameters.AddWithValue("@tc", lblTc.Text);
                kitap.ExecuteNonQuery();
                con.Close();

                con.Open();
                SqlCommand cmdDetay = new SqlCommand("INSERT INTO tblOkumaDetay(barkodNo, kitapAd, tc, adSoyad, okumaBaslangic, okumaBitis) VALUES(@barkodNo, @kitapAd, @tc, @adsoyad, @baslangic, @bitis)", con);
                cmdDetay.Parameters.AddWithValue("@barkodNo", lblBarkod.Text);
                cmdDetay.Parameters.AddWithValue("@kitapAd", lblKitapAd.Text);
                cmdDetay.Parameters.AddWithValue("@tc", lblTc.Text);
                cmdDetay.Parameters.AddWithValue("@adsoyad", dataGridView1.CurrentRow.Cells["adsoyad"].Value.ToString());
                cmdDetay.Parameters.AddWithValue("@baslangic", dataGridView1.CurrentRow.Cells["teslimTarihi"].Value.ToString());
                cmdDetay.Parameters.AddWithValue("@bitis", dataGridView1.CurrentRow.Cells["iadeTarihi"].Value.ToString());
                cmdDetay.ExecuteNonQuery();
                con.Close();

                con.Open();
                SqlCommand cmdKontrol = new SqlCommand("SELECT COUNT(*) AS okunmaSayisi FROM tblOkunanKitap where barkodNo = @barkodNo", con);
                cmdKontrol.Parameters.AddWithValue("@barkodNo", lblBarkod.Text);
                int varMi = (int)cmdKontrol.ExecuteScalar();

                if (varMi > 0)
                {
                    SqlCommand okuKitap = new SqlCommand("update tblOkunanKitap set okunmaSayisi = okunmaSayisi+1 ,sonOkunmaTarihi = @tarih where barkodNo = @barkodNo", con);
                    okuKitap.Parameters.AddWithValue("@barkodNo", lblBarkod.Text);
                    okuKitap.Parameters.AddWithValue("@tarih", DateTime.Now);
                    okuKitap.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand ilkKitap = new SqlCommand("insert into tblOkunanKitap(barkodNo,okunmaSayisi,sonOkunmaTarihi,kitapAd) values(@barkodNo,1,@tarih,@kitapAd)", con);
                    ilkKitap.Parameters.AddWithValue("@barkodNo", lblBarkod.Text);
                    ilkKitap.Parameters.AddWithValue("@tarih", DateTime.Now);
                    ilkKitap.Parameters.AddWithValue("kitapAd", lblKitapAd.Text);
                    ilkKitap.ExecuteNonQuery();
                }
                con.Close();
            }
            else//zamanında teslim ve okunan kitap arttı
            {
                con.Open();
                SqlCommand cmdTeslim = new SqlCommand("UPDATE tblEmanet SET teslimEdildiMi = 1 WHERE tc=@tc", con);
                cmdTeslim.Parameters.AddWithValue("@tc", lblTc.Text);
                cmdTeslim.ExecuteNonQuery();
                MessageBox.Show("Zamanında teslim edildi.");
                con.Close();

                con.Open();
                SqlCommand cmdDetay = new SqlCommand("INSERT INTO tblOkumaDetay(barkodNo, kitapAd, tc, adsoyad, okumaBaslangic, okumaBitis) VALUES(@barkodNo, @kitapAd, @tc, @adsoyad, @baslangic, @bitis)", con);
                cmdDetay.Parameters.AddWithValue("@barkodNo", lblBarkod.Text);
                cmdDetay.Parameters.AddWithValue("@kitapAd", lblKitapAd.Text);
                cmdDetay.Parameters.AddWithValue("@tc", lblTc.Text);
                cmdDetay.Parameters.AddWithValue("@adsoyad", dataGridView1.CurrentRow.Cells["adsoyad"].Value.ToString());
                cmdDetay.Parameters.AddWithValue("@baslangic", dataGridView1.CurrentRow.Cells["teslimTarihi"].Value.ToString());
                cmdDetay.Parameters.AddWithValue("@bitis", lblIade.Text);
                cmdDetay.ExecuteNonQuery();
                con.Close();


                con.Open();
                SqlCommand cmdKontrol = new SqlCommand("SELECT COUNT(*) AS okunmaSayisi FROM tblOkunanKitap where barkodNo = @barkodNo", con);
                cmdKontrol.Parameters.AddWithValue("@barkodNo", lblBarkod.Text);
                int varMi = (int)cmdKontrol.ExecuteScalar();

                if (varMi > 0)
                {
                    SqlCommand okuKitap = new SqlCommand("update tblOkunanKitap set okunmaSayisi = okunmaSayisi+1 ,sonOkunmaTarihi = @tarih where barkodNo = @barkodNo", con);
                    okuKitap.Parameters.AddWithValue("@barkodNo", lblBarkod.Text);
                    okuKitap.Parameters.AddWithValue("@tarih", DateTime.Now);
                    okuKitap.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand ilkKitap = new SqlCommand("insert into tblOkunanKitap(barkodNo,okunmaSayisi,sonOkunmaTarihi,kitapAd) values(@barkodNo,1,@tarih,@kitapAd)", con);
                    ilkKitap.Parameters.AddWithValue("@barkodNo", lblBarkod.Text);
                    ilkKitap.Parameters.AddWithValue("@tarih", DateTime.Now);
                    ilkKitap.Parameters.AddWithValue("kitapAd", lblKitapAd.Text);
                    ilkKitap.ExecuteNonQuery();
                }
                con.Close();
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)//tamamlandı
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                if (row.Cells["iadeTarihi"].Value != DBNull.Value)
                {
                    lblIade.Text = Convert.ToDateTime(row.Cells["iadeTarihi"].Value).ToShortDateString();
                }
                if (row.Cells["tc"].Value != DBNull.Value)
                {
                    lblTc.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["tc"].Value);
                }
                if (row.Cells["barkodNo"].Value != DBNull.Value)
                {
                    lblBarkod.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["barkodNo"].Value);
                }
                if (row.Cells["kitapAd"].Value != DBNull.Value)
                {
                    lblKitapAd.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["kitapAd"].Value);
                }
                if (row.Cells["teslimTarihi"].Value != DBNull.Value && row.Cells["iadeTarihi"].Value != DBNull.Value)
                {
                    DateTime iade = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["iadeTarihi"].Value.ToString());

                    if (DateTime.Now > iade)
                    {
                        TimeSpan fark = DateTime.Now - iade;
                        decimal ceza = fark.Days * 5;
                        // cezaMiktari güncelle
                    }
                    // Gecikme hesaplama
                    int gecikme = (DateTime.Now - iade).Days;
                    gecikme = gecikme > 0 ? gecikme : 0;
                    decimal cezaTutari = gecikme * 10;

                    // Label'lara yazdır
                    lblBugun.Text = DateTime.Now.ToString();
                    lblGecikmeGun.Text = gecikme + " gün";
                    lblCeza.Text = cezaTutari.ToString("0.00") + "₺";
                }
                else
                {
                    lblGecikmeGun.Text = "-";
                    lblCeza.Text = "0 TL";
                }
            }
        }
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;


                if (row.Cells["iadeTarihi"].Value != DBNull.Value)
                {
                    DateTime teslim = Convert.ToDateTime(row.Cells["teslimTarihi"].Value);
                    DateTime iade = Convert.ToDateTime(row.Cells["iadeTarihi"].Value);
                    DateTime bugun = DateTime.Today;

                    if (bugun <= iade)//iade tarihi geçmedi
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                    }
                    else if (bugun >= iade)//iade tarihi geçmiş
                    {
                        row.DefaultCellStyle.BackColor = Color.Orange;
                    }
                }
               
            }
        }
    }
}

