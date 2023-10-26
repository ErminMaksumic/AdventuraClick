using AdventuraClick.Model.Requests;
using AdventuraClick.Model.SearchObjects;
using AdventuraClick.Service.Implementation;
using AdventuraClick.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdventuraClick.Controllers
{
    [Route("api/[controller]")]
    public class ReservationController : CRUDController<Model.Reservation, ReservationSearchObject, ReservationInsertRequest,
        ReservationUpdateRequest>
    {
        EmailSenderService _emailService;
        private IConfiguration _configuration;
        private IReservationService _reservationService;

        public ReservationController(IReservationService service, EmailSenderService emailService, IConfiguration configuration) : base(service)
        {
            _emailService = emailService;
            _configuration = configuration;
            _reservationService = service;
        }
        [HttpPost("sendConfirmationEmail")]
        public void SendConfirmationEmail([FromBody] EmailSenderRequest request)
        {
            var messageBody = $@"
Dear {request.FullName},

Thank you for booking your trip with AdventuraClick.

Reservation Details:
- Destination: {request.TravelName}

Please review the details above and ensure everything is correct. Should you have any questions or need to make changes to your reservation, please contact us at info@adventuraclick.com.

We're excited to be a part of your journey and are committed to ensuring you have a wonderful travel experience.

Safe travels!

Warm regards,
AdventuraClick Team
";

            _ = _emailService.SendEmail(_configuration, request.FullName, request.Email, "Travel Reservation Confirmation", messageBody);
        }

        [HttpPut("{id}/status")]
        [Authorize(Roles = "Admin")]
        public Model.Reservation ChangeReservationStatus(int id, [FromBody] ChangeReservationStatus request)
        {
            return _reservationService.ChangeStatus(id, request);
        }


    }
}