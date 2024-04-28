# PowerApps TestEngine Modules

This repository is an experimental project that demonstrates sample Extensions modules for the Power Apps Test Engine that can be used to extend in the following ways:

1. User Authentication - Provide environment or browser cached credentials for login
2. Custom Power Fx and Networking Requests

## Authentication

There the following examples exist

|Approach|Description|Notes|
|--------|-----------|-----|
|Environment| Store user name and password in environment variables | Does not support MFA logins |
|Browser Cache | Interactive login and use cached browser state for later tests | Supports user accounts with MFA enabled |

[BrowserUserManagerModule](./src/PowerApps-TestEngine-Modules/testengine.user.browser/BrowserUserManagerModule.cs) and [EnvironmentUserManagerModule](./src/PowerApps-TestEngine-Modules/testengine.user.environment/EnvironmentUserManagerModule.cs) provide examples of MEF Implementations of [IUserManager](./src/Microsoft.PowerApps.TestEngine/Users/IUserManager.cs)

## Extensibility Model

The Test Engine models are based on [Managed Extensibility Framework (MEF)](https://learn.microsoft.com/dotnet/framework/mef/) .Net Assemblies.

The following interfaces can be exported using any of the following class attributed

```csharp
[Export(typeof(ITestEngineModule))]
[Export(typeof(IUserManager))]
```

## Getting Started

1. Clone the repository

```pwsh
git clone --recurse-submodules https://github.com/Grant-Archibald-MS/PowerApps-TestEngine-Modules.git
```

2. From the main folder you cloned the repository run the following commands to build the solutions

```pwsh
cd src\PowerApps-TestEngine-Modules
dotnet build
```

3. From the folder you clone the repository install Playwright Install using the following commands

```pwsh
cd PowerApps-TestEngine\bin\Debug\PowerAppsTestEngine
& .\playwright.ps1 install
```

4. Get the values for your environment and tenant id from the [Power Apps Portal](http://make.powerapps.com). See [Get the session ID for Power Apps](https://learn.microsoft.com/power-apps/maker/canvas-apps/get-sessionid#get-the-session-id-for-power-apps-makepowerappscom) for more information.

5. Before running any other samples you run the pause test to generate browser cached login credentials

```pwsh
cd PowerApps-TestEngine\bin\Debug\PowerAppsTestEngine
dotnet PowerAppsTestEngine.dll -i ..\..\..\..\samples\pause\testPlan.fx.yaml -e 12345678-1234-1234-1234-1234567890ab -t 11111111-2222-3333-4444-555555555555
```

## Run a sample

### PCF Control

Using the Creator Kit canvas application

```pwsh
dotnet PowerAppsTestEngine.dll -i ..\..\..\..\samples\creatorkit\testPlan.fx.yaml -e 12345678-1234-1234-1234-1234567890ab -t 11111111-2222-3333-4444-555555555555
```

### Networking

Using the [Automation Kit](https://aka.ms/AutomationCOE) Automation Project application from the Automation COE Main solution.

```pwsh
dotnet PowerAppsTestEngine.dll -i ..\..\..\..\samples\automationkit\testPlan.fx.yaml -e 12345678-1234-1234-1234-1234567890ab -t 11111111-2222-3333-4444-555555555555
```

### Playwright CSX Extension

Use any Playwright commands using CSharp script file (csx)

```pwsh
dotnet PowerAppsTestEngine.dll -i ..\..\..\..\samples\playwrightscript\testPlan.fx.yaml -e 12345678-1234-1234-1234-1234567890ab -t 11111111-2222-3333-4444-555555555555
```

### Sleep

Sleep test execution for a number of milliseconds

```pwsh
dotnet PowerAppsTestEngine.dll -i ..\..\..\..\samples\sleep\testPlan.fx.yaml -e 12345678-1234-1234-1234-1234567890ab -t 11111111-2222-3333-4444-555555555555
```
