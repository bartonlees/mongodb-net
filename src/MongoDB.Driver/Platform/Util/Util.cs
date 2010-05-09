//COPYRIGHT

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
namespace MongoDB.Driver.Platform.Util
{
    /// <summary>
    /// Misc utility helpers
    /// </summary>
    public static class Util
    {

        /// <summary>
        /// Converts the byte buffer to a hexadecimal encoded string
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        /// <returns>hex string</returns>
        public static string toHex(byte[] buffer)
        {
            return BitConverter.ToString(buffer).Replace("-", "");
        }

        /// <summary>
        /// Produce hex representation of the MD5 digest of a byte array
        /// </summary>
        /// <param name="data">bytes to digest</param>
        /// <returns>hex string of the MD5 digest</returns>
        public static string hexMD5(byte[] data)
        {
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            return toHex(x.ComputeHash(data));
        }
        /// <summary>
        /// Hexes the M d5.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string hexMD5(string data)
        {
            return hexMD5(Encoding.Default.GetBytes(data));
        }


        /// <summary>
        /// Shuffles the specified elements.
        /// </summary>
        /// <param name="elements">The elements.</param>
        public static void Shuffle(IList elements)
        {
            Random rng = new Random();
            int n = elements.Count;
            while (n > 1)
            {
                int k = rng.Next(n);
                --n;
                object temp = elements[n];
                elements[n] = elements[k];
                elements[k] = temp;
            }
        }

        /// <summary>
        /// _hashes the specified username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="passwd">The passwd.</param>
        /// <returns></returns>
        public static string _hash(string username, SecureString passwd)
        {
            //TODO:non-ascii check for secure string?
            //foreach (char c in passwd)
            //{
            //    if (c >= 128)
            //        throw new ArgumentException("can't handle non-ascii passwords yet");
            //}
            //TODO:Is this really default encoding? Or should be ASCII?
            return hexMD5(username + ":mongo:" + passwd);
        }

        /// <summary>
        /// _hashes the specified username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="passwd">The passwd.</param>
        /// <returns></returns>
        public static string _hash(string username, IEnumerable<char> passwd)
        {
            SecureString ss = new SecureString();
            foreach (char c in passwd)
            {
                ss.AppendChar(c);
            }
            return _hash(username, ss);
        }

        /// <summary>
        /// Appends the specified secure string.
        /// </summary>
        /// <param name="secureString">The secure string.</param>
        /// <param name="value">The value.</param>
        public static void Append(this SecureString secureString, string value)
        {
            foreach (char c in value.ToCharArray())
            {
                secureString.AppendChar(c);
            }
        }

        /// <summary>
        /// Appends the specified secure string.
        /// </summary>
        /// <param name="secureString">The secure string.</param>
        /// <param name="value">The value.</param>
        public static void Append(this SecureString secureString, SecureString value)
        {

            // Uncrypt the password and get a reference to it...
            IntPtr bstr = Marshal.SecureStringToBSTR(value);
            //TODO make sure my byte count assumptions are correct
            try
            {
                for (int i = 0; i < value.Length; i++)
                {
                    secureString.AppendChar(Convert.ToChar(Marshal.ReadInt16(bstr)));
                }
            }
            finally
            {
                Marshal.ZeroFreeBSTR(bstr);
            }
        }
    }
}
