using JwtAuthentication.Entities.Categorias;
using System.Collections.Generic;
using System.Linq;
using JwtAuthentication.Entities.Enums.Extensions;

namespace JwtAuthentication.Services
{
    public class CategoriasService
    {

        public IEnumerable<KeyValuePair<string, int>> GetGrupos()
        {
            var values = System.Enum.GetValues(typeof(CategoriaGrupoEnum)).Cast<int>();
            var enumDictionary = values.ToDictionary(value => ((CategoriaGrupoEnum)value).GetDescription());

            return enumDictionary.ToList();
        }

    }
}
