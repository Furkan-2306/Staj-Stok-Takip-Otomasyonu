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

## Proje Görüntüleri

Giriş:

<img width="434" height="361" alt="image" src="https://github.com/user-attachments/assets/556bb77e-9200-4a73-8676-db289cab63d0" />

Kayıt Ol

<img width="434" height="372" alt="image" src="https://github.com/user-attachments/assets/41cbfa61-26e5-4824-a8ab-d2b22aa96dea" />

Ana Menü:

<img width="174" height="100" alt="image" src="https://github.com/user-attachments/assets/49861065-7e65-4479-8016-2bd87fde7bd2" />
<img width="144" height="51" alt="image" src="https://github.com/user-attachments/assets/eddbb24e-5c10-4ff4-8467-19e05d662b1b" />
<img width="1183" height="660" alt="image" src="https://github.com/user-attachments/assets/51f9a97b-4be8-4e01-87a9-40739ebf01b3" />

Dashboard:

<img width="948" height="586" alt="image" src="https://github.com/user-attachments/assets/bdf29afc-8799-4b0b-905a-555cf9a351d2" />

Cari Yönetim Paneli:

<img width="894" height="535" alt="image" src="https://github.com/user-attachments/assets/9e5431e6-c277-459a-8616-07a6d225a012" />

Stok Yönetim Paneli:

<img width="951" height="586" alt="image" src="https://github.com/user-attachments/assets/0a12d655-25f1-41ea-bf0e-95929f6b7d32" />

Stok Haraketleri:

<img width="946" height="587" alt="image" src="https://github.com/user-attachments/assets/170c4da9-1119-4e5e-b562-1afa7655ca15" />



