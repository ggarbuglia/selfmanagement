using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using System.Globalization;

namespace ProvinciaNET.SelfManagement.WebApp.Shared
{
    public partial class CulturePicker
    {
        [Inject]
        protected IJSRuntime? JSRuntime { get; set; }

        [Inject]
        protected NavigationManager? NavigationManager { get; set; }

        [Inject]
        protected DialogService? DialogService { get; set; }

        [Inject]
        protected TooltipService? TooltipService { get; set; }

        [Inject]
        protected ContextMenuService? ContextMenuService { get; set; }

        [Inject]
        protected NotificationService? NotificationService { get; set; }

        protected string? culture;

        protected override void OnInitialized()
        {
            culture = CultureInfo.CurrentCulture.Name;
        }

        protected void ChangeCulture()
        {
            if (NavigationManager == null || culture == null) return;

            var redirect = new Uri(uriString: NavigationManager.Uri).GetComponents(UriComponents.PathAndQuery | UriComponents.Fragment, UriFormat.UriEscaped);
            var query = $"?culture={Uri.EscapeDataString(culture)}&redirectUri={redirect}";
            NavigationManager.NavigateTo("Culture/SetCulture" + query, forceLoad: true);
        }
    }
}