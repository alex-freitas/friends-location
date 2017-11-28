using FriendsLocation.App;
using FriendsLocation.Domain;
using FriendsLocation.Domain.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsLocation.UI.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Informe seus amigos e suas localizacoes");
            Console.WriteLine("Ex: Superman, 1, 1;Wonder Woman, 2, 2;");

            //Ex: Superman, 1, 1;Wonder Woman, 2, 2;Batman, 3, 3;Robin, 4, 4;
            //Botão direito no icone da janela do console > editar > colar
            var txt = Console.ReadLine();

            if (txt.Trim() != "")
            {

                try
                {
                    var friends = new List<Friend>();

                    var id = 0;

                    foreach (var item in txt.Split(';'))
                    {
                        if (item.Trim() != "")
                        {
                            var friendText = item.Split(',');

                            double lat, lon;
                            double.TryParse(friendText[1].Trim(), out lat);
                            double.TryParse(friendText[1].Trim(), out lon);
                            var location = new Location(lat, lon);

                            friends.Add(new Friend(++id, friendText[0], location));
                        }
                    }

                    var service = new FriendsLocationService();

                    var friendsLocations = service.OrderFriendsLocationProximity(friends);

                    Console.WriteLine("Amigos proximos:");

                    foreach (var friendDictionary in friendsLocations)
                    {
                        PrintFriend(friendDictionary.Key, "-");

                        foreach (var friendOfFriend in friendDictionary.Value)
                        {
                            PrintFriend(friendOfFriend, "---");
                        }

                        Console.WriteLine();
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Ocorreu um Erro.");
                    Console.WriteLine("Saindo...");
                }
            }
            else
            {
                Console.WriteLine("Saindo...");
            }


            Console.WriteLine("\nContinue...");
            Console.ReadKey();
        }

        public static void PrintFriend(Friend friend, string prefix)
        {
            Console.WriteLine("{0} {1}({2},{3})", prefix,
                friend.Name,
                friend.Location.Latitude,
                friend.Location.Longitude);
        }
    }
}
