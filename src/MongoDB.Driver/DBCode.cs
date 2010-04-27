using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDB.Driver
{
    /// <summary>
    /// Represents a piece of JavaScript code
    /// </summary>
    public class DBCode
    {
        public string Code { get; private set; }
        public DBCode(string code)
        {
            Code = code;
        }
        public override string ToString()
        {
            return Code;
        }
    }
}
