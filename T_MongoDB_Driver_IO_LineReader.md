# Summary #
Reads a data source line by line. The source can be a file, a stream, or a text reader. In any case, the source is only opened when the enumerator is fetched, and is closed when the iterator is disposed.

# Members #
## Methods ##
### Constructors ###
|LineReader(System.Func\_1[System.IO.Stream])|
|:-------------------------------------------|
|LineReader(System.Func\_1[System.IO.Stream], System.Text.Encoding)|
|LineReader(System.Func\_1[System.IO.TextReader])|
|LineReader(System.String)                   |
|LineReader(System.String, System.Text.Encoding)|
### GetEnumerator ###
|IEnumerator&lt;string&gt; GetEnumerator()   ||===== Returns =====|


|IEnumerator&lt;string&gt; GetEnumerator()||Enumerates the data source line by line.|
|:----------------------------------------|

### GetEnumerator ###
|IEnumerator&lt;string&gt; GetEnumerator()||===== Returns =====|
|:----------------------------------------|


|IEnumerator&lt;string&gt; GetEnumerator()||Enumerates the data source line by line.|
|:----------------------------------------|
