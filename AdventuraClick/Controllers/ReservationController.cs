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
        EmailSenderService _emailService;
        private IConfiguration _configuration;

        public ReservationController(IReservationService service, EmailSenderService emailService, IConfiguration configuration) : base(service)
        {
            _emailService = emailService;
            _configuration = configuration;
        }
        [HttpPost("sendConfirmationEmail")]
        public void SendConfirmationEmail([FromBody] EmailSenderRequest request)
        {
            _ = _emailService.SendEmail(_configuration, request.FullName, request.Email, request.Subject, request.Body);
        }
    }
}
