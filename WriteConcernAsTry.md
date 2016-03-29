# Introduction #

Instead of a writeconcern parameter (like the Java driver), mongodb-net uses alternate method calls prefaced with "try". Like standard .NET Try- methods, these will not throw exceptions. Thus, if you don't care about whether the write succeeded, etc, just use the Try version of the function and ignore the return value.