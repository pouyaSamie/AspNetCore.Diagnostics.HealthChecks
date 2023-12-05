using HealthChecks.UI.Configuration;
using HealthChecks.UI.Vue;

namespace HealthChecks.UI.Core;

internal static class UIResourceExtensions
{
    public static UIResource GetMainUI(this IEnumerable<UIResource> resources)
    {
        return resources
            .First(r => r.ContentType == ContentType.HTML && r.FileName == Keys.HEALTHCHECKSUI_MAIN_UI_RESOURCE);
    }

    public static ICollection<UIStylesheet> GetCustomStylesheets(this UIResource resource, Options options)
    {
        var styleSheets = new List<UIStylesheet>();

        if (options.CustomStylesheets.Count == 0)
        {
            resource.Content = resource.Content.Replace(Keys.HEALTHCHECKSUI_STYLESHEETS_TARGET, string.Empty);
            return styleSheets;
        }

        foreach (var stylesheet in options.CustomStylesheets)
        {
            styleSheets.Add(UIStylesheet.Create(options, stylesheet));
        }

        var htmlStyles = styleSheets.Select
            (s =>
        {
            var linkHref = options.UseRelativeResourcesPath ? s.ResourcePath.AsRelativeResource() : s.ResourcePath;
            return $"<link rel='stylesheet' href='{linkHref}'/>";
        });

        resource.Content = resource.Content.Replace(Keys.HEALTHCHECKSUI_STYLESHEETS_TARGET,
            string.Join("\n", htmlStyles));

        return styleSheets;
    }
}
