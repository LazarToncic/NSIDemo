using Demo.Api.Services;
using Demo.Application.Common.Dto.Product;
using Demo.Application.Common.Interfaces;
using Demo.Application.Common.Mappers;
using Demo.Application.Products.Commands;
using Demo.Application.Products.Queries;
using Demo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.Api.Controllers;

public class ProductController(IDemoDbContext dbContext, IEnumerable<ITestProduct> testProducts) : ApiBaseController
{
    
    // TEST METODA
    [HttpGet]
    public void TestProductionDetails()
    {
        foreach (var testProduct in testProducts)
        {

            if (testProduct.GetType() == typeof(TestProductTwo))
            {
                var result = testProduct.GetDetails("test");
            }
            
            
        }
    }

    [HttpGet]
    public async Task<IActionResult> Details([FromQuery] ProductDetailsQuery query)
    {
        return Ok(await Mediator.Send(query));
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(ProductCreateCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    
}