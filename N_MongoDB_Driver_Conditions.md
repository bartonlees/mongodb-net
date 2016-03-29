# Summary #
Fluent validation of (parameter) pre- and post-conditions.
# Remarks #
<pre>
Copyright (c) 2009 S. van Deursen<br>
The CuttingEdge.Conditions library<br>
<br>
To contact me, please visit my blog at http://www.cuttingedge.it/blogs/steven/<br>
<br>
Copyright (c) 2009 S. van Deursen<br>
<br>
Permission is hereby granted, free of charge, to any person obtaining a copy of this software and<br>
associated documentation files (the "Software"), to deal in the Software without restriction, including<br>
without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell<br>
copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the<br>
following conditions:<br>
<br>
The above copyright notice and this permission notice shall be included in all copies or substantial<br>
portions of the Software.<br>
<br>
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT<br>
LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO<br>
EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER<br>
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE<br>
USE OR OTHER DEALINGS IN THE SOFTWARE.<br>
</pre>


# Enumerations #
| **Enumeration** | **Summary** |
|:----------------|:------------|
| [ConstraintViolationType](T_MongoDB_Driver_Conditions_ConstraintViolationType.md) | This enumeration is used to determine the type of exception the validator should throw. |


# Classes #
| **Class** | **Summary** |
|:----------|:------------|
| [CollectionHelpers](T_MongoDB_Driver_Conditions_CollectionHelpers.md) | Helper methods for the Collection validation methods of the [ValidatorExtensions](T_MongoDB_Driver_Conditions_ValidatorExtensions.md) methods. |
| [Condition](T_MongoDB_Driver_Conditions_Condition.md) | Entry point methods to start validating pre- and postconditions. |
| [ConditionValidator`1](T_MongoDB_Driver_Conditions_ConditionValidator_1.md) |             |
| [DefaultComparer`1](T_MongoDB_Driver_Conditions_DefaultComparer_1.md) |             |
| [EnsuresValidator`1](T_MongoDB_Driver_Conditions_EnsuresValidator_1.md) |             |
| [PostconditionException](T_MongoDB_Driver_Conditions_PostconditionException.md) | The exception that is thrown when a method's postcondition is not valid. |
| [RequiresValidator`1](T_MongoDB_Driver_Conditions_RequiresValidator_1.md) |             |
| [SR](T_MongoDB_Driver_Conditions_SR.md) | String Resource helper class |
| [StringificationExtensions](T_MongoDB_Driver_Conditions_StringificationExtensions.md) | An internal helper class with extension methods for converting an object to a string representation. |
| [Throw](T_MongoDB_Driver_Conditions_Throw.md) | All throw logic is factored out of the public extension methods and put in this helper class. This allows more methods to be a candidate for inlining by the JIT compiler. |
| [ValidatorExtensions](T_MongoDB_Driver_Conditions_ValidatorExtensions.md) |             |
