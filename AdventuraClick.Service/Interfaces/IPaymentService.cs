using AdventuraClick.Model.Requests;
using AdventuraClick.Model.SearchObjects;

namespace AdventuraClick.Service.Interfaces
{
    public interface IPaymentService : ICRUDService<Model.Payment, PaymentSearchObject, PaymentUpsertRequest, PaymentUpsertRequest>
    { }
}
