The [`IDatabase` interface](http://code.google.com/p/mongodb-net/source/browse/trunk/MongoDB.Driver/IDatabase.cs) represents a database object hosted on a remote [server](IServer.md). Methods and properties on the interface will perform actions on the remote database and retrieve information about [collections](IDBCollection.md).

## Creating a new Collection ##

```

//GetCollection creates the named collection if it does not already exist
IDBCollection col1 = database.GetCollection("collectionName");

//Shorthand for GetCollection using array index syntax
IDBCollection col2 = database["collectionName"];

//Explicitly create a collection
IDBCollection col3 = database.CreateCollection("collectionName");
```

Further options are available to handle [capped collections](http://www.mongodb.org/display/DOCS/Capped+Collections):

```

//Create a capped collection that will not exceed 100 bytes
IDBCollection col4 = database.CreateCollection("collectionName", capped:true, size:100);

//Create a capped collection that will not exceed 100 bytes, and will contain no more than 5 documents
IDBCollection col5 = database.CreateCollection("collectionName", capped:true, size:100, max:5);

```