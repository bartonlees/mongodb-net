# Features #

  * BSON serialization/deserialization <font color='orange'><code>CC</code></font>
  * Basic Operations <font color='darkorange'><code>IP</code></font>
    * [Server](IServer.md) <font color='darkorange'><code>IP</code></font>
      * [Connection Options](BindingExamples.md) <font color='darkorange'><code>IP</code></font>
        * [Single Server](BindingExamples.md) <font color='green'><code>UT</code></font>
        * [Pair Mode](BindingExamples.md) <font color='orange'><code>CC</code></font>
          * Readonly Mode <font color='red'><code>NS</code></font>
          * Slave-Only Mode (for Debugging, etc.) <font color='red'><code>NS</code></font>
        * Automatic Reconnection `*` <font color='darkorange'><code>IP</code></font>
          * Buffer Pooling `*` <font color='darkorange'><code>IP</code></font>
          * Advanced connection management `*` <font color='darkorange'><code>IP</code></font>
            * master-server `*` <font color='darkorange'><code>IP</code></font>
            * replica pair `*` <font color='red'><code>NS</code></font>
            * `Option_SlaveOk` `*` <font color='red'><code>NS</code></font>
      * List Databases <font color='green'><code>UT</code></font>
      * Drop Database <font color='green'><code>UT</code></font>
      * Administration <font color='darkorange'><code>IP</code></font>
        * Database Profiling <font color='darkorange'><code>IP</code></font>
          * set/get profiling level <font color='darkorange'><code>IP</code></font>
          * get profiling info <font color='darkorange'><code>IP</code></font>
        * Validate a collection <font color='red'><code>NS</code></font>
    * [Database](IDatabase.md) <font color='darkorange'><code>IP</code></font>
      * Name <font color='orange'><code>CC</code></font>
      * List Collections <font color='orange'><code>CC</code></font>
      * [Create Collection](IDatabase#Creating_a_new_Collection.md) <font color='orange'><code>CC</code></font>
      * Retrieve Collection <font color='orange'><code>CC</code></font>
        * Strict Option mode <font color='darkorange'><code>IP</code></font>
      * Drop Database <font color='orange'><code>CC</code></font>
      * Execute Command <font color='orange'><code>CC</code></font>
      * Close (logical) Database <font color='darkorange'><code>IP</code></font>
      * Command Support <font color='darkorange'><code>IP</code></font>
        * Admin Only <font color='orange'><code>CC</code></font>
    * [Collection](IDBCollection.md) <font color='darkorange'><code>IP</code></font>
      * Drop Collection <font color='orange'><code>CC</code></font>
      * [Retrieve Document(s)](IDBCollection#Retrieve_Document(s).md) <font color='darkorange'><code>IP</code></font>
        * [Cursor Support](IDBCollection#Using_a_cursor.md) <font color='orange'><code>CC</code></font>
          * **`IDisposable` implementation for use in `using` blocks** <font color='orange'><code>CC</code></font>
          * Batching via `OP_GET_MORE` operation <font color='darkorange'><code>IP</code></font>
          * Tracking and closing cursors via `OP_KILL_CURSORS` <font color='darkorange'><code>IP</code></font>
          * Tailable cursor support `*`
        * **[Strongly-Typed Lambda Queries](IDBCollection#Strongly_Typed_Lambda_Queries.md)** <font color='orange'><code>CC</code></font>
      * Insert Document(s) <font color='orange'><code>CC</code></font>
      * Remove Document(s) <font color='orange'><code>CC</code></font>
      * Modify Document(s) (Remotely) <font color='darkorange'><code>IP</code></font>
      * Replace Existing Remote Document(s) <font color='darkorange'><code>IP</code></font>
      * Replace/Insert Remote Document(s) (Repsert) <font color='darkorange'><code>IP</code></font>
      * Count Documents(s) <font color='green'><code>UT</code></font>
      * List Indexes <font color='orange'><code>CC</code></font>
      * Create Index <font color='green'><code>UT</code></font>
    * [Index](IDBIndex.md) <font color='darkorange'><code>IP</code></font>
      * Drop Index <font color='orange'><code>CC</code></font>
      * Get Index Details <font color='orange'><code>CC</code></font>
  * Handle query errors <font color='darkorange'><code>IP</code></font>
  * Represent all strings in UTF-8 <font color='orange'><code>CC</code></font>
  * Higher Level Features
    * hint
    * explain
    * count
    * $where
  * **Native .NET API**
    * **Interface-Based business objects**
    * **Native, IDisposable-based .NET Networking**
    * **[MSDN-Style Documentation](http://www.codeplex.com/Sandcastle) for the public API**
    * **Written in C# v4.0**
    * **Unit Tests to ensure code quality and stability.**
    * **[Familiar Syntax](http://msdn.microsoft.com/en-us/library/ms229042.aspx) for .NET developers**
    * **Use [System.Configuration](http://msdn.microsoft.com/en-us/library/system.configuration.aspx) (app.config) files for settings rather than environment variables.** <font color='darkorange'><code>IP</code></font>
  * **[URI representations](UriMapping.md) of server-side objects** <font color='orange'><code>CC</code></font>
  * **Optional bridge to JSON.NET's BSON readers/writers for "over the wire" objects** <font color='darkorange'><code>IP</code></font>
  * **WPF-Based [MongoDBExplorer](MongoDBExplorer.md) GUI to exercise functionality and provide Windows-style** MongoDB management <font color='darkorange'><code>IP</code></font>
  * **Linq to MongoDB** <font color='red'><code>NS</code></font>
  * **log4net integration** <font color='red'><code>NS</code></font>