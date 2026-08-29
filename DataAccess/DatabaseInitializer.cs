using System;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;

namespace StokTakipOtomasyonu.DataAccess
{
    /// <summary>
    /// Uygulama açılışında veritabanı ve tabloların otomatik oluşturulmasını sağlar (Auto-Migration).
    /// Veritabanı yoksa CREATE DATABASE IF NOT EXISTS ile otomatik yaratılır.
    /// SHA-256 hash metodu da bu sınıfta tanımlıdır.
    /// </summary>
    public class DatabaseInitializer
    {
        /// <summary>
        /// Ana MySQL sunucusuna bağlanıp StokTakipDB veritabanının var olup olmadığını kontrol eder.
        /// Yoksa veritabanını, tabloları ve varsayılan admin kullanıcısını oluşturur.
        /// </summary>
        public static void VeritabaniniKontrolEtVeKur()
        {
            // Veritabanı belirtilmeden sadece XAMPP MySQL ana sunucusuna bağlanılır
            string masterConnection = "Server=localhost;Uid=root;Pwd=;CharSet=utf8mb4;";
            using (MySqlConnection conn = new MySqlConnection(masterConnection))
            {
                conn.Open();

                // Veritabanı yoksa oluştur
                string createDbQuery = "CREATE DATABASE IF NOT EXISTS StokTakipDB CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;";
                MySqlCommand createCmd = new MySqlCommand(createDbQuery, conn);
                createCmd.ExecuteNonQuery();

                // Oluşturulan veritabanına geç
                conn.ChangeDatabase("StokTakipDB");

                // Tabloları oluştur
                TablolariOlustur(conn);

                // Varsayılan admin kullanıcısını ekle
                VarsayilanKullaniciOlustur(conn);
            }
        }

        /// <summary>
        /// Tüm tabloları (Kullanicilar, Cariler, Stoklar, Hareketler) IF NOT EXISTS ile oluşturur.
        /// Foreign Key ilişkileri tanımlanır.
        /// </summary>
        private static void TablolariOlustur(MySqlConnection conn)
        {
            // Kullanicilar tablosu
            string sqlKullanicilar = @"CREATE TABLE IF NOT EXISTS Kullanicilar (
                KullaniciID INT AUTO_INCREMENT PRIMARY KEY,
                KullaniciAdi VARCHAR(50) NOT NULL,
                SifreHash VARCHAR(256) NOT NULL
            );";
            new MySqlCommand(sqlKullanicilar, conn).ExecuteNonQuery();

            // Cariler tablosu (IsActive: Soft Delete desteği)
            string sqlCariler = @"CREATE TABLE IF NOT EXISTS Cariler (
                CariID INT AUTO_INCREMENT PRIMARY KEY,
                AdSoyad VARCHAR(100) NOT NULL,
                Telefon VARCHAR(15),
                Adres VARCHAR(250),
                Bakiye DECIMAL(18,2) DEFAULT 0.00,
                IsActive TINYINT(1) DEFAULT 1
            );";
            new MySqlCommand(sqlCariler, conn).ExecuteNonQuery();

            // Stoklar tablosu (UrunKodu UNIQUE, IsActive: Soft Delete desteği)
            string sqlStoklar = @"CREATE TABLE IF NOT EXISTS Stoklar (
                StokID INT AUTO_INCREMENT PRIMARY KEY,
                UrunKodu VARCHAR(50) UNIQUE NOT NULL,
                UrunAdi VARCHAR(100) NOT NULL,
                SatisFiyati DECIMAL(18,2) NOT NULL,
                MevcutStok INT DEFAULT 0,
                IsActive TINYINT(1) DEFAULT 1
            );";
            new MySqlCommand(sqlStoklar, conn).ExecuteNonQuery();

            // Hareketler tablosu (Foreign Key: CariID, StokID)
            string sqlHareketler = @"CREATE TABLE IF NOT EXISTS Hareketler (
                HareketID INT AUTO_INCREMENT PRIMARY KEY,
                CariID INT,
                StokID INT,
                IslemTipi VARCHAR(20),
                Miktar INT NOT NULL,
                IslemTarihi DATETIME DEFAULT CURRENT_TIMESTAMP,
                FOREIGN KEY (CariID) REFERENCES Cariler(CariID),
                FOREIGN KEY (StokID) REFERENCES Stoklar(StokID)
            );";
            new MySqlCommand(sqlHareketler, conn).ExecuteNonQuery();
        }

        /// <summary>
        /// Varsayılan admin kullanıcısını oluşturur (admin / admin — SHA-256 ile hashlenmiş).
        /// Eğer zaten varsa tekrar eklemez.
        /// </summary>
        private static void VarsayilanKullaniciOlustur(MySqlConnection conn)
        {
            string checkQuery = "SELECT COUNT(*) FROM Kullanicilar WHERE KullaniciAdi = 'admin';";
            MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
            long count = (long)checkCmd.ExecuteScalar();

            if (count == 0)
            {
                string hash = SifreyiHashle("admin");
                string insertQuery = "INSERT INTO Kullanicilar (KullaniciAdi, SifreHash) VALUES (@user, @hash);";
                MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);
                insertCmd.Parameters.AddWithValue("@user", "admin");
                insertCmd.Parameters.AddWithValue("@hash", hash);
                insertCmd.ExecuteNonQuery();

                // Admin kullanıcısı ilk defa oluşturuluyorsa, veritabanına örnek verileri de doldur.
                VarsayilanVerileriOlustur(conn);
            }
        }

        /// <summary>
        /// Sistem ilk defa kurulduğunda Dashboard'un boş görünmemesi için örnek Cariler, Stoklar ve Hareketler ekler.
        /// </summary>
        private static void VarsayilanVerileriOlustur(MySqlConnection conn)
        {
            // Örnek Cariler
            string sqlCariler = @"
                INSERT INTO Cariler (AdSoyad, Telefon, Adres, Bakiye) VALUES 
                ('Ahmet Yılmaz', '0532-111-2233', 'Kadıköy / İstanbul', 0),
                ('Mehmet Kaya', '0544-222-3344', 'Çankaya / Ankara', 0),
                ('Ayşe Demir', '0555-333-4455', 'Bornova / İzmir', 0);";
            new MySqlCommand(sqlCariler, conn).ExecuteNonQuery();

            // Örnek Stoklar
            string sqlStoklar = @"
                INSERT INTO Stoklar (UrunKodu, UrunAdi, SatisFiyati, MevcutStok) VALUES 
                ('KLV-01', 'Mekanik Klavye', 1250.00, 50),
                ('MOU-02', 'Kablosuz Mouse', 450.50, 100),
                ('MON-03', '27 inç Oyuncu Monitörü', 4500.00, 20);";
            new MySqlCommand(sqlStoklar, conn).ExecuteNonQuery();

            // Örnek Hareketler (Alış ve Satış) ve Stok Güncellemeleri
            string sqlHareketler = @"
                INSERT INTO Hareketler (CariID, StokID, IslemTipi, Miktar, IslemTarihi) VALUES 
                (1, 1, 'Satış', 2, DATE_SUB(NOW(), INTERVAL 5 DAY)),
                (2, 2, 'Alış', 10, DATE_SUB(NOW(), INTERVAL 2 DAY)),
                (3, 3, 'Satış', 1, NOW());
                
                UPDATE Stoklar SET MevcutStok = MevcutStok - 2 WHERE StokID = 1;
                UPDATE Stoklar SET MevcutStok = MevcutStok + 10 WHERE StokID = 2;
                UPDATE Stoklar SET MevcutStok = MevcutStok - 1 WHERE StokID = 3;
            ";
            new MySqlCommand(sqlHareketler, conn).ExecuteNonQuery();
        }

        /// <summary>
        /// Verilen şifre metnini SHA-256 algoritması ile geri döndürülemez bir hash'e dönüştürür.
        /// Hexadecimal string formatında döner.
        /// </summary>
        /// <param name="sifre">Düz metin şifre</param>
        /// <returns>SHA-256 hash (64 karakter hex string)</returns>
        public static string SifreyiHashle(string sifre)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Şifre metnini byte dizisine çevir ve SHA256 algoritmasıyla şifrele
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(sifre));

                // Şifrelenmiş byte dizisini veritabanına yazılabilir string formatına (Hexadecimal) dönüştür
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
