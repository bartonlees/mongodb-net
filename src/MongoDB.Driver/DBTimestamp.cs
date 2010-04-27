//COPYRIGHT

using System;
namespace MongoDB.Driver
{
    /// <summary>
    /// Used for internal increment values.
    /// For storing normal dates in MongoDB, you should use java.util.DateTime
    /// </summary>
    public class DBTimestamp
    {
        public DBTimestamp()
        {
            Inc = 0;
            _time = null;
        }

        public DBTimestamp(int time, int i)
        {
            _time = new DateTime(time * 1000L);
            Inc = i;
        }

        public int Time
        {
            get
            {
                if (_time == null)
                    return 0;
                return (int)(_time.Value.Ticks / 1000);
            }
        }

        public override string ToString()
        {
            return "TS time:" + _time + " inc:" + Inc;
        }

        public int Inc { get; private set;}
        DateTime? _time;
    }
}