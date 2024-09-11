using Demo.Application.Common.Dto.Product;
using Demo.Application.Products.Commands;
using Demo.BaseTest.Builders.Dto;

namespace Demo.BaseTest.Builders.Commands;

public class ProductCreateCommandBuilder
{
    private ProductCreateDto _productCreateDto = new ProductCreateDtoBuilder().Build();
    public ProductCreateCommand Build()
    {
        return new ProductCreateCommand(_productCreateDto);
    }

    public ProductCreateCommandBuilder WithProductCreateDto(ProductCreateDto productCreateDto)
    {
        _productCreateDto = productCreateDto;
        return this;
    }
}