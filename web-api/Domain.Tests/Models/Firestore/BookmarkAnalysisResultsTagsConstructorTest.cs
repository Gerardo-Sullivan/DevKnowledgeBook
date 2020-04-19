using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Domain.Tests.Models.Firestore
{
    [TestClass]
    public class BookmarkAnalysisResultsTagsConstructorTest : BookmarkAnalysisResultsConstructorTest
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
