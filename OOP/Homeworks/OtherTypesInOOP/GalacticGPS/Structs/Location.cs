using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalacticGPS.Enums;

namespace GalacticGPS.Structs
{
    struct Location
    {
        private double latitude;
        private double longitude;

        public Location(double latitude, double longitude, Planet planet)
            : this()
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Planet = planet;
        }

        public double Latitude
        {
            get
            {
                return this.latitude;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Latitude must be greater than 0.");
                }
                this.latitude = value;
            }
        }
        public double Longitude
        {
            get
            {
                return this.longitude;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Longitude must be greater than 0.");
                }
                this.longitude = value;
            }
        }
        public Planet Planet { get; private set; }

        public override string ToString()
        {
            return String.Format("{0}, {1} - {2}", this.latitude, this.longitude, this.Planet);
        }
    }
}
