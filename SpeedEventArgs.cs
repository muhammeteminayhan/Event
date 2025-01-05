using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuhammetEminAyhan_203301137
{
    // SpeedEventArgs sınıfı: Olay parametreleri (current speed, latitude, longitude)
    public class SpeedEventArgs : EventArgs
    {
        public byte CurrentSpeed { get; }
        public double Latitude { get; }
        public double Longitude { get; }
        public DateTime EventTime { get; }

        // Constructor ile tüm parametreler alınır
        public SpeedEventArgs(byte currentSpeed, double latitude, double longitude, DateTime eventTime)
        {
            CurrentSpeed = currentSpeed;
            Latitude = latitude;
            Longitude = longitude;
            EventTime = eventTime;
        }
    }


}
