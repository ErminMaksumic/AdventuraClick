using AdventuraClick.Model.Requests;
using AdventuraClick.Model.SearchObjects;
using AdventuraClick.Service.Database;
using AdventuraClick.Service.Interfaces;
using AutoMapper;

namespace AdventuraClick.Service.Implementation
{
    public class PaymentService : CRUDService<Model.Payment, PaymentSearchObject, Database.Payment, PaymentUpsertRequest, PaymentUpsertRequest>, IPaymentService
    {
        public PaymentService(AdventuraClickInitContext service, IMapper mapper) : base(service, mapper)
        { }
    }
}
