namespace StokTakipOtomasyonu
{
    partial class FrmDashboard
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
            this.pnlKPI = new System.Windows.Forms.Panel();
            this.grpToplamIslem = new System.Windows.Forms.GroupBox();
            this.lblToplamIslem = new System.Windows.Forms.Label();
            this.grpToplamStok = new System.Windows.Forms.GroupBox();
            this.lblToplamStok = new System.Windows.Forms.Label();
            this.grpToplamCari = new System.Windows.Forms.GroupBox();
            this.lblToplamCari = new System.Windows.Forms.Label();
            this.pnlFiltre = new System.Windows.Forms.Panel();
            this.btnFiltrele = new System.Windows.Forms.Button();
            this.dtpBitis = new System.Windows.Forms.DateTimePicker();
            this.lblBitis = new System.Windows.Forms.Label();
            this.dtpBaslangic = new System.Windows.Forms.DateTimePicker();
            this.lblBaslangic = new System.Windows.Forms.Label();
            this.btnTumKayitlar = new System.Windows.Forms.Button();
            this.dgvRapor = new System.Windows.Forms.DataGridView();
            this.pnlKPI.SuspendLayout();
            this.grpToplamIslem.SuspendLayout();
            this.grpToplamStok.SuspendLayout();
            this.grpToplamCari.SuspendLayout();
            this.pnlFiltre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRapor)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlKPI
            // 
            this.pnlKPI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlKPI.Controls.Add(this.grpToplamIslem);
            this.pnlKPI.Controls.Add(this.grpToplamStok);
            this.pnlKPI.Controls.Add(this.grpToplamCari);
            this.pnlKPI.Location = new System.Drawing.Point(12, 12);
            this.pnlKPI.Name = "pnlKPI";
            this.pnlKPI.Size = new System.Drawing.Size(910, 90);
            this.pnlKPI.TabIndex = 0;
            // 
            // grpToplamCari
            // 
            this.grpToplamCari.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.grpToplamCari.Controls.Add(this.lblToplamCari);
            this.grpToplamCari.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpToplamCari.ForeColor = System.Drawing.Color.White;
            this.grpToplamCari.Location = new System.Drawing.Point(0, 0);
            this.grpToplamCari.Name = "grpToplamCari";
            this.grpToplamCari.Size = new System.Drawing.Size(295, 85);
            this.grpToplamCari.TabIndex = 0;
            this.grpToplamCari.TabStop = false;
            this.grpToplamCari.Text = "Toplam Müşteri Sayısı";
            // 
            // lblToplamCari
            // 
            this.lblToplamCari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblToplamCari.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblToplamCari.ForeColor = System.Drawing.Color.White;
            this.lblToplamCari.Location = new System.Drawing.Point(3, 19);
            this.lblToplamCari.Name = "lblToplamCari";
            this.lblToplamCari.Size = new System.Drawing.Size(289, 63);
            this.lblToplamCari.TabIndex = 0;
            this.lblToplamCari.Text = "0";
            this.lblToplamCari.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpToplamStok
            // 
            this.grpToplamStok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.grpToplamStok.Controls.Add(this.lblToplamStok);
            this.grpToplamStok.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpToplamStok.ForeColor = System.Drawing.Color.White;
            this.grpToplamStok.Location = new System.Drawing.Point(305, 0);
            this.grpToplamStok.Name = "grpToplamStok";
            this.grpToplamStok.Size = new System.Drawing.Size(295, 85);
            this.grpToplamStok.TabIndex = 1;
            this.grpToplamStok.TabStop = false;
            this.grpToplamStok.Text = "Toplam Ürün Kalemi";
            // 
            // lblToplamStok
            // 
            this.lblToplamStok.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblToplamStok.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblToplamStok.ForeColor = System.Drawing.Color.White;
            this.lblToplamStok.Location = new System.Drawing.Point(3, 19);
            this.lblToplamStok.Name = "lblToplamStok";
            this.lblToplamStok.Size = new System.Drawing.Size(289, 63);
            this.lblToplamStok.TabIndex = 0;
            this.lblToplamStok.Text = "0";
            this.lblToplamStok.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpToplamIslem
            // 
            this.grpToplamIslem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.grpToplamIslem.Controls.Add(this.lblToplamIslem);
            this.grpToplamIslem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpToplamIslem.ForeColor = System.Drawing.Color.White;
            this.grpToplamIslem.Location = new System.Drawing.Point(610, 0);
            this.grpToplamIslem.Name = "grpToplamIslem";
            this.grpToplamIslem.Size = new System.Drawing.Size(295, 85);
            this.grpToplamIslem.TabIndex = 2;
            this.grpToplamIslem.TabStop = false;
            this.grpToplamIslem.Text = "Toplam İşlem Hacmi";
            // 
            // lblToplamIslem
            // 
            this.lblToplamIslem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblToplamIslem.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblToplamIslem.ForeColor = System.Drawing.Color.White;
            this.lblToplamIslem.Location = new System.Drawing.Point(3, 19);
            this.lblToplamIslem.Name = "lblToplamIslem";
            this.lblToplamIslem.Size = new System.Drawing.Size(289, 63);
            this.lblToplamIslem.TabIndex = 0;
            this.lblToplamIslem.Text = "0";
            this.lblToplamIslem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlFiltre
            // 
            this.pnlFiltre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFiltre.Controls.Add(this.btnTumKayitlar);
            this.pnlFiltre.Controls.Add(this.btnFiltrele);
            this.pnlFiltre.Controls.Add(this.dtpBitis);
            this.pnlFiltre.Controls.Add(this.lblBitis);
            this.pnlFiltre.Controls.Add(this.dtpBaslangic);
            this.pnlFiltre.Controls.Add(this.lblBaslangic);
            this.pnlFiltre.Location = new System.Drawing.Point(12, 108);
            this.pnlFiltre.Name = "pnlFiltre";
            this.pnlFiltre.Size = new System.Drawing.Size(910, 40);
            this.pnlFiltre.TabIndex = 1;
            // 
            // lblBaslangic
            // 
            this.lblBaslangic.AutoSize = true;
            this.lblBaslangic.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBaslangic.Location = new System.Drawing.Point(5, 9);
            this.lblBaslangic.Name = "lblBaslangic";
            this.lblBaslangic.Size = new System.Drawing.Size(75, 19);
            this.lblBaslangic.TabIndex = 0;
            this.lblBaslangic.Text = "Başlangıç:";
            // 
            // dtpBaslangic
            // 
            this.dtpBaslangic.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpBaslangic.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBaslangic.Location = new System.Drawing.Point(85, 8);
            this.dtpBaslangic.Name = "dtpBaslangic";
            this.dtpBaslangic.Size = new System.Drawing.Size(130, 23);
            this.dtpBaslangic.TabIndex = 1;
            // 
            // lblBitis
            // 
            this.lblBitis.AutoSize = true;
            this.lblBitis.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBitis.Location = new System.Drawing.Point(230, 9);
            this.lblBitis.Name = "lblBitis";
            this.lblBitis.Size = new System.Drawing.Size(40, 19);
            this.lblBitis.TabIndex = 2;
            this.lblBitis.Text = "Bitiş:";
            // 
            // dtpBitis
            // 
            this.dtpBitis.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpBitis.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBitis.Location = new System.Drawing.Point(275, 8);
            this.dtpBitis.Name = "dtpBitis";
            this.dtpBitis.Size = new System.Drawing.Size(130, 23);
            this.dtpBitis.TabIndex = 3;
            // 
            // btnFiltrele
            // 
            this.btnFiltrele.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnFiltrele.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrele.FlatAppearance.BorderSize = 0;
            this.btnFiltrele.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrele.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFiltrele.ForeColor = System.Drawing.Color.White;
            this.btnFiltrele.Location = new System.Drawing.Point(420, 5);
            this.btnFiltrele.Name = "btnFiltrele";
            this.btnFiltrele.Size = new System.Drawing.Size(100, 30);
            this.btnFiltrele.TabIndex = 4;
            this.btnFiltrele.Text = "Filtrele";
            this.btnFiltrele.UseVisualStyleBackColor = false;
            this.btnFiltrele.Click += new System.EventHandler(this.btnFiltrele_Click);
            // 
            // btnTumKayitlar
            // 
            this.btnTumKayitlar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnTumKayitlar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTumKayitlar.FlatAppearance.BorderSize = 0;
            this.btnTumKayitlar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTumKayitlar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTumKayitlar.ForeColor = System.Drawing.Color.White;
            this.btnTumKayitlar.Location = new System.Drawing.Point(530, 5);
            this.btnTumKayitlar.Name = "btnTumKayitlar";
            this.btnTumKayitlar.Size = new System.Drawing.Size(120, 30);
            this.btnTumKayitlar.TabIndex = 5;
            this.btnTumKayitlar.Text = "Tüm Kayıtlar";
            this.btnTumKayitlar.UseVisualStyleBackColor = false;
            this.btnTumKayitlar.Click += new System.EventHandler(this.btnTumKayitlar_Click);
            // 
            // dgvRapor
            // 
            this.dgvRapor.AllowUserToAddRows = false;
            this.dgvRapor.AllowUserToDeleteRows = false;
            this.dgvRapor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRapor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRapor.BackgroundColor = System.Drawing.Color.White;
            this.dgvRapor.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.dgvRapor.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvRapor.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvRapor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRapor.EnableHeadersVisualStyles = false;
            this.dgvRapor.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvRapor.Location = new System.Drawing.Point(12, 154);
            this.dgvRapor.MultiSelect = false;
            this.dgvRapor.Name = "dgvRapor";
            this.dgvRapor.ReadOnly = true;
            this.dgvRapor.RowHeadersVisible = false;
            this.dgvRapor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRapor.Size = new System.Drawing.Size(910, 384);
            this.dgvRapor.TabIndex = 2;
            this.dgvRapor.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvRapor_CellFormatting);
            // 
            // FrmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(934, 550);
            this.Controls.Add(this.dgvRapor);
            this.Controls.Add(this.pnlFiltre);
            this.Controls.Add(this.pnlKPI);
            this.Name = "FrmDashboard";
            this.Text = "Genel Durum Raporu (Dashboard)";
            this.Load += new System.EventHandler(this.FrmDashboard_Load);
            this.pnlKPI.ResumeLayout(false);
            this.grpToplamIslem.ResumeLayout(false);
            this.grpToplamStok.ResumeLayout(false);
            this.grpToplamCari.ResumeLayout(false);
            this.pnlFiltre.ResumeLayout(false);
            this.pnlFiltre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRapor)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlKPI;
        private System.Windows.Forms.GroupBox grpToplamCari;
        private System.Windows.Forms.Label lblToplamCari;
        private System.Windows.Forms.GroupBox grpToplamStok;
        private System.Windows.Forms.Label lblToplamStok;
        private System.Windows.Forms.GroupBox grpToplamIslem;
        private System.Windows.Forms.Label lblToplamIslem;
        private System.Windows.Forms.Panel pnlFiltre;
        private System.Windows.Forms.Label lblBaslangic;
        private System.Windows.Forms.DateTimePicker dtpBaslangic;
        private System.Windows.Forms.Label lblBitis;
        private System.Windows.Forms.DateTimePicker dtpBitis;
        private System.Windows.Forms.Button btnFiltrele;
        private System.Windows.Forms.Button btnTumKayitlar;
        private System.Windows.Forms.DataGridView dgvRapor;
    }
}
