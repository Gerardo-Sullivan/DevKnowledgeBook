using Google.Cloud.Firestore;
using IBM.WatsonDeveloperCloud.NaturalLanguageUnderstanding.v1.Model;

namespace Domain.Models.Firestore
{
    [FirestoreData]
    public class Keyword
    {
        public const string COLLECTION_PATH = "keywords";

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
