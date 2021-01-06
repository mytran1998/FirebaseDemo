using FirebaseCore.Entity;
using FirebaseCore.Utils;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirebaseCore
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + DbUtils.DB_JSON_NAME;
            Environment.SetEnvironmentVariable( DbUtils.GOOGLE_APPLICATION_CREDENTIALS, path );

            Console.WriteLine("---Get list of users: ");
            var lstUser = await FirestoreDB.GetUsersAsync();
            lstUser.ForEach( (user) => Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Token: {user.AccessToken}") );

            Console.WriteLine("---Starting insert user: ");
            var userInsert = new User("00001", "Demo insert", "EAAABBBBCCCC");

            var result = await FirestoreDB.AddUserAsync( userInsert );

            if ( result.UpdateTime != null )
                Console.WriteLine("INSERT SUCCESS");
            else
                Console.WriteLine("INSERT FAILS");

            Console.ReadKey();
        }
    }
}
