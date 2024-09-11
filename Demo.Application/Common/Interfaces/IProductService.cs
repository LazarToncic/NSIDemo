using Demo.Application.Common.Dto.Product;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Demo.Application.Common.Interfaces;

public interface IProductService
{
    Task<ProductDetailsDto> CreateAsync(ProductCreateDto product, CancellationToken cancellationToken);
}