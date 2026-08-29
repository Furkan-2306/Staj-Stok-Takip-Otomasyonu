using System;
using System.Drawing;
using System.Windows.Forms;
using StokTakipOtomasyonu.DataAccess;

namespace StokTakipOtomasyonu
{
    /// <summary>
    /// Genel Durum Raporu (Dashboard) Formu.
    /// INNER JOIN kullanarak Hareketler, Cariler ve Stoklar tablolarından özet veri çeker.
    /// KPI metrikleri ve tarih filtreli rapor sunar.
    /// CellFormatting event'i ile Alış işlemleri yeşil, Satış işlemleri kırmızı font ile gösterilir.
    /// </summary>
    public partial class FrmDashboard : Form
    {
        private HareketDAL hareketDAL = new HareketDAL();

        public FrmDashboard()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form yüklendiğinde KPI değerlerini ve rapor verisini yükler.
        /// </summary>
        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            KPIDegerleriniYukle();
            RaporuYukle();

            // Tarih filtresi varsayılan aralığı: son 30 gün
            dtpBaslangic.Value = DateTime.Now.AddDays(-30);
            dtpBitis.Value = DateTime.Now;
        }

        /// <summary>
        /// Dashboard üst kısmındaki KPI (Performans Göstergesi) değerlerini veritabanından çeker.
        /// </summary>
        private void KPIDegerleriniYukle()
        {
            try
            {
                lblToplamCari.Text = hareketDAL.ToplamCariSayisi().ToString();
                lblToplamStok.Text = hareketDAL.ToplamStokKalemi().ToString();
                lblToplamIslem.Text = hareketDAL.ToplamIslemSayisi().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("KPI değerleri yüklenirken hata: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Tüm hareketleri INNER JOIN sorgusu ile DataGridView'e yükler.
        /// </summary>
        private void RaporuYukle()
        {
            dgvRapor.DataSource = hareketDAL.TumHareketleriGetir();
        }

        /// <summary>
        /// Filtrele butonuna basıldığında belirtilen tarih aralığındaki hareketleri getirir.
        /// </summary>
        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            if (dtpBaslangic.Value > dtpBitis.Value)
            {
                MessageBox.Show("Başlangıç tarihi bitiş tarihinden büyük olamaz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime baslangic = dtpBaslangic.Value.Date;
            DateTime bitis = dtpBitis.Value.Date.AddDays(1).AddSeconds(-1); // Gün sonuna kadar dahil et

            dgvRapor.DataSource = hareketDAL.HareketleriTariheFiltresineGoreGetir(baslangic, bitis);
        }

        /// <summary>
        /// Tüm Kayıtlar butonuna basıldığında filtreyi kaldırır.
        /// </summary>
        private void btnTumKayitlar_Click(object sender, EventArgs e)
        {
            RaporuYukle();
        }

        /// <summary>
        /// DataGridView CellFormatting event'i.
        /// Alış işlemleri yeşil font, Satış işlemleri kırmızı font ile gösterilir.
        /// Staj defterinin 24. gününde tanımlanan görsel hiyerarşi kuralı.
        /// </summary>
        private void dgvRapor_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvRapor.Columns[e.ColumnIndex].HeaderText == "İşlem Tipi" && e.Value != null)
            {
                string islemTipi = e.Value.ToString();

                if (islemTipi == "Alış")
                {
                    // Alış (giriş) işlemleri yeşil renkli metinle gösterilir
                    dgvRapor.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(39, 174, 96);
                    dgvRapor.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
                else if (islemTipi == "Satış")
                {
                    // Satış (çıkış) işlemleri kırmızı renkli metinle gösterilir
                    dgvRapor.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(192, 57, 43);
                    dgvRapor.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
            }
        }
    }
}
