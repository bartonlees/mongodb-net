//COPYRIGHT

using System;
namespace MongoDB.Driver
{
    public class MongoInternalException : Exception
    {

        public MongoInternalException(string msg)
            : base(msg)
        {
        }

        public MongoInternalException(string msg, Exception innerException)
            : base(msg, MongoException._massage(innerException))
        {

        }
    }
}