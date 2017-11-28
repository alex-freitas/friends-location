namespace FriendsLocation.Domain.VO
{
    public class Location
    {
        public double Latitude { get;  }
        public double Longitude { get;  }

        public Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }        

        public static bool operator !=(Location location1, Location location2)
        {
            return (location1.Latitude != location2.Latitude) || (location1.Longitude != location2.Longitude); 
        }

        public static bool operator ==(Location location1, Location location2)
        {
            return location1.Latitude == location2.Latitude && location1.Longitude == location2.Longitude;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;

            var location = obj as Location;

            if (ReferenceEquals(null, location)) return false;

            return this == location;
        }

        public override int GetHashCode()
        {
            return (Latitude + Longitude).GetHashCode();
        }
    }
}