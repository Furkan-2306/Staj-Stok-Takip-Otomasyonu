using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using StokTakipOtomasyonu.Models;

namespace StokTakipOtomasyonu.DataAccess
{
    /// <summary>
    /// Cariler tablosu için tüm CRUD (Create, Read, Update, Delete) işlemlerini içeren
    /// Data Access Layer sınıfı. Silme işlemi Soft Delete (IsActive = 0) mantığıyla çalışır.
    /// Tüm sorgularda SQL Injection'a karşı MySqlParameter kullanılır.
    /// </summary>
    public class CariDAL
    {
        /// <summary>
        /// Aktif (IsActive = 1) tüm carileri DataTable olarak döndürür.
        /// </summary>
        public DataTable TumCarileriGetir()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT CariID, AdSoyad, Telefon, Adres, Bakiye FROM Cariler WHERE IsActive = 1";
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
                MessageBox.Show("İşlem sırasında beklenmeyen bir sistem hatası oluştu: " + ex.Message,
                    "Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        /// <summary>
        /// Yeni bir cari kaydı ekler.
        /// </summary>
        /// <param name="cari">Eklenecek cari bilgileri</param>
        /// <returns>İşlem başarılı ise true</returns>
        public bool CariEkle(Cari cari)
        {
            bool sonuc = false;
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = "INSERT INTO Cariler (AdSoyad, Telefon, Adres) VALUES (@p1, @p2, @p3)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@p1", cari.AdSoyad);
                    cmd.Parameters.AddWithValue("@p2", cari.Telefon);
                    cmd.Parameters.AddWithValue("@p3", cari.Adres);
                    int etkilenenSatir = cmd.ExecuteNonQuery();
                    if (etkilenenSatir > 0) sonuc = true;
                }
            }
            catch (MySqlException mysqlEx)
            {
                MessageBox.Show("Cari eklenirken veritabanı hatası: " + mysqlEx.Message,
                    "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beklenmeyen hata: " + ex.Message,
                    "Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return sonuc;
        }

        /// <summary>
        /// Mevcut bir cari kaydını günceller.
        /// </summary>
        /// <param name="cari">Güncellenecek cari bilgileri (CariID zorunlu)</param>
        /// <returns>İşlem başarılı ise true</returns>
        public bool CariGuncelle(Cari cari)
        {
            bool sonuc = false;
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = "UPDATE Cariler SET AdSoyad=@p1, Telefon=@p2, Adres=@p3 WHERE CariID=@id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@p1", cari.AdSoyad);
                    cmd.Parameters.AddWithValue("@p2", cari.Telefon);
                    cmd.Parameters.AddWithValue("@p3", cari.Adres);
                    cmd.Parameters.AddWithValue("@id", cari.CariID);
                    sonuc = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException mysqlEx)
            {
                MessageBox.Show("Cari güncellenirken veritabanı hatası: " + mysqlEx.Message,
                    "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beklenmeyen hata: " + ex.Message,
                    "Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return sonuc;
        }

        /// <summary>
        /// Cari kaydını fiziksel olarak silmez, sadece pasife alır (Soft Delete).
        /// UPDATE Cariler SET IsActive = 0 WHERE CariID = @id
        /// </summary>
        /// <param name="cariID">Pasife alınacak carinin ID'si</param>
        /// <returns>İşlem başarılı ise true</returns>
        public bool CariSil(int cariID)
        {
            bool sonuc = false;
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = "UPDATE Cariler SET IsActive = 0 WHERE CariID = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", cariID);
                    sonuc = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException mysqlEx)
            {
                MessageBox.Show("Cari silinirken veritabanı hatası: " + mysqlEx.Message,
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
