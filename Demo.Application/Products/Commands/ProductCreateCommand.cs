using Demo.Application.Common.Dto.Product;
using Demo.Application.Common.Exceptions;
using Demo.Application.Common.Interfaces;
using Demo.Application.Common.Mappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Demo.Application.Products.Commands;

public record ProductCreateCommand(ProductCreateDto Product) : IRequest<ProductDetailsDto?>;

public class ProductsCreateCommandHandler(IProductService productService) : IRequestHandler<ProductCreateCommand, ProductDetailsDto?>
{
    public async Task<ProductDetailsDto?> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
    {
        var result = await productService.CreateAsync(request.Product, cancellationToken);
        return result;
    }
}
