using AdventuraClick.Model.Requests;
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
    public class ReservationService : CRUDService<Model.Reservation, ReservationSearchObject, Database.Reservation, ReservationInsertRequest,
        ReservationUpdateRequest>, IReservationService
    {
        public ReservationService(AdventuraClickInitContext context, IMapper mapper) : base(context, mapper)
        {}
    }
}
