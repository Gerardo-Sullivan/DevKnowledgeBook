using Google.Cloud.Firestore;
using IBM.WatsonDeveloperCloud.NaturalLanguageUnderstanding.v1.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Firestore
{
    [FirestoreData]
    public class Bookmark
    {
        public const string COLLECTIONPATH = "bookmarks";

        [FirestoreDocumentId]
        public string Id { get; set; } // FirestoreDocumentId must be placed on a property of type string or DocumentReference https://googleapis.github.io/google-cloud-dotnet/docs/Google.Cloud.Firestore/datamodel.html#mapping-with-attributed-classes

        [JsonIgnore]
        public string Path { get; set; }

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

        //TODO: add json serializer
        [FirestoreProperty("createdTime")]
        public Timestamp CreatedTime { get; set; }

        //public List<Category> CategoriesCollection { get; set; }

        //public List<Concept> ConceptsCollection { get; set; }

        //public List<Keyword> KeywordsCollection { get; set; }

        public Bookmark()
        {
            //CategoriesCollection = new List<Category>();
            //ConceptsCollection = new List<Concept>();
            //KeywordsCollection = new List<Keyword>();
        }

        public Bookmark(AnalysisResults analysisResults) : this()
        {
            Title = analysisResults.Metadata.Title;
            Url = analysisResults.RetrievedUrl;
            Categories = analysisResults.Categories.Select(c => c.Label).ToList();
            Concepts = analysisResults.Concepts.Select(c => c.Text).ToList();
            Keywords = analysisResults.Keywords.Select(k => k.Text).ToList();
            Tags = new List<string>();
            CreatedTime = Timestamp.FromDateTime(DateTime.UtcNow);
            //CategoriesCollection.AddRange(analysisResults.Categories.Select(c => new Category(c)));
            //ConceptsCollection.AddRange(analysisResults.Concepts.Select(c => new Concept(c)));
            //KeywordsCollection.AddRange(analysisResults.Keywords.Select(k => new Keyword(k)));
        }

        public Bookmark(AnalysisResults analysisResults, List<string> tags) : this(analysisResults)
        {
            if (tags != null)
            {
                Tags = tags;
            }
        }
    }
}