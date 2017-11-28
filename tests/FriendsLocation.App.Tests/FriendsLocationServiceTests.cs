using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using FriendsLocation.Domain;
using FriendsLocation.Domain.VO;
using FriendsLocation.App;
using System.Linq;

namespace FriendsLocation.App.Tests
{
    [TestClass]
    public class FriendsLocationServiceTests
    {

        public List<Friend> SuperFriends { get; private set; }


        public FriendsLocationServiceTests()
        {

            SuperFriends = new List<Friend>
            {
                new Friend(1, "Superman", new Location(1, 1)),
                new Friend(2, "Wonder Woman", new Location(2, 2)),
                new Friend(3, "Batman", new Location(3, 3)),
                new Friend(4, "Robin", new Location(4, 4)),
                new Friend(5, "Aquaman", new Location(5, 5)),
                new Friend(6, "Jayna (Wonder Twins)", new Location(6, 6)),
                new Friend(7, "Zan (Wonder Twins)", new Location(7, 7)),
                new Friend(8, "Gleek", new Location(8, 8)),
            };


        }

        [TestMethod]
        public void OrderFriendsLocationProximityByFriend_List3NearestFriends_Success()
        {
            var sut = new FriendsLocationService();

            var apacheChief = new Friend(9, "Apache Chief", new Location(5.5, 5.5));
            var aquaman = new Friend(5, "Aquaman", new Location(5, 5));

            var friends = sut.OrderFriendsLocationProximityByFriend(SuperFriends, apacheChief);

            Assert.AreEqual(friends.First(), aquaman);
        }


        [TestMethod]
        public void OrderFriendsLocationProximity_List3NearestFriends_Success()
        {
            var sut = new FriendsLocationService();

            var batman = new Friend(3, "Batman", new Location(3, 3));
            var robin = new Friend(4, "Robin", new Location(4, 4));
            var jayna = new Friend(6, "Jayna (Wonder Twins)", new Location(6, 6));
            var zan = new Friend(7, "Zan (Wonder Twins)", new Location(7, 7));

            var friends = sut.OrderFriendsLocationProximity(SuperFriends);

            var robinNearestFriends = friends.First(f => f.Key.Equals(robin)).Value;
            Assert.IsTrue(robinNearestFriends.First().Equals(batman));
            Assert.IsTrue(robinNearestFriends.Count == 3);

            var zanNearestFriends = friends.Where(f => f.Key.Equals(zan)).FirstOrDefault().Value;
            Assert.IsTrue(zanNearestFriends.First().Equals(jayna));
            Assert.IsTrue(zanNearestFriends.Count == 3);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void OrderFriendsLocationProximity_InvalidFriendsQuantity_ExceptionThrown()
        {
            var sut = new FriendsLocationService();

            var jimmyOlsen = new Friend(10, "Jimmy Olsen", new Location(10, 10));
            var superman = new Friend(1, "Superman", new Location(1, 1));

            var friends = sut.OrderFriendsLocationProximity(new List<Friend>() { superman });
        }

        [TestMethod]
        public void Friend_Equals_Sucess()
        {
            var f1 = new Friend(1, "John Doe", new Location(0, 0));
            var f2 = new Friend(1, "Another John Doe", new Location(0, 0));

            Assert.IsTrue(f1.Equals(f2));
        }

        [TestMethod]
        public void Friend_Equals_Fail()
        {
            var f1 = new Friend(1, "John Doe", new Location(0, 0));
            var f2 = new Friend(2, "Another John Doe", new Location(0, 0));

            Assert.IsFalse(f1.Equals(f2));
        }

        [TestMethod]
        public void Localtion_Equals_Success()
        {
            var l1 = new Location(1, 0);
            var l2 = new Location(1, 0);

            Assert.IsTrue(l1 == l2);
        }

        [TestMethod]
        public void Localtion_Equals_Fail()
        {
            var l1 = new Location(0, 0);
            var l2 = new Location(1, 0);

            Assert.IsFalse(l1 == l2);
        }

    }
}
