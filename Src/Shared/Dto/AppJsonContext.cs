using Mc2.CrudTest.Shared.Dto.Customers;
using Mc2.CrudTest.Shared.Exceptions;
using System.Text.Json.Serialization;


namespace Mc2.CrudTest.Shared.Dto;

[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(CustomerDto))]
[JsonSerializable(typeof(List<CustomerDto>))]
[JsonSerializable(typeof(PagedResult<CustomerDto>))]
[JsonSerializable(typeof(ExceptionWrapperData))]
public partial class AppJsonContext : JsonSerializerContext
{
}
