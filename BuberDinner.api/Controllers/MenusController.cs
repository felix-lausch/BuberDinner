namespace BuberDinner.Api.Controllers;

using BuberDinner.api.Controllers;
using BuberDinner.application.Menus.Commands.CreateMenu;
using BuberDinner.contracts.Menus;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("hosts/{hostId}/menus")]
public class MenusController : ApiController
{
    private readonly IMapper mapper;
    private readonly ISender mediator;

    public MenusController(IMapper mapper, ISender mediator)
    {
        this.mapper = mapper;
        this.mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMenu(
        CreateMenuRequest request,
        string hostId)
    {
        var command = mapper.Map<CreateMenuCommand>((request, hostId));

        var createMenuResult = await mediator.Send(command);

        return createMenuResult.Match(
            result => Ok(mapper.Map<MenuResponse>(result)),
            Problem);
    }
}
