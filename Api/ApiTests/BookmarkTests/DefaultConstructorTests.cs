using Api.Models.Firestore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTests.BookmarkTests
{
    [TestClass]
    public class DefaultConstructorTests
    {
        [TestMethod]
        public void CategoriesTest()
        {
            var bookmark = new Bookmark();

            Assert.IsNotNull(bookmark.Categories);
        }

        [TestMethod]
        public void ConceptsTest()
        {
            var bookmark = new Bookmark();

            Assert.IsNotNull(bookmark.Concepts);
        }

        [TestMethod]
        public void KeywordsTest()
        {
            var bookmark = new Bookmark();

            Assert.IsNotNull(bookmark.Keywords);
        }

        [TestMethod]
        public void TagsTest()
        {
            var bookmark = new Bookmark();

            Assert.IsNotNull(bookmark.Tags);
        }

        [TestMethod]
        public void CreatedTimeTest()
        {
            var bookmark = new Bookmark();

            Assert.IsNotNull(bookmark.CreatedTime);
        }
    }
}