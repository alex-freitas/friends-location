using FriendsLocation.Domain;
using FriendsLocation.Domain.VO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FriendsLocation.App
{
    public class FriendsLocationService 
    {

        public Dictionary<Friend, List<Friend>> OrderFriendsLocationProximity(List<Friend> friends)
        {
            if (friends.Count <= 3)
            {
                throw new ArgumentException("Go out and make some friends.", "friends");        
            }

            var friendsDictionary = new Dictionary<Friend, List<Friend>>();

            foreach (var friend in friends)
            {
                var nearestFriends = OrderFriendsLocationProximityByFriend(friends, friend);

                friendsDictionary.Add(friend, nearestFriends);
            }

            return friendsDictionary;
        }


        public List<Friend> OrderFriendsLocationProximityByFriend(List<Friend> friends, Friend friend)
        {
            var nearestFriends = friends.Where(f => f.Location != friend.Location).
                           OrderBy(f => CalculateDistance(friend.Location, f.Location))
                           .Take(3)
                           .ToList();

            return nearestFriends;
        }

        /*Based on https://stackoverflow.com/questions/9113780/fast-algorithm-to-find-the-x-closest-points-to-a-given-point-on-a-plane*/
        private double CalculateDistance(Location source, Location target)
        {
            return Math.Pow(target.Longitude - source.Longitude, 2) + Math.Pow(target.Latitude - source.Latitude, 2);
        }
    }
}
