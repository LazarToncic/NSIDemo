using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.WebHooks;

[ApiController]
[Route("webhook/[controller]/[action]")]
public class BaseWebHook : ControllerBase
{
    private ISender? _mediator;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}