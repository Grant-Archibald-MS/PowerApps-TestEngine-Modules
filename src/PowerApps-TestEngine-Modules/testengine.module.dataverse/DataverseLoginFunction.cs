// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using Microsoft.PowerFx.Types;
using Microsoft.PowerFx;
using Microsoft.Extensions.Logging;
using Microsoft.PowerApps.TestEngine.TestInfra;
using Microsoft.PowerApps.TestEngine.Config;

namespace testengine.module
{
    /// <summary>
    /// This sleep test execution for the defined time in milliseconds
    /// </summary>
    public class DataverseLoginFunction : ReflectionFunction
    {
        private readonly ILogger _logger;
        private readonly ITestState _state;
        private readonly ITestInfraFunctions _testInfraFunctions;

        public DataverseLoginFunction(ILogger logger, ITestInfraFunctions testInfraFunctions, ITestState state)
            : base("DataverseLogin", FormulaType.Blank)
        {
            _logger = logger;
            _state = state;
            _testInfraFunctions = testInfraFunctions;
        }

        public BlankValue Execute()
        {
            _logger.LogInformation("------------------------------\n\n" +
                "Executing Dataverse Login function.");

            _testInfraFunctions.GoToUrlAsync(Environment.GetEnvironmentVariable("EnvironmentUrl")).Wait();

            _logger.LogInformation("Successfully finished executing Dataverse Login function.");

            return FormulaValue.NewBlank();
        }
    }
}

