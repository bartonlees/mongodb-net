# Example #
ServerBinding withport = new ServerBinding("localhost", 1910); //Equivalent to "mongo://localhost:1910"
# Members #
## Methods ##
### Constructors ###
|ServerBinding(System.Uri, Boolean)|
|:---------------------------------|
### Equals ###
|bool Equals(object other)         ||===== Returns =====|
`true`if the specified [Object](http://msdn.microsoft.com/en-us/library/System.Object.aspx) is equal to this instance; otherwise,`false`.

### GetDBBinding ###
|IDBBinding GetDBBinding(Uri name)||===== Returns =====|
|:--------------------------------|


### GetHashCode ###
|int GetHashCode()||===== Returns =====|
|:----------------|
A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.

### ToString ###
|string ToString()||===== Returns =====|
|:----------------|
A [String](http://msdn.microsoft.com/en-us/library/System.String.aspx) that represents this instance.
