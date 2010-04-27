using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDB.Driver
{
    public class DBObjectWrapper
    {
        public IDBObject Object { get; private set; }

        public DBObjectWrapper(IDBObject obj)
        {
            Object = obj;
        }        
    }
}
