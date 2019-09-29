using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Firestore
{
    [FirestoreData]
    public class User
    {
        [FirestoreDocumentId]
        public string Id { get; set; }

        [FirestoreProperty("firstname")]
        public string Firstname { get; set; }

        [FirestoreProperty("lastname")]
        public string Lastname { get; set; }

        [FirestoreProperty("fullname")]
        public string Fullname { get; set; }

        [FirestoreProperty("favourites")]
        public List<string> Favourites { get; set; } //TODO: change to string or document reference

        [FirestoreProperty("createdTime")]
        public Timestamp CreatedTime { get; set; }

        public User(string firstname, string lastname)
        {
            Firstname = firstname.Trim();
            Lastname = lastname.Trim();
            Fullname = $"{Firstname} {Lastname}";
            Favourites = new List<string>();
            CreatedTime = Timestamp.FromDateTime(DateTime.UtcNow);
        }
    }
}