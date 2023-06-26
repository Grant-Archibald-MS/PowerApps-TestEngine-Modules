// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using Microsoft.PowerFx.Types;
using Microsoft.PowerFx;
using Microsoft.Extensions.Logging;
using Microsoft.PowerApps.TestEngine.TestInfra;
using Microsoft.PowerApps.TestEngine.Config;
using Microsoft.PowerApps.TestEngine.Reporting.Format;
using System.Text.Json;

namespace testengine.module
{
    /// <summary>
    /// This sleep test execution for the defined time in milliseconds
    /// </summary>
    public class DataverseGetFunction : ReflectionFunction
    {
        private readonly ILogger _logger;
        private readonly ITestState _state;
        private readonly ITestInfraFunctions _testInfraFunctions;

        public DataverseGetFunction(ILogger logger, ITestInfraFunctions testInfraFunctions, ITestState state)
            : base("DataverseGet", StringType.String, StringType.String, StringType.String)
        {
            _logger = logger;
            _state = state;
            _testInfraFunctions = testInfraFunctions;
        }

        public FormulaValue Execute(StringValue name, StringValue property)
        {
            _logger.LogInformation("------------------------------\n\n" +
                "Executing Dataverse Get function.");

            var variable = name.Value;

            var page = _testInfraFunctions.GetContext().Pages.First();
            string result = page.EvaluateAsync<string>($"typeof document.Dataverse === 'undefined' ? '' : document.Dataverse['{variable}']").Result;

            if ( string.IsNullOrEmpty( property.Value ) ) {
                return StringValue.New(result);
            }

            using var doc = JsonDocument.Parse(result);
            var match = doc.RootElement.EnumerateObject().FirstOrDefault(p => p.NameEquals(property.Value));

            return StringValue.New(match.Value.ToString());
        }
    }
}

