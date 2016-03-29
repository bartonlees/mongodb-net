# Summary #
Well-Known Query Operations

# Members #
## Fields ##
| **Name** | **Literal** | **Comments** |
|:---------|:------------|:-------------|
| All      | $all        | The $all operator is similar to $in, but instead of matching any value in the specified array all values in the array must be matched |
| Divisor  | divisor     | $mod divisor |
| Exists   | $exists     | Check for existence (or lack thereof) of a field. |
| Gt       | $gt         | Greater than |
| Gte      | $gte        | Greater than or equal to |
| In       | $in         | The $in operator is analogous to the SQL IN modifier, allowing you to specify an array of possible matches. |
| Lt       | $lt         | Less than    |
| Lte      | $lte        | Less than or equal to |
| Mod      | $mod        | The $mod operator allows you to do fast modulo queries to replace a common case for where clauses. |
| Ne       | $ne         | Not equals   |
| Nin      | $nin        | The $nin operator is similar to $in except that it selects objects for which the specified field does not have any value in the specified array. |
| Remainder | remainder   | The $mod operator allows you to do fast modulo queries to replace a common case for where clauses. |
| Size     | $size       | The $size operator matches any array with the specified number of elements |
