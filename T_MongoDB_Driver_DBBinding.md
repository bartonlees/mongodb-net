# Summary #
A Simple database binding.

# Members #
## Methods ##
### Constructors ###
|DBBinding(MongoDB.Driver.IServerBinding, System.String, Boolean)|
|:---------------------------------------------------------------|
|DBBinding(MongoDB.Driver.IServerBinding, System.Uri, Boolean)   |
### _Say ###_|bool _Say(IDBCollection cmdCollection, IDBRequest request, bool checkError, bool suppressException)                                                           ||===== Returns =====|_


### Bind ###
|void Bind(IDatabase database)|
|:----------------------------|
### Call ###
|IDBResponse&lt;TDoc&gt; Call&lt;TDoc&gt;(IDBCollection cmdCollection, IDBRequest request)||===== Returns =====|


### Equals ###
|bool Equals(object other)||===== Returns =====|
|:------------------------|
`true`if the specified [Object](http://msdn.microsoft.com/en-us/library/System.Object.aspx) is equal to this instance; otherwise,`false`.

### GetHashCode ###
|int GetHashCode()||===== Returns =====|
|:----------------|
A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.

### GetSisterBinding ###
|IDBBinding GetSisterBinding(Uri databaseUri)||===== Returns =====|
|:-------------------------------------------|


### RequireConnection ###
|IDBConnection RequireConnection(Transaction transaction)||===== Returns =====|
|:-------------------------------------------------------|


### Say ###
|void Say(IDBCollection cmdCollection, IDBRequest request, bool checkError)|
|:-------------------------------------------------------------------------|
### SetCredentials ###
|void SetCredentials(string username, SecureString password)               |
### ToString ###
|string ToString()                                                         ||===== Returns =====|
A [String](http://msdn.microsoft.com/en-us/library/System.String.aspx) that represents this instance.

### TrySay ###
|bool TrySay(IDBCollection cmdCollection, IDBRequest request, bool checkError)||===== Returns =====|
|:----------------------------------------------------------------------------|

