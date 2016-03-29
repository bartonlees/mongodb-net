# Introduction #

The `IDBObject` interface is the **mongodb-net** representation of a JSON document. It is based off of the generic collection type `IDictionary<string, object>` and there are several types that make use of this interface to communicate with the MongoDB server.

## DBObject ##
`DBObject` is the primary public implementation of the `IDBObject` interface. It is used for JSON literal objects and mocking up documents for transmission to the server. There are several ways to construct `DBObject` instances:

```
//Simple constructor, explicit adds
IDBObject o1 = new DBObject();
o1.Add("key", "value");
o1.Add("key2", 0);
o1.Add("key3", true);

//Convenience constructor
IDBObject o2 = new DBObject("key", "value");

//Convenience constructor 2
IDBObject o3 = new DBObject("key", "value", "key2", 0);
```
You can also make use of [Collection initialization](http://msdn.microsoft.com/en-us/library/bb531208.aspx) thanks to our `IDictionary<string, object>` based implementation:

```
//Simple Collection initialization
IDBObject o4 = new DBObject 
{
   {"key", "value"},
   {"key2", 0},
   {"key3", true}
}

//Nested object
IDBObject o4 = new DBObject 
{
   {"key", new DBObject{
     {"key2", 0},
     {"key3", true}}
   }
}

```