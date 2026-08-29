using System;
using System.Windows.Forms;
using StokTakipOtomasyonu.DataAccess;

namespace StokTakipOtomasyonu
{
    public partial class FrmRegister : Form
    {
        private KullaniciDAL kullaniciDAL = new KullaniciDAL();

        public FrmRegister()
        {
            InitializeComponent();
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text.Trim();
            string sifre = txtSifre.Text;
            string sifreTekrar = txtSifreTekrar.Text;

            // Alanların doluluk kontrolü
            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre) || string.IsNullOrEmpty(sifreTekrar))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz!", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Şifre eşleşme kontrolü
            if (sifre != sifreTekrar)
            {
                MessageBox.Show("Şifreler eşleşmiyor, lütfen tekrar deneyiniz!", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kullanıcı adı daha önce alınmış mı?
            if (kullaniciDAL.KullaniciVarMi(kullaniciAdi))
            {
                MessageBox.Show("Bu kullanıcı adı zaten alınmış. Lütfen farklı bir kullanıcı adı seçiniz.", "Bilgi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Kayıt işlemi
            if (kullaniciDAL.KullaniciEkle(kullaniciAdi, sifre))
            {
                MessageBox.Show("Kayıt işlemi başarıyla tamamlandı. Artık giriş yapabilirsiniz.", "Başarılı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Formu kapatıp login ekranına dön
            }
        }
    }
}
