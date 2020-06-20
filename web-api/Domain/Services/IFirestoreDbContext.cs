using Domain.Models.Firestore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Contracts.Bookmarks;

namespace Domain.Services
{
    /// <summary>
    /// Firestore db context.
    /// </summary>
    /// <remarks>
    /// Google Firebase No SQL database https://firebase.google.com/docs/firestore
    /// </remarks>
    public interface IFirestoreDbContext
    {
        /// <summary>
        /// Returns the first <see cref="Bookmark"/> with the matching url property.
        ///
        /// Returns <see langword="null"/> if no <see cref="Bookmark"/> with a matching url property was found.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        Task<Bookmark> GetBookmarkFromUrlAsync(string url);

        /// <summary>
        /// Returns a <see cref="bookmark"/> matching a specific id.
        ///
        /// Returns null if no bookmark was found.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Bookmark> GetBookmarkAsync(string id);

        /// <summary>
        /// Returns all <see cref="Bookmark"/>s.
        /// </summary>
        /// <remarks>
        /// Returns an empty list if no bookmarks exists.
        /// </remarks>
        /// <returns></returns>
        Task<List<Bookmark>> GetBookmarksAsync();

        /// <summary>
        /// Returns all <see cref="Bookmark"/>s that result from the given <see cref="GetBookmarksRequest"/>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<List<Bookmark>> GetBookmarksAsync(GetBookmarksRequest request);

        /// <summary>
        /// Returns <see cref="true"/> if a <see cref="Bookmark"/> was found with the matching url property.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        Task<bool> HasBookmarkAsync(string url);

        /// <summary>
        /// Adds a <see cref="Bookmark"/> to the firestore database.
        /// </summary>
        /// <param name="bookmark"></param>
        /// <returns></returns>
        Task<Bookmark> AddBookmarkAsync(Bookmark bookmark);
    }
}
