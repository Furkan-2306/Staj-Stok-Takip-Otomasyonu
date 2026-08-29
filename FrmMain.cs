using System;
using System.Windows.Forms;
using StokTakipOtomasyonu.DataAccess;

namespace StokTakipOtomasyonu
{
    /// <summary>
    /// MDI (Multiple Document Interface) Ana Form.
    /// Tüm alt modülleri (Cari, Stok, Hareketler, Dashboard) tek çatı altında toplar.
    /// Singleton benzeri yapı ile aynı formun birden fazla açılması engellenir.
    /// </summary>
    public partial class FrmMain : Form
    {
        private string aktifKullanici;

        public FrmMain(string kullaniciAdi)
        {
            InitializeComponent();
            this.aktifKullanici = kullaniciAdi;
        }

        /// <summary>
        /// Form yüklendiğinde bağlantı durumu ve aktif kullanıcı bilgisi güncellenir.
        /// </summary>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Aktif kullanıcıyı StatusStrip'te göster
            tsslKullanici.Text = "Kullanıcı: " + aktifKullanici;

            // Veritabanı bağlantı durumunu kontrol et
            if (DatabaseConnection.BaglantiKontrol())
            {
                tsslBaglanti.Text = "Bağlantı: Aktif ✓";
                tsslBaglanti.ForeColor = System.Drawing.Color.LightGreen;
            }
            else
            {
                tsslBaglanti.Text = "Bağlantı: Bağlantı Yok ✗";
                tsslBaglanti.ForeColor = System.Drawing.Color.Red;
            }
        }

        /// <summary>
        /// Singleton benzeri form açma mantığı.
        /// Aynı türde bir child form zaten açıksa onu öne getirir, açık değilse yeni oluşturur.
        /// </summary>
        private void ChildFormAc<T>() where T : Form, new()
        {
            // Aynı formun tekrar açılmasını engelle (Singleton deseni)
            foreach (Form childForm in this.MdiChildren)
            {
                if (childForm is T)
                {
                    childForm.Activate();
                    return;
                }
            }

            T form = new T();
            form.MdiParent = this;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }

        private void tsmiCariYonetimi_Click(object sender, EventArgs e)
        {
            ChildFormAc<FrmCari>();
        }

        private void tsmiStokYonetimi_Click(object sender, EventArgs e)
        {
            ChildFormAc<FrmStok>();
        }

        private void tsmiStokHareketleri_Click(object sender, EventArgs e)
        {
            ChildFormAc<FrmHareket>();
        }

        private void tsmiDashboard_Click(object sender, EventArgs e)
        {
            ChildFormAc<FrmDashboard>();
        }
    }
}
