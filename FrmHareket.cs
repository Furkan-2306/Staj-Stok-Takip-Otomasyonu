using System;
using System.Windows.Forms;
using StokTakipOtomasyonu.DataAccess;
using StokTakipOtomasyonu.Models;

namespace StokTakipOtomasyonu
{
    /// <summary>
    /// Stok Hareketleri (Alış / Satış) Formu.
    /// Cari ve Stok seçimi ComboBox ile Data Binding (DisplayMember / ValueMember) yapılır.
    /// Hareket kaydı MySqlTransaction ile atomik olarak yapılır (Ya hep ya hiç).
    /// </summary>
    public partial class FrmHareket : Form
    {
        private CariDAL cariDAL = new CariDAL();
        private StokDAL stokDAL = new StokDAL();
        private HareketDAL hareketDAL = new HareketDAL();

        public FrmHareket()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form yüklendiğinde ComboBox'ları doldurur ve hareket listesini yükler.
        /// </summary>
        private void FrmHareket_Load(object sender, EventArgs e)
        {
            ComboboxlariDoldur();
            HareketleriListele();
        }

        /// <summary>
        /// Cari ve Stok ComboBox'larını veritabanından gelen verilerle doldurur.
        /// DisplayMember: Kullanıcının ekranda göreceği metin.
        /// ValueMember: Arka planda (veritabanında) tutulacak ID değeri.
        /// </summary>
        public void ComboboxlariDoldur()
        {
            // Carileri ComboBox'a bağlama
            System.Data.DataTable dtCariler = cariDAL.TumCarileriGetir();
            cmbCariler.DataSource = dtCariler;
            cmbCariler.DisplayMember = "AdSoyad"; // Kullanıcının ekranda göreceği metin
            cmbCariler.ValueMember = "CariID";    // Arka planda tutulacak ID değeri

            // Stokları ComboBox'a bağlama
            System.Data.DataTable dtStoklar = stokDAL.TumStoklariGetir();
            cmbStoklar.DataSource = dtStoklar;
            cmbStoklar.DisplayMember = "UrunAdi";
            cmbStoklar.ValueMember = "StokID";
        }

        /// <summary>
        /// Tüm hareketleri INNER JOIN ile DataGridView'e yükler.
        /// </summary>
        private void HareketleriListele()
        {
            dgvHareketler.DataSource = hareketDAL.TumHareketleriGetir();
        }

        /// <summary>
        /// İşlemi Kaydet butonuna basıldığında MySqlTransaction ile atomik kayıt yapılır.
        /// Önce Hareketler tablosuna INSERT, ardından Stoklar tablosunda MevcutStok güncellenir.
        /// </summary>
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // Doğrulama kontrolleri
            if (cmbCariler.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir cari (müşteri) seçiniz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbStoklar.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir stok (ürün) seçiniz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // İşlem tipini RadioButton'lardan belirle
            string islemTipi = rbAlis.Checked ? "Alış" : "Satış";

            Hareket hareket = new Hareket
            {
                CariID = Convert.ToInt32(cmbCariler.SelectedValue),
                StokID = Convert.ToInt32(cmbStoklar.SelectedValue),
                IslemTipi = islemTipi,
                Miktar = (int)nudMiktar.Value
            };

            // Transaction ile güvenli kayıt
            if (hareketDAL.GuvenliHareketEkle(hareket))
            {
                MessageBox.Show($"{islemTipi} işlemi başarıyla kaydedildi.", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ComboBox'ları ve listeyi güncelle
                ComboboxlariDoldur();
                HareketleriListele();
                nudMiktar.Value = 1;
            }
        }
    }
}
