//COPYRIGHT

using System;
namespace MongoDB.Driver
{
    /// <summary>
    /// Used for internal increment values.
    /// </summary>
    /// <remarks>
    /// For storing normal dates in MongoDB, you should use System.DateTime
    /// </remarks>
    public class DBTimestamp
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DBTimestamp"/> class.
        /// </summary>
        public DBTimestamp()
        {
            Inc = 0;
            _time = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBTimestamp"/> class.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <param name="i">The i.</param>
        public DBTimestamp(int time, int i)
        {
            _time = new DateTime(time * 1000L);
            Inc = i;
        }

        /// <summary>
        /// Gets the time.
        /// </summary>
        /// <value>The time.</value>
        public int Time
        {
            get
            {
                if (_time == null)
                    return 0;
                return (int)(_time.Value.Ticks / 1000);
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return "TS time:" + _time + " inc:" + Inc;
        }

        /// <summary>
        /// Gets or sets the increment.
        /// </summary>
        /// <value>The increment.</value>
        public int Inc { get; private set; }
        DateTime? _time;
    }
}