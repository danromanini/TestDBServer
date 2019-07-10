using AutoFixture;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using Test.Domain.Chain;
using Test.Domain.DTO;
using Test.Domain.Entities;
using Test.Domain.Interface;

namespace DaniloTest.Tests.Chain
{
    class CreditoChainTest
    {        
        private Mock<ILancamentoRepository> _lancamentoRepository;
        private IChain<LancamentoChainParameters, bool> _chain;

        [SetUp]
        public void Setup()
        {
            var retorno = true;
            _lancamentoRepository = new Mock<ILancamentoRepository>();
            
            _chain = new CreditoChain(_lancamentoRepository.Object)
            {
                Next = new DafaultChain<LancamentoChainParameters, bool>(retorno)
            };
        }

        [Test]
        public async Task ShouldExecuteSuccessfully()
        {

            _lancamentoRepository.Setup(s => s.DoCredit(It.IsAny<Lancamentos>())).Returns(true);
            var result = await _chain.Execute(GetParam());

            result.Should().BeTrue();
            _lancamentoRepository.VerifyAll();
        }

        [Test]
        public async Task ShouldFailExecute()
        {
            _lancamentoRepository.Setup((s => s.DoCredit(It.IsAny<Lancamentos>()))).Returns(() => false);
            var result = await _chain.Execute(GetParam());
            result.Should().BeFalse();
            _lancamentoRepository.VerifyAll();
        }
        
        private LancamentoChainParameters GetParam()
            =>
                new LancamentoChainParameters
                {
                    LancamentoDTO = new LancamentoDTO
                    {
                        ContaCredito = 12345,
                        ContaDebido = 67890,
                        Valor = 150
                    }                    
                };
    }
}
