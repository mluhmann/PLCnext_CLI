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

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA2213:'OutgoingMessage' contains field 'communicationProtocol' that is of IDisposable type 'NamedPipeCommunicationProtocol', but it is never disposed. Change the Dispose method on 'OutgoingMessage' to call Close or Dispose on this field.", Justification = "Disposed by owner.", Scope = "member", Target = "~F:PlcNext.NamedPipeServer.Communication.NamedPipeCommunicationProtocol.OutgoingMessage.communicationProtocol")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA2213:'OutgoingMessage' contains field 'writeStream' that is of IDisposable type 'PipeStream', but it is never disposed. Change the Dispose method on 'OutgoingMessage' to call Close or Dispose on this field.", Justification = "Disposed by owner.", Scope = "member", Target = "~F:PlcNext.NamedPipeServer.Communication.NamedPipeCommunicationProtocol.OutgoingMessage.writeStream")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA2000:Call System.IDisposable.Dispose on object created by 'new CancellationTokenSource()' before all references to it are out of scope.", Justification = "Is disposed in continuation task in finally block. Dont know how to dispose in case of cancellation.", Scope = "member", Target = "~M:PlcNext.NamedPipeServer.CommandLine.CommandLineFacade.ExecuteCommand(PlcNext.NamedPipeServer.Data.Command)~System.Threading.Tasks.Task{PlcNext.NamedPipeServer.Data.Command}")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1031:Modify 'StartAndWaitForInterProcessUpdateInternal' to catch a more specific exception type, or rethrow the exception.", Justification = "Logging would lead to another exception. Exception is irrelevant.", Scope = "member", Target = "~M:PlcNext.NamedPipeServer.Communication.InterProcessUpdateReceiver.StartAndWaitForInterProcessUpdateInternal")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1031:Modify 'CompleteMessage' to catch a more specific exception type, or rethrow the exception.", Justification = "Exception is logged. It is irrelevant.", Scope = "member", Target = "~M:PlcNext.NamedPipeServer.Communication.NamedPipeCommunicationProtocol.IncomingMessageQueue.CompleteMessage(PlcNext.NamedPipeServer.Communication.NamedPipeCommunicationProtocol.IncomingMessage,System.Guid,System.Byte)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA2000:Use recommended dispose pattern to ensure that object created by 'new IncomingMessage(messageGuid, messageStream, log)' is disposed on all paths. If possible, wrap the creation within a 'using' statement or a 'using' declaration. Otherwise, use a try-finally pattern, with a dedicated local variable declared before the try region and an unconditional Dispose invocation on non-null value in the 'finally' region, say 'x?.Dispose()'. If the object is explicitly disposed within the try region or the dispose ownership is transfered to another object or method, assign 'null' to the local variable just after such an operation to prevent double dispose in 'finally'.", Justification = "Checked and disposed in all execution paths.", Scope = "member", Target = "~M:PlcNext.NamedPipeServer.Communication.NamedPipeCommunicationProtocol.IncomingMessageQueue.StartReading")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA2000:Call System.IDisposable.Dispose on object created by 'out OutgoingMessage message' before all references to it are out of scope.", Justification = "Checked and disposed in all execution paths.", Scope = "member", Target = "~M:PlcNext.NamedPipeServer.Communication.NamedPipeCommunicationProtocol.OutgoingMessageQueue.ResendMessage(System.Guid)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1031:Modify 'WaitForFirstMessage' to catch a more specific exception type, or rethrow the exception.", Justification = "Needs to be catched as the code is executed in own Thread.", Scope = "member", Target = "~M:PlcNext.NamedPipeServer.Communication.NamedPipeCommunicationProtocol.OutgoingMessageQueue.WaitForFirstMessage")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA2000:Call System.IDisposable.Dispose on object created by 'NamedPipeCommunicationProtocol.Connect(serverAddress, streamFactory,' before all references to it are out of scope.", Justification = "Disposed by DI container.", Scope = "member", Target = "~M:PlcNext.NamedPipeServer.Communication.NamedPipeInstanceCommunicationChannel.OpenChannel(System.String,PlcNext.Common.Tools.IO.StreamFactory,Autofac.IContainer,PlcNext.Common.Tools.UI.ILog,System.Threading.CancellationToken)~System.Threading.Tasks.Task{PlcNext.NamedPipeServer.Communication.NamedPipeInstanceCommunicationChannel}")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1031:Modify 'StartHeartbeat' to catch a more specific exception type, or rethrow the exception.", Justification = "Needs to be catched as the code is executed in own Thread.", Scope = "member", Target = "~M:PlcNext.NamedPipeServer.Communication.ThreadingHeart.StartHeartbeat")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1031:Modify 'ExecuteTimer' to catch a more specific exception type, or rethrow the exception.", Justification = "Needs to be catched as the code is executed in own Thread.", Scope = "member", Target = "~M:PlcNext.NamedPipeServer.Tools.HighResolutionTimer.ExecuteTimer")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1308:In method '.ctor', replace the call to 'ToLowerInvariant' with 'ToUpperInvariant'.", Justification = "Usage enforces to lower invariant.", Scope = "member", Target = "~M:PlcNext.NamedPipeServer.Communication.JsonMessageSender.Message.#ctor(System.String,System.String,System.String,PlcNext.NamedPipeServer.Data.MessageType)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1031:Modify 'StartReading' to catch a more specific exception type, or rethrow the exception.", Justification = "Needs to be catched as the code is executed in own Thread.", Scope = "member", Target = "~M:PlcNext.NamedPipeServer.Communication.NamedPipeCommunicationProtocol.IncomingMessageQueue.StartReading")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "Is handled by the MessageBoard.", Scope = "member", Target = "~M:PlcNext.NamedPipeServer.AgentBased.Communication.NamedPipeConnectorAgent.StartClient(PlcNext.NamedPipeServer.AgentBased.Communication.NamedPipeClientStartRequestedMessage)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "Is handled by the MessageBoard.", Scope = "member", Target = "~M:PlcNext.NamedPipeServer.AgentBased.Communication.NamedPipeConnectorAgent.StartServer(PlcNext.NamedPipeServer.AgentBased.Communication.NamedPipeServerStartRequestedMessage)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "Is handled by the MessageBoard.", Scope = "member", Target = "~M:PlcNext.AgentBased.NamedPipeServer.Communication.NamedPipeCommunicationProtocolAgent.OnMessageReceived(System.Object,PlcNext.NamedPipeServer.Communication.MessageReceivedEventArgs)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Indepenant thread. Therefore exceptions need to be catched.", Scope = "member", Target = "~M:PlcNext.AgentBased.NamedPipeServer.Communication.NamedPipeCommunicationProtocolAgent.IncomingMessageQueue.StartReading")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Exception is logged. It is irrelevant.", Scope = "member", Target = "~M:PlcNext.AgentBased.NamedPipeServer.Communication.NamedPipeCommunicationProtocolAgent.IncomingMessageQueue.CompleteMessage(PlcNext.AgentBased.NamedPipeServer.Communication.NamedPipeCommunicationProtocolAgent.IncomingMessage,System.Guid,System.Byte)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Exception is logged. It is irrelevant.", Scope = "member", Target = "~M:PlcNext.AgentBased.NamedPipeServer.Communication.NamedPipeCommunicationProtocolAgent.IncomingMessageQueue.CompleteMessage(System.IO.Stream)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Indepenant thread. Therefore exceptions need to be catched.", Scope = "member", Target = "~M:PlcNext.AgentBased.NamedPipeServer.Communication.NamedPipeCommunicationProtocolAgent.OutgoingMessageQueue.WaitForFirstMessage")]
