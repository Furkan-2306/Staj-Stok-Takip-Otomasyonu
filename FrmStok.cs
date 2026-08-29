using System;
using System.Windows.Forms;
using StokTakipOtomasyonu.DataAccess;
using StokTakipOtomasyonu.Models;

namespace StokTakipOtomasyonu
{
    /// <summary>
    /// Stok (Ürün) Yönetim Formu.
    /// CRUD işlemleri StokDAL üzerinden yapılır. Anlık LIKE arama desteği mevcuttur.
    /// Fiyat alanında sadece rakam ve virgül girilmesine izin verilir (KeyPress validation).
    /// </summary>
    public partial class FrmStok : Form
    {
        private StokDAL stokDAL = new StokDAL();
        private int seciliStokID = 0;

        public FrmStok()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form yüklendiğinde stok listesini DataGridView'e bağlar.
        /// </summary>
        private void FrmStok_Load(object sender, EventArgs e)
        {
            StoklariListele();
        }

        /// <summary>
        /// Aktif stokları DataGridView'e yükler.
        /// </summary>
        private void StoklariListele()
        {
            dgvStoklar.DataSource = stokDAL.TumStoklariGetir();
        }

        /// <summary>
        /// Arama kutusundaki metin değiştiğinde anlık filtreleme yapar.
        /// LIKE operatörü ile ürün kodu ve adında arama yapılır.
        /// </summary>
        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            string kelime = txtArama.Text.Trim();
            if (string.IsNullOrEmpty(kelime))
            {
                StoklariListele();
            }
            else
            {
                dgvStoklar.DataSource = stokDAL.StokAra(kelime);
            }
        }

        /// <summary>
        /// Fiyat alanında sadece rakam ve virgül (ondalık ayırıcı) girilmesine izin verir.
        /// Geçersiz tuş vuruşları donanımsal düzeyde iptal edilir.
        /// </summary>
        private void txtSatisFiyati_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sadece rakam, kontrol tuşları ve virgül/nokta (ondalık) kabul et
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Birden fazla ondalık ayırıcı girilmesini engelle
            if ((e.KeyChar == ',' || e.KeyChar == '.') && ((TextBox)sender).Text.Contains(","))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Kaydet butonuna basıldığında yeni stok ekler.
        /// </summary>
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // Zorunlu alan kontrolü
            if (string.IsNullOrWhiteSpace(txtUrunKodu.Text))
            {
                MessageBox.Show("Ürün Kodu alanı boş bırakılamaz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUrunKodu.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUrunAdi.Text))
            {
                MessageBox.Show("Ürün Adı alanı boş bırakılamaz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUrunAdi.Focus();
                return;
            }

            decimal fiyat;
            if (!decimal.TryParse(txtSatisFiyati.Text.Replace('.', ','), out fiyat) || fiyat <= 0)
            {
                MessageBox.Show("Geçerli bir satış fiyatı giriniz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSatisFiyati.Focus();
                return;
            }

            Stok stok = new Stok
            {
                UrunKodu = txtUrunKodu.Text.Trim(),
                UrunAdi = txtUrunAdi.Text.Trim(),
                SatisFiyati = fiyat,
                MevcutStok = (int)nudMevcutStok.Value
            };

            if (stokDAL.StokEkle(stok))
            {
                MessageBox.Show("Stok başarıyla kaydedildi.", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormuTemizle();
                StoklariListele();
            }
        }

        /// <summary>
        /// Güncelle butonuna basıldığında seçili stoğu günceller.
        /// </summary>
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (seciliStokID == 0)
            {
                MessageBox.Show("Lütfen güncellenecek bir stok seçiniz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUrunKodu.Text) || string.IsNullOrWhiteSpace(txtUrunAdi.Text))
            {
                MessageBox.Show("Ürün Kodu ve Ürün Adı alanları boş bırakılamaz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal fiyat;
            if (!decimal.TryParse(txtSatisFiyati.Text.Replace('.', ','), out fiyat) || fiyat <= 0)
            {
                MessageBox.Show("Geçerli bir satış fiyatı giriniz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSatisFiyati.Focus();
                return;
            }

            Stok stok = new Stok
            {
                StokID = seciliStokID,
                UrunKodu = txtUrunKodu.Text.Trim(),
                UrunAdi = txtUrunAdi.Text.Trim(),
                SatisFiyati = fiyat,
                MevcutStok = (int)nudMevcutStok.Value
            };

            if (stokDAL.StokGuncelle(stok))
            {
                MessageBox.Show("Stok başarıyla güncellendi.", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormuTemizle();
                StoklariListele();
            }
        }

        /// <summary>
        /// Sil butonuna basıldığında Soft Delete uygular (IsActive = 0).
        /// </summary>
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (seciliStokID == 0)
            {
                MessageBox.Show("Lütfen silinecek bir stok seçiniz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show("Bu stoğu pasife almak istediğinize emin misiniz?",
                "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                if (stokDAL.StokSil(seciliStokID))
                {
                    MessageBox.Show("Stok pasife alındı (Soft Delete).", "Bilgi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormuTemizle();
                    StoklariListele();
                }
            }
        }

        /// <summary>
        /// DataGridView'de bir satıra tıklandığında verileri sol paneldeki alanlara aktarır.
        /// </summary>
        private void dgvStoklar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStoklar.Rows[e.RowIndex];
                seciliStokID = Convert.ToInt32(row.Cells["StokID"].Value);
                txtUrunKodu.Text = row.Cells["UrunKodu"].Value.ToString();
                txtUrunAdi.Text = row.Cells["UrunAdi"].Value.ToString();
                txtSatisFiyati.Text = row.Cells["SatisFiyati"].Value.ToString();
                nudMevcutStok.Value = Convert.ToDecimal(row.Cells["MevcutStok"].Value);
            }
        }

        /// <summary>
        /// Temizle butonu — formu sıfırlar.
        /// </summary>
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            FormuTemizle();
        }

        private void FormuTemizle()
        {
            seciliStokID = 0;
            lblStokID.Text = "";
            txtUrunKodu.Clear();
            txtUrunAdi.Clear();
            txtSatisFiyati.Clear();
            nudMevcutStok.Value = 0;
            txtUrunKodu.Focus();
        }
    }
}
