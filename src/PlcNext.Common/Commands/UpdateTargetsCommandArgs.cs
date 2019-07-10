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

namespace PlcNext.Common.Commands
{
    public class UpdateTargetsCommandArgs : CommandArgs
    {
        public UpdateTargetsCommandArgs(string path)
        {
            Path = path;
        }

        public string Path { get; }
    }
}