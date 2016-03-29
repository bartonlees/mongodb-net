# Summary #
The default implementation of the database interface

# Members #
## Fields ##
| **Name** | **Literal** | **Comments** |
|:---------|:------------|:-------------|
| NUM\_CURSORS\_BEFORE\_KILL |             | The maximum number of cursors allowed |
| StandardCollectionNames |             |              |

## Methods ##
### Constructors ###
|Database(MongoDB.Driver.IServer, MongoDB.Driver.IDBBinding)|
|:----------------------------------------------------------|
### AddUser ###
|void AddUser(string username, SecureString passwd)         |
### ClearCollectionCache ###
|void ClearCollectionCache()                                ||Clears the collection cache.|

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
|IDatabase GetSisterDatabase(Uri databaseUri)||===== Returns =====|
|:-------------------------------------------|


### ToString ###
|string ToString()||===== Returns =====|
|:----------------|
A [String](http://msdn.microsoft.com/en-us/library/System.String.aspx) that represents this instance.
