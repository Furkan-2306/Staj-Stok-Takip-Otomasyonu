namespace StokTakipOtomasyonu.Models
{
    /// <summary>
    /// Kullanicilar tablosunun C# nesne karşılığı.
    /// Sisteme giriş yapacak personel bilgilerini taşır.
    /// Şifre, SHA-256 hash olarak saklanır (SifreHash).
    /// </summary>
    public class Kullanici
    {
        public int KullaniciID { get; set; }
        public string KullaniciAdi { get; set; }
        public string SifreHash { get; set; }
    }
}
