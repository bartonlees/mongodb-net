# Summary #
Entry point methods to start validating pre- and postconditions.

# Members #
## Methods ##
### Ensures ###
|ConditionValidator&lt;TCollection&gt; Ensures&lt;T&gt;(T value)||===== Example =====|
|:--------------------------------------------------------------|
For an example of the usage of Ensures see the overload.
|ConditionValidator&lt;TCollection&gt; Ensures&lt;T&gt;(T value, string argumentName)||===== Example =====|
The following example shows a way to use the Ensures extension method. Shown is an IObjectBuilder interface which contract states that the BuildObject method should never return null. That contract, however, is not enforced by the compiler or the runtime. To allow this contract to be validated, the ObjectBuilderValidator class is a decorator for objects implementing the IObjectBuilder interface and it ensures that the given contract is fulfilled, by checking the return value of the called BuildObject of the wrapped IObjectBuilder. using MongoDB.Driver.Conditions; public interface IObjectBuilder { /// 

&lt;summary&gt;

Builds an object.

&lt;/summary&gt;

 /// 

&lt;returns&gt;

Returns a newly built object. Will not return null.

&lt;/returns&gt;

 object BuildObject(); } public class ObjectBuilderValidator : IObjectBuilder { public object BuildObject() { object obj = wrappedObjectBuilder.BuildObject(); // When obj == null, a PostconditionException is thrown, with the following message: // "Postcondition 'the value returned by IObjectBuilder.BuildObject() should not be null' // failed." Conditions.Ensures(obj, "the value returned by IObjectBuilder.BuildObject()") .IsNotNull(); return obj; } private readonly IObjectBuilder wrappedObjectBuilder; /// 

&lt;summary&gt;

 /// Initializes a new instance of the 

&lt;see cref="ObjectBuilderValidator"/&gt;

 class. /// 

&lt;/summary&gt;

 /// 

&lt;param name="objectBuilder"&gt;

The object builder.

&lt;/param&gt;

 /// 

&lt;exception cref="ArgumentNullException"&gt;

 /// Thrown when 

&lt;paramref name="objectBuilder"/&gt;

 is a null reference. /// 

&lt;/exception&gt;

 public ObjectBuilderWrapper(IObjectBuilder objectBuilder) { // Throws a ArgumentNullException when objectBuilder == null. Condition.Requires(objectBuilder, "objectBuilder").IsNotNull(); this.wrappedObjectBuilder = objectBuilder; } } See the class for more code examples.
### Ensures ###
|ConditionValidator&lt;TCollection&gt; Ensures&lt;T&gt;(T value)||===== Example =====|
For an example of the usage of Ensures see the overload.
|ConditionValidator&lt;TCollection&gt; Ensures&lt;T&gt;(T value, string argumentName)||===== Example =====|
The following example shows a way to use the Ensures extension method. Shown is an IObjectBuilder interface which contract states that the BuildObject method should never return null. That contract, however, is not enforced by the compiler or the runtime. To allow this contract to be validated, the ObjectBuilderValidator class is a decorator for objects implementing the IObjectBuilder interface and it ensures that the given contract is fulfilled, by checking the return value of the called BuildObject of the wrapped IObjectBuilder. using MongoDB.Driver.Conditions; public interface IObjectBuilder { /// 

&lt;summary&gt;

Builds an object.

&lt;/summary&gt;

 /// 

&lt;returns&gt;

Returns a newly built object. Will not return null.

&lt;/returns&gt;

 object BuildObject(); } public class ObjectBuilderValidator : IObjectBuilder { public object BuildObject() { object obj = wrappedObjectBuilder.BuildObject(); // When obj == null, a PostconditionException is thrown, with the following message: // "Postcondition 'the value returned by IObjectBuilder.BuildObject() should not be null' // failed." Conditions.Ensures(obj, "the value returned by IObjectBuilder.BuildObject()") .IsNotNull(); return obj; } private readonly IObjectBuilder wrappedObjectBuilder; /// 

&lt;summary&gt;

 /// Initializes a new instance of the 

&lt;see cref="ObjectBuilderValidator"/&gt;

 class. /// 

&lt;/summary&gt;

 /// 

&lt;param name="objectBuilder"&gt;

The object builder.

&lt;/param&gt;

 /// 

&lt;exception cref="ArgumentNullException"&gt;

 /// Thrown when 

&lt;paramref name="objectBuilder"/&gt;

 is a null reference. /// 

&lt;/exception&gt;

 public ObjectBuilderWrapper(IObjectBuilder objectBuilder) { // Throws a ArgumentNullException when objectBuilder == null. Condition.Requires(objectBuilder, "objectBuilder").IsNotNull(); this.wrappedObjectBuilder = objectBuilder; } } See the class for more code examples.
### Requires ###
|ConditionValidator&lt;TCollection&gt; Requires&lt;T&gt;(T value)||===== Example =====|
The following example shows how to use the Requires extension method. using MongoDB.Driver.Conditions; public class Person { private int age; public int Age { get { return this.age; } set { // Throws an ArgumentOutOfRangeException when value is less than 0 Condition.Requires(value).IsGreaterOrEqual(0); this.age = value; } } } See the class for more code examples.
|ConditionValidator&lt;TCollection&gt; Requires&lt;T&gt;(T value, string argumentName)||===== Example =====|
The following example shows how to use the Requires extension method. using MongoDB.Driver.Conditions; public class Point { private readonly int x; private readonly int y; public Point(int x, int y) { // Throws an ArgumentOutOfRangeException when x is less than 0 Condition.Requires(x, "x").IsGreaterOrEqual(0); // Throws an ArgumentOutOfRangeException when y is less than 0 Condition.Requires(y, "y").IsGreaterOrEqual(0); this.x = x; this.y = y; } public int X { get { return this.x; } } public int Y { get { return this.y; } } } See the class for more code examples.
### Requires ###
|ConditionValidator&lt;TCollection&gt; Requires&lt;T&gt;(T value)||===== Example =====|
The following example shows how to use the Requires extension method. using MongoDB.Driver.Conditions; public class Person { private int age; public int Age { get { return this.age; } set { // Throws an ArgumentOutOfRangeException when value is less than 0 Condition.Requires(value).IsGreaterOrEqual(0); this.age = value; } } } See the class for more code examples.
|ConditionValidator&lt;TCollection&gt; Requires&lt;T&gt;(T value, string argumentName)||===== Example =====|
The following example shows how to use the Requires extension method. using MongoDB.Driver.Conditions; public class Point { private readonly int x; private readonly int y; public Point(int x, int y) { // Throws an ArgumentOutOfRangeException when x is less than 0 Condition.Requires(x, "x").IsGreaterOrEqual(0); // Throws an ArgumentOutOfRangeException when y is less than 0 Condition.Requires(y, "y").IsGreaterOrEqual(0); this.x = x; this.y = y; } public int X { get { return this.x; } } public int Y { get { return this.y; } } } See the class for more code examples.