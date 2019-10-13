using Api.Models.Firestore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTests.BookmarkTests
{
    [TestClass]
    public class AnalysisResultsTagsConstructorTest : AnalysisResultsConstructorTest
    {
        private readonly List<string> _tags = new List<string> { "tag" };

        [TestMethod]
        public void TagsTest()
        {
            var bookmarks = new Bookmark(_analysisResults, _tags);

            Assert.AreEqual(1, bookmarks.Tags.Count);
        }
    }
}