using ego_auto.BFF.Domain.Common;
using ego_auto.BFF.Domain.Entities;
using ego_auto.BFF.Domain.Requests;
using ego_auto.BFF.Domain.Responses;

namespace ego_auto.BFF.Application.Contracts;

public interface IPaymentService
{
    Task<CustomResponse<Payment>> GetPaymentByIdAsync(int id);
    Task<CustomResponse<PaginatedResult<Payment>>> GetPaymentsAsync(GetPaymentsRequest request);
    Task<CustomResponse> MakePayment(PaymentRequest request, int userId);
    Task<CustomResponse> RefundPaymentAsync(int id);
    Task<CustomResponse> UpdatePaymentStatus(UpdatePaymentStatusRequest request);
}
