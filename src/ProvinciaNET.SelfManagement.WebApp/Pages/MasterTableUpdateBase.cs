using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Localization;
using ProvinciaNET.SelfManagement.Core.Entities;
using ProvinciaNET.SelfManagement.WebApp.Services;
using ProvinciaNET.SelfManagement.WebApp.Shared;
using Radzen;

namespace ProvinciaNET.SelfManagement.WebApp.Pages
{
    /// <summary>
    /// Master Table Update Base Class
    /// </summary>
    /// <typeparam name="S">The service type.</typeparam>
    /// <typeparam name="T">The main type.</typeparam>
    /// <seealso cref="Microsoft.AspNetCore.Components.ComponentBase" />
    public class MasterTableUpdateBase<S, T> : ComponentBase where S : IWebApiServiceBase<T> where T : BaseEntity
    {
        /// <summary>
        /// Gets or sets the HTTP context accessor.
        /// </summary>
        /// <value>
        /// The HTTP context accessor.
        /// </value>
        [Inject]
        protected IHttpContextAccessor HttpContextAccessor { get; set; } = null!;

        /// <summary>
        /// Gets or sets the dialog service.
        /// </summary>
        /// <value>
        /// The dialog service.
        /// </value>
        [Inject]
        protected DialogService DialogService { get; set; } = null!;

        /// <summary>
        /// Gets or sets the localization resource.
        /// </summary>
        /// <value>
        /// The l.
        /// </value>
        [Inject]
        protected IStringLocalizer<LocalizationResource> L { get; set; } = null!;

        /// <summary>
        /// Gets or sets the main service.
        /// </summary>
        /// <value>
        /// The service.
        /// </value>
        [Inject]
        protected S? MainService { get; set; }

        /// <summary>
        /// Gets or sets the item identifier.
        /// </summary>
        /// <value>
        /// The item identifier.
        /// </value>
        [Parameter]
        public int Id { get; set; }

        /// <summary>
        /// The can edit variable.
        /// </summary>
        protected bool canEdit = true;

        /// <summary>
        /// The error visible variable.
        /// </summary>
        protected bool errorVisible = false;

        /// <summary>
        /// The has changes variable.
        /// </summary>
        protected bool hasChanges = false;

        /// <summary>
        /// The resource object variable.
        /// </summary>
        protected T? resource;

        /// <summary>
        /// Method invoked when the component is ready to start, having received its
        /// initial parameters from its parent in the render tree.
        /// Override this method if you will perform an asynchronous operation and
        /// want the component to refresh when that operation is completed.
        /// </summary>
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            resource = await MainService!.GetAsync(Id);
        }

        /// <summary>
        /// Submit event.
        /// </summary>
        protected async Task FormSubmit()
        {
            if (resource == null) return;

            try
            {
                resource.CreatedBy = $"{HttpContextAccessor.HttpContext?.User.Identity?.Name?.Split("\\").Last()}";
                await MainService!.UpdateAsync(Id, resource);
                DialogService.Close(resource);
            }
            catch (Exception)
            {
                canEdit = true;
                errorVisible = true;
            }
        }

        /// <summary>
        /// Cancel event.
        /// </summary>
        /// <param name="args">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        protected void CancelButtonClick(MouseEventArgs args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            DialogService.Close(null);
        }

        /// <summary>
        /// Reload event.
        /// </summary>
        /// <param name="args">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        protected async Task ReloadButtonClick(MouseEventArgs args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            hasChanges = false;
            canEdit = true;
            resource = await MainService!.GetAsync(Id);
        }
    }
}