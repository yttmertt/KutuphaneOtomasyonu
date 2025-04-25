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
    public partial class KitapListele : Form
    {
        public KitapListele()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source= MERT.;Initial Catalog=KütüphaneOtomasyonu;Integrated Security=True");
        DataSet ds = new DataSet();

        private void kitapListeleme()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tblKitap ORDER BY barkodNo asc;", con);
            da.Fill(ds, "tblKitap");
            dataGridView1.DataSource = ds.Tables["tblKitap"];
            con.Close();
        }

        private void btnSil_Click(object sender, EventArgs e)//tamamlandı
        {
            DialogResult dr = MessageBox.Show("Silmek istediğinize emin misiniz?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from tblKitap where barkodNo=@barkodNo", con);
                cmd.Parameters.AddWithValue("@barkodNo", dataGridView1.CurrentRow.Cells["barkodNo"].Value.ToString());
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Silme Tamamlandı");
                ds.Tables["tblKitap"].Clear();
                kitapListeleme();

                foreach (Control item in Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
            }
        }
        private void btnGuncelle_Click(object sender, EventArgs e)//tamamlandı
        {
            SqlCommand cmd = new SqlCommand("update tblKitap set kitapAdi=@kitapAdi,yazar=@yazar,sayfaSayisi=@sayfaSayisi,yayinevi=@yayinevi,turu=@turu,rafNo=@rafNo,stokSayisi=@stokSayisi,aciklama=@aciklama where barkodNo=@barkodNo", con);
            if (txtBarkod.Text != "" && txtKitapAd.Text != "" && txtYazar.Text != "" && txtSayfaSayisi.Text != "" && txtYayinEvi.Text != "" && cbTur.Text != "" && txtRafNo.Text != "" && txtStokSayisi.Text != "" && txtAciklama.Text != "")
            {
                con.Open();
                cmd.Parameters.AddWithValue("@barkodNo", txtBarkod.Text);
                cmd.Parameters.AddWithValue("@kitapAdi", txtKitapAd.Text);
                cmd.Parameters.AddWithValue("@yazar", txtYazar.Text);
                cmd.Parameters.AddWithValue("@sayfaSayisi", txtSayfaSayisi.Text);
                cmd.Parameters.AddWithValue("@yayinevi", txtYayinEvi.Text);
                cmd.Parameters.AddWithValue("@turu", cbTur.Text);
                cmd.Parameters.AddWithValue("@rafNo", txtRafNo.Text);
                cmd.Parameters.AddWithValue("@stokSayisi", txtStokSayisi.Text);
                cmd.Parameters.AddWithValue("@aciklama", txtAciklama.Text);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Güncelleme Tamamlandı");
                ds.Tables["tblKitap"].Clear();
                kitapListeleme();

                foreach (Control item in Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen boş olan yerleri doldurunuz");
            }
        }
        private void KitapListele_Load(object sender, EventArgs e)
        {
            kitapListeleme();
        }
        private void txtBarkodNoAra_TextChanged(object sender, EventArgs e)//tamamlandı
        {
            ds.Tables.Clear();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from tblKitap where barkodNo like '%" + txtBarkodNoAra.Text + "%'", con);
            da.Fill(ds, "tblKitap");
            dataGridView1.DataSource = ds.Tables["tblKitap"];
            con.Close();
        }
        private void txtBarkod_TextChanged(object sender, EventArgs e)//tamamlandı
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblKitap where barkodNo like '" + txtBarkod.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtKitapAd.Text = dataGridView1.CurrentRow.Cells["kitapAdi"].Value.ToString();
                txtYazar.Text = dataGridView1.CurrentRow.Cells["yazar"].Value.ToString();
                txtSayfaSayisi.Text = dataGridView1.CurrentRow.Cells["sayfaSayisi"].Value.ToString();
                txtYayinEvi.Text = dataGridView1.CurrentRow.Cells["yayinevi"].Value.ToString();
                cbTur.Text = dataGridView1.CurrentRow.Cells["turu"].Value.ToString();
                txtRafNo.Text = dataGridView1.CurrentRow.Cells["rafNo"].Value.ToString();
                txtStokSayisi.Text = dataGridView1.CurrentRow.Cells["stokSayisi"].Value.ToString();
                txtAciklama.Text = dataGridView1.CurrentRow.Cells["aciklama"].Value.ToString();
            }
            con.Close();
        }
        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)//tamamlandı
        {
            txtBarkod.Text = dataGridView1.CurrentRow.Cells["barkodNo"].Value.ToString();
            txtKitapAd.Text = dataGridView1.CurrentRow.Cells["kitapAdi"].Value.ToString();
            txtYazar.Text = dataGridView1.CurrentRow.Cells["yazar"].Value.ToString();
            txtSayfaSayisi.Text = dataGridView1.CurrentRow.Cells["sayfaSayisi"].Value.ToString();
            txtYayinEvi.Text = dataGridView1.CurrentRow.Cells["yayinevi"].Value.ToString();
            cbTur.Text = dataGridView1.CurrentRow.Cells["turu"].Value.ToString();
            txtRafNo.Text = dataGridView1.CurrentRow.Cells["rafNo"].Value.ToString();
            txtStokSayisi.Text = dataGridView1.CurrentRow.Cells["stokSayisi"].Value.ToString();
            txtAciklama.Text = dataGridView1.CurrentRow.Cells["aciklama"].Value.ToString();
        }
    }
}
   

