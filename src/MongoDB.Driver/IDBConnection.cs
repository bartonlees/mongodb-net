//COPYRIGHT

using System;
using System.Security;

namespace MongoDB.Driver
{
    /// <summary>
    /// Represents a direct, physical database connection
    /// </summary>
    public interface IDBConnection : IDisposable
    {
        /// <summary>
        /// Gets a value indicating whether this instance can request.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance can request; otherwise, <c>false</c>.
        /// </value>
        bool CanRequest { get; }
        /// <summary>
        /// Says the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        void Say(IDBRequest msg);
        /// <summary>
        /// Calls the specified MSG.
        /// </summary>
        /// <typeparam name="TDoc">The type of the doc.</typeparam>
        /// <param name="msg">The MSG.</param>
        /// <returns></returns>
        IDBResponse<TDoc> Call<TDoc>(IDBRequest msg) where TDoc : class, IDocument;
        /// <summary>
        /// Tries the authenticate.
        /// </summary>
        /// <param name="cmdCollection">The CMD collection.</param>
        /// <param name="username">The username.</param>
        /// <param name="usrPassHash">The usr pass hash.</param>
        /// <returns></returns>
        bool TryAuthenticate(IDBCollection cmdCollection, string username, SecureString usrPassHash);
    }
}