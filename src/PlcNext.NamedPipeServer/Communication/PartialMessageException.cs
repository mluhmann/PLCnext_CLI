﻿#region Copyright
///////////////////////////////////////////////////////////////////////////////
//
//  Copyright (c) Phoenix Contact GmbH & Co KG
//  This software is licensed under Apache-2.0
//
///////////////////////////////////////////////////////////////////////////////
#endregion

using System;
using System.Globalization;

namespace PlcNext.NamedPipeServer.Communication
{
    public class PartialMessageException : Exception
    {
        public PartialMessageException(Guid messageGuid) : base(string.Format(CultureInfo.InvariantCulture, ExceptionTexts.PartialMessage,messageGuid))
        {
            
        }
    }
}
