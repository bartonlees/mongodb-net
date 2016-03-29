
# Overview #
The [`IDBCollection` interface](http://code.google.com/p/mongodb-net/source/browse/trunk/MongoDB.Driver/IDBCollection.cs) represents a [collection](http://www.mongodb.org/display/DOCS/Collections) object inside a remote [database](IDatabase.md). Methods and properties on the interface will perform actions on the remote collection and retrieve information about [indexes](IDBIndex.md). It is named `IDBCollection` instead of `ICollection` to avoid conflicting with the .NET Frameworks collection interface.

# Retrieve Document(s) #
There are a variety of ways to retrieve documents (represented by the [IDocument interface](IDocument.md) from the remote collection using the `IDBCollection` instance. Each method is tailored to a specific use case:

## Retrieve all documents in a collection ##
`IDBCollection` extends `IEnumerable<IDocument>`, and so can be used directly to retrieve all documents in the collection:

```
//Setup a collection instance
IDBCollection collection = ...

//Into a List
List<Document> documents = new List<Document>(collection);

//Iterating through
foreach (IDocument d in collection)
{
   //Do something with d
}

//Explicitly request all documents
IEnumerable<IDocument> docs = collection.Find(DBQuery.SelectAll);
```

## Retrieve exactly one document ##
There are convenience methods for dealing with cases wherein you only wish to retrieve a single document that matches a certain criteria. Typically this is done when you know the unique identification of that document (its `_id` for example).

```
//Find by a known id (typically of type Oid)
IDocument doc1 = collection.FindByID(id);

//Find one document (more on queries later)
IDocument doc2 = collection.FindOne(query);
```

## Retrieve only certain fields from a document ##
All of the major retrieval functions provide a parameter that takes a `DBFieldSet` object. By specifying this object, the returned documents will contain only the specified subset of document fields.

```
//return only fields a,b, and c
IDocument doc1 = collection.FindByID(id, new DBFieldSet("a","b","c"));

//return only field a (convenience cast)
IDocument doc1 = collection.FindByID(id, "a");

//return only field a,b, and c (convenience cast)
IDocument doc1 = collection.FindByID(id, "a,b,c");
```

### Retrieve a document subset using a query ###
MongoDB supports a fairly robust querying system. Ultimately each query is represented as a JSON object / dictionary, but some higher-level tools are available to make query writing strongly typed and intellisense-enabled.

```
//Explicitly create a DBQuery that finds all objects whose field 'a' is 1
DBQuery q = new DBQuery() {{"a",1}};

//Using the query to find documents
IEnumerable<IDocument> docs = collection.Find(q);

//Using the where-clause (javascript) helper method
IEnumerable<IDocument> docs2 = collection.Find("this.a > 3");

//Using a lambda expression 
IEnumerable<IDocument> docs3 = collection.Find(Where.Field(a => a > 3));

```

### Strongly Typed Lambda Queries ###
To allow for Intellisense-enabled, strongly-typed MongoDB queries, a Lambda expression transformation is used to generate a `DBQuery` object from the well-known syntax.

```
//Find all documents where value of "test" field is within a range
IEnumerable<IDocument> docs1 = collection.Find(Where.Field(test => test > 3 && test < 25));

//Queries that involve two fields
IEnumerable<IDocument> docs2 = collection.Find(Where.Fields((a,b) => a == 3 && b >= 5));

//Explicitly setting a field name (for interop purposes, etc.)
//(will search for objects whose 'test' field has a value of 3 (instead of 'a' field)
IEnumerable<IDocument> docs3 = collection.Find(Where.Field(a => a["test"] == 3));

//Array operations are available such as:
//Membership check (is value of field "a" found in the set 1,2,3?)
IEnumerable<IDocument> docs5 = collection.Find(Where.Field(a => a.In(1,2,3)));

```

## Using a cursor ##
A cursor allows for a set of document results to exist beyond a single request. It would be most commonly used to retrieve a large collection of documents in bite-sized batches. The `DBCursor` type implements the `IDisposable` interface to better control the lifespan of the cursor resource.

**This documentation is not yet finalized and may be subject to change**

```
//Retrieve documents using a cursor
using (DBCursor cursor = collection.GetCursor())
{
    foreach (IDocument d in cursor)
    {
      //Do something with d
    }
}
```