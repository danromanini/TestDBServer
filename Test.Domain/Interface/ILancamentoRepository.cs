using System.Threading.Tasks;
using Test.Domain.Chain;
using Test.Domain.Entities;

namespace Test.Domain.Interface
{
    public interface ILancamentoRepository
    {
        bool DoDebit(Lancamentos lancamento);
        bool DoCredit(Lancamentos lancamento);
    }
}
