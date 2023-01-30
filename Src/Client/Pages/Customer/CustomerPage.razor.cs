using Bit.BlazorUI;
using Mc2.CrudTest.Client.Web.Components;
using Mc2.CrudTest.Client.Web.Pages.Customer;
using Mc2.CrudTest.Shared.Dto;
using Mc2.CrudTest.Shared.Dto.Customers;
using Microsoft.AspNetCore.Components;

namespace Mc2.CrudTest.Client.Web.Pages.Customers;

public partial class CustomerPage:AppComponentBase
{
    private bool _isLoading;
    private CreateEditCustomerModal? _modal;
    private string _customerNameFilter = string.Empty;
    string CustomerNameFilter
    {
        get => _customerNameFilter;
        set
        {
            _customerNameFilter = value;
            _ = RefreshData();
        }
    }

    private BitDataGrid<CustomerDto>? _dataGrid;
    private BitDataGridItemsProvider<CustomerDto> _customerProvider = default!;
    private BitDataGridPaginationState _pagination = new() { ItemsPerPage = 10 };


    protected override async Task OnInitAsync()
    {
        PrepareGridDataProvider();

        await base.OnInitAsync();
    }

    private async Task RefreshData()
    {
        await _dataGrid!.RefreshDataAsync();
    }

    private void PrepareGridDataProvider()
    {
        _customerProvider = async req =>
        {
            _isLoading = true;

            try
            {
                var query = new Dictionary<string, object?>()
                {
                    {"MaxResultCount",req.Count ?? 10 },
                    { "skip", req.StartIndex }
                };

                if (string.IsNullOrEmpty(_customerNameFilter) is false)
                {
                    query.Add("filter", _customerNameFilter);
                }

                var url = NavigationManager.GetUriWithQueryParameters("customers", query);

                var data = await HttpClient.GetFromJsonAsync(url, AppJsonContext.Default.PagedResultCustomerDto);

                return BitDataGridItemsProviderResult.From(data!.Items, (int)data!.TotalCount);
            }
            catch
            {
                return BitDataGridItemsProviderResult.From(new List<CustomerDto> { }, 0);
            }
            finally
            {
                _isLoading = false;

                StateHasChanged();
            }
        };
    }

    private async Task CreateProduct()
    {
        await _modal!.ShowModal(new CustomerDto());
    }

    private async Task EditCustomer(CustomerDto customer)
    {
        await _modal!.ShowModal(customer);
    }

    private async Task DeleteCustomer(CustomerDto customer)
    {
        var confirmed = await MessageBox.Show("Are you sure to delete?",$"{customer.Firstname}-{customer.Lastname}",true);

        if (confirmed)
        {
            await HttpClient.DeleteAsync($"customers/{customer.Id}");

            await RefreshData();
        }
    }
}
