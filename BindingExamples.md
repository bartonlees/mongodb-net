# Bindings #

MongoDB.NET objects typically act as a proxy for their remote counterparts on the server. We will refer to the process of associating a local proxy object with a remote server object as  'binding'.

## Simple Bindings ##
Typically you will be connecting to one and only one server in your application. But even if you are dealing with multiple connections to multiple individual servers, then you have the simple binding case.

The following represent binding to a local server running on a default port and are functionally equivalent. The URIs used in some of these examples is described in more detail [here](UriMapping.md).

```
//Local Server
IServer s1 = Mongo.GetServer("mongo://localhost");

//Local Server via Loopback address
IServer s2 = Mongo.GetServer("mongo://127.0.0.1");

//Local Server with explicit port
IServer s3 = Mongo.GetServer("mongo://localhost:27017");

//Local Server with IPv6 address
IServer s4 = Mongo.GetServer("mongo://[::1]")

//Local Server via URI
Uri uri = new Uri("mongo://127.0.0.1:27017");
IServer s5 = Mongo.GetServer(uri);

//Explicit Server Binding with hostname and port (no URI required)
IServer s6 = Mongo.GetServer("localhost", 27017);
```


### Default Server ###

In most casual scenarios, the MongoDB instance you are connecting to will reside on the same machine that you are connecting from. This is certainly true for developer test cases. Thus:

```
IServer server = Mongo.DefaultServer;
```

Would give you a proxy object that would connect to the default server as specified by the application's config file. Unless explicitly overridden, this will be functionally equivalent to:

```
IServer server = Mongo.GetServer("mongo://localhost:27017");
```

### Database Quick Connect ###
While the ability to explicitly specify your server bindings allows for more complicated scenarios, it is overkill for most cases. Thus you can also do the following:

```
IDatabase myDatabase = Mongo.GetDatabase("mongo://localhost:27017/mydatabase");
```

For the test suites, another convenience property is defined:
```
IDatabase testDatabase = Mongo.DefaultDatabase;
//Equivalent to Mongo.GetDatabase("mongo://localhost:27017/test") by default
```

### Collection Quick Connect ###
**The feature in this section is not yet implemented**

Similarly, you can direct connect to a Collection:

```
ICollection myCollection = Mongo.GetCollection("mongo://localhost:27017/mydatabase/mycollection");
```

## Pair Bindings ##
**The approach to this feature has changed. The documentation will be updated once the code is finalized**

MongoDB supports [Replica Pairs](http://www.mongodb.org/display/DOCS/Replica+Pairs), and this driver supports them via a Server Pair Binding:

```
ServerBinding peanutButter = new ServerBinding("peanutbutter", 27017);
ServerBinding jelly = new ServerBinding("jelly", 27017);
IServer s = Mongo.GetServer(new ServerPairBinding(peanutButter, jelly));
```