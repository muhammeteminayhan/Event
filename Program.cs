
using MuhammetEminAyhan_203301137;
using System;

namespace MuhammetEminAyhan_203301137
{
    // Program sınıfı
    class Program
    {
        static void Main(string[] args)
        {
            // Araba nesneleri
            CargoVehicle kargo_aracı1 = new CargoVehicle("42SU1975", "Mercedes", 0.0, 456579.7883);
            CargoVehicle kargo_aracı2 = new CargoVehicle("06TR1923", "Mercedes", 0.0, 456579.7883);

            // Hız limitini aşınca tetiklenecek event'e bağlama
            kargo_aracı1.SpeedExceeded += Kargo_aracı_SpeedExceeded;
            kargo_aracı2.SpeedExceeded += Kargo_aracı_SpeedExceeded;

            // Hız 5'er 5'er artacak
            for (byte i = 80; i < 130; i += 5)
            {
                kargo_aracı1.Speed = i;
                kargo_aracı2.Speed = (byte)(i + 8);  // Farklı hız artışı
                Console.WriteLine(kargo_aracı1.Plaka + " plakalı aracın hızı = " + kargo_aracı1.Speed);
                Console.WriteLine(kargo_aracı2.Plaka + " plakalı aracın hızı = " + kargo_aracı2.Speed);
                Thread.Sleep(1000); // 1 saniye bekle
            }
        }

        // Event handler
        private static void Kargo_aracı_SpeedExceeded(object sender, SpeedEventArgs e)
        {
            CargoVehicle vehicle = sender as CargoVehicle;

            // Hız limitini aşan araç hakkında bilgi
            Console.WriteLine($"{vehicle.Plaka} plakalı {vehicle.Marka} marka kargo aracı hız limitini aştı.");
            Console.WriteLine($"Aracın hız limitini aştığı konum : {e.Latitude}° enlem ve {e.Longitude}° boylam");
            Console.WriteLine($"Aracın şu anki konumu : {e.Latitude}° enlem ve {e.Longitude + 250}° boylam"); // Boylam biraz değiştiriyoruz
            Console.WriteLine($"{e.EventTime:dd.MM.yyyy HH:mm:ss} anında aracın hızı = {e.CurrentSpeed} olarak ölçüldü.");
        }
    }

}
