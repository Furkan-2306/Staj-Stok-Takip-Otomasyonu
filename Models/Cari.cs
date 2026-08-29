namespace StokTakipOtomasyonu.Models
{
    /// <summary>
    /// Cariler tablosunun C# nesne karşılığı (OOP - Kapsülleme).
    /// Müşteri bilgilerini taşıyan Data Transfer Object.
    /// </summary>
    public class Cari
    {
        public int CariID { get; set; }
        public string AdSoyad { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public decimal Bakiye { get; set; }
        public bool IsActive { get; set; }
    }
}
