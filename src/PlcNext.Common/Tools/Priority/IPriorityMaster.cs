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

namespace PlcNext.Common.Tools.Priority
{
    public interface IPriorityMaster
    {
        IReadOnlyCollection<T> SortPriorities<T>(IEnumerable<T> unsortedEnumerable) where T : IPrioritySubject;
    }
}
