using System;
using System.Windows.Forms;
using StokTakipOtomasyonu.DataAccess;
using StokTakipOtomasyonu.Models;

namespace StokTakipOtomasyonu
{
    /// <summary>
    /// Cari (Müşteri) Yönetim Formu.
    /// CRUD işlemleri CariDAL üzerinden yapılır. Form code-behind'da SQL komutu yoktur.
    /// Silme işlemi fiziksel değildir (Soft Delete — IsActive = 0).
    /// </summary>
    public partial class FrmCari : Form
    {
        private CariDAL cariDAL = new CariDAL();
        private int seciliCariID = 0;

        public FrmCari()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form yüklendiğinde cari listesini DataGridView'e bağlar.
        /// </summary>
        private void FrmCari_Load(object sender, EventArgs e)
        {
            CarileriListele();
        }

        /// <summary>
        /// Aktif carileri DataGridView'e yükler.
        /// </summary>
        private void CarileriListele()
        {
            dgvCariler.DataSource = cariDAL.TumCarileriGetir();
        }

        /// <summary>
        /// Kaydet butonuna basıldığında yeni cari ekler.
        /// </summary>
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // Zorunlu alan kontrolü
            if (string.IsNullOrWhiteSpace(txtAdSoyad.Text))
            {
                MessageBox.Show("Ad Soyad alanı boş bırakılamaz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdSoyad.Focus();
                return;
            }

            Cari cari = new Cari
            {
                AdSoyad = txtAdSoyad.Text.Trim(),
                Telefon = mskTelefon.Text.Trim(),
                Adres = txtAdres.Text.Trim()
            };

            if (cariDAL.CariEkle(cari))
            {
                MessageBox.Show("Cari başarıyla kaydedildi.", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormuTemizle();
                CarileriListele();
            }
        }

        /// <summary>
        /// Güncelle butonuna basıldığında seçili cariyi günceller.
        /// </summary>
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (seciliCariID == 0)
            {
                MessageBox.Show("Lütfen güncellenecek bir cari seçiniz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAdSoyad.Text))
            {
                MessageBox.Show("Ad Soyad alanı boş bırakılamaz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdSoyad.Focus();
                return;
            }

            Cari cari = new Cari
            {
                CariID = seciliCariID,
                AdSoyad = txtAdSoyad.Text.Trim(),
                Telefon = mskTelefon.Text.Trim(),
                Adres = txtAdres.Text.Trim()
            };

            if (cariDAL.CariGuncelle(cari))
            {
                MessageBox.Show("Cari başarıyla güncellendi.", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormuTemizle();
                CarileriListele();
            }
        }

        /// <summary>
        /// Sil butonuna basıldığında Soft Delete uygular (IsActive = 0).
        /// Fiziksel silme yapılmaz, cari pasife alınır.
        /// </summary>
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (seciliCariID == 0)
            {
                MessageBox.Show("Lütfen silinecek bir cari seçiniz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show("Bu cariyi pasife almak istediğinize emin misiniz?",
                "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                if (cariDAL.CariSil(seciliCariID))
                {
                    MessageBox.Show("Cari pasife alındı (Soft Delete).", "Bilgi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormuTemizle();
                    CarileriListele();
                }
            }
        }

        /// <summary>
        /// DataGridView'de bir satıra tıklandığında verileri sol paneldeki alanlara aktarır.
        /// </summary>
        private void dgvCariler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCariler.Rows[e.RowIndex];
                seciliCariID = Convert.ToInt32(row.Cells["CariID"].Value);
                txtAdSoyad.Text = row.Cells["AdSoyad"].Value.ToString();
                mskTelefon.Text = row.Cells["Telefon"].Value.ToString();
                txtAdres.Text = row.Cells["Adres"].Value.ToString();
            }
        }

        /// <summary>
        /// Temizle butonuna basıldığında formu sıfırlar.
        /// </summary>
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            FormuTemizle();
        }

        /// <summary>
        /// Form alanlarını temizler ve seçili ID'yi sıfırlar.
        /// </summary>
        private void FormuTemizle()
        {
            seciliCariID = 0;
            lblCariID.Text = "";
            txtAdSoyad.Clear();
            mskTelefon.Clear();
            txtAdres.Clear();
            txtAdSoyad.Focus();
        }
    }
}
