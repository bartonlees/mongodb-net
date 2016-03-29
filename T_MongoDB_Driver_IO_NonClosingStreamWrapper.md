# Summary #
Wraps a stream for all operations except Close and Dispose, which merely flush the stream and prevent further operations from being carried out using this wrapper.

# Members #
## Methods ##
### Constructors ###
|NonClosingStreamWrapper(System.IO.Stream)|
|:----------------------------------------|
### BeginRead ###
|IAsyncResult BeginRead(byte[.md](.md) buffer, int offset, int count, AsyncCallback callback, object state)|
### BeginWrite ###
|IAsyncResult BeginWrite(byte[.md](.md) buffer, int offset, int count, AsyncCallback callback, object state)|
### Close ###
|void Close()                             ||This method is not proxied to the underlying stream; instead, the wrapper is marked as unusable for other (non-close/Dispose) operations. The underlying stream is flushed if the wrapper wasn't closed before this call.|

### CreateObjRef ###
|ObjRef CreateObjRef(Type requestedType)|
|:--------------------------------------|
### EndRead ###
|int EndRead(IAsyncResult asyncResult)  |
### EndWrite ###
|void EndWrite(IAsyncResult asyncResult)|
### Flush ###
|void Flush()                           |
### InitializeLifetimeService ###
|object InitializeLifetimeService()     |
### Read ###
|int Read(byte[.md](.md) buffer, int offset, int count)|
### ReadByte ###
|int ReadByte()                         |
### Seek ###
|long Seek(long offset, SeekOrigin origin)|
### SetLength ###
|void SetLength(long value)             |
### Write ###
|void Write(byte[.md](.md) buffer, int offset, int count)|
### WriteByte ###
|void WriteByte(byte value)             |