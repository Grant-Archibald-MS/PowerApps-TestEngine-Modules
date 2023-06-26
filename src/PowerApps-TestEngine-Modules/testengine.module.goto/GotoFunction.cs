// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using Microsoft.PowerFx.Types;
using Microsoft.PowerFx;
using Microsoft.Extensions.Logging;
using System.Threading;
using Microsoft.PowerApps.TestEngine.TestInfra;

namespace testengine.module
{
    /// <summary>
    /// This sleep test execution for the defined time in milliseconds
    /// </summary>
    public class GotoFunction : ReflectionFunction
    {
        private readonly ILogger _logger;
        private readonly ITestInfraFunctions _testInfraFunctions;

        public GotoFunction(ILogger logger, ITestInfraFunctions testInfraFunctions)
            : base("Goto", FormulaType.Blank, FormulaType.String)
        {
            _logger = logger;
            _testInfraFunctions = testInfraFunctions;
        }

        public BlankValue Execute(StringValue url)
        {
            _logger.LogInformation("------------------------------\n\n" +
                "Executing Goto function.");

            _testInfraFunctions.GoToUrlAsync(url.Value).Wait();

            _logger.LogInformation("Successfully finished executing Goto function.");

            return FormulaValue.NewBlank();
        }
    }
}

