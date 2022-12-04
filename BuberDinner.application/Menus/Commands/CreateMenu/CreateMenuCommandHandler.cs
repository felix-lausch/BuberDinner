namespace BuberDinner.application.Menus.Commands.CreateMenu;

using BuberDinner.application.Common.Interfaces.Persistence;
using BuberDinner.domain.HostAggregate.ValueObjects;
using BuberDinner.domain.MenuAggregate;
using BuberDinner.domain.MenuAggregate.Entities;
using ErrorOr;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    private readonly IMenuRepository menuRepository;

    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        this.menuRepository = menuRepository;
    }

    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        var menu = Menu.Create(
            hostId: HostId.Create(request.HostId),
            name: request.Name,
            description: request.Description,
            sections: request.Sections.ConvertAll(section =>
            {
                return MenuSection.Create(
                    section.Name,
                    section.Description,
                    section.Items.ConvertAll(item => MenuItem.Create(item.Name, item.Description)));
            }));

        await menuRepository.Add(menu);

        return menu;
    }
}
