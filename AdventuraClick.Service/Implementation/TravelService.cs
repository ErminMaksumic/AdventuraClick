﻿using AdventuraClick.Model;
using AdventuraClick.Model.SearchObjects;
using AdventuraClick.Service.Database;
using AdventuraClick.Service.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuraClick.Service.Implementation
{
    public class TravelService : CRUDService<Model.Travel, TravelSearchObject, Database.Travel, TravelUpsertRequest,
        TravelUpsertRequest>, ITravelService
    {
        public TravelService(AdventuraClickInitContext context, IMapper mapper) : base(context, mapper)
        { }
    }
}