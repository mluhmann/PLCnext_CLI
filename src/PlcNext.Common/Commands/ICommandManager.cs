﻿#region Copyright
///////////////////////////////////////////////////////////////////////////////
//
//  Copyright (c) Phoenix Contact GmbH & Co KG
//  This software is licensed under Apache-2.0
//
///////////////////////////////////////////////////////////////////////////////
#endregion

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlcNext.Common.Commands
{
    public interface ICommandManager
    {
        Task<int> Execute(CommandArgs commandArgs);
    }
}
