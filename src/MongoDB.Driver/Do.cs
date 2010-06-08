using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace MongoDB.Driver
{
    /// <summary>
    /// Fluent root for <see cref="T:MongoDB.Driver.IDocument"/> modifier expressions
    /// </summary>
    public static class Do
    {
        /// <summary>
        /// Requests that the field be incremented by the specified value
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DBModifier Inc(string fieldName, object value)
        {
            return new DBModifier().Inc(fieldName, value);
        }

        /// <summary>
        /// Requests that the field be set the the specified value
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DBModifier Set(string fieldName, object value)
        {
            return new DBModifier().Set(fieldName, value);
        }

        /// <summary>
        /// Requests that the field be unset
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DBModifier Unset(string fieldName, object value)
        {
            return new DBModifier().Unset(fieldName, value);
        }

        /// <summary>
        /// Requests that the value be pushed onto the field's stack
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DBModifier Push(string fieldName, object value)
        {
            return new DBModifier().Push(fieldName, value);
        }

        /// <summary>
        /// Requests that all the values be pushed on to the field's stack
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DBModifier PushAll(string fieldName, IList value)
        {
            return new DBModifier().PushAll(fieldName, value);
        }

        /// <summary>
        /// Requests that the value be added to the field's set
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DBModifier AddToSet(string fieldName, object value)
        {
            return new DBModifier().AddToSet(fieldName, value);
        }

        /// <summary>
        /// Requests that each value in a list be added to the field's set
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DBModifier AddEachToSet(string fieldName, IList value)
        {
            return new DBModifier().AddEachToSet(fieldName, value);
        }

        /// <summary>
        /// Requests that a value be popped from the field's stack
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="fromTop">if set to <c>true</c> [from top].</param>
        /// <returns></returns>
        public static DBModifier Pop(string fieldName, bool fromTop = true)
        {
            return new DBModifier().Pop(fieldName, fromTop);
        }

        /// <summary>
        /// Requests that a value be pulled from the field's list
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DBModifier Pull(string fieldName, object value)
        {
            return new DBModifier().Pull(fieldName, value);
        }

        /// <summary>
        /// Requests that all values in a list be pulled from the field's list
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
