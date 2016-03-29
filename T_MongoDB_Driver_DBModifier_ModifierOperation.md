# Summary #
Well-Known Modifying commands

# Members #
## Fields ##
| **Name** | **Literal** | **Comments** |
|:---------|:------------|:-------------|
| Add      | $add        | ???          |
| AddToSet | $addToSet   | Adds value to the array only if its not in the array already. |
| Each     | $each       | Helper field for array operations |
| Inc      | $inc        | increments field by the number value if field is present in the object, otherwise sets field to the number value. |
| Pop      | $pop        | removes the last/first element in an array. v1.1+ |
| Pull     | $pull       | removes all occurrences of value from field, if field is an array. If field is present but is not an array, an error condition is raised. |
| PullAll  | $pullAll    | removes all occurrences of each value in value\_array from field, if field is an array. If field is present but is not an array, an error condition is raised. |
| Push     | $push       | Appends value to field, if field is an existing array, otherwise sets field to the array [value](value.md) if field is not present. If field is present but is not an array, an error condition is raised. |
| PushAll  | $pushAll    | appends each value in value\_array to field, if field is an existing array, otherwise sets field to the array value\_array if field is not present. If field is present but is not an array, an error condition is raised. |
| Set      | $set        | sets field to value. All datatypes are supported with $set. |
| Unset    | $unset      | Deletes a given field. v1.3+ |
