namespace StokTakipOtomasyonu
{
    partial class FrmHareket
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
            this.grpIslemDetay = new System.Windows.Forms.GroupBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.nudMiktar = new System.Windows.Forms.NumericUpDown();
            this.lblMiktar = new System.Windows.Forms.Label();
            this.grpIslemTipi = new System.Windows.Forms.GroupBox();
            this.rbSatis = new System.Windows.Forms.RadioButton();
            this.rbAlis = new System.Windows.Forms.RadioButton();
            this.cmbStoklar = new System.Windows.Forms.ComboBox();
            this.lblStok = new System.Windows.Forms.Label();
            this.cmbCariler = new System.Windows.Forms.ComboBox();
            this.lblCari = new System.Windows.Forms.Label();
            this.dgvHareketler = new System.Windows.Forms.DataGridView();
            this.grpIslemDetay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMiktar)).BeginInit();
            this.grpIslemTipi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHareketler)).BeginInit();
            this.SuspendLayout();
            // 
            // grpIslemDetay
            // 
            this.grpIslemDetay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpIslemDetay.Controls.Add(this.btnKaydet);
            this.grpIslemDetay.Controls.Add(this.nudMiktar);
            this.grpIslemDetay.Controls.Add(this.lblMiktar);
            this.grpIslemDetay.Controls.Add(this.grpIslemTipi);
            this.grpIslemDetay.Controls.Add(this.cmbStoklar);
            this.grpIslemDetay.Controls.Add(this.lblStok);
            this.grpIslemDetay.Controls.Add(this.cmbCariler);
            this.grpIslemDetay.Controls.Add(this.lblCari);
            this.grpIslemDetay.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.grpIslemDetay.Location = new System.Drawing.Point(12, 12);
            this.grpIslemDetay.Name = "grpIslemDetay";
            this.grpIslemDetay.Size = new System.Drawing.Size(910, 160);
            this.grpIslemDetay.TabIndex = 0;
            this.grpIslemDetay.TabStop = false;
            this.grpIslemDetay.Text = "İşlem Detayları";
            // 
            // lblCari
            // 
            this.lblCari.AutoSize = true;
            this.lblCari.Location = new System.Drawing.Point(15, 30);
            this.lblCari.Name = "lblCari";
            this.lblCari.Size = new System.Drawing.Size(105, 19);
            this.lblCari.TabIndex = 0;
            this.lblCari.Text = "Cari (Müşteri):";
            // 
            // cmbCariler
            // 
            this.cmbCariler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCariler.FormattingEnabled = true;
            this.cmbCariler.Location = new System.Drawing.Point(15, 52);
            this.cmbCariler.Name = "cmbCariler";
            this.cmbCariler.Size = new System.Drawing.Size(250, 25);
            this.cmbCariler.TabIndex = 1;
            // 
            // lblStok
            // 
            this.lblStok.AutoSize = true;
            this.lblStok.Location = new System.Drawing.Point(280, 30);
            this.lblStok.Name = "lblStok";
            this.lblStok.Size = new System.Drawing.Size(85, 19);
            this.lblStok.TabIndex = 2;
            this.lblStok.Text = "Stok (Ürün):";
            // 
            // cmbStoklar
            // 
            this.cmbStoklar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStoklar.FormattingEnabled = true;
            this.cmbStoklar.Location = new System.Drawing.Point(280, 52);
            this.cmbStoklar.Name = "cmbStoklar";
            this.cmbStoklar.Size = new System.Drawing.Size(250, 25);
            this.cmbStoklar.TabIndex = 3;
            // 
            // grpIslemTipi
            // 
            this.grpIslemTipi.Controls.Add(this.rbSatis);
            this.grpIslemTipi.Controls.Add(this.rbAlis);
            this.grpIslemTipi.Location = new System.Drawing.Point(545, 22);
            this.grpIslemTipi.Name = "grpIslemTipi";
            this.grpIslemTipi.Size = new System.Drawing.Size(170, 55);
            this.grpIslemTipi.TabIndex = 4;
            this.grpIslemTipi.TabStop = false;
            this.grpIslemTipi.Text = "İşlem Tipi";
            // 
            // rbAlis
            // 
            this.rbAlis.AutoSize = true;
            this.rbAlis.Checked = true;
            this.rbAlis.Location = new System.Drawing.Point(15, 25);
            this.rbAlis.Name = "rbAlis";
            this.rbAlis.Size = new System.Drawing.Size(52, 23);
            this.rbAlis.TabIndex = 0;
            this.rbAlis.TabStop = true;
            this.rbAlis.Text = "Alış";
            this.rbAlis.UseVisualStyleBackColor = true;
            // 
            // rbSatis
            // 
            this.rbSatis.AutoSize = true;
            this.rbSatis.Location = new System.Drawing.Point(90, 25);
            this.rbSatis.Name = "rbSatis";
            this.rbSatis.Size = new System.Drawing.Size(57, 23);
            this.rbSatis.TabIndex = 1;
            this.rbSatis.Text = "Satış";
            this.rbSatis.UseVisualStyleBackColor = true;
            // 
            // lblMiktar
            // 
            this.lblMiktar.AutoSize = true;
            this.lblMiktar.Location = new System.Drawing.Point(15, 95);
            this.lblMiktar.Name = "lblMiktar";
            this.lblMiktar.Size = new System.Drawing.Size(54, 19);
            this.lblMiktar.TabIndex = 5;
            this.lblMiktar.Text = "Miktar:";
            // 
            // nudMiktar
            // 
            this.nudMiktar.Location = new System.Drawing.Point(15, 117);
            this.nudMiktar.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            this.nudMiktar.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudMiktar.Name = "nudMiktar";
            this.nudMiktar.Size = new System.Drawing.Size(200, 25);
            this.nudMiktar.TabIndex = 6;
            this.nudMiktar.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKaydet.FlatAppearance.BorderSize = 0;
            this.btnKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKaydet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnKaydet.ForeColor = System.Drawing.Color.White;
            this.btnKaydet.Location = new System.Drawing.Point(545, 95);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(170, 45);
            this.btnKaydet.TabIndex = 7;
            this.btnKaydet.Text = "İşlemi Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // dgvHareketler
            // 
            this.dgvHareketler.AllowUserToAddRows = false;
            this.dgvHareketler.AllowUserToDeleteRows = false;
            this.dgvHareketler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHareketler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHareketler.BackgroundColor = System.Drawing.Color.White;
            this.dgvHareketler.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.dgvHareketler.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvHareketler.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvHareketler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHareketler.EnableHeadersVisualStyles = false;
            this.dgvHareketler.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvHareketler.Location = new System.Drawing.Point(12, 178);
            this.dgvHareketler.MultiSelect = false;
            this.dgvHareketler.Name = "dgvHareketler";
            this.dgvHareketler.ReadOnly = true;
            this.dgvHareketler.RowHeadersVisible = false;
            this.dgvHareketler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHareketler.Size = new System.Drawing.Size(910, 360);
            this.dgvHareketler.TabIndex = 1;
            // 
            // FrmHareket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(934, 550);
            this.Controls.Add(this.dgvHareketler);
            this.Controls.Add(this.grpIslemDetay);
            this.Name = "FrmHareket";
            this.Text = "Stok Hareketleri (Alış / Satış)";
            this.Load += new System.EventHandler(this.FrmHareket_Load);
            this.grpIslemDetay.ResumeLayout(false);
            this.grpIslemDetay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMiktar)).EndInit();
            this.grpIslemTipi.ResumeLayout(false);
            this.grpIslemTipi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHareketler)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpIslemDetay;
        private System.Windows.Forms.Label lblCari;
        private System.Windows.Forms.ComboBox cmbCariler;
        private System.Windows.Forms.Label lblStok;
        private System.Windows.Forms.ComboBox cmbStoklar;
        private System.Windows.Forms.GroupBox grpIslemTipi;
        private System.Windows.Forms.RadioButton rbAlis;
        private System.Windows.Forms.RadioButton rbSatis;
        private System.Windows.Forms.Label lblMiktar;
        private System.Windows.Forms.NumericUpDown nudMiktar;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.DataGridView dgvHareketler;
    }
}
