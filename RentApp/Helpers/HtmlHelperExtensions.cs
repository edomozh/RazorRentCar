namespace RentApp.Helpers
{
    using Microsoft.AspNetCore.Mvc.Rendering;

    public static class HtmlHelperExtensions
    {
        public static string IsSelected(
            this IHtmlHelper html,
            string controller = null!,
            string action = null!,
            string cssClass = null!)
        {
            if (string.IsNullOrEmpty(cssClass)) cssClass = "active";

            var currentAction = (string)html.ViewContext.RouteData.Values["action"]!;
            var currentController = (string)html.ViewContext.RouteData.Values["controller"]!;

            return controller == currentController && action == currentAction ? cssClass : string.Empty;
        }
    }
}
