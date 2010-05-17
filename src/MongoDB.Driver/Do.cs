using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace MongoDB.Driver
{
    /// <summary>
    /// Fluent root for modifier expressions
    /// </summary>
    public static class Do
    {
        /// <summary>
        /// Incs the specified field name.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DBModifier Inc(string fieldName, object value)
        {
            return new DBModifier().Inc(fieldName, value);
        }

        /// <summary>
        /// Sets the specified field name.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DBModifier Set(string fieldName, object value)
        {
            return new DBModifier().Set(fieldName, value);
        }

        /// <summary>
        /// Unsets the specified field name.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DBModifier Unset(string fieldName, object value)
        {
            return new DBModifier().Unset(fieldName, value);
        }

        /// <summary>
        /// Pushes the specified field name.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DBModifier Push(string fieldName, object value)
        {
            return new DBModifier().Push(fieldName, value);
        }

        /// <summary>
        /// Pushes all.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DBModifier PushAll(string fieldName, IList value)
        {
            return new DBModifier().PushAll(fieldName, value);
        }

        /// <summary>
        /// Adds to set.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DBModifier AddToSet(string fieldName, object value)
        {
            return new DBModifier().AddToSet(fieldName, value);
        }

        /// <summary>
        /// Adds the each to set.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DBModifier AddEachToSet(string fieldName, IList value)
        {
            return new DBModifier().AddEachToSet(fieldName, value);
        }

        /// <summary>
        /// Pops the specified field name.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="fromTop">if set to <c>true</c> [from top].</param>
        /// <returns></returns>
        public static DBModifier Pop(string fieldName, bool fromTop = true)
        {
            return new DBModifier().Pop(fieldName, fromTop);
        }

        /// <summary>
        /// Pulls the specified field name.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DBModifier Pull(string fieldName, object value)
        {
            return new DBModifier().Pull(fieldName, value);
        }

        /// <summary>
        /// Pulls all.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DBModifier PullAll(string fieldName, IList value)
        {
            return new DBModifier().PullAll(fieldName, value);
        }
    }
}
