# Remarks #
DBObjects are dynamic blocks of data for use in server transmissions.

**Example:**Simple constructor, explicit adds

```
            IDBObject o1 = new DBObject();
            o1.Add("key", "value");
            o1.Add("key2", 0);
            o1.Add("key3", true);
```


**Example:**Convenience constructor

```
            IDBObject o2 = new DBObject("key", "value");
```


**Example:**[Collection initialization](http://msdn.microsoft.com/en-us/library/bb531208.aspx)

```
            IDBObject o3 = new DBObject() 
            {
               {"key", "value"},
               {"key2", 0},
               {"key3", true}
            }
```


**Example:**Nested object

```
            IDBObject o4 = new DBObject 
            {
               {"key", new DBObject{
                 {"key2", 0},
                 {"key3", true}}
               }
            }
```


# Members #
## Methods ##
### Constructors ###
|DBModifier()||Initializes a new instance of the [DBModifier](T_MongoDB_Driver_DBModifier.md) class.|
|:-----------|

|DBModifier(System.Collections.Generic.IDictionary\_2[System.String,System.Object])|
|:---------------------------------------------------------------------------------|
|DBModifier(System.String, System.Object)                                          |
|DBObject()                                                                        ||Initializes a new instance of the [DBObject](T_MongoDB_Driver_DBObject.md) class.|

|DBObject(System.Collections.Generic.IDictionary\_2[System.String,System.Object])|
|:-------------------------------------------------------------------------------|
|DBObject(System.String, System.Object)                                          |
### AddEachToSet ###
|DBModifier AddEachToSet(string fieldName, IList list)                           ||===== Returns =====|
The DBModifier that is being built

### AddToSet ###
|DBModifier AddToSet(string fieldName, object value)||===== Returns =====|
|:--------------------------------------------------|
The DBModifier that is being built

### Append ###
|DBObject Append(string key, object val)||===== Returns =====|
|:--------------------------------------|


### Inc ###
|DBModifier Inc(string fieldName, object value)||===== Returns =====|
|:---------------------------------------------|
The DBModifier that is being built

### Pop ###
|DBModifier Pop(string fieldName, bool fromTop)||===== Returns =====|
|:---------------------------------------------|
The DBModifier that is being built

### Pull ###
|DBModifier Pull(string fieldName, object value)||===== Returns =====|
|:----------------------------------------------|
The DBModifier that is being built

### PullAll ###
|DBModifier PullAll(string fieldName, IList list)||===== Returns =====|
|:-----------------------------------------------|


### Push ###
|DBModifier Push(string fieldName, object value)||===== Returns =====|
|:----------------------------------------------|
The DBModifier that is being built

### PushAll ###
|DBModifier PushAll(string fieldName, IList list)||===== Returns =====|
|:-----------------------------------------------|
The DBModifier that is being built

### PutAll ###
|void PutAll(IDictionary&lt;string, object&gt; dbObject)|
|:------------------------------------------------------|
### Set ###
|DBModifier Set(string fieldName, object value)         ||===== Returns =====|
The DBModifier that is being built

### Unset ###
|DBModifier Unset(string fieldName, object value)||===== Returns =====|
|:-----------------------------------------------|
The DBModifier that is being built
