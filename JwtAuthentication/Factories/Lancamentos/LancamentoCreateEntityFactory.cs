using JwtAuthentication.Entities.Lancamentos;
using JwtAuthentication.Requests.Lancamentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthentication.Factories.Lancamentos
{
    public static class LancamentoCreateEntityFactory
    {

        public static Lancamento CreateOneByRequest(LancamentoCreateRequest lancamentoRequest)
        {
            return new Lancamento
            {
                Nome = lancamentoRequest.Nome,
                Data = lancamentoRequest.Data,
                Valor = lancamentoRequest.Valor,
                Tipo = lancamentoRequest.Tipo,
                TipoMovimentacao = lancamentoRequest.TipoMovimentacao,
                Situacao = lancamentoRequest.Situacao,
                TipoOperacao = lancamentoRequest.TipoOperacao,
                CategoriaId = lancamentoRequest.CategoriaId
            };
        }

    }
}
