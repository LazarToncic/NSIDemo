using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Demo.Application.Common.Dto.Product;
using Demo.Application.Common.Interfaces;
using Demo.Application.Products.Commands;
using Demo.BaseTest.Builders.Commands;
using Demo.BaseTest.Builders.Domain;
using Demo.BaseTest.Builders.Dto;
using Demo.Infrastructure.Contexts;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.OpenApi.Extensions;
using Moq;

namespace Demo.FunctionalTests.Products.Commands;

public class ProductCreateCommandTest : BaseTests
{
    public static readonly JsonSerializerOptions DefaultOptions = new();
    public static readonly JsonSerializerOptions SettingsWebOptions = new(JsonSerializerDefaults.Web)
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };
    
    [Fact]
    public async Task ProductCreateCommandTest_GivenValidProduct_StatusOk()
    {
        //Given
        var company = new CompanyBuilder().Build();
        
        await DemoDbContext.Companies.AddAsync(company);
        await DemoDbContext.SaveChangesAsync();

        var productDto = new ProductCreateDtoBuilder().WithCompanyId(company.Id).Build();
        var product = new ProductCreateCommandBuilder().WithProductCreateDto(productDto).Build();
        var jsonProduct = JsonSerializer.Serialize(product);
        var contentRequest = new StringContent(jsonProduct, Encoding.UTF8, "application/json");
        
        MockCompanyService.Setup(x => x.CreateAsync()).Returns("Test");
        
        //When
        var response = await Client.PostAsync("/api/Product/Create/create", contentRequest, new CancellationToken());
        
        //Then
        using var _ = new AssertionScope();

        response.StatusCode
            .Should()
            .Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<ProductDetailsDto?>();

        content.Should()
            .NotBeNull();
        
        MockCompanyService.Verify(x => x.CreateAsync(), Times.Once); // ovo ne prolazi
    }

    public ProductCreateCommandTest(CustomWebApplicationFactory<Program> factory) : base(factory)
    {
    }
}