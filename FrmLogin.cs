using System;
using System.Windows.Forms;
using StokTakipOtomasyonu.DataAccess;

namespace StokTakipOtomasyonu
{
    /// <summary>
    /// Kullanıcı Giriş (Login) Formu.
    /// Kullanıcı adı ve şifre alarak SHA-256 hash ile veritabanındaki kayıtla karşılaştırır.
    /// Başarılı girişte FrmMain (MDI Ana Form) açılır.
    /// </summary>
    public partial class FrmLogin : Form
    {
        private KullaniciDAL kullaniciDAL = new KullaniciDAL();

        public FrmLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Giriş Yap butonuna tıklandığında çalışır.
        /// Girilen şifre SHA-256 ile hashlenerek veritabanındaki ile karşılaştırılır.
        /// </summary>
        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text.Trim();
            string sifre = txtSifre.Text;

            // Boş alan kontrolü
            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Kullanıcı adı ve şifre alanları boş bırakılamaz!",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // KullaniciDAL sınıfından MySQL'e bağlanıp kullanıcıyı doğrulayan metot çağrılır
            bool girisBasarili = kullaniciDAL.KullaniciDogrula(kullaniciAdi, sifre);

            if (girisBasarili)
            {
                // Giriş başarılı ise ana formu örnekle ve aç
                FrmMain anaForm = new FrmMain(kullaniciAdi);
                this.Hide(); // Login formunu kullanıcıdan gizle
                anaForm.ShowDialog(); // Ana formu modal olarak aç
                this.Close(); // Ana form kapatıldığında arka plandaki Login formunu da tamamen kapat
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı!",
                    "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSifre.Clear();
                txtSifre.Focus();
            }
        }

        private void lnkKayitOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRegister registerForm = new FrmRegister();
            this.Hide();
            registerForm.ShowDialog();
            this.Show(); // Kayıt ekranı kapanınca login ekranını tekrar göster
        }
    }
}
