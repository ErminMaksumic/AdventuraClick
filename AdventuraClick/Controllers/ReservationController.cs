using AdventuraClick.Model.Requests;
using AdventuraClick.Model.SearchObjects;
using AdventuraClick.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdventuraClick.Controllers
{
    [Route("api/[controller]")]
    public class ReservationController : CRUDController<Model.Reservation, ReservationSearchObject, ReservationInsertRequest,
        ReservationUpdateRequest>
    {
        public ReservationController(IReservationService service) : base(service)
        { }
    }
}
