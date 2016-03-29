# Summary #
Represents an object whose uniqueness can be determined by a Uri parameter

# Members #
## Methods ##
### AddUser ###
|void AddUser(string username, SecureString passwd)|
|:-------------------------------------------------|
### ClearCollectionCache ###
|void ClearCollectionCache()                       ||Clears the collection cache.|

### DropCollection ###
|void DropCollection(IDBCollection collection)|
|:--------------------------------------------|
### ExecuteCommand ###
|IDBObject ExecuteCommand(DBQuery cmd)        ||===== Returns =====|
The response object

### GetCollection ###
|IDBCollection GetCollection(Uri collectionUri)||===== Returns =====|
|:---------------------------------------------|


### GetSisterDatabase ###
|IDatabase GetSisterDatabase(Uri name)||===== Returns =====|
|:------------------------------------|

