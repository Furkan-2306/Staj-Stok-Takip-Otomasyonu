using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace StokTakipOtomasyonu.DataAccess
{
    /// <summary>
    /// Sistemdeki tüm modüllerin ortaklaşa kullanacağı merkezi veritabanı bağlantı sınıfı.
    /// XAMPP MySQL varsayılan ayarları ile bağlantı kurar.
    /// </summary>
    public class DatabaseConnection
    {
        // XAMPP MySQL varsayılan bağlantı dizesi
        private static string connectionString =
            "Server=localhost;Database=StokTakipDB;Uid=root;Pwd=;CharSet=utf8mb4;";

        /// <summary>
        /// MySQL veritabanına yeni bir bağlantı açar ve döndürür.
        /// </summary>
        /// <returns>Açılmış MySqlConnection nesnesi</returns>
        public static MySqlConnection GetConnection()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message,
                    "Kritik Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return conn;
        }

        /// <summary>
        /// Veritabanı bağlantısının aktif olup olmadığını kontrol eder.
        /// StatusStrip'te bağlantı durumu göstermek için kullanılır.
        /// </summary>
        public static bool BaglantiKontrol()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
