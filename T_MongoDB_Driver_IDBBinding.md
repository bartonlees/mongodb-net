# Example #
DBBinding withport = new DBBinding("localhost", 1910, "db"); //Equivalent to "mongo://localhost:1910/db"
# Members #
## Methods ##
### Bind ###
|void Bind(IDatabase database)|
|:----------------------------|
### Call ###
|IDBResponse&lt;TDoc&gt; Call&lt;TDoc&gt;(IDBCollection cmdCollection, IDBRequest msg)||===== Returns =====|


### GetSisterBinding ###
|IDBBinding GetSisterBinding(Uri name)||===== Returns =====|
|:------------------------------------|


### Say ###
|void Say(IDBCollection cmdCollection, IDBRequest msg, bool checkError)|
|:---------------------------------------------------------------------|
### SetCredentials ###
|void SetCredentials(string username, SecureString passwd)             |
### TrySay ###
|bool TrySay(IDBCollection cmdCollection, IDBRequest msg, bool checkError)||===== Returns =====|

