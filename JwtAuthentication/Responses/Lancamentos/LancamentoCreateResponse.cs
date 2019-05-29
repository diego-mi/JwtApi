using JwtAuthentication.Entities.Lancamentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthentication.Responses.Lancamentos
{
    public class LancamentoCreateResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public Lancamento Lancamento { get; set; }
        public IList<Lancamento> Lancamentos { get; set; }
    }
}
