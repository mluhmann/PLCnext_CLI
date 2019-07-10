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
using Test.PlcNext.SystemTests.Tools;
using Test.PlcNext.Tools;
using Test.PlcNext.Tools.Abstractions.Mocked;

namespace Test.PlcNext.SystemTests.StepDefinitions
{
    public class MockedSystemTestBase : SystemTestBase
    {
        public MockedSystemTestBase() : base(new SystemTestContext(new MockedFileSystemAbstraction(),
                                                 new MockedDownloadServiceAbstraction(),
                                                 new MockedProcessManagerAbstraction(),
                                                 new MockedUserInterfaceAbstraction(),
                                                 new MockedEnvironmentServiceAbstraction(),
                                                 new MockedExceptionHandlerAbstraction(),
                                                 new MockedGuidAbstraction(),
                                                 new MockedCMakeConversationAbstraction()))
        {
        }
    }
}