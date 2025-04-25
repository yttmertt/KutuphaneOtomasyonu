using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KütüphaneOtomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnUyeEkle_Click(object sender, EventArgs e)
        {
            UyeEkleme uyeEkleme = new UyeEkleme();
            uyeEkleme.ShowDialog();
        }

        private void btnUyeListele_Click(object sender, EventArgs e)
        {
            UyeListele listele = new UyeListele();
            listele.ShowDialog();
        }

        private void btnKitapEkle_Click(object sender, EventArgs e)
        {
            KitapEkle kitapEkle = new KitapEkle();
            kitapEkle.ShowDialog();
        }

        private void btnKitapListele_Click(object sender, EventArgs e)
        {
            KitapListele kitapListele = new KitapListele();
            kitapListele.ShowDialog();
        }

        private void btnEmanetKitapVerme_Click(object sender, EventArgs e)
        {
            EmanetKitapVerme emanetKitapVerme = new EmanetKitapVerme();
            emanetKitapVerme.ShowDialog();
        }

        private void btnEmanetKitapListele_Click(object sender, EventArgs e)
        {
            EmanetKitapListele emanetKitapListele = new EmanetKitapListele();
            emanetKitapListele.ShowDialog();
        }

        private void btnEmanetKitapIade_Click(object sender, EventArgs e)
        {
            EmanetKitapIade emanetKitapIade = new EmanetKitapIade();
            emanetKitapIade.ShowDialog();
        }

        private void btnSiralama_Click(object sender, EventArgs e)
        {
            Sıralama sıralama = new Sıralama();
            sıralama.ShowDialog();
        }

        private void btnGrafik_Click(object sender, EventArgs e)
        {
            Grafikler grafikler = new Grafikler();
            grafikler.ShowDialog();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTarihSaat.Text = DateTime.Now.ToString("dd MMMM yyyy HH:mm");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           btnEmanetKitapListele.Visible = false;
           button2.Visible=false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            GelişmişAramaFiltreleme gaf = new GelişmişAramaFiltreleme();
            gaf.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EnCokOkunanKitap ecok = new EnCokOkunanKitap();
            ecok.ShowDialog();
        }
    }
}
