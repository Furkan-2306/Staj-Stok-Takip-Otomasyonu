namespace StokTakipOtomasyonu
{
    partial class FrmStok
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.grpStok = new System.Windows.Forms.GroupBox();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.nudMevcutStok = new System.Windows.Forms.NumericUpDown();
            this.lblMevcutStok = new System.Windows.Forms.Label();
            this.txtSatisFiyati = new System.Windows.Forms.TextBox();
            this.lblSatisFiyati = new System.Windows.Forms.Label();
            this.txtUrunAdi = new System.Windows.Forms.TextBox();
            this.lblUrunAdi = new System.Windows.Forms.Label();
            this.txtUrunKodu = new System.Windows.Forms.TextBox();
            this.lblUrunKodu = new System.Windows.Forms.Label();
            this.lblStokID = new System.Windows.Forms.Label();
            this.pnlArama = new System.Windows.Forms.Panel();
            this.txtArama = new System.Windows.Forms.TextBox();
            this.lblArama = new System.Windows.Forms.Label();
            this.dgvStoklar = new System.Windows.Forms.DataGridView();
            this.grpStok.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMevcutStok)).BeginInit();
            this.pnlArama.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStoklar)).BeginInit();
            this.SuspendLayout();
            // 
            // grpStok
            // 
            this.grpStok.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpStok.Controls.Add(this.btnTemizle);
            this.grpStok.Controls.Add(this.btnSil);
            this.grpStok.Controls.Add(this.btnGuncelle);
            this.grpStok.Controls.Add(this.btnKaydet);
            this.grpStok.Controls.Add(this.nudMevcutStok);
            this.grpStok.Controls.Add(this.lblMevcutStok);
            this.grpStok.Controls.Add(this.txtSatisFiyati);
            this.grpStok.Controls.Add(this.lblSatisFiyati);
            this.grpStok.Controls.Add(this.txtUrunAdi);
            this.grpStok.Controls.Add(this.lblUrunAdi);
            this.grpStok.Controls.Add(this.txtUrunKodu);
            this.grpStok.Controls.Add(this.lblUrunKodu);
            this.grpStok.Controls.Add(this.lblStokID);
            this.grpStok.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.grpStok.Location = new System.Drawing.Point(12, 12);
            this.grpStok.Name = "grpStok";
            this.grpStok.Size = new System.Drawing.Size(280, 526);
            this.grpStok.TabIndex = 0;
            this.grpStok.TabStop = false;
            this.grpStok.Text = "Stok Bilgileri";
            // 
            // lblStokID
            // 
            this.lblStokID.AutoSize = true;
            this.lblStokID.Location = new System.Drawing.Point(15, 30);
            this.lblStokID.Name = "lblStokID";
            this.lblStokID.Size = new System.Drawing.Size(0, 19);
            this.lblStokID.TabIndex = 0;
            this.lblStokID.Visible = false;
            // 
            // lblUrunKodu
            // 
            this.lblUrunKodu.AutoSize = true;
            this.lblUrunKodu.Location = new System.Drawing.Point(15, 40);
            this.lblUrunKodu.Name = "lblUrunKodu";
            this.lblUrunKodu.Size = new System.Drawing.Size(78, 19);
            this.lblUrunKodu.TabIndex = 1;
            this.lblUrunKodu.Text = "Ürün Kodu:";
            // 
            // txtUrunKodu
            // 
            this.txtUrunKodu.Location = new System.Drawing.Point(15, 62);
            this.txtUrunKodu.Name = "txtUrunKodu";
            this.txtUrunKodu.Size = new System.Drawing.Size(248, 25);
            this.txtUrunKodu.TabIndex = 2;
            // 
            // lblUrunAdi
            // 
            this.lblUrunAdi.AutoSize = true;
            this.lblUrunAdi.Location = new System.Drawing.Point(15, 100);
            this.lblUrunAdi.Name = "lblUrunAdi";
            this.lblUrunAdi.Size = new System.Drawing.Size(68, 19);
            this.lblUrunAdi.TabIndex = 3;
            this.lblUrunAdi.Text = "Ürün Adı:";
            // 
            // txtUrunAdi
            // 
            this.txtUrunAdi.Location = new System.Drawing.Point(15, 122);
            this.txtUrunAdi.Name = "txtUrunAdi";
            this.txtUrunAdi.Size = new System.Drawing.Size(248, 25);
            this.txtUrunAdi.TabIndex = 4;
            // 
            // lblSatisFiyati
            // 
            this.lblSatisFiyati.AutoSize = true;
            this.lblSatisFiyati.Location = new System.Drawing.Point(15, 160);
            this.lblSatisFiyati.Name = "lblSatisFiyati";
            this.lblSatisFiyati.Size = new System.Drawing.Size(111, 19);
            this.lblSatisFiyati.TabIndex = 5;
            this.lblSatisFiyati.Text = "Satış Fiyatı (TL):";
            // 
            // txtSatisFiyati
            // 
            this.txtSatisFiyati.Location = new System.Drawing.Point(15, 182);
            this.txtSatisFiyati.Name = "txtSatisFiyati";
            this.txtSatisFiyati.Size = new System.Drawing.Size(248, 25);
            this.txtSatisFiyati.TabIndex = 6;
            this.txtSatisFiyati.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSatisFiyati.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSatisFiyati_KeyPress);
            // 
            // lblMevcutStok
            // 
            this.lblMevcutStok.AutoSize = true;
            this.lblMevcutStok.Location = new System.Drawing.Point(15, 220);
            this.lblMevcutStok.Name = "lblMevcutStok";
            this.lblMevcutStok.Size = new System.Drawing.Size(92, 19);
            this.lblMevcutStok.TabIndex = 7;
            this.lblMevcutStok.Text = "Mevcut Stok:";
            // 
            // nudMevcutStok
            // 
            this.nudMevcutStok.Location = new System.Drawing.Point(15, 242);
            this.nudMevcutStok.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            this.nudMevcutStok.Name = "nudMevcutStok";
            this.nudMevcutStok.Size = new System.Drawing.Size(248, 25);
            this.nudMevcutStok.TabIndex = 8;
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKaydet.FlatAppearance.BorderSize = 0;
            this.btnKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKaydet.ForeColor = System.Drawing.Color.White;
            this.btnKaydet.Location = new System.Drawing.Point(15, 290);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(248, 35);
            this.btnKaydet.TabIndex = 9;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnGuncelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuncelle.FlatAppearance.BorderSize = 0;
            this.btnGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuncelle.ForeColor = System.Drawing.Color.White;
            this.btnGuncelle.Location = new System.Drawing.Point(15, 331);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(248, 35);
            this.btnGuncelle.TabIndex = 10;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = false;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSil.FlatAppearance.BorderSize = 0;
            this.btnSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSil.ForeColor = System.Drawing.Color.White;
            this.btnSil.Location = new System.Drawing.Point(15, 372);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(248, 35);
            this.btnSil.TabIndex = 11;
            this.btnSil.Text = "Sil (Pasife Al)";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnTemizle
            // 
            this.btnTemizle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnTemizle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTemizle.FlatAppearance.BorderSize = 0;
            this.btnTemizle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTemizle.ForeColor = System.Drawing.Color.White;
            this.btnTemizle.Location = new System.Drawing.Point(15, 413);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(248, 35);
            this.btnTemizle.TabIndex = 12;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.UseVisualStyleBackColor = false;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // pnlArama
            // 
            this.pnlArama.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlArama.Controls.Add(this.txtArama);
            this.pnlArama.Controls.Add(this.lblArama);
            this.pnlArama.Location = new System.Drawing.Point(298, 12);
            this.pnlArama.Name = "pnlArama";
            this.pnlArama.Size = new System.Drawing.Size(624, 35);
            this.pnlArama.TabIndex = 1;
            // 
            // lblArama
            // 
            this.lblArama.AutoSize = true;
            this.lblArama.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblArama.Location = new System.Drawing.Point(5, 7);
            this.lblArama.Name = "lblArama";
            this.lblArama.Size = new System.Drawing.Size(66, 19);
            this.lblArama.TabIndex = 0;
            this.lblArama.Text = "🔍 Ara:";
            // 
            // txtArama
            // 
            this.txtArama.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArama.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtArama.Location = new System.Drawing.Point(75, 4);
            this.txtArama.Name = "txtArama";
            this.txtArama.Size = new System.Drawing.Size(545, 25);
            this.txtArama.TabIndex = 1;
            this.txtArama.TextChanged += new System.EventHandler(this.txtArama_TextChanged);
            // 
            // dgvStoklar
            // 
            this.dgvStoklar.AllowUserToAddRows = false;
            this.dgvStoklar.AllowUserToDeleteRows = false;
            this.dgvStoklar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStoklar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStoklar.BackgroundColor = System.Drawing.Color.White;
            this.dgvStoklar.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.dgvStoklar.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvStoklar.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvStoklar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStoklar.EnableHeadersVisualStyles = false;
            this.dgvStoklar.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvStoklar.Location = new System.Drawing.Point(298, 53);
            this.dgvStoklar.MultiSelect = false;
            this.dgvStoklar.Name = "dgvStoklar";
            this.dgvStoklar.ReadOnly = true;
            this.dgvStoklar.RowHeadersVisible = false;
            this.dgvStoklar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStoklar.Size = new System.Drawing.Size(624, 485);
            this.dgvStoklar.TabIndex = 2;
            this.dgvStoklar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStoklar_CellClick);
            // 
            // FrmStok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(934, 550);
            this.Controls.Add(this.dgvStoklar);
            this.Controls.Add(this.pnlArama);
            this.Controls.Add(this.grpStok);
            this.Name = "FrmStok";
            this.Text = "Stok Yönetim Paneli";
            this.Load += new System.EventHandler(this.FrmStok_Load);
            this.grpStok.ResumeLayout(false);
            this.grpStok.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMevcutStok)).EndInit();
            this.pnlArama.ResumeLayout(false);
            this.pnlArama.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStoklar)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpStok;
        private System.Windows.Forms.Label lblStokID;
        private System.Windows.Forms.Label lblUrunKodu;
        private System.Windows.Forms.TextBox txtUrunKodu;
        private System.Windows.Forms.Label lblUrunAdi;
        private System.Windows.Forms.TextBox txtUrunAdi;
        private System.Windows.Forms.Label lblSatisFiyati;
        private System.Windows.Forms.TextBox txtSatisFiyati;
        private System.Windows.Forms.Label lblMevcutStok;
        private System.Windows.Forms.NumericUpDown nudMevcutStok;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Panel pnlArama;
        private System.Windows.Forms.Label lblArama;
        private System.Windows.Forms.TextBox txtArama;
        private System.Windows.Forms.DataGridView dgvStoklar;
    }
}
