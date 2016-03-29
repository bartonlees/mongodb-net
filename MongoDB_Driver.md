# Summary #
Core driver types for connecting to a MongoDB Server
# Remarks #
This is the primary assembly needed for using the MongoDB.NET driver. This assembly is not yet set up for being put in the GAC, and so will need to be placed in the same directory of the executing assembly.

**Example:**Importing MongoDB.Driver

At the top of your .cs file:

```
//Other using statements here
using MongoDB.Driver;
```

And then make use of the [Mongo](T_MongoDB_Driver_Mongo.md) class to get a collection proxy:

```
IDBCollection coll = Mongo.GetCollection("mongo://localhost/database/myCollection");
```
Most of the standard types needed for interaction will live in the [MongoDB.Driver](N_MongoDB_Driver.md) namespace.

# Namespaces #
| **Namespace** | **Summary** |
|:--------------|:------------|
| [MongoDB.Driver](N_MongoDB_Driver.md) | Core types for connecting to a remote MongoDB Server |
| [MongoDB.Driver.Command](N_MongoDB_Driver_Command.md) | Strongly-typed MongoDB command classes |
| [MongoDB.Driver.Command.Admin](N_MongoDB_Driver_Command_Admin.md) | Administrator-only strongly-typed MongoDB command classes |
| [MongoDB.Driver.Conditions](N_MongoDB_Driver_Conditions.md) | Fluent validation of (parameter) pre- and post-conditions. |
| [MongoDB.Driver.Conversion](N_MongoDB_Driver_Conversion.md) | Endianess conversion support |
| [MongoDB.Driver.IO](N_MongoDB_Driver_IO.md) | I/O and streaming support types |