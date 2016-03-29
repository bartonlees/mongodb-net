# Summary #
BSON Element Type designator

# Members #
## Values ##
| **Name** | **Literal** | **Comments** |
|:---------|:------------|:-------------|
| EOO      | 0           | End Of Object |
| NUMBER   | 1           | Number       |
| STRING   | 2           | String       |
| OBJECT   | 3           | Object       |
| ARRAY    | 4           | Array/List   |
| BINARY   | 5           | Binary data  |
| UNDEFINED | 6           | Undefined block of data |
| OID      | 7           | ObjectID     |
| BOOLEAN  | 8           | Boolean      |
| DATE     | 9           | Date         |
| NULL     | 10          | Null representation |
| REGEX    | 11          | Regular Expression |
| REF      | 12          | Reference/DBPointer (Obsolete) |
| CODE     | 13          | JavaScript Code |
| SYMBOL   | 14          | Similar to string but for languages with a distinct symbol type |
| CODE\_W\_SCOPE | 15          | Javascript code with scope |
| NUMBER\_INT | 16          | 32-bit Integer |
| TIMESTAMP | 17          | Special internal type used by MongoDB replication and sharding |
| NUMBER\_LONG | 18          | 64-bit Integer |
| MAXKEY   | 127         | Special type that compares higher than all other possible BSON element values |
| MINKEY   | 255         | Special type that compares lower than all other possible BSON element values |
