using FriendsLocation.Domain;
using System.Collections.Generic;

namespace FriendsLocation.Infra.Data
{
    public interface IFriendsRepository
    {
        IEnumerable<Friend> GetAll();
        Friend Get(int id);
    }
}