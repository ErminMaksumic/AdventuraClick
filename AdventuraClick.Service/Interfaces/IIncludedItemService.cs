using AdventuraClick.Model.Requests;
using AdventuraClick.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuraClick.Service.Interfaces
{
    public interface IIncludedItem : ICRUDService<Model.IncludedItem, IncludedItemSearchObject, IncludedItemUpsertRequest,
       IncludedItemUpsertRequest>
    { }
}
