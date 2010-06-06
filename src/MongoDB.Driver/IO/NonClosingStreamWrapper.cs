// "Miscellaneous Utility Library" Software Licence
//
// Version 1.0
//
// Copyright (c) 2004-2008 Jon Skeet and Marc Gravell.
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions
// are met:
//
// 1. Redistributions of source code must retain the above copyright
// notice, this list of conditions and the following disclaimer.
//
// 2. Redistributions in binary form must reproduce the above copyright
// notice, this list of conditions and the following disclaimer in the
// documentation and/or other materials provided with the distribution.
//
// 3. The end-user documentation included with the redistribution, if
// any, must include the following acknowledgment:
//
// "This product includes software developed by Jon Skeet
// and Marc Gravell. Contact skeet@pobox.com, or see 
// http://www.pobox.com/~skeet/)."
//
// Alternately, this acknowledgment may appear in the software itself,
// if and wherever such third-party acknowledgments normally appear.
//
// 4. The name "Miscellaneous Utility Library" must not be used to endorse 
// or promote products derived from this software without prior written 
// permission. For written permission, please contact skeet@pobox.com.
//
// 5. Products derived from this software may not be called 
// "Miscellaneous Utility Library", nor may "Miscellaneous Utility Library"
// appear in their name, without prior written permission of Jon Skeet.
//
// THIS SOFTWARE IS PROVIDED "AS IS" AND ANY EXPRESSED OR IMPLIED
// WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF
// MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
// IN NO EVENT SHALL JON SKEET BE LIABLE FOR ANY DIRECT, INDIRECT,
// INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
// LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
// LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
// POSSIBILITY OF SUCH DAMAGE. 

using System;
using System.IO;
using System.Runtime.Remoting;

namespace MongoDB.Driver.IO
{
    /// <summary>
    /// Wraps a stream for all operations except Close and Dispose, which
    /// merely flush the stream and prevent further operations from being
    /// carried out using this wrapper.
    /// </summary>
    public sealed class NonClosingStreamWrapper : Stream
    {
        #region Members specific to this wrapper class
        /// <summary>
        /// Creates a new instance of the class, wrapping the specified stream.
        /// </summary>
        /// <param name="stream">The stream to wrap. Must not be null.</param>
        /// <exception cref="ArgumentNullException">stream is null</exception>
        public NonClosingStreamWrapper(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }
            this.stream = stream;
        }

        Stream stream;
        /// <summary>
        /// Stream wrapped by this wrapper
        /// </summary>
        /// <value>The base stream.</value>
        public Stream BaseStream
        {
            get { return stream; }
        }

        /// <summary>
        /// Whether this stream has been closed or not
        /// </summary>
        bool closed = false;

        /// <summary>
        /// Throws an InvalidOperationException if the wrapper is closed.
        /// </summary>
        void CheckClosed()
        {
            if (closed)
            {
                throw new InvalidOperationException("Wrapper has been closed or disposed");
            }
        }
        #endregion

        #region Overrides of Stream methods and properties
        /// <summary>
        /// Begins an asynchronous read operation.
        /// </summary>
        /// <param name="buffer">The buffer to read the data into.</param>
        /// <param name="offset">The byte offset in buffer at which to begin writing data read from the stream.</param>
        /// <param name="count">The maximum number of bytes to read.</param>
        /// <param name="callback">An optional asynchronous callback, to be called when the read is complete.</param>
        /// <param name="state">A user-provided object that distinguishes this particular
        /// asynchronous read request from other requests.</param>
        /// <returns>
        /// An IAsyncResult that represents the asynchronous read,
        /// which could still be pending.
        /// </returns>
        /// <exception cref="T:System.IO.IOException">Attempted an asynchronous read past the end of the stream, or a disk error occurs. </exception>
        /// <exception cref="T:System.ArgumentException">One or more of the arguments is invalid. </exception>
        /// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed. </exception>
        /// <exception cref="T:System.NotSupportedException">The current Stream implementation does not support the read operation. </exception>
        public override IAsyncResult BeginRead(byte[] buffer, int offset, int count,
                                               AsyncCallback callback, object state)
        {
            CheckClosed();
            return stream.BeginRead(buffer, offset, count, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous write operation.
        /// </summary>
        /// <param name="buffer">The buffer to write data from.</param>
        /// <param name="offset">The byte offset in buffer from which to begin writing.</param>
        /// <param name="count">The maximum number of bytes to write.</param>
        /// <param name="callback">An optional asynchronous callback, to be called when the write is complete.</param>
        /// <param name="state">A user-provided object that distinguishes this particular asynchronous
        /// write request from other requests.</param>
        /// <returns>
        /// An IAsyncResult that represents the asynchronous write,
        /// which could still be pending.
        /// </returns>
        /// <exception cref="T:System.IO.IOException">Attempted an asynchronous write past the end of the stream, or a disk error occurs. </exception>
        /// <exception cref="T:System.ArgumentException">One or more of the arguments is invalid. </exception>
        /// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed. </exception>
        /// <exception cref="T:System.NotSupportedException">The current Stream implementation does not support the write operation. </exception>
        public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count,
                                                AsyncCallback callback, object state)
        {
            CheckClosed();
            return stream.BeginWrite(buffer, offset, count, callback, state);
        }

        /// <summary>
        /// Indicates whether or not the underlying stream can be read from.
        /// </summary>
        /// <value></value>
        /// <returns>true if the stream supports reading; otherwise, false.</returns>
        public override bool CanRead
        {
            get { return closed ? false : stream.CanRead; }
        }

        /// <summary>
        /// Indicates whether or not the underlying stream supports seeking.
        /// </summary>
        /// <value></value>
        /// <returns>true if the stream supports seeking; otherwise, false.</returns>
        public override bool CanSeek
        {
            get { return closed ? false : stream.CanSeek; }
        }

        /// <summary>
        /// Indicates whether or not the underlying stream can be written to.
        /// </summary>
        /// <value></value>
        /// <returns>true if the stream supports writing; otherwise, false.</returns>
        public override bool CanWrite
        {
            get { return closed ? false : stream.CanWrite; }
        }

        /// <summary>
        /// This method is not proxied to the underlying stream; instead, the wrapper
        /// is marked as unusable for other (non-close/Dispose) operations. The underlying
        /// stream is flushed if the wrapper wasn't closed before this call.
        /// </summary>
        public override void Close()
        {
            if (!closed)
            {
                stream.Flush();
            }
            closed = true;
        }

        /// <summary>
        /// Throws a NotSupportedException.
        /// </summary>
        /// <param name="requestedType">The Type of the object that the new ObjRef will reference.</param>
        /// <returns>n/a</returns>
        /// <exception cref="T:System.Runtime.Remoting.RemotingException">This instance is not a valid remoting object. </exception>
        /// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission. </exception>
        /// <PermissionSet>
        /// 	<IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="Infrastructure"/>
        /// </PermissionSet>
        public override ObjRef CreateObjRef(Type requestedType)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Waits for the pending asynchronous read to complete.
        /// </summary>
        /// <param name="asyncResult">The reference to the pending asynchronous request to finish.</param>
        /// <returns>
        /// The number of bytes read from the stream, between zero (0)
        /// and the number of bytes you requested. Streams only return
        /// zero (0) at the end of the stream, otherwise, they should
        /// block until at least one byte is available.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// 	<paramref name="asyncResult"/> is null. </exception>
        /// <exception cref="T:System.ArgumentException">
        /// 	<paramref name="asyncResult"/> did not originate from a <see cref="M:System.IO.Stream.BeginRead(System.Byte[],System.Int32,System.Int32,System.AsyncCallback,System.Object)"/> method on the current stream. </exception>
        /// <exception cref="T:System.IO.IOException">The stream is closed or an internal error has occurred.</exception>
        public override int EndRead(IAsyncResult asyncResult)
        {
            CheckClosed();
            return stream.EndRead(asyncResult);
        }

        /// <summary>
        /// Ends an asynchronous write operation.
        /// </summary>
        /// <param name="asyncResult">A reference to the outstanding asynchronous I/O request.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// 	<paramref name="asyncResult"/> is null. </exception>
        /// <exception cref="T:System.ArgumentException">
        /// 	<paramref name="asyncResult"/> did not originate from a <see cref="M:System.IO.Stream.BeginWrite(System.Byte[],System.Int32,System.Int32,System.AsyncCallback,System.Object)"/> method on the current stream. </exception>
        /// <exception cref="T:System.IO.IOException">The stream is closed or an internal error has occurred.</exception>
        public override void EndWrite(IAsyncResult asyncResult)
        {
            CheckClosed();
            stream.EndWrite(asyncResult);
        }

        /// <summary>
        /// Flushes the underlying stream.
        /// </summary>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void Flush()
        {
            CheckClosed();
            stream.Flush();
        }

        /// <summary>
        /// Throws a NotSupportedException.
        /// </summary>
        /// <returns>n/a</returns>
        /// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission. </exception>
        /// <PermissionSet>
        /// 	<IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="RemotingConfiguration, Infrastructure"/>
        /// </PermissionSet>
        public override object InitializeLifetimeService()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Returns the length of the underlying stream.
        /// </summary>
        /// <value></value>
        /// <returns>A long value representing the length of the stream in bytes.</returns>
        /// <exception cref="T:System.NotSupportedException">A class derived from Stream does not support seeking. </exception>
        /// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed. </exception>
        public override long Length
        {
            get
            {
                CheckClosed();
                return stream.Length;
            }
        }

        /// <summary>
        /// Gets or sets the current position in the underlying stream.
        /// </summary>
        /// <value></value>
        /// <returns>The current position within the stream.</returns>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <exception cref="T:System.NotSupportedException">The stream does not support seeking. </exception>
        /// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed. </exception>
        public override long Position
        {
            get
            {
                CheckClosed();
                return stream.Position;
            }
            set
            {
                CheckClosed();
                stream.Position = value;
            }
        }

        /// <summary>
        /// Reads a sequence of bytes from the underlying stream and advances the
        /// position within the stream by the number of bytes read.
        /// </summary>
        /// <param name="buffer">An array of bytes. When this method returns, the buffer contains
        /// the specified byte array with the values between offset and
        /// (offset + count- 1) replaced by the bytes read from the underlying source.</param>
        /// <param name="offset">The zero-based byte offset in buffer at which to begin storing the data
        /// read from the underlying stream.</param>
        /// <param name="count">The maximum number of bytes to be read from the
        /// underlying stream.</param>
        /// <returns>
        /// The total number of bytes read into the buffer.
        /// This can be less than the number of bytes requested if that many
        /// bytes are not currently available, or zero (0) if the end of the
        /// stream has been reached.
        /// </returns>
        /// <exception cref="T:System.ArgumentException">The sum of <paramref name="offset"/> and <paramref name="count"/> is larger than the buffer length. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        /// 	<paramref name="buffer"/> is null. </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// 	<paramref name="offset"/> or <paramref name="count"/> is negative. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <exception cref="T:System.NotSupportedException">The stream does not support reading. </exception>
        /// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed. </exception>
        public override int Read(byte[] buffer, int offset, int count)
        {
            CheckClosed();
            return stream.Read(buffer, offset, count);
        }

        /// <summary>
        /// Reads a byte from the stream and advances the position within the
        /// stream by one byte, or returns -1 if at the end of the stream.
        /// </summary>
        /// <returns>
        /// The unsigned byte cast to an Int32, or -1 if at the end of the stream.
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">The stream does not support reading. </exception>
        /// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed. </exception>
        public override int ReadByte()
        {
            CheckClosed();
            return stream.ReadByte();
        }

        /// <summary>
        /// Sets the position within the current stream.
        /// </summary>
        /// <param name="offset">A byte offset relative to the origin parameter.</param>
        /// <param name="origin">A value of type SeekOrigin indicating the reference
        /// point used to obtain the new position.</param>
        /// <returns>
        /// The new position within the underlying stream.
        /// </returns>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <exception cref="T:System.NotSupportedException">The stream does not support seeking, such as if the stream is constructed from a pipe or console output. </exception>
        /// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed. </exception>
        public override long Seek(long offset, SeekOrigin origin)
        {
            CheckClosed();
            return stream.Seek(offset, origin);
        }

        /// <summary>
        /// Sets the length of the underlying stream.
        /// </summary>
        /// <param name="value">The desired length of the underlying stream in bytes.</param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <exception cref="T:System.NotSupportedException">The stream does not support both writing and seeking, such as if the stream is constructed from a pipe or console output. </exception>
        /// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed. </exception>
        public override void SetLength(long value)
        {
            CheckClosed();
            stream.SetLength(value);
        }

        /// <summary>
        /// Writes a sequence of bytes to the underlying stream and advances
        /// the current position within the stream by the number of bytes written.
        /// </summary>
        /// <param name="buffer">An array of bytes. This method copies count bytes
        /// from buffer to the underlying stream.</param>
        /// <param name="offset">The zero-based byte offset in buffer at
        /// which to begin copying bytes to the underlying stream.</param>
        /// <param name="count">The number of bytes to be written to the underlying stream.</param>
        /// <exception cref="T:System.ArgumentException">The sum of <paramref name="offset"/> and <paramref name="count"/> is greater than the buffer length. </exception>
        /// <exception cref="T:System.ArgumentNullException">
        /// 	<paramref name="buffer"/> is null. </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// 	<paramref name="offset"/> or <paramref name="count"/> is negative. </exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <exception cref="T:System.NotSupportedException">The stream does not support writing. </exception>
        /// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed. </exception>
        public override void Write(byte[] buffer, int offset, int count)
        {
            CheckClosed();
            stream.Write(buffer, offset, count);
        }

        /// <summary>
        /// Writes a byte to the current position in the stream and
        /// advances the position within the stream by one byte.
        /// </summary>
        /// <param name="value">The byte to write to the stream.</param>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        /// <exception cref="T:System.NotSupportedException">The stream does not support writing, or the stream is already closed. </exception>
        /// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed. </exception>
        public override void WriteByte(byte value)
        {
            CheckClosed();
            stream.WriteByte(value);
        }
        #endregion
    }
}
