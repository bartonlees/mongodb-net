//COPYRIGHT

using System;
using System.Collections.Generic;
using MongoDB.Driver.Conditions;
namespace MongoDB.Driver
{
    /// <summary>
    /// Represents a unit of send/receive-able data
    /// </summary>
    public interface IDBObject : IDictionary<string, object> //IComparable, IComparable<DBObject>, IEquatable<DBObject>
    {
        /// <summary>
        /// Puts all.
        /// </summary>
        /// <param name="m">The m.</param>
        void PutAll(IDictionary<string, object> m);
    }

    /// <summary>
    /// Represents an <see cref="IDBObject"/> that defines its own custom serialization to/from the wire protocol
    /// </summary>
    public interface IDBObjectCustom : IDBObject
    {
        /// <summary>
        /// Writes the specified writer.
        /// </summary>
        /// <param name="writer">The writer.</param>
        void Write(WireProtocolWriter writer);
        /// <summary>
        /// Reads the specified reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        void Read(WireProtocolReader reader);
    }

    /// <summary>
    /// Extension methods for <see cref="IDBObject"/>
    /// </summary>
    public static class IDBObjectExtensions
    {

        /// <summary>
        /// Cames from DB.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <returns></returns>
        /// Determines whether the given object was once part of a db collection.
        /// This method is not foolproof, the the object has had its _id or _ns fields since
        /// it was fetched, this will return that 
        /// <code>o</code>
        ///  did not come from the db.
        /// @param o the object to check
        /// @return if 
        /// <code>o</code>
        ///  contains fields that are automatically added by the database on insertion
        public static bool CameFromDB(this IDBObject o)
        {
            if (o == null)
                return false;

            if (!o.ContainsKey("_id"))
                return false;

            if (!o.ContainsKey("_ns"))
                return false;

            return true;
        }

        /// <summary>
        /// Determines whether the specified value is a number.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// 	<c>true</c> if the specified value is a number; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNumber(object value)
        {
            return value is int || value is long || value is double || value is float;
        }

        /// <summary>
        /// Determines if a server response was an error
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="error">The error.</param>
        /// <returns>
        /// true if this is a response from the server like {"ok":0}, false otherwise
        /// </returns>
        public static bool WasError(this IDBObject o, out DBError error)
        {
            error = null;
            Condition.Requires(o, "this").IsNotNull();
            object value = null;
            if (!o.TryGetValue("ok", out value))
                return false;
            if (!IsNumber(value))
                return false;
            if (Convert.ToInt32(value) == 1)
                return false;
            error = new DBError(o);
            return true;
        }

        /// <summary>
        /// Throws if response not OK.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="failureMessage">The failure message.</param>
        public static void ThrowIfResponseNotOK(this IDBObject o, string failureMessage)
        {
            DBError error;
            if (!WasError(o, out error))
                return;
            error.Throw(failureMessage);
        }

        /// <summary>
        /// Gets a JSON pair value as an int.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="name">The name.</param>
        /// <returns>the pair's value as an int</returns>
        public static int GetAsInt(this IDBObject o, string name)
        {
            object value = o[name];
            return Convert.ToInt32(value);
        }

        /// <summary>
        /// Gets a JSON pair value as the specified type
        /// </summary>
        /// <typeparam name="T">The reference type</typeparam>
        /// <param name="o">The o.</param>
        /// <param name="name">The key.</param>
        /// <returns>the pair's value as an int</returns>
        public static T GetAs<T>(this IDBObject o, string name)
            where T : class
        {
            return GetAs<T>(o, name, null);
        }

        /// <summary>
        /// Gets a JSON pair value as the specified type
        /// </summary>
        /// <typeparam name="T">The reference type</typeparam>
        /// <param name="o">The o.</param>
        /// <param name="name">The key.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>the pair's value as an int</returns>
        public static T GetAs<T>(this IDBObject o, string name, T defaultValue)
            where T : class
        {
            object value = null;
            if (!o.TryGetValue(name, out value) || value == null)
                return defaultValue;
            T t = value as T;
            if (value == null)
                return defaultValue;
            return t;
        }

        /// <summary>
        /// Gets a JSON pair value as an int.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="name">The name.</param>
        /// <param name="def">The default value.</param>
        /// <returns>
        /// the pair's value as an int if possible, or defaultValue
        /// </returns>
        public static int GetAsInt(this IDBObject o, string name, int def)
        {
            object value = null;
            if (!o.TryGetValue(name, out value) || value == null)
                return def;
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return def;
            }
        }

        /// <summary>
        /// Gets a JSON pair value as a long.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="name">The name.</param>
        /// <returns>the pair's value as a long</returns>
        public static long GetAsLong(this IDBObject o, string name)
        {
            object value = o[name];
            return Convert.ToInt64(value);
        }

        /// <summary>
        /// Gets a JSON pair value as an long.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="name">The pair's name.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>
        /// the pair's value as a long if possible, or defaultValue
        /// </returns>
        public static long GetAsLong(this IDBObject o, string name, long defaultValue)
        {
            object value = null;
            if (!o.TryGetValue(name, out value) || value == null)
                return defaultValue;
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Gets the JSON pair value as a string.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="name">The pair's name.</param>
        /// <returns>the pair's value as a string</returns>
        public static string GetAsString(this IDBObject o, string name)
        {
            return GetAsString(o, name, null);
        }

        /// <summary>
        /// Gets the JSON pair value as a string.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="name">The name.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>
        /// the pair's value as a string if possible, or defaultValue
        /// </returns>
        public static string GetAsString(this IDBObject o, string name, string defaultValue)
        {
            object value = null;
            if (!o.TryGetValue(name, out value) || value == null)
                return defaultValue;
            try
            {
                return Convert.ToString(value);
            }
            catch
            {
                return defaultValue;
            }
        }


        /// <summary>
        /// Gets the JSON pair value as a nested IDBObject.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="name">The name.</param>
        /// <returns>
        /// the pair's value as a string if possible, or defaultValue
        /// </returns>
        public static IDBObject GetAsIDBObject(this IDBObject o, string name)
        {
            return GetAs<IDBObject>(o, name);
        }

        /// <summary>
        /// Determines whether the specified object has an _id field of type <see cref="Oid"/>.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <returns>
        /// 	<c>true</c> if the specified o has oid; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasOid(this IDBObject o)
        {
            return GetOid(o) != Oid.Empty;
        }

        /// <summary>
        /// Requires the oid.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <returns></returns>
        public static Oid RequireOid(this IDBObject o)
        {
            object value = null;
            o.TryGetValue("_id", out value);
            if (value == null)
            {
                Oid id = Oid.NewOid();
                o["_id"] = id;
                return id;
            }
            else
            {
                return (Oid)value;
            }
        }

        /// <summary>
        /// Determines whether the specified object has a non-null _id field.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <returns>
        /// 	<c>true</c> if the specified o has oid; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasID(this IDBObject o)
        {
            object value = null;
            o.TryGetValue("_id", out value);
            return value != null;
        }

        /// <summary>
        /// Gets the ID of this object as an <see cref="Oid"/>
        /// </summary>
        /// <param name="o">The o.</param>
        /// <returns>
        /// The Oid if the field is present and of type Oid, or Oid.Empty otherwise
        /// </returns>
        public static Oid GetOid(this IDBObject o)
        {
            object value = null;
            if (!o.TryGetValue("_id", out value))
                return Oid.Empty;
            return (Oid)value;
        }

        /// <summary>
        /// Gets the ID of this object as an <see cref="Oid"/>
        /// </summary>
        /// <param name="o">The o.</param>
        /// <returns>
        /// The Oid if the field is present and of type Oid, or Oid.Empty otherwise
        /// </returns>
        public static object GetID(this IDBObject o)
        {
            object value = null;
            o.TryGetValue("_id", out value);
            return value;
        }
    }
}