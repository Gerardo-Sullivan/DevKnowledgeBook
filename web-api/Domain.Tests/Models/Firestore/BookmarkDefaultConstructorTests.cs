using Domain.Models.Firestore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Tests.Models.Firestore
{
    [TestClass]
    public class BookmarkDefaultConstructorTests
    {
        [TestMethod]
        public void CategoriesNotNullTest()
        {
            var bookmark = new Bookmark();

            Assert.IsNotNull(bookmark.Categories);
        }

        [TestMethod]
        public void ConceptsNotNullTest()
        {
            var bookmark = new Bookmark();

            Assert.IsNotNull(bookmark.Concepts);
        }

        [TestMethod]
        public void KeywordsNotNullTest()
        {
            var bookmark = new Bookmark();

            Assert.IsNotNull(bookmark.Keywords);
        }

        [TestMethod]
        public void TagsNotNullTest()
        {
            var bookmark = new Bookmark();

            Assert.IsNotNull(bookmark.Tags);
        }

        [TestMethod]
        public void CreatedTimeNotNullTest()
        {
            var bookmark = new Bookmark();

            Assert.IsNotNull(bookmark.CreatedTime);
        }
    }
}
