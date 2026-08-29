using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using StokTakipOtomasyonu.Models;

namespace StokTakipOtomasyonu.DataAccess
{
    /// <summary>
    /// Hareketler tablosu için veri erişim katmanı.
    /// MySqlTransaction ile atomik işlem güvenliği sağlar (Ya hep ya hiç).
    /// INNER JOIN ile ilişkisel rapor sorguları içerir.
    /// Dashboard KPI metriklerini hesaplar.
    /// </summary>
    public class HareketDAL
    {
        /// <summary>
        /// Yeni bir hareket kaydı ekler ve stok miktarını günceller.
        /// MySqlTransaction kullanarak ACID prensiplerine uygun atomik işlem yapar.
        /// Alış ise stok artar (+), Satış ise stok azalır (-).
        /// Hata durumunda Rollback() ile tüm işlemler geri alınır.
        /// </summary>
        /// <param name="hareket">Eklenecek hareket bilgileri</param>
        /// <returns>İşlem başarılı ise true</returns>
        public bool GuvenliHareketEkle(Hareket hareket)
        {
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                // Transaction işlemini başlat (Ya hep ya hiç kuralı)
                MySqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    // 1. Adım: Hareketi (Fişi) kaydet
                    string hareketSorgu = "INSERT INTO Hareketler (CariID, StokID, IslemTipi, Miktar) VALUES (@p1, @p2, @p3, @p4)";
                    MySqlCommand cmdHareket = new MySqlCommand(hareketSorgu, conn, transaction);
                    cmdHareket.Parameters.AddWithValue("@p1", hareket.CariID);
                    cmdHareket.Parameters.AddWithValue("@p2", hareket.StokID);
                    cmdHareket.Parameters.AddWithValue("@p3", hareket.IslemTipi);
                    cmdHareket.Parameters.AddWithValue("@p4", hareket.Miktar);
                    cmdHareket.ExecuteNonQuery();

                    // 2. Adım: Stok miktarını işlem türüne göre güncelle
                    string operatorTipi = hareket.IslemTipi == "Alış" ? "+" : "-";
                    string stokSorgu = $"UPDATE Stoklar SET MevcutStok = MevcutStok {operatorTipi} @miktar WHERE StokID = @stokId";
                    MySqlCommand cmdStok = new MySqlCommand(stokSorgu, conn, transaction);
                    cmdStok.Parameters.AddWithValue("@miktar", hareket.Miktar);
                    cmdStok.Parameters.AddWithValue("@stokId", hareket.StokID);
                    cmdStok.ExecuteNonQuery();

                    // İki işlem de sorunsuz bittiyse veritabanına kalıcı olarak onayla
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    // Hata anında tüm işlemleri geri al, veritabanını eski haline döndür
                    transaction.Rollback();
                    MessageBox.Show("Hareket kaydı sırasında hata oluştu. İşlem geri alındı.\n\nHata: " + ex.Message,
                        "İşlem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        /// <summary>
        /// INNER JOIN kullanarak tüm hareketleri Cari ve Stok bilgileriyle birlikte getirir.
        /// Toplam işlem tutarı hesaplanır.
        /// </summary>
        public DataTable TumHareketleriGetir()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = @"SELECT 
                        H.HareketID,
                        C.AdSoyad AS 'Müşteri Adı',
                        S.UrunAdi AS 'Ürün Adı',
                        H.IslemTipi AS 'İşlem Tipi',
                        H.Miktar,
                        (H.Miktar * S.SatisFiyati) AS 'Toplam Tutar (TL)',
                        H.IslemTarihi AS 'İşlem Tarihi'
                    FROM Hareketler H
                    INNER JOIN Cariler C ON H.CariID = C.CariID
                    INNER JOIN Stoklar S ON H.StokID = S.StokID
                    ORDER BY H.IslemTarihi DESC";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    da.Fill(dt);
                }
            }
            catch (MySqlException mysqlEx)
            {
                MessageBox.Show("Hareketler yüklenirken veritabanı hatası: " + mysqlEx.Message,
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
        /// Belirli bir tarih aralığındaki hareketleri INNER JOIN ile getirir.
        /// Dashboard tarih filtresi için kullanılır.
        /// </summary>
        public DataTable HareketleriTariheFiltresineGoreGetir(DateTime baslangic, DateTime bitis)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = @"SELECT 
                        H.HareketID,
                        C.AdSoyad AS 'Müşteri Adı',
                        S.UrunAdi AS 'Ürün Adı',
                        H.IslemTipi AS 'İşlem Tipi',
                        H.Miktar,
                        (H.Miktar * S.SatisFiyati) AS 'Toplam Tutar (TL)',
                        H.IslemTarihi AS 'İşlem Tarihi'
                    FROM Hareketler H
                    INNER JOIN Cariler C ON H.CariID = C.CariID
                    INNER JOIN Stoklar S ON H.StokID = S.StokID
                    WHERE H.IslemTarihi BETWEEN @baslangic AND @bitis
                    ORDER BY H.IslemTarihi DESC";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@baslangic", baslangic);
                    da.SelectCommand.Parameters.AddWithValue("@bitis", bitis);
                    da.Fill(dt);
                }
            }
            catch (MySqlException mysqlEx)
            {
                MessageBox.Show("Rapor oluşturulurken veritabanı hatası: " + mysqlEx.Message,
                    "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beklenmeyen hata: " + ex.Message,
                    "Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        /// <summary>
        /// Aktif cari sayısını döndürür (Dashboard KPI).
        /// </summary>
        public int ToplamCariSayisi()
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT COUNT(*) FROM Cariler WHERE IsActive = 1";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Aktif stok kalemi sayısını döndürür (Dashboard KPI).
        /// </summary>
        public int ToplamStokKalemi()
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT COUNT(*) FROM Stoklar WHERE IsActive = 1";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Toplam işlem (hareket) sayısını döndürür (Dashboard KPI).
        /// </summary>
        public int ToplamIslemSayisi()
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT COUNT(*) FROM Hareketler";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
