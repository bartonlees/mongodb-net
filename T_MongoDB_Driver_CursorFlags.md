# Summary #
Bitwise Cursor option flags

# Members #
## Values ##
| **Name** | **Literal** | **Comments** |
|:---------|:------------|:-------------|
| None     | 0           | No flags are specified |
| TailableCursor | 2           | Tailable Cursor |
| SlaveOK  | 4           | Whether or not connecting to a Slave is OK |
| NoCursorTimeout | 16          | Oplog replay: 8 (internal replication use only - drivers should not implement) |
