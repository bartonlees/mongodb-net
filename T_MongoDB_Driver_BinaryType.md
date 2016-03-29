# Summary #
BSON type indicator byte

# Members #
## Values ##
| **Name** | **Literal** | **Comments** |
|:---------|:------------|:-------------|
| Function | 1           | Indicates that a Function is encoded in the binary data |
| Binary   | 2           | This is the most commonly used binary subtype. The structure of the binary data (the byte**array in the binary non-terminal) must be an int32 followed by a (byte**). The int32 is the number of bytes in the repetition. |
| UUID     | 3           | Indicates that a Universal Unique IDentifier is encoded in the binary data |
| MD5      | 5           | Indicates that an MD5 Hashs is encoded in the binary data |
| UserDefined | 128         | Indicates that a User-Define format is used to encode the binary data |
