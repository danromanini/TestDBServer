using System.Threading.Tasks;
using Test.Domain.Entities;
using Test.Domain.Interface;

namespace Test.Domain.Chain
{
    public class CreditoChain : IChain<LancamentoChainParameters, bool>
    {
        private readonly ILancamentoRepository _lancamentoRepository;

        public IChain<LancamentoChainParameters, bool> Next { get; set; }

        public CreditoChain(ILancamentoRepository lancamentoRepository)
        {
            _lancamentoRepository = lancamentoRepository;
        }

        public Task<bool> Execute(LancamentoChainParameters chainParam)
        {
            var lancamentoDebito = new Lancamentos
            {
                Conta = chainParam.LancamentoDTO.ContaCredito,
                Lancamento = "Lançamento de crédito na conta " + chainParam.LancamentoDTO.ContaCredito,
                TipoLancamento = "Credito",
                Valor = chainParam.LancamentoDTO.Valor
            };

            var result = _lancamentoRepository.DoCredit(lancamentoDebito);
            
            return (!result) ? Task.FromResult(false) : Task.FromResult(result);
        }
    }
}
