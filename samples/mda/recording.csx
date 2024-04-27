#r "Microsoft.Playwright.dll"
#r "Microsoft.Extensions.Logging.dll"
using Microsoft.Playwright;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class PlaywrightScript {
    public static void Run(IBrowserContext context, ILogger logger) {
        var page = context.Pages.First();
        
        RunSteps(page).Wait();
    }

    async static Task RunSteps(IPage page) {
        await page.GetByRole(AriaRole.Menuitem, new() { Name = "New", Exact = true }).ClickAsync();

        await page.GetByRole(AriaRole.Textbox, new() { Name = "Account Name" }).ClickAsync();

        await page.GetByRole(AriaRole.Textbox, new() { Name = "Account Name" }).FillAsync("Test 2");

        await page.GetByRole(AriaRole.Menuitem, new() { Name = "Save & Close" }).ClickAsync();

        await page.GetByRole(AriaRole.Link, new() { Name = "Test 2" }).ClickAsync(new LocatorClickOptions
        {
            Button = MouseButton.Right,
        });
    }
}