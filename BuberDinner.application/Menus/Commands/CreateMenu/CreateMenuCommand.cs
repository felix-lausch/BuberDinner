namespace BuberDinner.application.Menus.Commands.CreateMenu;

using BuberDinner.domain.MenuAggregate;
using ErrorOr;
using MediatR;
using System.Collections.Generic;

public record CreateMenuCommand(
    string HostId,
    string Name,
    string Description,
    List<MenuSectionCommand> Sections) : IRequest<ErrorOr<Menu>>;

public record MenuSectionCommand(
    string Name,
    string Description,
    List<MenuItemCommand> Items);

public record MenuItemCommand(
    string Name,
    string Description);