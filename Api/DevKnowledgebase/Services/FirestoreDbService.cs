using Api.Models.Firestore;
using Google.Cloud.Firestore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{
    public class FirestoreDbService : IFirestoreDbService
    {
        private readonly FirestoreDb _db;
        private readonly CollectionReference _bookmarksCollection;

        public FirestoreDbService(FirestoreDb db)
        {
            _db = db;
            _bookmarksCollection = _db.Collection(Bookmark.COLLECTIONPATH);
        }

        //private Task AddCategory(CollectionReference categoriesCollection, Category category)
        //{
        //    return categoriesCollection.AddAsync(category);
        //}

        //private Task AddConcept(CollectionReference conceptsCollection, Concept concept)
        //{
        //    return conceptsCollection.AddAsync(concept);
        //}

        //private Task AddConcept(CollectionReference keywordCollection, Keyword keyword)
        //{
        //    return keywordCollection.AddAsync(keyword);
        //}

        //private async Task AddCategories(DocumentReference bookmarkDocument, Bookmark bookmark)
        //{
        //    CollectionReference categoriesReference = bookmarkDocument.Collection(Category.COLLECTIONPATH);

        //    foreach (Category category in bookmark.CategoriesCollection)
        //    {
        //        AddCategory(categoriesReference, category); //TODO: complete
        //    }

        //    throw new NotImplementedException();
        //}

        /// <summary>
        /// Returns the first <see cref="Bookmark"/> with the matching url property
        ///
        /// Returns <see cref="null"/> if no <see cref="Bookmark"/> with a matching url property was found
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<Bookmark> GetBookmarkFromUrlAsync(string url)
        {
            Query query = _bookmarksCollection.WhereEqualTo("url", url); //TODO: change "url" to use reflection
            QuerySnapshot querySnapshot = await query.GetSnapshotAsync();

            if (querySnapshot.Documents.Any())
            {
                var bookmarkDocument = querySnapshot.First();
                var bookmark = bookmarkDocument.ConvertTo<Bookmark>();
                bookmark.Path = bookmarkDocument.Reference.Path;

                return bookmark;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns a <see cref="bookmark"/> matching a specific id.
        ///
        /// Returns null if no bookmark was found.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Bookmark> GetBookmarkAsync(string id)
        {
            DocumentReference bookmarkReference = _bookmarksCollection.Document(id);
            DocumentSnapshot bookmarkSnapshot = await bookmarkReference.GetSnapshotAsync();

            if (bookmarkSnapshot.Exists)
            {
                return bookmarkSnapshot.ConvertTo<Bookmark>();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns all Bookmarks
        /// </summary>
        /// <returns></returns>
        public async Task<List<Bookmark>> GetBookmarksAsync()
        {
            List<Bookmark> bookmarks = new List<Bookmark>();
            QuerySnapshot bookmarksSnapshot = await _bookmarksCollection.GetSnapshotAsync();

            foreach (var bookmarkSnapshot in bookmarksSnapshot.Documents)
            {
                bookmarks.Add(bookmarkSnapshot.ConvertTo<Bookmark>());
            }

            return bookmarks;
        }

        /// <summary>
        /// Returns <see cref="true"/> if a Bookmark was found with the matching url property
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<bool> HasBookmarkAsync(string url)
        {
            Query query = _bookmarksCollection.WhereEqualTo("url", url); //TODO: change "url" to use reflection
            QuerySnapshot querySnapshot = await query.GetSnapshotAsync();

            if (querySnapshot.Documents.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Adds a Bookmark to the database
        /// </summary>
        /// <param name="bookmark"></param>
        /// <returns></returns>
        public async Task<Bookmark> AddBookmarkAsync(Bookmark bookmark)
        {
            DocumentReference bookmarkDocument = await _bookmarksCollection.AddAsync(bookmark);

            //TODO: set the boomarks id

            throw new NotImplementedException();
        }
    }

    public interface IFirestoreDbService
    {
        Task<Bookmark> GetBookmarkFromUrlAsync(string url);

        Task<Bookmark> GetBookmarkAsync(string id);

        Task<List<Bookmark>> GetBookmarksAsync();

        Task<bool> HasBookmarkAsync(string url);

        Task<Bookmark> AddBookmarkAsync(Bookmark bookmark);
    }
}