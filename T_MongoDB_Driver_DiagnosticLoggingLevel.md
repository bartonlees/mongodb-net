# Summary #
The diagnostic logging level of the server

# Members #
## Values ##
| **Name** | **Literal** | **Comments** |
|:---------|:------------|:-------------|
| Unknown  | -1          | Unknown      |
| Off      | 0           | Also flushes any pending data to the file. |
| LogWriteOperations | 1           | Write operations should be/are logged |
| LogReadOperations | 2           | if you log reads, it will record the findOnes above and if you replay them, that will have an effect! |
| LogAllOperations | 3           | All operations should be/are logged |
