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
using PlcNext.Common.DataModel;

namespace PlcNext.Common.Templates
{
    internal class ForeachItemContainer
    {
        public ForeachItemContainer(string key)
        {
            Key = key;
        }

        public Entity Current { get; set; }

        public string Key { get; }
    }
}
