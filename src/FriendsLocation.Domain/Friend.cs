using FriendsLocation.Domain.VO;
using System;

namespace FriendsLocation.Domain
{
    public class Friend : IEquatable<Friend>
    {

        public int Id { get; private set; }

        public string Name { get; private set; }

        public Location Location { get; private set; }

        public Friend(int id, string name, Location location)
        {
            Id = id;
            Name = name;
            Location = location;
        }

        public bool Equals(Friend other)
        {
            return other != null && other.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Friend);
        }
    }
}
