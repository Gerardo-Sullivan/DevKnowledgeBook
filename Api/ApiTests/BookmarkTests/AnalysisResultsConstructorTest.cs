using Api.Models.Firestore;
using IBM.WatsonDeveloperCloud.NaturalLanguageUnderstanding.v1.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTests.BookmarkTests
{
    [TestClass]
    public class AnalysisResultsConstructorTest : AnalysisResultsConstructorTestBase
    {
        [TestMethod]
        public void CategoriesNotNullTest()
        {
            var bookmark = new Bookmark(_analysisResults);

            Assert.IsNotNull(bookmark.Categories);
        }

        [TestMethod]
        public void ConceptsNotNullTest()
        {
            var bookmark = new Bookmark(_analysisResults);

            Assert.IsNotNull(bookmark.Concepts);
        }

        [TestMethod]
        public void KeywordsNotNullTest()
        {
            var bookmark = new Bookmark(_analysisResults);

            Assert.IsNotNull(bookmark.Keywords);
        }

        [TestMethod]
        public void TagsNotNullTest()
        {
            var bookmark = new Bookmark(_analysisResults);

            Assert.IsNotNull(bookmark.Tags);
        }

        [TestMethod]
        public void CreatedTimeNotNullTest()
        {
            var bookmark = new Bookmark(_analysisResults);

            Assert.IsNotNull(bookmark.CreatedTime);
        }

        [TestMethod]
        public void CategoriesTest()
        {
            _analysisResults.Categories.Add(new CategoriesResult { Label = "label" });
            var bookmark = new Bookmark(_analysisResults);

            Assert.AreEqual(1, bookmark.Categories.Count);
        }

        [TestMethod]
        public void ConceptsTest()
        {
            _analysisResults.Concepts.Add(new ConceptsResult { Text = "text" });
            var bookmark = new Bookmark(_analysisResults);

            Assert.AreEqual(1, bookmark.Concepts.Count);
        }

        [TestMethod]
        public void KeywordsTest()
        {
            _analysisResults.Keywords.Add(new KeywordsResult { Text = "text" });
            var bookmark = new Bookmark(_analysisResults);

            Assert.AreEqual(1, bookmark.Keywords.Count);
        }
    }
}