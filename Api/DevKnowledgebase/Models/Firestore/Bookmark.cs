using Google.Cloud.Firestore;
using IBM.WatsonDeveloperCloud.NaturalLanguageUnderstanding.v1.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Models.Firestore
{
    [FirestoreData]
    public class Bookmark
    {
        public const string COLLECTION_PATH = "bookmarks";

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

        public Bookmark()
        {
            Categories = new List<string>();
            Concepts = new List<string>();
            Keywords = new List<string>();
            Tags = new List<string>();
            CreatedTime = Timestamp.FromDateTime(DateTime.UtcNow);
        }

        public Bookmark(AnalysisResults analysisResults) : this()
        {
            Title = analysisResults.Metadata.Title;
            Url = analysisResults.RetrievedUrl;

            // NOTE: categories, concepts and keywords are assumed to be in order from the natural language processor
            Categories.AddRange(analysisResults.Categories.Select(c => c.Label));
            Concepts.AddRange(analysisResults.Concepts.Select(c => c.Text).ToList());
            Keywords.AddRange(analysisResults.Keywords.Select(k => k.Text).ToList());
        }

        public Bookmark(AnalysisResults analysisResults, List<string> tags) : this(analysisResults)
        {
            Tags.AddRange(tags);
        }

        /// <summary>
        /// Adds important Firestore to the <see cref="Bookmark"/>
        /// </summary>
        /// <param name="reference"></param>
        public void AddDocumentReference(DocumentReference reference)
        {
            Id = reference.Id;
            Path = reference.Path;
        }
    }
}
