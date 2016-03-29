# Summary #
Represents the life cycle state of an [IDocument](T_MongoDB_Driver_IDocument.md)

# Members #
## Values ##
| **Name** | **Literal** | **Comments** |
|:---------|:------------|:-------------|
| None     | 0           | The document state is undefined |
| Detached | 1           | An is in this state immediately after it has been created and before it is added to a collection, or if it has been removed from a collection. |
| Unchanged | 2           | This has not changed since it was last retrieved from or saved to its collection |
| Added    | 4           | This has been added but not yet pushed to a remote collection |
| Deleted  | 8           | This has been deleted from its collection and marked deleted locally |
| Modified | 16          | This attached has been modified and not yet updated back to the database |
