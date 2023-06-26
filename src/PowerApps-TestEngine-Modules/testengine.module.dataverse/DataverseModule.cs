// Copyright (c) Microsoft Corporation.
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
using Microsoft.PowerFx.Types;

namespace testengine.module
{
    [Export(typeof(ITestEngineModule))]
    public class DataverseModule : ITestEngineModule
    {
        public void ExtendBrowserContextOptions(BrowserNewContextOptions options, TestSettings settings)
        {

        }

        public void RegisterPowerFxFunction(PowerFxConfig config, ITestInfraFunctions testInfraFunctions, IPowerAppFunctions powerAppFunctions, ISingleTestInstanceState singleTestInstanceState, ITestState testState, IFileSystem fileSystem)
        {
            ILogger logger = singleTestInstanceState.GetLogger();
            config.AddFunction(new DataverseLoginFunction(logger, testInfraFunctions, testState));
            config.AddFunction(new DataverseExecuteFunction(logger, testInfraFunctions, testState));
            config.AddFunction(new DataverseGetFunction(logger, testInfraFunctions, testState));
            config.AddFunction(new LogMessageFunction(logger));

            config.EnableSetFunction();
            config.SymbolTable.AddVariable("Result", StringType.String);
            config.SymbolTable.EnableMutationFunctions();
            
            logger.LogInformation("Registered DataverseLoginFunction()");
        }

        public async Task RegisterNetworkRoute(ITestState state, ISingleTestInstanceState singleTestInstanceState, IFileSystem fileSystem, IPage Page, NetworkRequestMock mock)
        {
            await Task.CompletedTask;
        }
    }
}