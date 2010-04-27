//COPYRIGHT

using System;
namespace MongoDB.Driver
{

    public class MongoException : Exception
    {

        public MongoException(string msg)
            : base(msg)
        {
        }

        public MongoException(string msg, Exception t)
            : base(msg, _massage(t))
        {
        }

        internal static Exception _massage(Exception t)
        {
            if (t is Network)
                return ((Network)t)._ioe;
            return t;
        }

        public sealed class Response : MongoException
        {
            public IDBResponse ActualResponse { get; private set;}
            internal Response(string msg, IDBResponse response)
                : base(msg)
            {
                ActualResponse = response;
            }
        }

        public sealed class Authentication : MongoException
        {
            internal Authentication(string username)
                : base(string.Format("Cannot authenticate user \"{0}\".", username))
            {

            }
        }

        public sealed class LastError : MongoException
        {
            public MongoDB.Driver.LastError ActualLastError { get; private set; }
            internal LastError(MongoDB.Driver.LastError lastError)
                : base(lastError.ErrorMessage)
            {
                ActualLastError = lastError;
            }
        }

        public sealed class Network : MongoException
        {

            internal Network(string msg, System.IO.IOException ioe)
                : base(msg, ioe)
            {
                _ioe = ioe;
            }

            internal Network(System.IO.IOException ioe)
                : this(ioe.Message, ioe)
            {
            }

            internal System.IO.IOException _ioe;
        }

        public sealed class DuplicateKey : MongoException
        {
            public DuplicateKey(string msg)
                : base(msg)
            {
            }
        }
    }
}