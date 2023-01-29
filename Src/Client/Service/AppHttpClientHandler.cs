using Mc2.CrudTest.Shared.Dto;
using Microsoft.AspNetCore.Components;
using System.Globalization;
using System.Net.Http.Headers;

namespace Mc2.CrudTest.Client.Web.Service;

public partial class AppHttpClientHandler : HttpClientHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var response = await base.SendAsync(request, cancellationToken);

        if (!response.IsSuccessStatusCode && response.Content.Headers.ContentType?.MediaType == "application/json")
        {
            var expData = await response.Content.ReadFromJsonAsync(AppJsonContext.Default.ExceptionWrapperData);

            //Todo: The error needs to be recovered and adjusted
            throw new Exception(expData?.Error);
        }

        response.EnsureSuccessStatusCode();

        return response;
    }
}
