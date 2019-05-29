using JwtAuthentication.Entities.Lancamentos;
using JwtAuthentication.Responses.Lancamentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthentication.Factories.Lancamentos
{
    public static class LancamentoCreateResponseFactory
    {

        public static LancamentoCreateResponse CreatedOneSuccess(Lancamento lancamento)
        {
            return new LancamentoCreateResponse
            {
                Success = true,
                Lancamento = lancamento
            };
        }

        public static LancamentoCreateResponse CreateOneFailedWithServerError(string Message)
        {
            return new LancamentoCreateResponse
            {
                Success = false,
                Message = Message
            };
        }


        public static LancamentoCreateResponse CreatedManySuccess(IList<Lancamento> lancamentos)
        {
            return new LancamentoCreateResponse
            {
                Success = true,
                Lancamentos = lancamentos
            };
        }

        public static LancamentoCreateResponse CreateManyFailedWithServerError(string Message)
        {
            return new LancamentoCreateResponse
            {
                Success = false,
                Message = Message
            };
        }

    }
}
