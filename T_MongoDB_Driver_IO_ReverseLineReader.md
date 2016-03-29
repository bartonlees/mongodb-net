# Summary #
Takes an encoding (defaulting to UTF-8) and a function which produces a seekable stream (or a filename for convenience) and yields lines from the end of the stream backwards. Only single byte encodings, and UTF-8 and Unicode, are supported. The stream returned by the function must be seekable.

# Members #
## Methods ##
### Constructors ###
|ReverseLineReader(System.Func\_1[System.IO.Stream])|
|:--------------------------------------------------|
|ReverseLineReader(System.Func\_1[System.IO.Stream], System.Text.Encoding)|
|ReverseLineReader(System.String)                   |
|ReverseLineReader(System.String, System.Text.Encoding)|
### GetEnumerator ###
|IEnumerator&lt;string&gt; GetEnumerator()          ||===== Returns =====|

