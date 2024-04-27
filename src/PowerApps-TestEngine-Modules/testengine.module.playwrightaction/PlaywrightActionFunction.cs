﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using Microsoft.PowerFx.Types;
using Microsoft.PowerFx;
using Microsoft.Playwright;
using Microsoft.PowerApps.TestEngine.TestInfra;
using Microsoft.Extensions.Logging;
using Microsoft.PowerApps.TestEngine.Config;

namespace testengine.module
{
    /// <summary>
    /// This will execute playwright actions for the current page
    /// </summary>
    public class PlaywrightActionFunction : ReflectionFunction
    {
        private readonly ITestInfraFunctions _testInfraFunctions;
        private readonly ITestState _testState;
        private readonly ILogger _logger;

        public PlaywrightActionFunction(ITestInfraFunctions testInfraFunctions, ITestState testState, ILogger logger)
            : base("PlaywrightAction", FormulaType.Blank, FormulaType.String, FormulaType.String)
        {
            _testInfraFunctions = testInfraFunctions;
            _testState = testState;
            _logger = logger;
        }


        public BooleanValue Execute(StringValue locator, StringValue action)
        {
            _logger.LogInformation("------------------------------\n\n" +
                "Executing PlaywrightAction function.");


            if (string.IsNullOrEmpty(locator.Value))
            {
                _logger.LogError("locator cannot be empty.");
                throw new ArgumentException();
            }

            IPage page = _testInfraFunctions.GetContext().Pages.First();

            switch (action.Value.ToLower())
            {
                case "click":
                    _logger.LogInformation("Click item");
                    _testInfraFunctions.ClickAsync(locator.Value).Wait();
                    break;
                case "navigate":
                    _logger.LogInformation("Navigate to page");
                    string url = locator.Value;
                    if ( url.IndexOf("{environment}") >=0 ) {
                        var env = _testState.GetEnvironment();
                        url = url.Replace("{environment}", env);
                    }
                    page.GotoAsync(url).Wait();
                    break;
                case "wait":
                    _logger.LogInformation("Wait for locator");
                    page.WaitForSelectorAsync(locator.Value).Wait();
                    break;
                case "exists":
                    _logger.LogInformation("Check if locator exists");
                    var result = page.Locator(locator.Value).CountAsync().Result > 0;
                    var existsMessage = $"Exists {result}";
                    _logger.LogInformation(existsMessage);
                    return BooleanValue.New(result);
                default:
                    _logger.LogError("Action not found " + action.Value);
                    throw new ArgumentException();
            }

            _logger.LogInformation("Successfully finished executing PlaywrightAction function.");

            return BooleanValue.New(true);
        }
    }
}

