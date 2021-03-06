﻿#region Copyright
///////////////////////////////////////////////////////////////////////////////
//
//  Copyright (c) Phoenix Contact GmbH & Co KG
//  This software is licensed under Apache-2.0
//
///////////////////////////////////////////////////////////////////////////////
#endregion


// This file is used by Code Analysis to maintain SuppressMessage 
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given 
// a specific target and scoped to a namespace, type, member, etc.

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1031:Modify 'LoadCache' to catch a more specific exception type, or rethrow the exception.", Justification = "Exception is purposefully logged and ignored.", Scope = "member", Target = "~M:PlcNext.CppParser.CppRipper.CodeModel.Includes.JsonIncludeCache.LoadCache(PlcNext.Common.Tools.FileSystem.VirtualFile)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1031:Modify 'SaveCache' to catch a more specific exception type, or rethrow the exception.", Justification = "Exception is purposefully logged and ignored.", Scope = "member", Target = "~M:PlcNext.CppParser.CppRipper.CodeModel.Includes.JsonIncludeCache.SaveCache")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1062:In externally visible method 'void ParserState.Push(ParseNode x)', validate parameter 'x' is non-null before using it. If appropriate, throw an ArgumentNullException when the argument is null or add a Code Contract precondition asserting non-null argument.", Justification = "It is checked with Trace.Assert().", Scope = "member", Target = "~M:PlcNext.CppParser.CppRipper.ParserState.Push(PlcNext.CppParser.CppRipper.ParseNode)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1721:The property name 'Rules' is confusing given the existence of method 'GetRules'. Rename or remove one of these members.", Justification = "Rules is protected and GetRules public -> no confilct.", Scope = "member", Target = "~P:PlcNext.CppParser.CppRipper.Rule.Rules")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1812:CppCodeLanguage is an internal class that is apparently never instantiated. If so, remove the code from the assembly. If this class is intended to contain only static members, make it static (Shared in Visual Basic).", Justification = "Create by DI container.", Scope = "type", Target = "~T:PlcNext.CppParser.CppRipper.CodeModel.CppCodeLanguage")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1812:CppFileParser is an internal class that is apparently never instantiated. If so, remove the code from the assembly. If this class is intended to contain only static members, make it static (Shared in Visual Basic).", Justification = "Create by DI container.", Scope = "type", Target = "~T:PlcNext.CppParser.CppRipper.CodeModel.CppFileParser")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1812:CppIncludeManager is an internal class that is apparently never instantiated. If so, remove the code from the assembly. If this class is intended to contain only static members, make it static (Shared in Visual Basic).", Justification = "Create by DI container.", Scope = "type", Target = "~T:PlcNext.CppParser.CppRipper.CodeModel.Includes.CppIncludeManager")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1812:JsonIncludeCache is an internal class that is apparently never instantiated. If so, remove the code from the assembly. If this class is intended to contain only static members, make it static (Shared in Visual Basic).", Justification = "Create by DI container.", Scope = "type", Target = "~T:PlcNext.CppParser.CppRipper.CodeModel.Includes.JsonIncludeCache")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1812:CppRipper is an internal class that is apparently never instantiated. If so, remove the code from the assembly. If this class is intended to contain only static members, make it static (Shared in Visual Basic).", Justification = "Create by DI container.", Scope = "type", Target = "~T:PlcNext.CppParser.CppRipper.CppRipper")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1710:Rename PlcNext.CppParser.CppRipper.ParseNode to end in 'Collection'.", Scope = "type", Target = "~T:PlcNext.CppParser.CppRipper.ParseNode")]