using AdventuraClick.Model.Requests;
using AdventuraClick.Model.SearchObjects;
using AdventuraClick.Service.Database;
using AdventuraClick.Service.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuraClick.Service.Implementation
{
    public class IncludedItemService : CRUDService<Model.IncludedItem, IncludedItemSearchObject, Database.IncludedItem, IncludedItemUpsertRequest,
        IncludedItemUpsertRequest>, IIncludedItem
    {
        public IncludedItemService(AdventuraClickInitContext context, IMapper mapper) : base(context, mapper)
        { }
    }
}
