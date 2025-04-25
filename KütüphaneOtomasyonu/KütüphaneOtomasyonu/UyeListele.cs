using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KütüphaneOtomasyonu
{
    public partial class UyeListele : Form
    {
        public UyeListele()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=MERT.;Initial Catalog=KütüphaneOtomasyonu;Integrated Security=True");
        DataSet ds = new DataSet();
        private void UyeListele_Load(object sender, EventArgs e)
        {
            UyeListeleme();
            cezaKontrol();
        }
        private void btnIptal_Click(object sender, EventArgs e)//tamamlandı
        {
            this.Close();
        }
        private void cezaKontrol()
        {
            if (!string.IsNullOrEmpty(txtCeza.Text)&&Convert.ToDecimal(txtCeza.Text)>0)
            {
                btnCezaOde.Visible = true;
            }
            else
            {
                btnCezaOde.Visible = false;
            }
        }
        private void UyeListeleme()//tamamlandı
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from tblUye", con);
            da.Fill(ds, "tblUye");
            dataGridView1.DataSource = ds.Tables["tblUye"];
            con.Close();
        }
        private void txtTcAra_TextChanged(object sender, EventArgs e)//tamamlandı
        {
            ds.Tables.Clear();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from tblUye where tc like '%" + txtTcAra.Text + "%'", con);
            da.Fill(ds, "tblUye");
            dataGridView1.DataSource = ds.Tables["tblUye"];
            con.Close();
        }
        private void txtTc_TextChanged(object sender, EventArgs e)//tamamlandı
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblUye where tc like '" + txtTc.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtAdSoyad.Text = dr["adsoyad"].ToString();
                txtYas.Text = dr["yas"].ToString();
                cbCinsiyet.Text = dr["cinsiyet"].ToString();
                txtTel.Text = dr["telefon"].ToString();
                txtAdres.Text = dr["adres"].ToString();
                txtEmail.Text = dr["email"].ToString();
                txtOkunanKitap.Text = dr["oku_kitap_sayisi"].ToString();
                txtCeza.Text = dr["toplamCeza"].ToString();

            }
            con.Close();
        }
        private void btnSil_Click(object sender, EventArgs e)//tamamlandı
        {
            DialogResult dr = MessageBox.Show("Silmek istediğinize emin misiniz?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from tblUye where tc=@tc", con);
                cmd.Parameters.AddWithValue("@tc", dataGridView1.CurrentRow.Cells["tc"].Value.ToString());
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Silme Tamamlandı");
                ds.Tables["tblUye"].Clear();
                UyeListeleme();

                foreach (Control item in Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txtTc.Text = dataGridView1.CurrentRow.Cells["tc"].Value.ToString();
            txtAdSoyad.Text = dataGridView1.CurrentRow.Cells["adsoyad"].Value.ToString();
            txtYas.Text = dataGridView1.CurrentRow.Cells["yas"].Value.ToString();
            cbCinsiyet.Text = dataGridView1.CurrentRow.Cells["cinsiyet"].Value.ToString();
            txtTel.Text = dataGridView1.CurrentRow.Cells["telefon"].Value.ToString();
            txtAdres.Text = dataGridView1.CurrentRow.Cells["adres"].Value.ToString();
            txtEmail.Text = dataGridView1.CurrentRow.Cells["email"].Value.ToString();
            txtOkunanKitap.Text = dataGridView1.CurrentRow.Cells["oku_kitap_sayisi"].Value.ToString();
            txtCeza.Text = dataGridView1.CurrentRow.Cells["toplamCeza"].Value.ToString();

            cezaKontrol();

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            row = dataGridView1.Rows[e.RowIndex];

            if (row.Cells["toplamCeza"].Value != DBNull.Value)
            {
                txtCeza.Text = Convert.ToDecimal(row.Cells["toplamCeza"].Value).ToString("0.00");
            }
            else
            {
                txtCeza.Text = "0.00";
            }
        }
        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update tblUye set adsoyad=@adsoyad,yas=@yas,cinsiyet=@cinsiyet,telefon=@telefon,adres=@adres,email=@email,oku_kitap_sayisi=@oku_kitap_sayisi, toplamCeza=@toplamCeza where tc=@tc", con);
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
                cmd.Parameters.AddWithValue("@oku_kitap_sayisi", int.Parse(txtOkunanKitap.Text));
                cmd.Parameters.AddWithValue("@toplamCeza", Convert.ToDecimal(txtCeza.Text));
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Güncelleme Tamamlandı");
                ds.Tables["tblUye"].Clear();
                UyeListeleme();

                foreach (Control item in Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
            }
            else MessageBox.Show("Lütfen boş olan yerleri doldurunuz");
        }
        private void btnCezaOde_Click(object sender, EventArgs e)//tamamlandı
        {
            try
            {
                con.Open();
                SqlCommand cmdOdeme = new SqlCommand("UPDATE tblUye SET toplamCeza = 0 WHERE tc = @tc", con);
                cmdOdeme.Parameters.AddWithValue("@tc", txtTc.Text);
                int sonuc = cmdOdeme.ExecuteNonQuery();
                con.Close();

                if (sonuc > 0)
                {
                    MessageBox.Show("Ceza ödendi.");
                    txtCeza.Text = "0.00 TL";
                    ds.Tables["tblUye"].Clear();
                    UyeListeleme();
                }
                else
                {
                    MessageBox.Show("TC bulunamadı veya ceza zaten ödenmiş.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
                con.Close();
            }
        }

    }
} 
