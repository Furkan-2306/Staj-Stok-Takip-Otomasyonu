using System;
using System.Windows.Forms;
using StokTakipOtomasyonu.DataAccess;

namespace StokTakipOtomasyonu
{
    static class Program
    {
        /// <summary>
        /// Uygulamanın ana giriş noktası.
        /// Sistem açılışında veritabanı yoksa otomatik olarak oluşturulur (Auto-Migration).
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // Auto-Migration: Veritabanı ve tablolar yoksa otomatik oluştur
                DatabaseInitializer.VeritabaniniKontrolEtVeKur();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Veritabanı kurulumu sırasında hata oluştu. XAMPP panelinden MySQL servisinin çalıştığından emin olun.\n\nHata: " + ex.Message,
                    "Kritik Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Login ekranını başlat
            Application.Run(new FrmLogin());
        }
    }
}
