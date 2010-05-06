using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDB.Driver
{
    /// <summary>
    /// Base class for strongly typed wrappers of IDBObjects
    /// </summary>
    public class DBObjectWrapper
    {
        protected IDBObject Object { get; private set; }

        public DBObjectWrapper(IDBObject obj)
        {
            Object = obj;
        }

        public override bool Equals(object obj)
        {
            DBObjectWrapper wrapper = obj as DBObjectWrapper;
            if (wrapper != null)
            {
                return Object.Equals(wrapper.Object);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Object.GetHashCode();
        }
    }
}
