using Mc2.CrudTest.API;
using Mc2.CrudTest.Shared.Dto.Customer;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    public class CreateCustomerTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
             "test_Firstname",
             "test_Lastname",
             "test_Email@test_Email.com",
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
