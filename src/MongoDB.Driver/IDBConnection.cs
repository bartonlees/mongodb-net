//COPYRIGHT

using System.Net;
using System.Runtime.CompilerServices;
using MongoDB.Driver.Platform.Util;
using System.Threading;
using System;
using System.Collections.Generic;
using MongoDB.Driver.Platform.IO;
using System.IO;
using System.Net.Sockets;
using MongoDB.Driver.Platform.Conversion;
using System.Security;

namespace MongoDB.Driver
{

    /// <summary>
    /// A database port that you can connect to
    /// </summary>
    public interface IDBConnection : IDisposable
    {
        bool CanRequest { get; }
        void Say(IDBRequest msg);
        IDBResponse<TDoc> Call<TDoc>(IDBRequest msg) where TDoc : class, IDocument;
        bool TryAuthenticate(IDBCollection cmdCollection, string username, SecureString usrPassHash);
    }
}