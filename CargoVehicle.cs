using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuhammetEminAyhan_203301137
{
    // Delegate tanımlaması: Hız limiti aşılması olayını temsil edecek metod imzası
    public delegate void SpeedHandler(object sender, SpeedEventArgs e);

    public class CargoVehicle
    {
        public string Plaka { get; set; }
        public string Marka { get; set; }
        public double Enlem { get; }
        public double Boylam { get; }
        private byte speed;

        // Olay tanımlaması
        public event SpeedHandler SpeedExceeded;

        // Constructor
        public CargoVehicle(string plaka, string marka, double enlem, double boylam)
        {
            Plaka = plaka;
            Marka = marka;
            Enlem = enlem;
            Boylam = boylam;
        }

        public byte Speed
        {
            get { return speed; }
            set
            {
                speed = value;
                // Hız limiti 120'yi geçtiyse olay tetiklenir
                if (speed > 120)
                {
                    OnSpeedExceeded();
                }
            }
        }

        // Hız aşıldığında tetiklenecek olay metodunu çağıran metod
        protected virtual void OnSpeedExceeded()
        {
            SpeedExceeded?.Invoke(this, new SpeedEventArgs(speed, Enlem, Boylam, DateTime.Now));
        }
    }



}
