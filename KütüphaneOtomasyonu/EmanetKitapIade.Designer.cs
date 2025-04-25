namespace KütüphaneOtomasyonu
{
    partial class EmanetKitapIade
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnTeslimAl = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTcSirala = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBarkodSirala = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblGecikmeGun = new System.Windows.Forms.Label();
            this.lblCeza = new System.Windows.Forms.Label();
            this.lblBugun = new System.Windows.Forms.Label();
            this.lblIade = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTc = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblBarkod = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblKitapAd = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(330, 46);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(626, 261);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // btnTeslimAl
            // 
            this.btnTeslimAl.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnTeslimAl.FlatAppearance.BorderSize = 0;
            this.btnTeslimAl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTeslimAl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeslimAl.ForeColor = System.Drawing.Color.White;
            this.btnTeslimAl.Location = new System.Drawing.Point(44, 213);
            this.btnTeslimAl.Name = "btnTeslimAl";
            this.btnTeslimAl.Size = new System.Drawing.Size(96, 42);
            this.btnTeslimAl.TabIndex = 1;
            this.btnTeslimAl.Text = "TESLİM AL";
            this.btnTeslimAl.UseVisualStyleBackColor = false;
            this.btnTeslimAl.Click += new System.EventHandler(this.btnTeslimAl_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.BackColor = System.Drawing.Color.Red;
            this.btnIptal.FlatAppearance.BorderSize = 0;
            this.btnIptal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIptal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIptal.ForeColor = System.Drawing.Color.White;
            this.btnIptal.Location = new System.Drawing.Point(157, 213);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(96, 42);
            this.btnIptal.TabIndex = 1;
            this.btnIptal.Text = "İPTAL";
            this.btnIptal.UseVisualStyleBackColor = false;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "TC Ara  : ";
            // 
            // txtTcSirala
            // 
            this.txtTcSirala.Location = new System.Drawing.Point(136, 55);
            this.txtTcSirala.Name = "txtTcSirala";
            this.txtTcSirala.Size = new System.Drawing.Size(100, 20);
            this.txtTcSirala.TabIndex = 3;
            this.txtTcSirala.TextChanged += new System.EventHandler(this.txtTcSirala_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Barkod Ara : ";
            // 
            // txtBarkodSirala
            // 
            this.txtBarkodSirala.Location = new System.Drawing.Point(136, 92);
            this.txtBarkodSirala.Name = "txtBarkodSirala";
            this.txtBarkodSirala.Size = new System.Drawing.Size(100, 20);
            this.txtBarkodSirala.TabIndex = 3;
            this.txtBarkodSirala.TextChanged += new System.EventHandler(this.txtBarkodSirala_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(103, 362);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "İade Tarihi : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(90, 394);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Bugün Tarihi : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(79, 429);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Gecikme(gün) : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(97, 460);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Ceza Tutarı : ";
            // 
            // lblGecikmeGun
            // 
            this.lblGecikmeGun.AutoSize = true;
            this.lblGecikmeGun.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGecikmeGun.Location = new System.Drawing.Point(212, 429);
            this.lblGecikmeGun.Name = "lblGecikmeGun";
            this.lblGecikmeGun.Size = new System.Drawing.Size(17, 20);
            this.lblGecikmeGun.TabIndex = 4;
            this.lblGecikmeGun.Text = "0";
            // 
            // lblCeza
            // 
            this.lblCeza.AutoSize = true;
            this.lblCeza.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCeza.Location = new System.Drawing.Point(212, 460);
            this.lblCeza.Name = "lblCeza";
            this.lblCeza.Size = new System.Drawing.Size(17, 20);
            this.lblCeza.TabIndex = 4;
            this.lblCeza.Text = "0";
            // 
            // lblBugun
            // 
            this.lblBugun.AutoSize = true;
            this.lblBugun.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBugun.Location = new System.Drawing.Point(212, 394);
            this.lblBugun.Name = "lblBugun";
            this.lblBugun.Size = new System.Drawing.Size(17, 20);
            this.lblBugun.TabIndex = 4;
            this.lblBugun.Text = "0";
            // 
            // lblIade
            // 
            this.lblIade.AutoSize = true;
            this.lblIade.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblIade.Location = new System.Drawing.Point(212, 362);
            this.lblIade.Name = "lblIade";
            this.lblIade.Size = new System.Drawing.Size(17, 20);
            this.lblIade.TabIndex = 4;
            this.lblIade.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(435, 362);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Üye TC : ";
            // 
            // lblTc
            // 
            this.lblTc.AutoSize = true;
            this.lblTc.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTc.Location = new System.Drawing.Point(506, 362);
            this.lblTc.Name = "lblTc";
            this.lblTc.Size = new System.Drawing.Size(17, 20);
            this.lblTc.TabIndex = 4;
            this.lblTc.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(397, 394);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 20);
            this.label8.TabIndex = 4;
            this.label8.Text = "Kitap Barkod : ";
            // 
            // lblBarkod
            // 
            this.lblBarkod.AutoSize = true;
            this.lblBarkod.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBarkod.Location = new System.Drawing.Point(506, 394);
            this.lblBarkod.Name = "lblBarkod";
            this.lblBarkod.Size = new System.Drawing.Size(17, 20);
            this.lblBarkod.TabIndex = 4;
            this.lblBarkod.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(425, 429);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 20);
            this.label9.TabIndex = 4;
            this.label9.Text = "Kitap Ad : ";
            // 
            // lblKitapAd
            // 
            this.lblKitapAd.AutoSize = true;
            this.lblKitapAd.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKitapAd.Location = new System.Drawing.Point(506, 429);
            this.lblKitapAd.Name = "lblKitapAd";
            this.lblKitapAd.Size = new System.Drawing.Size(17, 20);
            this.lblKitapAd.TabIndex = 4;
            this.lblKitapAd.Text = "0";
            // 
            // EmanetKitapIade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(980, 512);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblCeza);
            this.Controls.Add(this.lblKitapAd);
            this.Controls.Add(this.lblBarkod);
            this.Controls.Add(this.lblTc);
            this.Controls.Add(this.lblIade);
            this.Controls.Add(this.lblBugun);
            this.Controls.Add(this.lblGecikmeGun);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBarkodSirala);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTcSirala);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnTeslimAl);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EmanetKitapIade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EmanetKitapIade";
            this.Load += new System.EventHandler(this.EmanetKitapIade_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnTeslimAl;
        private System.Windows.Forms.Button btnIptal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTcSirala;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBarkodSirala;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblGecikmeGun;
        private System.Windows.Forms.Label lblCeza;
        private System.Windows.Forms.Label lblBugun;
        private System.Windows.Forms.Label lblIade;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblBarkod;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblKitapAd;
    }
}