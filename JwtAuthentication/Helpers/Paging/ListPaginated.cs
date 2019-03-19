using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthentication.Helpers.Paging
{
    public class ListPaginated<T>
    {
        public int TotalItems { get; }

        public int TotalPages { get; }

        public IList<T> List { get; }

        public ListPaginated(int TotalItems, int TotalPages, IList<T> List)
        {
            this.TotalItems = TotalItems;
            this.TotalPages = TotalPages;
            this.List = List;
        }

        public string ToJson() => JsonConvert.SerializeObject(this,
                                    new JsonSerializerSettings
                                    {
                                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                                    });
    }
}
