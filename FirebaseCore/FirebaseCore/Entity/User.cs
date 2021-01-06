using System;
using System.Collections.Generic;
using System.Text;

namespace FirebaseCore.Entity
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string AccessToken { get; set; }

        public User(string id, string name, string accessToken)
        {
            Id = id;
            Name = name;
            AccessToken = accessToken;
        }
    }
}
