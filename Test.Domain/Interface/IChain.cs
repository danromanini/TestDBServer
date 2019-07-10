using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Test.Domain.Interface
{
    public interface IChain<TParam, TResult>
    {
        IChain<TParam, TResult> Next { get; set; }

        Task<TResult> Execute(TParam chainParam);
    }
}
