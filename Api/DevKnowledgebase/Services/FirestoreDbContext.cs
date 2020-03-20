using Domain.Models.Firestore;
using Google.Cloud.Firestore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiContracts;

namespace Api.Services
{
    public interface IFirestoreDbContext
    {
        Task<Bookmark> GetBookmarkFromUrlAsync(string url);
        Task<Bookmark> GetBookmarkAsync(string id);
        Task<List<Bookmark>> GetBookmarksAsync(GetBookmarksRequest request);
        Task<bool> HasBookmarkAsync(string url);
        Task<Bookmark> AddBookmarkAsync(Bookmark bookmark);
    }

    public class FirestoreDbContext : IFirestoreDbContext
    {
        private readonly FirestoreDb _db;
        private readonly CollectionReference _bookmarksCollection;
        private readonly ILogger<FirestoreDbContext> _logger;

        public FirestoreDbContext(
            FirestoreDb db,
            ILogger<FirestoreDbContext> logger)
        {
            _db = db;
            _bookmarksCollection = _db.Collection(Bookmark.COLLECTION_PATH);
            _logger = logger;
        }

        /// <summary>
        /// Returns the first <see cref="Bookmark"/> with the matching url property.
        ///
        /// Returns <see cref="null"/> if no <see cref="Bookmark"/> with a matching url property was found.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<Bookmark> GetBookmarkFromUrlAsync(string url)
        {
            _logger.LogDebug($"Searching Bookmarks for url equal to '{url}'.");
            Query query = _bookmarksCollection.WhereEqualTo("url", url); //TODO: change "url" to use reflection
            QuerySnapshot querySnapshot = await query.GetSnapshotAsync();

            if (querySnapshot.Documents.Any())
            {
                _logger.LogDebug($"Bookmark found with url equal to '{url}'.");
                var bookmarkDocument = querySnapshot.First();
                var bookmark = bookmarkDocument.ConvertTo<Bookmark>();
                bookmark.Path = bookmarkDocument.Reference.Path;

                return bookmark;
            }
            else
            {
                _logger.LogInformation($"No Boomark found with url equal to '{url}'");
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
            _logger.LogDebug($"Searching for Bookmark with id '{id}'.");

            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException($"Bookmark id with value '{id}' is invalid.");
            }

            DocumentReference bookmarkReference = _bookmarksCollection.Document(id);
            DocumentSnapshot bookmarkSnapshot = await bookmarkReference.GetSnapshotAsync();

            if (bookmarkSnapshot.Exists)
            {
                _logger.LogDebug($"Bookmark found with id '{id}'.");
                return bookmarkSnapshot.ConvertTo<Bookmark>();
            }
            else
            {
                _logger.LogInformation($"No Bookmark found with id '{id}'.");
                return null;
            }
        }

        /// <summary>
        /// Returns all Bookmarks.
        /// </summary>
        /// <remarks>
        /// Returns an empty list if no bookmarks exists.
        /// </remarks>
        /// <returns></returns>
        public async Task<List<Bookmark>> GetBookmarksAsync(GetBookmarksRequest request)
        {
            //TODO: change query to handle request

            _logger.LogDebug("Getting Bookmarks from firestore.");
            List<Bookmark> bookmarks = new List<Bookmark>();
            QuerySnapshot bookmarksSnapshot = await _bookmarksCollection.GetSnapshotAsync();

            foreach (var bookmarkSnapshot in bookmarksSnapshot.Documents)
            {
                bookmarks.Add(bookmarkSnapshot.ConvertTo<Bookmark>());
            }

            _logger.LogInformation($"{bookmarks.Count} Boomarks in firestore.");

            return bookmarks;
        }

        /// <summary>
        /// Returns <see cref="true"/> if a Bookmark was found with the matching url property.
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
        /// Adds a Bookmark to the firestore database.
        /// </summary>
        /// <param name="bookmark"></param>
        /// <returns></returns>
        public async Task<Bookmark> AddBookmarkAsync(Bookmark bookmark)
        {
            DocumentReference bookmarkDocument = await _bookmarksCollection.AddAsync(bookmark);
            bookmark.AddDocumentReference(bookmarkDocument);

            return bookmark;
        }
    }
}
