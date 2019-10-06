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

        private Task AddCategory(CollectionReference categoriesCollection, Category category)
        {
            return categoriesCollection.AddAsync(category);
        }

        private Task AddConcept(CollectionReference conceptsCollection, Concept concept)
        {
            return conceptsCollection.AddAsync(concept);
        }

        private Task AddConcept(CollectionReference keywordCollection, Keyword keyword)
        {
            return keywordCollection.AddAsync(keyword);
        }

        private async Task AddCategories(DocumentReference bookmarkDocument, Bookmark bookmark)
        {
            CollectionReference categoriesReference = bookmarkDocument.Collection(Category.COLLECTIONPATH);

            foreach (Category category in bookmark.CategoriesCollection)
            {
                AddCategory(categoriesReference, category); //TODO: complete
            }

            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the first <see cref="Bookmark"/> with the matching url property
        ///
        /// Returns <see cref="null"/> if no <see cref="Bookmark"/> has a matching url property
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<Bookmark> GetBookmarkAsync(string url)
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

        public IEnumerable<Bookmark> GetBookmarks()
        {
            IAsyncEnumerable<DocumentReference> bookmarkDocuments = _bookmarksCollection.ListDocumentsAsync();
            IAsyncEnumerable<Bookmark> bookmarks = bookmarkDocuments.Cast<Bookmark>();

            return bookmarks.ToEnumerable();
        }

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

        public async Task AddBookmarkAsync(Bookmark bookmark)
        {
            DocumentReference bookmarkDocument = await _bookmarksCollection.AddAsync(bookmark);

            //TODO: need to save the associated categories, concepts, and keywords collection for the newly added document

            throw new NotImplementedException();
        }
    }

    public interface IFirestoreDbService
    {
        Task<Bookmark> GetBookmarkAsync(string url);

        IEnumerable<Bookmark> GetBookmarks();

        Task<bool> HasBookmarkAsync(string url);

        Task<Bookmark> AddBookmarkAsync(Bookmark bookmark);
    }
}