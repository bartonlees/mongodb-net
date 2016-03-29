# Remarks #
An`IDBCollection`is a member of an [IDatabase](T_MongoDB_Driver_IDatabase.md) and contains [IDBIndex](T_MongoDB_Driver_IDBIndex.md) instances and houses a collection of [IDocument](T_MongoDB_Driver_IDocument.md) instances that can be saved and loaded.

**Example:**Attaching to a remote collection

```
            IDatabase database = ...
            
            //GetCollection creates the named collection if it does not already exist
            IDBCollection col1 = database.GetCollection("collectionName");
            
            //Shorthand for GetCollection using array index syntax
            IDBCollection col2 = database["collectionName"];
            
            //Explicitly create a collection
            IDBCollection col3 = database.CreateCollection("collectionName");
```


**Example:**[capped collections](http://www.mongodb.org/display/DOCS/Capped+Collections)

> //Create a capped collection that will not exceed 100 bytes
> IDBCollection col4 = database.CreateCollection("collectionName", capped:true, size:100);

> //Create a capped collection that will not exceed 100 bytes, and will contain no more than 5 documents
> IDBCollection col5 = database.CreateCollection("collectionName", capped:true, size:100, max:5);


# Members #
## Methods ##
### ClearIndexCache ###
|void ClearIndexCache()||Resets the index cache.|
|:---------------------|

### DropIndex ###
|void DropIndex(IDBIndex index)|
|:-----------------------------|
### EnsureIDIndex ###
|IDBIndex EnsureIDIndex()      ||===== Returns =====|


### EnsureIndex ###
|IDBIndex EnsureIndex(DBFieldSet indexKeyFieldSet, Uri name, bool unique)||===== Returns =====|
|:-----------------------------------------------------------------------|


### GetIndex ###
|IDBIndex GetIndex(Uri indexUri)||===== Returns =====|
|:------------------------------|


### GetMore ###
|IEnumerable&lt;TElement&gt; GetMore&lt;TDoc&gt;(IDBCursor&lt;TDoc&gt; cursor)||===== Returns =====|
|:----------------------------------------------------------------------------|
The documents of this batch

### Insert ###
|void Insert(IEnumerable&lt;IDocument&gt; documents, bool checkError)|
|:-------------------------------------------------------------------|
### Query ###
|IEnumerable&lt;TElement&gt; Query&lt;TDoc&gt;(IDBCursor&lt;TDoc&gt; cursor)||===== Returns =====|
The documents of this batch

### Remove ###
|void Remove(IDocument document, bool checkError)|
|:-----------------------------------------------|
### TryInsert ###
|bool TryInsert(IEnumerable&lt;IDocument&gt; documents, bool checkError)||===== Returns =====|


### TryRemove ###
|bool TryRemove(IDocument document, bool checkError)||===== Returns =====|
|:--------------------------------------------------|


### TryUpdate ###
|bool TryUpdate(DBQuery selector, IDocument document, DBModifier modifier, bool upsert, bool multi, bool checkError)||===== Returns =====|
|:------------------------------------------------------------------------------------------------------------------|


### Update ###
|void Update(DBQuery selector, IDocument document, DBModifier modifier, bool upsert, bool multi, bool checkError)|
|:---------------------------------------------------------------------------------------------------------------|