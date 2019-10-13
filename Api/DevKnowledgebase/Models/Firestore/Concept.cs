using Google.Cloud.Firestore;
using IBM.WatsonDeveloperCloud.NaturalLanguageUnderstanding.v1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Firestore
{
    [FirestoreData]
    public class Concept
    {
        public const string COLLECTIONPATH = "concepts";

        [FirestoreDocumentId]
        public string Id { get; private set; }

        [FirestoreProperty("text")]
        public string Text { get; set; }

        [FirestoreProperty("revelence")]
        public double? Relevance { get; set; }

        [FirestoreProperty("dbpediaResource")]
        public string DbpediaResource { get; set; }

        public Concept()
        {
        }

        public Concept(ConceptsResult conceptsResult)
        {
            Text = conceptsResult.Text;
            Relevance = conceptsResult.Relevance;
            DbpediaResource = conceptsResult.DbpediaResource;
        }
    }
}