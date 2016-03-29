# Summary #
Extension methods for [IDBObject](T_MongoDB_Driver_IDBObject.md)

# Members #
## Methods ##
### IsNumber ###
|bool IsNumber(object value)||===== Returns =====|
|:--------------------------|
`true`if the specified value is a number; otherwise,`false`.

### WasError ###
|bool WasError(IDBObject o, DBError& error)||===== Returns =====|
|:-----------------------------------------|
true if this is a response from the server like {"ok":0}, false otherwise
