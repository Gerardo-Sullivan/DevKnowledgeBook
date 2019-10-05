using Api.Models.Firestore;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Responses
{
    public class AnalyzeResponse
    {
        //TODO: add custom json serializers
        public DocumentReference Document { get; private set; }

        public Bookmark Bookmark { get; private set; }

        public AnalyzeResponse(DocumentReference document, Bookmark bookmark)
        {
            if (document is null || bookmark is null)
            {
                throw new NullReferenceException();
            }

            Document = document;
            Bookmark = bookmark;
        }
    }
}