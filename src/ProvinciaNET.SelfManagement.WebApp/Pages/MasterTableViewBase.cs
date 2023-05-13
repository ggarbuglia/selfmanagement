using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Localization;
using ProvinciaNET.SelfManagement.Core.Entities;
using ProvinciaNET.SelfManagement.WebApp.Services;
using ProvinciaNET.SelfManagement.WebApp.Shared;
using Radzen;
using Radzen.Blazor;

namespace ProvinciaNET.SelfManagement.WebApp.Pages
{
    /// <summary>
    /// Master Table View Base Class
    /// </summary>
    /// <typeparam name="S">The service type.</typeparam>
    /// <typeparam name="T">The main type.</typeparam>
    /// <typeparam name="TC">The create component.</typeparam>
    /// <typeparam name="TU">The update component.</typeparam>
    /// <seealso cref="Microsoft.AspNetCore.Components.ComponentBase" />
    public class MasterTableViewBase<S, T, TC, TU> : ComponentBase where S : IWebApiServiceBase<T> where T : BaseEntity where TC : ComponentBase where TU : ComponentBase
    {
        /// <summary>
        /// Gets or sets the notification service.
        /// </summary>
        /// <value>
        /// The notification service.
        /// </value>
        [Inject]
        protected NotificationService NotificationService { get; set; } = null!;

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
        /// The main service.
        /// </value>
        [Inject]
        protected S? MainService { get; set; }

        /// <summary>
        /// The is loading variable.
        /// </summary>
        protected bool isLoading = false;

        /// <summary>
        /// The item count variable.
        /// </summary>
        protected int count = 0;

        /// <summary>
        /// The pagesize variable.
        /// </summary>
        protected int pagesize = 10;

        /// <summary>
        /// The grid0 object variable.
        /// </summary>
        protected RadzenDataGrid<T>? grid0;

        /// <summary>
        /// The resource list variable.
        /// </summary>
        protected IEnumerable<T>? resources;

        /// <summary>
        /// The resource object variable.
        /// </summary>
        protected T? resource;

        /// <summary>
        /// Loads the data.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="top">The top.</param>
        /// <param name="skip">The skip.</param>
        /// <param name="orderby">The orderby.</param>
        protected virtual async Task GetData(string? filter = null, int? top = null, int? skip = null, string? orderby = null)
        {
            try
            {
                var result = await MainService!.GetOdataAsync(filter: filter, top: top, skip: skip, orderby: orderby, count: true);
                resources = result.Value.AsODataEnumerable();
                count = result.Count;
            }
            catch (Exception ex)
            {
                resources = new List<T>();
                count = 0;
                NotificationService.Notify(new NotificationMessage
                {
                    Duration = 8000,
                    Severity = NotificationSeverity.Error,
                    Summary = $"Error",
                    Detail = $"{L["Unable to retrieve"]} {@L[$"{typeof(T).Name}s"]}. {ex.Message}"
                }
                );
            }
        }

        /// <summary>
        /// Loads the data. This method is used by grid.
        /// </summary>
        /// <param name="args">The arguments.</param>
        protected virtual async Task LoadData(LoadDataArgs args)
        {
            isLoading = true;
            await GetData(filter: args.Filter, top: args.Top, skip: args.Skip, orderby: args.OrderBy);
            isLoading = false;
        }

        /// <summary>
        /// Search event.
        /// </summary>
        /// <param name="args">The <see cref="ChangeEventArgs"/> instance containing the event data.</param>
        protected virtual async Task Search(ChangeEventArgs args)
        {
            if (args.Value == null)
                return;

            var search = args.Value.ToString()!.ToLowerInvariant();

            if (grid0 != null)
                await grid0.GoToPage(0);

            isLoading = true;
            await GetData(filter: $"contains(tolower(Name),'{search}')", top: grid0!.PageSize, skip: 0);
            isLoading = false;
        }

        /// <summary>
        /// Adds button click event.
        /// </summary>
        /// <param name="args">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        protected virtual async Task AddButtonClick(MouseEventArgs args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            await DialogService.OpenAsync<TC>($"{L["Add"]} {L[$"{typeof(T).Name}"]}", null);

            if (grid0 != null)
                await grid0.Reload();
        }

        /// <summary>
        /// Edit event.
        /// </summary>
        /// <param name="args">The <see cref="DataGridRowMouseEventArgs{T}"/> instance containing the event data.</param>
        protected virtual async Task EditRow(DataGridRowMouseEventArgs<T> args)
        {
            await DialogService.OpenAsync<TU>($"{L["Edit"]} {L[$"{typeof(T).Name}"]}", new Dictionary<string, object> { { "Id", args.Data.Id } });

            if (grid0 != null)
                await grid0.Reload();
        }

        /// <summary>
        /// Delete event.
        /// </summary>
        /// <param name="args">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        /// <param name="resource">The resource.</param>
        protected virtual async Task GridDeleteButtonClick(MouseEventArgs args, T resource)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            try
            {
                if (await DialogService.Confirm(L["Delete Confirmation"]) == true)
                {
                    await MainService!.DeleteAsync(resource.Id);

                    if (grid0 != null)
                        await grid0.Reload();
                }
            }
            catch (Exception ex)
            {
                NotificationService.Notify(new NotificationMessage
                {
                    Duration = 8000,
                    Severity = NotificationSeverity.Error,
                    Summary = $"Error",
                    Detail = $"{L["Unable to delete"]} {@L[$"{typeof(T).Name}"]}. {ex.Message}"
                }
                );
            }
        }

        /// <summary>
        /// Export event.
        /// </summary>
        /// <param name="args">The arguments.</param>
        protected virtual void ExportClick(RadzenSplitButtonItem args)
        {
            MainService!.ExportToFile((args is null ? "xlsx" : args.Value), $"{typeof(T).Name}s");
        }
    }
}