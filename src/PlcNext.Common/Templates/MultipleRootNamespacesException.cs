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
using PlcNext.Common.Tools;

namespace PlcNext.Common.Templates
{
    public class MultipleRootNamespacesException : FormattableException
    {
        public MultipleRootNamespacesException(IEnumerable<string> rootNamespaces) : base(string.Format(ExceptionTexts.MultipleRootNamespaces, Environment.NewLine+string.Join(", ",rootNamespaces))) 
        {
            
        }
    }
}