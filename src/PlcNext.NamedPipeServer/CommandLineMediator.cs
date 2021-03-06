﻿#region Copyright
///////////////////////////////////////////////////////////////////////////////
//
//  Copyright (c) Phoenix Contact GmbH & Co KG
//  This software is licensed under Apache-2.0
//
///////////////////////////////////////////////////////////////////////////////
#endregion

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Nito.AsyncEx;
using PlcNext.Common.Tools;
using PlcNext.Common.Tools.UI;
using PlcNext.NamedPipeServer.CommandLine;
using PlcNext.NamedPipeServer.Communication;
using PlcNext.NamedPipeServer.Data;
using MessageReceivedEventArgs = PlcNext.NamedPipeServer.CommandLine.MessageReceivedEventArgs;

namespace PlcNext.NamedPipeServer
{
    internal class CommandLineMediator : IDisposable
    {
        private readonly IMessageParser messageParser;
        private readonly ICommandLineFacade commandLine;
        private readonly ICliServer server;
        private readonly IMessageSender messageSender;
        private readonly ILog logger;
        private readonly ConcurrentDictionary<Task,Task> executingCommands = new ConcurrentDictionary<Task, Task>();

        public CommandLineMediator(IMessageParser messageParser, ICommandLineFacade commandLine, ICliServer server, IMessageSender messageSender, ILog logger)
        {
            this.messageParser = messageParser;
            this.commandLine = commandLine;
            this.server = server;
            this.messageSender = messageSender;
            this.logger = logger;
            messageParser.CommandIssued += MessageParserOnCommandIssued;
            messageParser.CommandCanceled += MessageParserOnCommandCanceled;
            messageParser.SuicideIssued += MessageParserOnSuicideIssued;
            messageParser.HandshakeCompleted += MessageParserOnHandshakeCompleted;
            commandLine.MessageReceived += CommandLineOnMessageReceived;
            commandLine.ProgressReceived += CommandLineOnProgressReceived;
            commandLine.InfiniteProgressStarted += CommandLineOnInfiniteProgressStarted;
        }

        private void CommandLineOnInfiniteProgressStarted(object sender, InfiniteProgressStartedEventArgs e)
        {
            messageSender.SendMessage(e.Message, MessageType.Information, e.Command);
        }

        private void CommandLineOnProgressReceived(object sender, ProgressReceivedEventArgs e)
        {
            messageSender.SendProgress(e.Progress);
        }

        private void CommandLineOnMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            logger.LogVerbose($"Sending message from command line: {e.MessageType} - {e.Message}");
            messageSender.SendMessage(e.Message, e.MessageType, e.Command);
        }

        private void MessageParserOnHandshakeCompleted(object sender, HandshakeEventArgs e)
        {
            logger.LogVerbose($"Send handshake reply.");
            messageSender.SendHandshakeReply(e.Success);
        }

        private async void MessageParserOnSuicideIssued(object sender, EventArgs e)
        {
            commandLine.CancelAllCommands();
            await WaitForCommandsToFinish().ConfigureAwait(false);
            server.StopServer();

            async Task WaitForCommandsToFinish()
            {
                await Task.WhenAll(executingCommands.Keys.ToArray()).ConfigureAwait(false);
            }
        }

        private void MessageParserOnCommandIssued(object sender, CommandEventArgs e)
        {
            Task executingTask = commandLine.ExecuteCommand(e.Command)
                                            .ContinueWith(task =>
                                             {
                                                 AsyncAutoResetEvent waitEvent = new AsyncAutoResetEvent(false);
                                                 
                                                 messageSender.SendCommandReply(task.Result,
                                                                                () => waitEvent.Set());
                                                 waitEvent.WaitAsync().Wait();
                                             }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.Default);
            executingCommands.TryAdd(executingTask, executingTask);
            executingTask.ContinueWith(t => executingCommands.TryRemove(executingTask, out _),
                                       CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.Default);
        }

        private void MessageParserOnCommandCanceled(object sender, CommandEventArgs e)
        {
            commandLine.CancelCommand(e.Command);
        }

        public void Dispose()
        {
            messageParser.CommandIssued -= MessageParserOnCommandIssued;
            messageParser.CommandIssued -= MessageParserOnCommandCanceled;
            messageParser.SuicideIssued -= MessageParserOnSuicideIssued;
            messageParser.HandshakeCompleted -= MessageParserOnHandshakeCompleted;
            commandLine.MessageReceived -= CommandLineOnMessageReceived;
            commandLine.ProgressReceived -= CommandLineOnProgressReceived;
            commandLine.InfiniteProgressStarted -= CommandLineOnInfiniteProgressStarted;
        }
    }
}
