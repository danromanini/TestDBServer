using System.Threading.Tasks;
using Test.Domain.Entities;
using Test.Domain.Interface;

namespace Test.Domain.Chain
{
    public class DebitoChain : IChain<LancamentoChainParameters, bool>
    {
        private readonly ILancamentoRepository _lancamentoRepository;

        public IChain<LancamentoChainParameters, bool> Next { get; set; }

        public DebitoChain(ILancamentoRepository lancamentoRepository)
        {
            _lancamentoRepository = lancamentoRepository;
        }

        public async Task<bool> Execute(LancamentoChainParameters chainParam)
        {
            var lancamentoDebito = new Lancamentos
            {
                Conta = chainParam.LancamentoDTO.ContaDebido,
                Lancamento = "Lançamento de débito na conta " + chainParam.LancamentoDTO.ContaDebido,
                TipoLancamento = "Debito",
                Valor = chainParam.LancamentoDTO.Valor
            };

            var result = _lancamentoRepository.DoDebit(lancamentoDebito);

            if (result == false)
            {                
                return false;
            }

            return await Next.Execute(chainParam);
        }
    }
}
