# Summary #
Equivalent of System.IO.BinaryReader, but with either endianness, depending on the EndianBitConverter it is constructed with. No data is buffered in the reader; the client may seek within the stream at will.

# Members #
## Methods ##
### Constructors ###
|EndianBinaryReader(MongoDB.Driver.Conversion.EndianBitConverter, System.IO.Stream)|
|:---------------------------------------------------------------------------------|
|EndianBinaryReader(MongoDB.Driver.Conversion.EndianBitConverter, System.IO.Stream, System.Text.Encoding)|
### Close ###
|void Close()                                                                      ||Closes the reader, including the underlying stream..|

### Dispose ###
|void Dispose()||Disposes of the underlying stream.|
|:-------------|

### Read ###
|int Read()||===== Returns =====|
|:---------|
The character read, or -1 for end of stream.

|int Read(byte[.md](.md) buffer, int index, int count)||===== Returns =====|
|:----------------------------------------------------|
The number of bytes actually read. This will only be less than the requested number of bytes if the end of the stream is reached.

|int Read(char[.md](.md) data, int index, int count)||===== Returns =====|
|:--------------------------------------------------|
The number of characters actually read. This will only be less than the requested number of characters if the end of the stream is reached.

### Read ###
|int Read()||===== Returns =====|
|:---------|
The character read, or -1 for end of stream.

|int Read(byte[.md](.md) buffer, int index, int count)||===== Returns =====|
|:----------------------------------------------------|
The number of bytes actually read. This will only be less than the requested number of bytes if the end of the stream is reached.

|int Read(char[.md](.md) data, int index, int count)||===== Returns =====|
|:--------------------------------------------------|
The number of characters actually read. This will only be less than the requested number of characters if the end of the stream is reached.

### Read ###
|int Read()||===== Returns =====|
|:---------|
The character read, or -1 for end of stream.

|int Read(byte[.md](.md) buffer, int index, int count)||===== Returns =====|
|:----------------------------------------------------|
The number of bytes actually read. This will only be less than the requested number of bytes if the end of the stream is reached.

|int Read(char[.md](.md) data, int index, int count)||===== Returns =====|
|:--------------------------------------------------|
The number of characters actually read. This will only be less than the requested number of characters if the end of the stream is reached.

### Read7BitEncodedInt ###
|int Read7BitEncodedInt()||===== Returns =====|
|:-----------------------|
The 7-bit encoded integer read from the stream.

### ReadBigEndian7BitEncodedInt ###
|int ReadBigEndian7BitEncodedInt()||===== Returns =====|
|:--------------------------------|
The 7-bit encoded integer read from the stream.

### ReadBoolean ###
|bool ReadBoolean()||===== Returns =====|
|:-----------------|
The boolean read

### ReadByte ###
|byte ReadByte()||===== Returns =====|
|:--------------|
The byte read

### ReadBytes ###
|byte[.md](.md) ReadBytes(int count)||===== Returns =====|
|:----------------------------------|
The bytes read

### ReadBytesOrThrow ###
|byte[.md](.md) ReadBytesOrThrow(int count)||===== Returns =====|
|:-----------------------------------------|
The bytes read

### ReadDecimal ###
|Decimal ReadDecimal()||===== Returns =====|
|:--------------------|
The decimal value read

### ReadDouble ###
|bool ReadDouble()||===== Returns =====|
|:----------------|
The floating point value read

### ReadInt16 ###
|short ReadInt16()||===== Returns =====|
|:----------------|
The 16-bit integer read

### ReadInt32 ###
|int ReadInt32()||===== Returns =====|
|:--------------|
The 32-bit integer read

### ReadInt64 ###
|long ReadInt64()||===== Returns =====|
|:---------------|
The 64-bit integer read

### ReadSByte ###
|SByte ReadSByte()||===== Returns =====|
|:----------------|
The byte read

### ReadSingle ###
|float ReadSingle()||===== Returns =====|
|:-----------------|
The floating point value read

### ReadString ###
|string ReadString()||===== Returns =====|
|:------------------|
The string read from the stream.

### ReadUInt16 ###
|UInt16 ReadUInt16()||===== Returns =====|
|:------------------|
The 16-bit unsigned integer read

### ReadUInt32 ###
|UInt32 ReadUInt32()||===== Returns =====|
|:------------------|
The 32-bit unsigned integer read

### ReadUInt64 ###
|UInt64 ReadUInt64()||===== Returns =====|
|:------------------|
The 64-bit unsigned integer read

### Seek ###
|void Seek(int offset, SeekOrigin origin)|
|:---------------------------------------|