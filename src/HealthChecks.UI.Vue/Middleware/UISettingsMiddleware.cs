using HealthChecks.UI.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Options = HealthChecks.UI.Configuration.Options;
namespace HealthChecks.UI.Middleware;

internal class UISettingsMiddleware
{
    private readonly object _uiOutputSettings;

    public UISettingsMiddleware(RequestDelegate next, IOptions<Settings> settings, Options options)
    {
        _ = next;
        _ = Guard.ThrowIfNull(settings);

        var _apiPath = options.UseRelativeApiPath ? options.ApiPath.AsRelativeResource() : options.ApiPath;
        var _webhooksPath = options.UseRelativeWebhookPath ? options.WebhookPath.AsRelativeResource() : options.WebhookPath;
        var _resourcePath = options.UseRelativeResourcesPath ? options.ResourcesPath.AsRelativeResource() : options.ResourcesPath;

        _uiOutputSettings = new
        {
            pollingInterval = settings.Value.EvaluationTimeInSeconds,
            headerText = settings.Value.HeaderText,
            apiPath = _apiPath,
            webhooksPath = _webhooksPath,
            resourcePath = _resourcePath,
            asideMenuOpened = options.AsideMenuOpened.ToString().ToLower(),
            pageTitle = options.PageTitle

        };
    }

    public Task InvokeAsync(HttpContext context) => context.Response.WriteAsJsonAsync(_uiOutputSettings);
}
