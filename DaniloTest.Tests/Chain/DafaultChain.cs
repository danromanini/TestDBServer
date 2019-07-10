using System.Threading.Tasks;
using Test.Domain.Interface;

namespace DaniloTest.Tests.Chain
{
    public class DafaultChain<TParam, TResult> : IChain<TParam, TResult>
    {
        private readonly TResult _result;

        public IChain<TParam, TResult> Next { get; set; }

        public DafaultChain(TResult result) => _result = result;

        public Task<TResult> Execute(TParam chainParam) => Task.FromResult(_result);
    }
}
