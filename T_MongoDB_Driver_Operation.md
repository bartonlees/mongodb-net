# Summary #
Specifies [IDBMessage](T_MongoDB_Driver_IDBMessage.md) operation codes

# Members #
## Values ##
| **Name** | **Literal** | **Comments** |
|:---------|:------------|:-------------|
| Reply    | 1           | Reply to a client request. will always be received and never sent |
| Msg      | 1000        | generic msg command followed by a string |
| Update   | 2001        | update document |
| Insert   | 2002        | insert new document |
| GetByOID | 2003        | is this used? |
| Query    | 2004        | query a collection |
| GetMore  | 2005        | Get more data from a query. See Cursors |
| Delete   | 2006        | Delete documents |
| KillCursors | 2007        | Tell database client is done with a cursor |
