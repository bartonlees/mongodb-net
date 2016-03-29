# Summary #
Represents a full document that can be sent to or retrieved from a collection on the server

# Members #
## Methods ##
### Constructors ###
|Document()||===== Remarks =====|
|:---------|
This is the recommended constructor for new documents. The [State](T_MongoDB_Driver_Document#State.md) will be set to`DocumentState.Detached`.

|Document(MongoDB.Driver.Oid)|
|:---------------------------|
|Document(MongoDB.Driver.Oid, Boolean)|
|Document(System.Collections.Generic.IDictionary\_2[System.String,System.Object])|
|Document(System.String, System.Object)|
|Document(System.String, System.Object, System.String, System.Object)|
|Document(System.String, System.Object, System.String, System.Object, System.String, System.Object)|