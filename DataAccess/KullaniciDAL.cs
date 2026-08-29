using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace StokTakipOtomasyonu.DataAccess
{
    /// <summary>
    /// Kullanicilar tablosu için veri erişim katmanı.
    /// Şifre doğrulama işlemini SHA-256 hash karşılaştırması ile yapar.
    /// </summary>
    public class KullaniciDAL
    {
        /// <summary>
        /// Kullanıcı adı ve şifreyi doğrular.
        /// Girilen şifre SHA-256 ile hashlenerek veritabanındaki hash ile karşılaştırılır.
        /// </summary>
        /// <param name="kullaniciAdi">Girilen kullanıcı adı</param>
        /// <param name="sifre">Girilen düz metin şifre</param>
        /// <returns>Doğrulama başarılı ise true</returns>
        public bool KullaniciDogrula(string kullaniciAdi, string sifre)
        {
            try
            {
                // Şifreyi SHA-256 ile hashle
                string sifreHash = DatabaseInitializer.SifreyiHashle(sifre);

                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT COUNT(*) FROM Kullanicilar WHERE KullaniciAdi = @user AND SifreHash = @hash";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user", kullaniciAdi);
                    cmd.Parameters.AddWithValue("@hash", sifreHash);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (MySqlException mysqlEx)
            {
                MessageBox.Show("Giriş doğrulama sırasında veritabanı hatası oluştu. XAMPP panelinden MySQL servisinin çalıştığından emin olun.\n\nHata: " + mysqlEx.Message,
                    "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beklenmeyen bir sistem hatası oluştu: " + ex.Message,
                    "Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Kullanıcı adının sistemde kayıtlı olup olmadığını kontrol eder.
        /// </summary>
        public bool KullaniciVarMi(string kullaniciAdi)
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT COUNT(*) FROM Kullanicilar WHERE KullaniciAdi = @user";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user", kullaniciAdi);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Yeni bir kullanıcıyı şifresini SHA-256 ile hashleyerek veritabanına ekler.
        /// </summary>
        public bool KullaniciEkle(string kullaniciAdi, string sifre)
        {
            try
            {
                string sifreHash = DatabaseInitializer.SifreyiHashle(sifre);

                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = "INSERT INTO Kullanicilar (KullaniciAdi, SifreHash) VALUES (@user, @hash)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user", kullaniciAdi);
                    cmd.Parameters.AddWithValue("@hash", sifreHash);
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt sırasında hata oluştu: " + ex.Message,
                    "Kayıt Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
