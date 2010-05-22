using System;

namespace MongoDB.Driver
{
    /// <summary>
    /// Base class for strongly typed wrappers of <see cref="IDBObject"/>
    /// </summary>
    public class DBObjectWrapper
    {
        /// <summary>
        /// Gets or sets the object.
        /// </summary>
        /// <value>The object.</value>
        protected IDBObject Object { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBObjectWrapper"/> class.
        /// </summary>
        /// <param name="obj">The obj.</param>
        public DBObjectWrapper(IDBObject obj)
        {
            Object = obj;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            DBObjectWrapper wrapper = obj as DBObjectWrapper;
            if (wrapper != null)
            {
                return Object.Equals(wrapper.Object);
            }
            return false;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return Object.GetHashCode();
        }
    }
}
