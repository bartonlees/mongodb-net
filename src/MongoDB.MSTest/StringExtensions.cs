using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;

namespace MongoDB.MSTest
{    
    public static class StringExtensions
    {
        public static string RemoveWhitespace(this string input)
        {
            return input.Replace(Environment.NewLine, "").Replace("\t", "").Replace(" ", "");
        }

        public static byte[] FromDashedHexString(this string input)
        {
            string[] parts = input.Split('-');
            byte[] result = parts.Select(part => byte.Parse(part, System.Globalization.NumberStyles.HexNumber)).ToArray();
            return result;
        }

        public static string ToDashedHexString(this byte[] input)
        {
            return BitConverter.ToString(input, 0);
        }
    }
}
