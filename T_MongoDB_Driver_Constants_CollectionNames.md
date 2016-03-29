# Summary #
Well-Known Collection Names

# Members #
## Fields ##
| **Name** | **Literal** | **Comments** |
|:---------|:------------|:-------------|
| Cmd      | $cmd        | Name of the virtual collection used for sending database commands to the server |
| SystemJs | system.js   | There is a special system collection called system.js that can store JavaScript function to be re-used. To store a function, you would do: db.system.js.save( { _id : "foo" , value : function( x , y ){ return x + y; } } );_id is the name of the function, and is unique per database. Once you do that, you can use foo from any JavaScript context (db.eval, $where, map/reduce) See http://github.com/mongodb/mongo/tree/master/jstests/storefunc.js for a full example |
| SystemUsers | system.users | Name of the collection that houses user information |
