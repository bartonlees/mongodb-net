# Summary #
Core types for connecting to a remote MongoDB Server
# Remarks #
This namespace defines proxy objects and helper classes to allow a remote connection to a [MongoDB Server](http://www.mongodb.org). In general, you will want to make use of the [Mongo](T_MongoDB_Driver_Mongo.md) class to bind to a server and get [IServer](T_MongoDB_Driver_IServer.md) , [IDatabase](T_MongoDB_Driver_IDatabase.md) , and [IDBCollection](T_MongoDB_Driver_IDBCollection.md) proxies. These directly correlate with server-side representations of MongoDB objects, and by using local properties and methods, you can interact with the server.

**Example:**Inserting a new document into a collection

```
IDBCollection coll = Mongo.GetDatabase("http://localhost/db").GetCollection("test");
coll.Insert(new Document() { {"a", 1}, {"b", 2}});
```


**Example:**Querying for documents that match certain criteria

```
IDBCollection coll = Mongo.GetDatabase("http://localhost/db").GetCollection("test");

//Find first document in the collection whose "a" field is 1
coll.FindOne(Where.Field(a => a == 1)); 
```



# Enumerations #
| **Enumeration** | **Summary** |
|:----------------|:------------|
| [BinaryType](T_MongoDB_Driver_BinaryType.md) | BSON type indicator byte |
| [CursorFlags](T_MongoDB_Driver_CursorFlags.md) | Bitwise Cursor option flags |
| [DBError+Code](T_MongoDB_Driver_DBError_Code.md) | Well-known error codes |
| [DiagnosticLoggingLevel](T_MongoDB_Driver_DiagnosticLoggingLevel.md) | The diagnostic logging level of the server |
| [DocumentState](T_MongoDB_Driver_DocumentState.md) | Represents the life cycle state of an [IDocument](T_MongoDB_Driver_IDocument.md)  |
| [Operation](T_MongoDB_Driver_Operation.md) | Specifies [IDBMessage](T_MongoDB_Driver_IDBMessage.md) operation codes |
| [TypeByte](T_MongoDB_Driver_TypeByte.md) | BSON Element Type designator |
| [UpdateOption](T_MongoDB_Driver_UpdateOption.md) | Flags specifying how to apply updates |


# Interfaces #
| **Interface** | **Summary** |
|:--------------|:------------|
| [IAdminOperations](T_MongoDB_Driver_IAdminOperations.md) | Represents an [IDatabase](T_MongoDB_Driver_IDatabase.md) that supports administrative operations |
| [IDatabase](T_MongoDB_Driver_IDatabase.md) |             |
| [IDBBinding](T_MongoDB_Driver_IDBBinding.md) |             |
| [IDBCollection](T_MongoDB_Driver_IDBCollection.md) |             |
| [IDBConnection](T_MongoDB_Driver_IDBConnection.md) | Represents a direct, physical database connection |
| [IDBCursor](T_MongoDB_Driver_IDBCursor.md) | Represents an unfinished query result from the server |
| [IDBCursor`1](T_MongoDB_Driver_IDBCursor_1.md) |             |
| [IDBIndex](T_MongoDB_Driver_IDBIndex.md) | Represents an index on an [IDBCollection](T_MongoDB_Driver_IDBCollection.md)  |
| [IDBMessage](T_MongoDB_Driver_IDBMessage.md) | Represents a message sent to or received from the server |
| [IDBMultiBinding](T_MongoDB_Driver_IDBMultiBinding.md) | Represents a logical database connection that may connect to multiple physical databases |
| [IDBObject](T_MongoDB_Driver_IDBObject.md) | Represents a unit of send/receive-able data |
| [IDBObjectCustom](T_MongoDB_Driver_IDBObjectCustom.md) | Represents an [IDBObject](T_MongoDB_Driver_IDBObject.md) that defines its own custom serialization to/from the wire protocol |
| [IDBRequest](T_MongoDB_Driver_IDBRequest.md) | Represents an [IDBMessage](T_MongoDB_Driver_IDBMessage.md) sent from client to server |
| [IDBResponse](T_MongoDB_Driver_IDBResponse.md) | Represents an [IDBMessage](T_MongoDB_Driver_IDBMessage.md) sent from server to client |
| [IDBResponse`1](T_MongoDB_Driver_IDBResponse_1.md) |             |
| [IDocument](T_MongoDB_Driver_IDocument.md) | Represents a full document that can be sent to or retrieved from a collection on the server |
| [IServer](T_MongoDB_Driver_IServer.md) | Represents a remote MongoDB server |
| [IServerBinding](T_MongoDB_Driver_IServerBinding.md) | Represents a logical connection to a MongoDB server |
| [IServerMultiBinding](T_MongoDB_Driver_IServerMultiBinding.md) | Represents a logical server connection that may, in fact, consist of multiple physical servers |
| [IUriComparable](T_MongoDB_Driver_IUriComparable.md) | Represents an object whose uniqueness can be determined by a Uri parameter |


# Classes #
| **Class** | **Summary** |
|:----------|:------------|
| [BuildInfo](T_MongoDB_Driver_BuildInfo.md) | Information about the current build of the bound MongoDB server |
| [Constants](T_MongoDB_Driver_Constants.md) | Constants used in MongoDB.Driver namespace |
| [Constants+CollectionNames](T_MongoDB_Driver_Constants_CollectionNames.md) | Well-Known Collection Names |
| [Constants+SpecialFieldNames](T_MongoDB_Driver_Constants_SpecialFieldNames.md) | Well-Known, Special field names |
| [Database](T_MongoDB_Driver_Database.md) | The default implementation of the database interface |
| [DBBinary](T_MongoDB_Driver_DBBinary.md) | A generic container for binary data |
| [DBBinding](T_MongoDB_Driver_DBBinding.md) | A Simple database binding. |
| [DBCode](T_MongoDB_Driver_DBCode.md) | Represents a unit of JavaScript code |
| [DBConnection](T_MongoDB_Driver_DBConnection.md) | A database port that you can connect to |
| [DBConnectionOptions](T_MongoDB_Driver_DBConnectionOptions.md) | Options for setting up and maintaining logical database connections |
| [DBCursor`1](T_MongoDB_Driver_DBCursor_1.md) | A cursor from a document query |
| [DBCursorOptions](T_MongoDB_Driver_DBCursorOptions.md) | Represents the details of a query that results in a [IDBCursor](T_MongoDB_Driver_IDBCursor.md)  |
| [DBError](T_MongoDB_Driver_DBError.md) | Convenience wrapper for error responses from the database |
| [DBFieldSet](T_MongoDB_Driver_DBFieldSet.md) | A convenience [IDBObject](T_MongoDB_Driver_IDBObject.md) to hold sets of field names for queries in the correct format |
| [DBModifier](T_MongoDB_Driver_DBModifier.md) | A [IDBObject](T_MongoDB_Driver_IDBObject.md) that is optimized for modification clauses on DB updates |
| [DBModifier+ModifierOperation](T_MongoDB_Driver_DBModifier_ModifierOperation.md) | Well-Known Modifying commands |
| [DBMultiBinding](T_MongoDB_Driver_DBMultiBinding.md) | A database binding that leverages a pair of databases |
| [DBObject](T_MongoDB_Driver_DBObject.md) |             |
| [DBObjectWrapper](T_MongoDB_Driver_DBObjectWrapper.md) | Base class for strongly typed wrappers of [IDBObject](T_MongoDB_Driver_IDBObject.md)  |
| [DBQuery](T_MongoDB_Driver_DBQuery.md) | An implementation of [IDBObject](T_MongoDB_Driver_IDBObject.md) that is optimized for query (selector) clauses on DB operations |
| [DBQuery+ConditionalOperation](T_MongoDB_Driver_DBQuery_ConditionalOperation.md) | Well-Known Query Operations |
| [DBQueryParameter](T_MongoDB_Driver_DBQueryParameter.md) | A parameter for use in Lambda-based queries |
| [DBRef](T_MongoDB_Driver_DBRef.md) | A Wrapper for a reference to another object |
| [DBSymbol](T_MongoDB_Driver_DBSymbol.md) | Type to hold a BSON symbol object |
| [DBTimestamp](T_MongoDB_Driver_DBTimestamp.md) |             |
| [DBUndefined](T_MongoDB_Driver_DBUndefined.md) | Type to represent BSON 'undefined' type |
| [Do](T_MongoDB_Driver_Do.md) | Fluent root for [IDocument](T_MongoDB_Driver_IDocument.md) modifier expressions |
| [Document](T_MongoDB_Driver_Document.md) | The public, default implementation of [IDocument](T_MongoDB_Driver_IDocument.md) be stored to and retrieved from a server |
| [DocumentFactory`1](T_MongoDB_Driver_DocumentFactory_1.md) |             |
| [Extensions](T_MongoDB_Driver_Extensions.md) | Misc utilities and extensions |
| [IAdminOperationExtensions](T_MongoDB_Driver_IAdminOperationExtensions.md) | Extension Methods for [IAdminOperations](T_MongoDB_Driver_IAdminOperations.md)  |
| [IDatabaseExtensions](T_MongoDB_Driver_IDatabaseExtensions.md) | Extension methods for [IDatabase](T_MongoDB_Driver_IDatabase.md)  |
| [IDBBindingExtensions](T_MongoDB_Driver_IDBBindingExtensions.md) | Extension methods for [IDBBinding](T_MongoDB_Driver_IDBBinding.md)  |
| [IDBCollectionExtensions](T_MongoDB_Driver_IDBCollectionExtensions.md) | Extension method implementations for convenience overrides and common collection operations |
| [IDBIndexExtensions](T_MongoDB_Driver_IDBIndexExtensions.md) | Extension methods for [IDBIndex](T_MongoDB_Driver_IDBIndex.md)  |
| [IDBObjectExtensions](T_MongoDB_Driver_IDBObjectExtensions.md) | Extension methods for [IDBObject](T_MongoDB_Driver_IDBObject.md)  |
| [IDocumentExtensions](T_MongoDB_Driver_IDocumentExtensions.md) | Extension methods for [IDocument](T_MongoDB_Driver_IDocument.md)  |
| [IServerBindingExtensions](T_MongoDB_Driver_IServerBindingExtensions.md) | Extension methods for [IServerBinding](T_MongoDB_Driver_IServerBinding.md)  |
| [IServerExtensions](T_MongoDB_Driver_IServerExtensions.md) | Extension methods for [IServer](T_MongoDB_Driver_IServer.md)  |
| [LastError](T_MongoDB_Driver_LastError.md) | The result of the GetLastError command |
| [MapReduceInfo](T_MongoDB_Driver_MapReduceInfo.md) | Details of a MapReduce operation |
| [Mongo](T_MongoDB_Driver_Mongo.md) |             |
| [MongoException](T_MongoDB_Driver_MongoException.md) | An MongoDB.Net Exception |
| [MongoException+Authentication](T_MongoDB_Driver_MongoException_Authentication.md) | An exception while authenticating with MongoDB |
| [MongoException+LastError](T_MongoDB_Driver_MongoException_LastError.md) | An exception based on the last error received from the server |
| [MongoException+Network](T_MongoDB_Driver_MongoException_Network.md) | A network level exception |
| [MongoException+Response](T_MongoDB_Driver_MongoException_Response.md) | An exceptional state that came from an [IDBResponse](T_MongoDB_Driver_IDBResponse.md)  |
| [MongoUriParser](T_MongoDB_Driver_MongoUriParser.md) | Helper class to parse specialized MongoDB [Uri](http://msdn.microsoft.com/en-us/library/System.Uri.aspx) strings |
| [Oid](T_MongoDB_Driver_Oid.md) |             |
| [Oid+Generator](T_MongoDB_Driver_Oid_Generator.md) | A helper class that generates new [Oid](T_MongoDB_Driver_Oid.md) instances |
| [ServerBinding](T_MongoDB_Driver_ServerBinding.md) |             |
| [ServerMultiBinding](T_MongoDB_Driver_ServerMultiBinding.md) | A database binding that leverages a pair of databases |
| [UriEqualityComparer`1](T_MongoDB_Driver_UriEqualityComparer_1.md) | An equality comparer that investigates the Uri associated with an object |
| [UriExtensions](T_MongoDB_Driver_UriExtensions.md) | Extension functions for [Uri](http://msdn.microsoft.com/en-us/library/System.Uri.aspx)  |
| [Where](T_MongoDB_Driver_Where.md) | The static root for fluent [DBQuery](T_MongoDB_Driver_DBQuery.md) generation |
| [WireProtocol](T_MongoDB_Driver_WireProtocol.md) | Helper methods for communication via the MongoDB Wire Protocol |
| [WireProtocolReader](T_MongoDB_Driver_WireProtocolReader.md) | Deserializes messages from the MongoDB wire protocol |
| [WireProtocolWriter](T_MongoDB_Driver_WireProtocolWriter.md) | Serializes messages via the MongoDB wire protocol |
