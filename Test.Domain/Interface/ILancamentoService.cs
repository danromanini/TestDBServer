using System.Threading.Tasks;
using Test.Domain.DTO;

namespace Test.Domain.Interface
{
    public interface ILancamentoService
    {
        Task<bool> SaveLancamento(LancamentoDTO lancamentoDTO);
    }
}
