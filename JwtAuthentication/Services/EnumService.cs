using JwtAuthentication.Entities.Lancamentos;
using System.Collections.Generic;
using System.Linq;
using JwtAuthentication.Entities.Enums.Extensions;
using JwtAuthentication.Entities.Enums;
using JwtAuthentication.Entities.Categorias;

namespace JwtAuthentication.Services
{
    public class EnumService
    {

        public IEnumerable<KeyValuePair<string, int>> GetLancamentosSituacoesEnum()
        {
            var values = System.Enum.GetValues(typeof(LancamentoSituacaoEnum)).Cast<int>();
            var enumDictionary = values.ToDictionary(value => ((LancamentoSituacaoEnum)value).GetDescription());

            return enumDictionary.ToList();
        }

        public IEnumerable<KeyValuePair<string, int>> GetMovimentacoesEnum()
        {
            var values = System.Enum.GetValues(typeof(TipoMovimentacaoEnum)).Cast<int>();
            var enumDictionary = values.ToDictionary(value => ((TipoMovimentacaoEnum)value).GetDescription());

            return enumDictionary.ToList();
        }

        public IEnumerable<KeyValuePair<string, int>> GetOperacoesEnum()
        {
            var values = System.Enum.GetValues(typeof(TipoOperacaoEnum)).Cast<int>();
            var enumDictionary = values.ToDictionary(value => ((TipoOperacaoEnum)value).GetDescription());

            return enumDictionary.ToList();
        }

        public IEnumerable<KeyValuePair<string, int>> GetGruposEnum()
        {
            var values = System.Enum.GetValues(typeof(CategoriaGrupoEnum)).Cast<int>();
            var enumDictionary = values.ToDictionary(value => ((CategoriaGrupoEnum)value).GetDescription());

            return enumDictionary.ToList();
        }

    }
}
