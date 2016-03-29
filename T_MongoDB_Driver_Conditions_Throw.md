# Summary #
All throw logic is factored out of the public extension methods and put in this helper class. This allows more methods to be a candidate for inlining by the JIT compiler.

# Members #