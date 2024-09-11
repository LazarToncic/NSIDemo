using Demo.Application.Common.Dto.Product;
using Demo.Application.Common.Exceptions;
using Demo.Application.Common.Interfaces;
using Demo.Application.Common.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure.Services;

public class ProductService(IDemoDbContext dbContext) : IProductService
{
    public async Task<ProductDetailsDto> CreateAsync(ProductCreateDto product, CancellationToken cancellationToken)
    {
        var company = await dbContext.Companies
            .Where(x => x.Id == product.CompanyId)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (company == null)
            throw new NotFoundException("Company doesnt exist");

        var productEntity = product
            .FromCreateDtoToEntity()
            .AddCompany(company);

        dbContext.Products.Add(productEntity);
        await dbContext.SaveChangesAsync(cancellationToken);

        return productEntity.ToDto();
    }
}