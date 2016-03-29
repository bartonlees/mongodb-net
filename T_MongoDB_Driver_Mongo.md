# Remarks #
This object allows for the attachment of [IServer](T_MongoDB_Driver_IServer.md) instances, [IDatabase](T_MongoDB_Driver_IDatabase.md) instances, and [IDBCollection](T_MongoDB_Driver_IDBCollection.md) instances.

# Members #
## Methods ##
### GetDatabase ###
|IDatabase GetDatabase(string databaseUri, DBConnectionOptions options, bool readOnly)||===== Returns =====|
|:------------------------------------------------------------------------------------|
The database proxy instance

|IDatabase GetDatabase(string hostName, string databaseName, Nullable&lt;int&gt; port, DBConnectionOptions options, bool readOnly)||===== Example =====|
|:--------------------------------------------------------------------------------------------------------------------------------|
IDatabase db = Mongo.GetDatabase("localhost", 1910, "test"); //Result would be equivalent to: "mongo://localhost:1910/test"
|IDatabase GetDatabase(Uri databaseUri, DBConnectionOptions options, bool readOnly)                                               ||===== Returns =====|
The database proxy instance

### GetDatabase ###
|IDatabase GetDatabase(string databaseUri, DBConnectionOptions options, bool readOnly)||===== Returns =====|
|:------------------------------------------------------------------------------------|
The database proxy instance

|IDatabase GetDatabase(string hostName, string databaseName, Nullable&lt;int&gt; port, DBConnectionOptions options, bool readOnly)||===== Example =====|
|:--------------------------------------------------------------------------------------------------------------------------------|
IDatabase db = Mongo.GetDatabase("localhost", 1910, "test"); //Result would be equivalent to: "mongo://localhost:1910/test"
|IDatabase GetDatabase(Uri databaseUri, DBConnectionOptions options, bool readOnly)                                               ||===== Returns =====|
The database proxy instance

### GetDatabase ###
|IDatabase GetDatabase(string databaseUri, DBConnectionOptions options, bool readOnly)||===== Returns =====|
|:------------------------------------------------------------------------------------|
The database proxy instance

|IDatabase GetDatabase(string hostName, string databaseName, Nullable&lt;int&gt; port, DBConnectionOptions options, bool readOnly)||===== Example =====|
|:--------------------------------------------------------------------------------------------------------------------------------|
IDatabase db = Mongo.GetDatabase("localhost", 1910, "test"); //Result would be equivalent to: "mongo://localhost:1910/test"
|IDatabase GetDatabase(Uri databaseUri, DBConnectionOptions options, bool readOnly)                                               ||===== Returns =====|
The database proxy instance

### GetServer ###
|IServer GetServer(string host, int port, DBConnectionOptions options, bool readOnly)||===== Example =====|
|:-----------------------------------------------------------------------------------|
IServer server = Mongo.GetServer("localhost", 1910); //Result would be: "mongo://localhost:1910"
|IServer GetServer(string serverUriString, DBConnectionOptions options, bool readOnly)|
|IServer GetServer(Uri serverUri, DBConnectionOptions options, bool readOnly)        ||===== Returns =====|
The server proxy instance

### GetServer ###
|IServer GetServer(string host, int port, DBConnectionOptions options, bool readOnly)||===== Example =====|
|:-----------------------------------------------------------------------------------|
IServer server = Mongo.GetServer("localhost", 1910); //Result would be: "mongo://localhost:1910"
|IServer GetServer(string serverUriString, DBConnectionOptions options, bool readOnly)|
|IServer GetServer(Uri serverUri, DBConnectionOptions options, bool readOnly)        ||===== Returns =====|
The server proxy instance

### GetServer ###
|IServer GetServer(string host, int port, DBConnectionOptions options, bool readOnly)||===== Example =====|
|:-----------------------------------------------------------------------------------|
IServer server = Mongo.GetServer("localhost", 1910); //Result would be: "mongo://localhost:1910"
|IServer GetServer(string serverUriString, DBConnectionOptions options, bool readOnly)|
|IServer GetServer(Uri serverUri, DBConnectionOptions options, bool readOnly)        ||===== Returns =====|
The server proxy instance
