# Summary #
I/O and streaming support types
# Remarks #
<pre>
"Miscellaneous Utility Library" Software License<br>
<br>
Version 1.0<br>
<br>
Copyright (c) 2004-2008 Jon Skeet and Marc Gravell.<br>
All rights reserved.<br>
<br>
This product includes software developed by Jon Skeet<br>
and Marc Gravell. Contact skeet@pobox.com, or see<br>
http://www.pobox.com/~skeet/<br>
<br>
THIS SOFTWARE IS PROVIDED "AS IS" AND ANY EXPRESSED OR IMPLIED<br>
WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF<br>
MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.<br>
IN NO EVENT SHALL JON SKEET BE LIABLE FOR ANY DIRECT, INDIRECT,<br>
INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,<br>
BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;<br>
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER<br>
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT<br>
LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN<br>
ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE<br>
POSSIBILITY OF SUCH DAMAGE.<br>
</pre>


# Classes #
| **Class** | **Summary** |
|:----------|:------------|
| [EndianBinaryReader](T_MongoDB_Driver_IO_EndianBinaryReader.md) | Equivalent of System.IO.BinaryReader, but with either endianness, depending on the EndianBitConverter it is constructed with. No data is buffered in the reader; the client may seek within the stream at will. |
| [EndianBinaryWriter](T_MongoDB_Driver_IO_EndianBinaryWriter.md) | Equivalent of System.IO.BinaryWriter, but with either endianness, depending on the EndianBitConverter it is constructed with. |
| [LineReader](T_MongoDB_Driver_IO_LineReader.md) | Reads a data source line by line. The source can be a file, a stream, or a text reader. In any case, the source is only opened when the enumerator is fetched, and is closed when the iterator is disposed. |
| [NonClosingStreamWrapper](T_MongoDB_Driver_IO_NonClosingStreamWrapper.md) | Wraps a stream for all operations except Close and Dispose, which merely flush the stream and prevent further operations from being carried out using this wrapper. |
| [ReverseLineReader](T_MongoDB_Driver_IO_ReverseLineReader.md) | Takes an encoding (defaulting to UTF-8) and a function which produces a seekable stream (or a filename for convenience) and yields lines from the end of the stream backwards. Only single byte encodings, and UTF-8 and Unicode, are supported. The stream returned by the function must be seekable. |
| [StreamUtil](T_MongoDB_Driver_IO_StreamUtil.md) | Collection of utility methods which operate on streams. (With C# 3.0, these could well become extension methods on Stream.) |
