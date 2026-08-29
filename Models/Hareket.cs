using System;

namespace StokTakipOtomasyonu.Models
{
    /// <summary>
    /// Hareketler tablosunun C# nesne karşılığı.
    /// İşlemin türü (Alış veya Satış), miktarı, tarih bilgisi ve
    /// işlemin hangi Cari ile hangi Stok arasında gerçekleştiğini belirten
    /// birincil anahtar referanslarını (Foreign Key) içerir.
    /// </summary>
    public class Hareket
    {
        public int HareketID { get; set; }

        // İlişkisel tabloları temsil eden Foreign Key karşılıkları
        public int CariID { get; set; }
        public int StokID { get; set; }

        // İşlem Tipi ("Alış" veya "Satış")
        public string IslemTipi { get; set; }

        public int Miktar { get; set; }
        public DateTime IslemTarihi { get; set; }
    }
}
