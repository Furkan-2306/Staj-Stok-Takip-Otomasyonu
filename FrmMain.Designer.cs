namespace StokTakipOtomasyonu
{
    partial class FrmMain
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmiModuller = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCariYonetimi = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStokYonetimi = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStokHareketleri = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRaporlar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDashboard = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tsslBaglanti = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslSpring = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslKullanici = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiModuller,
            this.tsmiRaporlar});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(8, 4, 0, 4);
            this.menuStrip.Size = new System.Drawing.Size(1184, 35);
            this.menuStrip.TabIndex = 0;
            // 
            // tsmiModuller
            // 
            this.tsmiModuller.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCariYonetimi,
            this.tsmiStokYonetimi,
            this.tsmiStokHareketleri});
            this.tsmiModuller.ForeColor = System.Drawing.Color.White;
            this.tsmiModuller.Name = "tsmiModuller";
            this.tsmiModuller.Size = new System.Drawing.Size(80, 27);
            this.tsmiModuller.Text = "Modüller";
            // 
            // tsmiCariYonetimi
            // 
            this.tsmiCariYonetimi.Name = "tsmiCariYonetimi";
            this.tsmiCariYonetimi.Size = new System.Drawing.Size(180, 24);
            this.tsmiCariYonetimi.Text = "Cari Yönetimi";
            this.tsmiCariYonetimi.Click += new System.EventHandler(this.tsmiCariYonetimi_Click);
            // 
            // tsmiStokYonetimi
            // 
            this.tsmiStokYonetimi.Name = "tsmiStokYonetimi";
            this.tsmiStokYonetimi.Size = new System.Drawing.Size(180, 24);
            this.tsmiStokYonetimi.Text = "Stok Yönetimi";
            this.tsmiStokYonetimi.Click += new System.EventHandler(this.tsmiStokYonetimi_Click);
            // 
            // tsmiStokHareketleri
            // 
            this.tsmiStokHareketleri.Name = "tsmiStokHareketleri";
            this.tsmiStokHareketleri.Size = new System.Drawing.Size(180, 24);
            this.tsmiStokHareketleri.Text = "Stok Hareketleri";
            this.tsmiStokHareketleri.Click += new System.EventHandler(this.tsmiStokHareketleri_Click);
            // 
            // tsmiRaporlar
            // 
            this.tsmiRaporlar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDashboard});
            this.tsmiRaporlar.ForeColor = System.Drawing.Color.White;
            this.tsmiRaporlar.Name = "tsmiRaporlar";
            this.tsmiRaporlar.Size = new System.Drawing.Size(80, 27);
            this.tsmiRaporlar.Text = "Raporlar";
            // 
            // tsmiDashboard
            // 
            this.tsmiDashboard.Name = "tsmiDashboard";
            this.tsmiDashboard.Size = new System.Drawing.Size(180, 24);
            this.tsmiDashboard.Text = "Dashboard";
            this.tsmiDashboard.Click += new System.EventHandler(this.tsmiDashboard_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslBaglanti,
            this.tsslSpring,
            this.tsslKullanici});
            this.statusStrip.Location = new System.Drawing.Point(0, 639);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1184, 22);
            this.statusStrip.TabIndex = 1;
            // 
            // tsslBaglanti
            // 
            this.tsslBaglanti.ForeColor = System.Drawing.Color.LightGreen;
            this.tsslBaglanti.Name = "tsslBaglanti";
            this.tsslBaglanti.Size = new System.Drawing.Size(100, 17);
            this.tsslBaglanti.Text = "Bağlantı: Kontrol ediliyor...";
            // 
            // tsslSpring
            // 
            this.tsslSpring.Name = "tsslSpring";
            this.tsslSpring.Size = new System.Drawing.Size(900, 17);
            this.tsslSpring.Spring = true;
            // 
            // tsslKullanici
            // 
            this.tsslKullanici.ForeColor = System.Drawing.Color.White;
            this.tsslKullanici.Name = "tsslKullanici";
            this.tsslKullanici.Size = new System.Drawing.Size(100, 17);
            this.tsslKullanici.Text = "Kullanıcı: -";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bağımsız Cari ve Stok Takip Otomasyonu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiModuller;
        private System.Windows.Forms.ToolStripMenuItem tsmiCariYonetimi;
        private System.Windows.Forms.ToolStripMenuItem tsmiStokYonetimi;
        private System.Windows.Forms.ToolStripMenuItem tsmiStokHareketleri;
        private System.Windows.Forms.ToolStripMenuItem tsmiRaporlar;
        private System.Windows.Forms.ToolStripMenuItem tsmiDashboard;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tsslBaglanti;
        private System.Windows.Forms.ToolStripStatusLabel tsslSpring;
        private System.Windows.Forms.ToolStripStatusLabel tsslKullanici;
    }
}
