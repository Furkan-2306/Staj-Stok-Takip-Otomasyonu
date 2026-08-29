# Bağımsız Cari ve Stok Takip Otomasyonu

Bu proje, küçük ve orta ölçekli işletmelerin müşteri (cari) kayıtlarını, ürün (stok) durumlarını ve alım-satım hareketlerini tek bir merkezden yönetebilmesi amacıyla geliştirilmiş C# tabanlı bir masaüstü otomasyon yazılımıdır. 

## 🛠 Kullanılan Teknolojiler
* **Dil:** C# (.NET Framework)
* **Arayüz:** Windows Forms (WinForms)
* **Veritabanı:** MySQL (XAMPP altyapısı)
* **Veri Erişimi:** ADO.NET (MySql.Data)
* **Mimari:** N-Tier (Çok Katmanlı Mimarisi) & Nesne Yönelimli Programlama (OOP)

## 📌 Temel Özellikler
* **Güvenli Kimlik Doğrulama:** SHA-256 algoritması ile şifrelenmiş kullanıcı giriş sistemi.
* **Cari ve Stok Yönetimi:** Müşteri ve ürünler için tam kapsamlı CRUD operasyonları. Veri kaybını önlemek için fiziksel silme yerine `IsActive` mantığı (Soft Delete).
* **İşlem Güvenliği (ACID):** Alım ve satım işlemlerinde stok bakiyelerinin anlık güncellenmesi. Hata anında veri tutarlılığını korumak için `MySqlTransaction` kullanımı.
* **Gelişmiş Raporlama:** MDI ana form yapısı üzerinde anlık istatistikler ve JOIN sorgularıyla hesaplanmış dinamik gösterge paneli (Dashboard).
* **Hata Yönetimi:** Kapsamlı `try-catch` blokları ve donanımsal veri giriş kontrolleri.
