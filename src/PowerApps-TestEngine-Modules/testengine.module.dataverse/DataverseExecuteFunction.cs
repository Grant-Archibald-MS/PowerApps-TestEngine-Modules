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
    public class DataverseExecuteFunction : ReflectionFunction
    {
        private readonly ILogger _logger;
        private readonly ITestState _state;
        private readonly ITestInfraFunctions _testInfraFunctions;

        public DataverseExecuteFunction(ILogger logger, ITestInfraFunctions testInfraFunctions, ITestState state)
            : base("DataverseExecute", BlankType.String, FormulaType.String, FormulaType.String, FormulaType.String)
        {
            _logger = logger;
            _state = state;
            _testInfraFunctions = testInfraFunctions;
        }

        public BlankValue Execute(StringValue name, StringValue method, StringValue action)
        {
            _logger.LogInformation("------------------------------\n\n" +
                "Executing Dataverse Execute function.");

            var url = $"/api/data/v9.1/{action.Value}";
            var variable = name.Value;

            var page = _testInfraFunctions.GetContext().Pages.First();
            string fetchParams = "{}";
            switch ( method.Value )
            {
                case "POST":
                    // TODO Handle parameters
                    fetchParams = $"{{method: \"POST\", headers: {{ \"Content-Type\": \"application/json\" }}, body:\"{{}}\" }}";
                    break;
            }
            page.EvaluateAsync($"fetch('{url}', {fetchParams}).then(response=>response.json()).then(data=>{{ if (typeof document.Dataverse === 'undefined') {{ document.Dataverse = {{}} }} document.Dataverse['{variable}'] = JSON.stringify(data); }})").Wait();

            //TODO handle error
            _logger.LogInformation("Successfully executing Dataverse Execute function.");

            return BlankValue.NewBlank();
        }
    }
}

