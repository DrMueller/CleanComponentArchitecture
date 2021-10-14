using System.Threading.Tasks;
using Mmu.Cca.Bc.Individuals.Areas.UseCases.AppendRole.Dto;

namespace Mmu.Cca.Bc.Individuals.Areas.UseCases.AppendRole.Interactors
{
    public interface IAppendRoleInteractor
    {
        Task ExecuteAsync(long individualId, AppendRoleRequestDto dto);
    }
}