namespace BuberDinner.application.Common.Interfaces.Persistence;

using BuberDinner.domain.MenuAggregate;
using System.Threading.Tasks;

public interface IMenuRepository
{
    Task Add(Menu menu);
}
