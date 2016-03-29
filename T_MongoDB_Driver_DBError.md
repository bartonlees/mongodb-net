# Summary #
Convenience wrapper for error responses from the database

# Members #
## Methods ##
### Constructors ###
|DBError(MongoDB.Driver.IDBObject)|
|:--------------------------------|
### Throw ###
|void Throw(string context)       |
### ToCode ###
|Code ToCode(string error)        ||===== Returns =====|
the code, or Code.NoError if a code cannot be parsed
