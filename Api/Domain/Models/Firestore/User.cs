using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;

namespace Domain.Models.Firestore
{
    [FirestoreData]
    public class User
    {
        public const string COLLECTION_PATH = "users";

        [FirestoreDocumentId]
        public string Id { get; private set; }

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
