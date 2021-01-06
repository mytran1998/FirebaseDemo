using FirebaseCore.Entity;
using FirebaseCore.Utils;
using Google.Cloud.Firestore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseCore
{
    public static class FirestoreDB
    {
        private static FirestoreDb db = FirestoreDb.Create( DbUtils.DB_NAME );

        public static async Task<List<User>> GetUsersAsync()
        {
            var lstUser = new List<User>();

            CollectionReference usersRef = db.Collection( DbUtils.FS_COLLECTION_DATAS );
            QuerySnapshot snapshot = await usersRef.GetSnapshotAsync();
            foreach ( DocumentSnapshot document in snapshot.Documents )
            {
                Dictionary<string, object> documentDictionary = document.ToDictionary();
                var id = documentDictionary[UserUtils.USER_ID].ToString();
                var name = documentDictionary[UserUtils.USER_NAME].ToString();
                var access_token = documentDictionary[UserUtils.USER_ACCESSTOKEN].ToString();
                lstUser.Add( new User( id, name, access_token ) );
            }
            return lstUser;
        }

        public static async Task<WriteResult> AddUserAsync( User user )
        {
            DocumentReference docRef = db.Collection( DbUtils.FS_COLLECTION_DATAS ).Document( DbUtils.FS_DOCUMENT );
            var userDic = JObject.FromObject( user ).ToObject<Dictionary<string, object>>();
            return await docRef.SetAsync(userDic);
        }
    }
}
