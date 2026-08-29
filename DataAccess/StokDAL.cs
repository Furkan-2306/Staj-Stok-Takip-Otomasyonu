using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using StokTakipOtomasyonu.Models;

namespace StokTakipOtomasyonu.DataAccess
{
    /// <summary>
    /// Stoklar tablosu için CRUD işlemlerini ve arama fonksiyonunu içeren
    /// Data Access Layer sınıfı. Soft Delete ve LIKE arama desteği mevcuttur.
    /// </summary>
    public class StokDAL
    {
        /// <summary>
        /// Aktif (IsActive = 1) tüm stokları DataTable olarak döndürür.
        /// </summary>
        public DataTable TumStoklariGetir()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT StokID, UrunKodu, UrunAdi, SatisFiyati, MevcutStok FROM Stoklar WHERE IsActive = 1";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    da.Fill(dt);
                }
            }
            catch (MySqlException mysqlEx)
            {
                MessageBox.Show("Veritabanı ile iletişim kurulamadı. XAMPP panelinden MySQL servisinin çalıştığından emin olun.",
                    "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beklenmeyen hata: " + ex.Message,
                    "Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        /// <summary>
        /// Ürün kodu veya ürün adına göre LIKE araması yapar.
        /// TextChanged event'i ile anlık filtreleme için kullanılır.
        /// </summary>
        /// <param name="aranacakKelime">Aranacak metin</param>
        /// <returns>Filtrelenmiş DataTable</returns>
        public DataTable StokAra(string aranacakKelime)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT StokID, UrunKodu, UrunAdi, SatisFiyati, MevcutStok FROM Stoklar WHERE IsActive = 1 AND (UrunKodu LIKE @kelime OR UrunAdi LIKE @kelime)";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@kelime", "%" + aranacakKelime + "%");
                    da.Fill(dt);
                }
            }
            catch (MySqlException mysqlEx)
            {
                MessageBox.Show("Arama sırasında veritabanı hatası: " + mysqlEx.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beklenmeyen hata: " + ex.Message,
                    "Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        /// <summary>
        /// Yeni bir stok kaydı ekler.
        /// Duplicate UrunKodu girişinde MySQL Error 1062 yakalanır.
        /// </summary>
        /// <param name="stok">Eklenecek stok bilgileri</param>
        /// <returns>İşlem başarılı ise true</returns>
        public bool StokEkle(Stok stok)
        {
            bool sonuc = false;
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = "INSERT INTO Stoklar (UrunKodu, UrunAdi, SatisFiyati, MevcutStok) VALUES (@p1, @p2, @p3, @p4)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@p1", stok.UrunKodu);
                    cmd.Parameters.AddWithValue("@p2", stok.UrunAdi);
                    cmd.Parameters.AddWithValue("@p3", stok.SatisFiyati);
                    cmd.Parameters.AddWithValue("@p4", stok.MevcutStok);
                    sonuc = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException mysqlEx)
            {
                if (mysqlEx.Number == 1062) // Duplicate entry (Unique Constraint)
                {
                    MessageBox.Show("Bu ürün kodu zaten sistemde kayıtlıdır! Lütfen farklı bir kod giriniz.",
                        "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Stok eklenirken veritabanı hatası: " + mysqlEx.Message,
                        "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beklenmeyen hata: " + ex.Message,
                    "Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return sonuc;
        }

        /// <summary>
        /// Mevcut bir stok kaydını günceller.
        /// </summary>
        public bool StokGuncelle(Stok stok)
        {
            bool sonuc = false;
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = "UPDATE Stoklar SET UrunKodu=@p1, UrunAdi=@p2, SatisFiyati=@p3, MevcutStok=@p4 WHERE StokID=@id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@p1", stok.UrunKodu);
                    cmd.Parameters.AddWithValue("@p2", stok.UrunAdi);
                    cmd.Parameters.AddWithValue("@p3", stok.SatisFiyati);
                    cmd.Parameters.AddWithValue("@p4", stok.MevcutStok);
                    cmd.Parameters.AddWithValue("@id", stok.StokID);
                    sonuc = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException mysqlEx)
            {
                if (mysqlEx.Number == 1062)
                {
                    MessageBox.Show("Bu ürün kodu zaten başka bir üründe kullanılıyor!",
                        "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Stok güncellenirken veritabanı hatası: " + mysqlEx.Message,
                        "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beklenmeyen hata: " + ex.Message,
                    "Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return sonuc;
        }

        /// <summary>
        /// Stok kaydını fiziksel olarak silmez, sadece pasife alır (Soft Delete).
        /// </summary>
        public bool StokSil(int stokID)
        {
            bool sonuc = false;
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = "UPDATE Stoklar SET IsActive = 0 WHERE StokID = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", stokID);
                    sonuc = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException mysqlEx)
            {
                MessageBox.Show("Stok silinirken veritabanı hatası: " + mysqlEx.Message,
                    "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beklenmeyen hata: " + ex.Message,
                    "Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return sonuc;
        }
    }
}
