using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.Domain.Chain;
using Test.Domain.DTO;
using Test.Domain.Interface;
using Test.Domain.Patterns.ChainOfResponsability;

namespace Test.Domain.Service
{
    public class LancamentoService : ILancamentoService
    {
        
        private readonly ILancamentoRepository _lancamentoRepository;

        public LancamentoService(ILancamentoRepository lancamentoRepository)
        {
            _lancamentoRepository = lancamentoRepository;
        }

        public async Task<bool> SaveLancamento(LancamentoDTO lancamentoDTO)
        {
            var chain = new ChainBuilder<LancamentoChainParameters, bool>()
                        .Then(new DebitoChain(_lancamentoRepository))
                        .Then(new CreditoChain(_lancamentoRepository))
                        .Build();

            return await chain.Execute(new LancamentoChainParameters { LancamentoDTO = lancamentoDTO });
        }
    }
}
