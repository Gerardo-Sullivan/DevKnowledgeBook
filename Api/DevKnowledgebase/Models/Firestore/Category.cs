using Google.Cloud.Firestore;
using IBM.WatsonDeveloperCloud.NaturalLanguageUnderstanding.v1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Firestore
{
    [FirestoreData]
    public class Category
    {
        public const string COLLECTIONPATH = "categories";

        [FirestoreDocumentId]
        public string Id { get; private set; } // FirestoreDocumentId must be placed on a property of type string or DocumentReference https://googleapis.github.io/google-cloud-dotnet/docs/Google.Cloud.Firestore/datamodel.html#mapping-with-attributed-classes

        [FirestoreProperty("label")]
        public string Label { get; set; }

        [FirestoreProperty("score")]
        public double? Score { get; set; }

        public Category()
        {
        }

        public Category(CategoriesResult categoryResult)
        {
            Label = categoryResult.Label;
            Score = categoryResult.Score;
        }
    }
}