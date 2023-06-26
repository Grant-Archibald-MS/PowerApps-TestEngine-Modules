// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using Microsoft.PowerFx.Types;
using Microsoft.PowerFx;
using Microsoft.Extensions.Logging;
using Microsoft.PowerApps.TestEngine.TestInfra;
using Microsoft.PowerApps.TestEngine.Config;

namespace testengine.module
{
    public class LogMessageFunction : ReflectionFunction
    {
        private readonly ILogger _logger;


        public LogMessageFunction(ILogger logger)
            : base("LogMessage", BlankType.Blank, FormulaType.String)
        {
            _logger = logger;
        }

        public BlankValue Execute(StringValue message)
        {
            _logger.LogInformation(message.Value);

            return FormulaValue.NewBlank();
        }
    }
}

