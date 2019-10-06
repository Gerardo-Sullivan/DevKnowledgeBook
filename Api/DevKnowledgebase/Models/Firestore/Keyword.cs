using Google.Cloud.Firestore;
using IBM.WatsonDeveloperCloud.NaturalLanguageUnderstanding.v1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Firestore
{
    [FirestoreData]
    public class Keyword
    {
        public const string COLLECTIONPATH = "keywords";

        [FirestoreDocumentId]
        public string Id { get; private set; }

        [FirestoreProperty("text")]
        public string Text { get; set; }

        [FirestoreProperty("count")]
        public long? Count { get; set; }

        [FirestoreProperty("relevance")]
        public double? Relevance { get; set; }

        public Keyword()
        {
        }

        public Keyword(KeywordsResult keywordsResult)
        {
            Text = keywordsResult.Text;
            Count = keywordsResult.Count;
            Relevance = keywordsResult.Relevance;
        }
    }
}