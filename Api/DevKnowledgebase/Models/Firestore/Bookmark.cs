using Google.Cloud.Firestore;
using IBM.WatsonDeveloperCloud.NaturalLanguageUnderstanding.v1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Firestore
{
    [FirestoreData]
    public class Bookmark
    {
        [FirestoreDocumentId]
        public string Id { get; set; } // FirestoreDocumentId must be placed on a property of type string or DocumentReference https://googleapis.github.io/google-cloud-dotnet/docs/Google.Cloud.Firestore/datamodel.html#mapping-with-attributed-classes

        [FirestoreProperty("title")]
        public string Title { get; set; }

        [FirestoreProperty("url")]
        public string Url { get; set; }

        [FirestoreProperty("categories")]
        public List<string> Categories { get; set; }

        [FirestoreProperty("concepts")]
        public List<string> Concepts { get; set; }

        [FirestoreProperty("keywords")]
        public List<string> Keywords { get; set; }

        [FirestoreProperty("tags")]
        public List<string> Tags { get; set; }

        [FirestoreProperty("createdTime")]
        public Timestamp CreatedTime { get; set; }

        public Bookmark(AnalysisResults analysisResults)
        {
            Title = analysisResults.Metadata.Title;
            Url = analysisResults.RetrievedUrl;
            Categories = analysisResults.Categories.Select(c => c.Label).ToList();
            Concepts = analysisResults.Concepts.Select(c => c.Text).ToList();
            Keywords = analysisResults.Keywords.Select(k => k.Text).ToList();
            Tags = new List<string>();
            CreatedTime = Timestamp.FromDateTime(DateTime.UtcNow);
        }
    }
}