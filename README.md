# PowerApps TestEngine Modules

Sample Extensions modules for the Power Apps Test Engine that extend custom Power Fx and Networking Requests.

## Getting Started

1. Clone the repository

```pwsh
git clone --recurse-submodules git://github.com/Grant-Archibald-MS/PowerApps-TestEngine-Modules.git
```

1. Enable the Module support. This is currently in a git branch (testengine-modules)

```pwsh
cd PowerApps-TestEngin-Modules\PowerApps-TestEngine
git checkout testengine-modules
```

1. Build the solutions

```pwsh
cd src\PowerApps-TestEngine-Modules
dotnet build
```

## Run a sample

Get the values for your environment and tenant id from the [Power Apps Portal](http://make.powerapps.com). See [Get the session ID for Power Apps](https://learn.microsoft.com/power-apps/maker/canvas-apps/get-sessionid#get-the-session-id-for-power-apps-makepowerappscom) for more information.

### Pause

From the main folder of the cloned repository. To run this sample the button clicker solution must be loaded into the environment you waht to test.

```pwsh
$env:user1Email = "test@contoto.com"
$env:user1Password = "XXXXXXXXXXXXXXXXXXXXXXX"
cd PowerApps-TestEngine\src\PowerAppsTestEngine
dotnet run -- -i ..\..\..\samples\pause\testPlan.fx.yaml -e 12345678-1234-1234-1234-1234567890ab -t 11111111-2222-3333-4444-555555555555
```
