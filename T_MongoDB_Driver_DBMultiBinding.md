# Summary #
A database binding that leverages a pair of databases

# Members #
## Methods ##
### Constructors ###
|DBMultiBinding(MongoDB.Driver.IServerMultiBinding, System.Collections.Generic.IEnumerable\_1[MongoDB.Driver.IDBBinding], Boolean)|
|:--------------------------------------------------------------------------------------------------------------------------------|
### Call ###
|IDBResponse&lt;TDoc&gt; Call&lt;TDoc&gt;(IDBCollection cmdCollection, IDBRequest request)                                        ||===== Returns =====|


### CycleSubBinding ###
|void CycleSubBinding()||Cycles the sub binding. If there is not currently an active binding, one is chosen randomly. If there is an active binding, the alternative binding is activated.|
|:---------------------|

### GetSisterBinding ###
|IDBBinding GetSisterBinding(Uri name)||===== Returns =====|
|:------------------------------------|


### Say ###
|void Say(IDBCollection cmdCollection, IDBRequest request, bool checkError)|
|:-------------------------------------------------------------------------|
### SetCredentials ###
|void SetCredentials(string username, SecureString passwd)                 |
### TrySay ###
|bool TrySay(IDBCollection cmdCollection, IDBRequest msg, bool checkError) ||===== Returns =====|

