namespace StokTakipOtomasyonu.Models
{
    /// <summary>
    /// Stoklar tablosunun C# nesne karşılığı (OOP - Kapsülleme).
    /// Ürün bilgilerini taşıyan Data Transfer Object.
    /// </summary>
    public class Stok
    {
        public int StokID { get; set; }
        public string UrunKodu { get; set; }
        public string UrunAdi { get; set; }
        public decimal SatisFiyati { get; set; }
        public int MevcutStok { get; set; }
        public bool IsActive { get; set; }
    }
}
