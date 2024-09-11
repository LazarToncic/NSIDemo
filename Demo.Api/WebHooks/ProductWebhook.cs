using Demo.Api.Auth.Constants;
using Demo.Application.Products.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.WebHooks;

[Authorize(AuthenticationSchemes = nameof(AuthConstants.HeaderBasicAuthenticationScheme))]
public class ProductWebhook : BaseWebHook
{
    [HttpPost("create")]
    public async Task<IActionResult> Create(ProductCreateCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
}