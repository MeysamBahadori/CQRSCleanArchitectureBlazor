using AutoMapper;
using Mc2.CrudTest.API;
using Mc2.CrudTest.Application.Mappers;
using Mc2.CrudTest.Domain.Customers;
using Mc2.CrudTest.Shared.Dto.Customers;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Collections;
using System.Text;
using Xunit;

namespace Mc2.CrudTest.UnitTests;

public class CustomerControllerTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _webFactory;

    public CustomerControllerTest(WebApplicationFactory<Program> webFactory)
    {
        _webFactory = webFactory;
    }

    [Theory]
    [InlineData("api/customers/09532446-967B-45E4-BE15-013A4F03437E")]
    public async Task GetByIdEndpoint_Should_ReturnOk(string url)
    {
        // Arrange
        var client = _webFactory.CreateClient();

        // Act
        var response = await client.GetAsync(url);

        // Assert
        Assert.True(response.IsSuccessStatusCode);
    }

    [Fact]
    public async Task GetPagedEndpoint_Should_ReturnOk()
    {
        // Arrange
        var client = _webFactory.CreateClient();
        var url = "api/customers?MaxResultCount=10&Skip=0";

        // Act
        var response = await client.GetAsync(url);

        // Assert
        Assert.True(response.IsSuccessStatusCode);
    }

    [Theory, ClassData(typeof(CreateCustomerTestData))]
    public async Task CreateCustomer_Should_ReturnOk(string firstName, string lastname, string email,DateTimeOffset dateOfBirth, string bankAccountNumber, string phoneNumberCountryCode, string phoneNumber)
    {
        // Arrange
        var client = _webFactory.CreateClient();
        var url = "api/customers";
        var request = new CustomerDto()
        {
            Firstname = firstName,
            Lastname = lastname,
            Email = email,
            DateOfBirth = dateOfBirth,
            BankAccountNumber = bankAccountNumber,
            PhoneNumberCountryCode = phoneNumberCountryCode,
            PhoneNumber = phoneNumber
        };
        var json = JsonConvert.SerializeObject(request);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        // Act
        var response = await client.PostAsync(url, data);

        // Assert
        Assert.True(response.IsSuccessStatusCode);
    }

    [Fact]
    public async Task UpdateCustomer_Should_ReturnOk()
    {
        // Arrange
        var client = _webFactory.CreateClient();
        var url = "api/customers";

        Customer customerToUpdate = TestDataSetProvider.Instance.GetMockCustomerDbset().Object.FirstOrDefault()!;

        var mockMapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new CustomerMapperConfiguration());
        });
        var mapper = mockMapper.CreateMapper();

        var request = mapper.Map<CustomerDto>(customerToUpdate);

        request.Firstname = $"Firstname_{Guid.NewGuid()}";

        var json = JsonConvert.SerializeObject(request);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        // Act
        var response = await client.PutAsync(url, data);

        // Assert
        Assert.True(response.IsSuccessStatusCode);
    }

    [Theory]
    [InlineData("8bd6dfea-6784-4b02-97c7-6d69b47e332a")]
    public async Task DeleteCustomerEndpoint_Should_ReturnOk(string Id)
    {
        // Arrange
        var client = _webFactory.CreateClient();
        var url = $"api/customers/{Id}";

        // Act
        var response = await client.DeleteAsync(url);

        // Assert
        Assert.True(response.IsSuccessStatusCode);
    }

    public class CreateCustomerTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
             $"Firstname_{Guid.NewGuid()}",
             $"Lastname_{Guid.NewGuid()}",
             $"Firstname_ {Guid.NewGuid()}@gmail.com",
             DateTimeOffset.Now.AddYears(-30),
             "9999888877776666",
             "IR",
             "9397534280" };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
