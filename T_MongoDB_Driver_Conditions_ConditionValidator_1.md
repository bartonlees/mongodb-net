# Example #
The following example shows how to use MongoDB.Driver.Conditions. using System.Collections; using MongoDB.Driver.Conditions; public class ExampleClass { private enum StateType { Uninitialized = 0, Initialized }; private StateType currentState; public ICollection GetData(int? id, string xml, IEnumerable col) { // Check all preconditions: Condition.Requires(id, "id") .IsNotNull() // throws ArgumentNullException on failure .IsInRange(1, 999) // ArgumentOutOfRangeException on failure .IsNotEqualTo(128); // throws ArgumentException on failure Condition.Requires(xml, "xml") .StartsWith("

&lt;data&gt;

") // throws ArgumentException on failure .EndsWith("

&lt;/data&gt;

"); // throws ArgumentException on failure Condition.Requires(col, "col") .IsNotNull() // throws ArgumentNullException on failure .IsEmpty(); // throws ArgumentException on failure // Do some work // Example: Call a method that should return a not null ICollection object result = BuildResults(xml, col); // Check all postconditions: // A PostconditionException will be thrown at failure. Condition.Ensures(result, "result") .IsNotNull() .IsOfType(typeof(ICollection)); return result as ICollection; } } The following code examples shows how to extend the library with your own 'Invariant' entry point method. The first example shows a class with an Add method that validates the class state (the class invariants) before adding the Person object to the internal array and that code should throw an . using MongoDB.Driver.Conditions; public class Person { } public class PersonCollection { public PersonCollection(int capacity) { this.Capacity = capicity; } public void Add(Person person) { // Throws a ArgumentNullException when person == null Condition.Requires(person, "person").IsNotNull(); // Throws an InvalidOperationException on failure Invariants.Invariant(this.Count, "Count").IsLessOrEqual(this.Capacity); this.AddInternal(person); } public int Count { get; private set; } public int Capacity { get; private set; } private void AddInternal(Person person) { // some logic here } public bool Contains(Person person) { // some logic here return false; } } The following code example will show the implementation of the Invariants class. using System; using MongoDB.Driver.Conditions; namespace MyCompanyRootNamespace { public static class Invariants { public static ConditionValidator

&lt;T&gt;

 Invariant

&lt;T&gt;

(T value) { return new InvariantValidator

&lt;T&gt;

("value", value); } public static ConditionValidator

&lt;T&gt;

 Invariant

&lt;T&gt;

(T value, string argumentName) { return new InvariantValidator

&lt;T&gt;

(argumentName, value); } // Internal class that inherits from ConditionValidator

&lt;T&gt;

 sealed class InvariantValidator

&lt;T&gt;

 : ConditionValidator

&lt;T&gt;

 { public InvariantValidator(string argumentName, T value) : base(argumentName, value) { } protected override void ThrowExceptionCore(string condition, string additionalMessage, ConstraintViolationType type) { string exceptionMessage = string.Format("Invariant '{0}' failed.", condition); if (!String.IsNullOrEmpty(additionalMessage)) { exceptionMessage += " " + additionalMessage; } // Optionally, the 'type' parameter can be used, but never throw an exception // when the value of 'type' is unknown or unvalid. throw new InvalidOperationException(exceptionMessage); } } } }
# Members #
## Fields ##
| **Name** | **Literal** | **Comments** |
|:---------|:------------|:-------------|
| Value    |             | Gets the value of the argument. |

## Methods ##
### Equals ###
|bool Equals(object obj)||===== Returns =====|
|:----------------------|
true if the specified System.Object is equal to the current System.Object; otherwise, false.

### GetHashCode ###
|int GetHashCode()||===== Returns =====|
|:----------------|
The hash code of the current instance.

### GetType ###
|Type GetType()||===== Returns =====|
|:-------------|
The [Type](http://msdn.microsoft.com/en-us/library/System.Type.aspx) instance that represents the exact runtime type of the current instance.

### ThrowException ###
|void ThrowException(string condition)|
|:------------------------------------|
|void ThrowException(string condition, string additionalMessage, ConstraintViolationType type)|
### ThrowException ###
|void ThrowException(string condition)|
|void ThrowException(string condition, string additionalMessage, ConstraintViolationType type)|
### ToString ###
|string ToString()                    ||===== Returns =====|
A [String](http://msdn.microsoft.com/en-us/library/System.String.aspx) that represents the [ConditionValidator`1](T_MongoDB_Driver_Conditions_ConditionValidator_1.md) .
