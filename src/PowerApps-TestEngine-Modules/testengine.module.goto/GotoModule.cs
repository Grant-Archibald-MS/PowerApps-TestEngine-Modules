﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using Microsoft.PowerFx;
using System.ComponentModel.Composition;
using Microsoft.Extensions.Logging;
using Microsoft.PowerApps.TestEngine.Config;
using Microsoft.PowerApps.TestEngine.Modules;
using Microsoft.PowerApps.TestEngine.PowerApps;
using Microsoft.PowerApps.TestEngine.System;
using Microsoft.PowerApps.TestEngine.TestInfra;
using Microsoft.Playwright;

namespace testengine.module
{
    [Export(typeof(ITestEngineModule))]
    public class GotoModule : ITestEngineModule
    {
        public IPage _page;
        public void ExtendBrowserContextOptions(BrowserNewContextOptions options, TestSettings settings)
        {

        }

        public void RegisterPowerFxFunction(PowerFxConfig config, ITestInfraFunctions testInfraFunctions, IPowerAppFunctions powerAppFunctions, ISingleTestInstanceState singleTestInstanceState, ITestState testState, IFileSystem fileSystem)
        {
            ILogger logger = singleTestInstanceState.GetLogger();
            config.AddFunction(new GotoFunction(logger, testInfraFunctions));

            logger.LogInformation("Registered Goto()");
        }

        public async Task RegisterNetworkRoute(ITestState state, ISingleTestInstanceState singleTestInstanceState, IFileSystem fileSystem, IPage Page, NetworkRequestMock mock)
        {
            await Task.CompletedTask;
        }
    }
}