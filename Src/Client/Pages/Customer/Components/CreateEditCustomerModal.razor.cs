using Mc2.CrudTest.Client.Web.Components;
using Mc2.CrudTest.Shared.Dto;
using Mc2.CrudTest.Shared.Dto.Customers;
using Microsoft.AspNetCore.Components;

namespace Mc2.CrudTest.Client.Web.Pages.Customer;

public partial class CreateEditCustomerModal : AppComponentBase
{
    private bool _isOpen;
    private bool _isSaving;
    private CustomerDto _customer = new() ;

    [Parameter] public EventCallback OnSave { get; set; }

    public async Task ShowModal(CustomerDto customer)
    {
        await InvokeAsync(() =>
        {
            _isOpen = true;
            _customer = customer;
            StateHasChanged();
        });
    }

    private async Task Save()
    {
        _isSaving = true;

        try
        {
            if (_customer.Id is null)
            {
               await HttpClient.PostAsJsonAsync("customers", _customer, AppJsonContext.Default.CustomerDto);
            }
            else
            {
                await HttpClient.PutAsJsonAsync("customers", _customer, AppJsonContext.Default.CustomerDto);
            }

            _isOpen = false;
        }
        finally
        {
            _isSaving = false;

            await OnSave.InvokeAsync();
        }
    }

    private void OnCloseClick()
    {
        _isOpen = false;
    }
}
