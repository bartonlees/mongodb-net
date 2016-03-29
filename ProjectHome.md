# Migrated to [github](http://github.com/automatonic/mongodb-net) #

# What Is **mongodb-net**? #

**mongodb-net** (MongoDB.Driver.dll) is a .Net [driver](http://www.mongodb.org/display/DOCS/Drivers) for [MongoDB](http://www.mongodb.com). Initially ported from the [Java Driver](http://www.mongodb.org/display/DOCS/Java+Language+Center), it is now written entirely in C# and care has been to taken to leverage .NET language features where appropriate. Due to the nature of .NET assemblies, this work should be usable in any .NET language (C#, VB.NET, etc.)

## What features does/will **mongodb-net** support? ##
  * Strongly-typed interaction with one or more MongoDB servers from a .NET environment
  * A Windows-style WPF-based management GUI for MongoDB [Explorer](Explorer.md)
  * [More Features](Features.md)
  * [Features currently in the task list](http://code.google.com/p/mongodb-net/issues/list?can=1&q=Feature&sort=milestone&colspec=ID%20Type%20Status%20Priority%20Milestone%20Owner%20Summary)

## What is the current status? ##

Basic infrastructure is in place. I am currently [working on](http://search.twitter.com/search?q=from:devfuel+%23mongodbnet+OR+%23mongodb-net) solidifying the code, bug fixing, turning unit tests green, and fulfilling level-0 driver requirements.

**Please note:** This driver is underway, but should be considered "pre-alpha". Although a release is up and available, it is not yet production ready.

## What is the deal with the "Explorer"? ##

The explorer now [has an installer](http://code.google.com/p/mongodb-net/downloads/list) and should run on machines with .NET 4.0 installed. It is simultaneously an example of how to use MongoDB.NET (in progress), and it intends to be a GUI manager for MongoDB servers. In its current state, it should allow you to connect to a local server running on the default port and view the server/database/collection/index metadata. It can also manage database objects! Be careful, as some operations (drops, etc.) cannot be undone.

## How can I help? ##

If you are a .net developer, [grab the source code](http://code.google.com/p/mongodb-net/source/checkout), or a [binary distribution](http://code.google.com/p/mongodb-net/downloads/list) and start using the library. Feedback is welcome. It is never too early to start [squashing bugs](http://code.google.com/p/mongodb-net/issues/entry) and verifying functionality.

If you have other skills and want to help, drop me a line on [this wiki page](HowCanIHelp.md).

## Influences ##

While now a re-imagining of the Java Driver's logic and API syntax, the work of [Samus et all](http://github.com/samus/mongodb-csharp) was used as a reference and a resource.