# Introduction #

MongoDB objects can be mapped to URIs for convenient interaction between relative and non-relative object identification. It also provides a clean structure for internal driver representations. The mapping itself is straight forward and follows the logical nesting of the basic business objects:

```
mongo://hostname:port/database/collection/index
```

**Please Note** the "mongo://" URI scheme was invented only for use in this driver. Although I can see it as being a candidate for wider (and perhaps even official) adoption, it does not yet exist outside of this driver.

# Absolute vs. Relative #
Absolute URIs are convenient for explicitly specifying a MongoDB object:
> i.e. The index named "mykey" on the collection named "clients" in the database named  "financial" on the MongoDB server running on the "somehost" machine and port "27017"

The driver leverages this precision by storing an absolute URI for each active business object (IServer, IDatabase, IDBCollection, and IDBCollectionIndex). However, relative URIs are also supported for convenience and intuitive operations in code.

Absolute operations:

```
IServer server = Mongo.GetServer("mongo://somehost:27017");
IDatabase database = server.GetDatabase("mongo://somehost:27017/database");
ICollection collection = database.GetCollection("mongo://somehost:27017/database/collection");
```

Relative operations:

```
IServer server = Mongo.GetServer("mongo://somehost");
IDatabase database = server.GetDatabase("database");
ICollection collection = database.GetCollection("collection");
```

Relative operations with indexing operators:
```
ICollection collection = Mongo["mongo://somehost"]["database"]["collection"];
```

# URI and string signatures #
Any function that queries for a remote MongoDB object representation has two parallel signatures. One signature will take a `System.Uri` type and the other will take a `System.string` type. This is done for convenience. Internally, everything is represented as URIs for clean manipulation of namespaces. When you use the `string` version, it is parsed as a URI (either absolute or relative) and then sent to the URI version of the function.

# Dotted collection names #
MongoDB supported dotted collection names like "my.collection" which, in other drivers, required custom validation and handling as there is not much distinction between "colname.subcolname" and "database.colname" in the namespace system. In this driver, this is cleanly handled as "database/colname.subcolname" and then transformed on transmission to suit the requirements of the MongoDB server.