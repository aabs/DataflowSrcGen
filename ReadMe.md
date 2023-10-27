﻿# Welcome to DataflowSrcGen 
 
DataflowSrcGen is a C# Source Generator allowing the conversion of simple Actor based C# POCOs into Dataflow compatible classes supporting the actor model.

The aim of the source generator is to generate the boilerplate code needed to use TPL Dataflow with a regular class. So you can take something like this:

![image](https://github.com/aabs/DataflowSrcGen/assets/157775/5a921de0-f2e5-455a-ae0b-f9828d44fe66)

And add something like this to it at compile time:

![image](https://github.com/aabs/DataflowSrcGen/assets/157775/4fdd10b5-16a7-4413-81bb-4481951dbdcb)


With thanks to:

- [DataflowEx](https://github.com/gridsum/DataflowEx)
- [Bnaya.SourceGenerator.Template](https://github.com/bnayae/Bnaya.SourceGenerator.Template) (see [article](https://blog.stackademic.com/source-code-generators-diy-f04229c59e1a))
