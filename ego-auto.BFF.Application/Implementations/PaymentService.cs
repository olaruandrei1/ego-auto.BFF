using ego_auto.BFF.Application.Contracts.Application;
using ego_auto.BFF.Application.Contracts.Persistence;
using ego_auto.BFF.Application.Utilities;
using ego_auto.BFF.Domain.Common;
using ego_auto.BFF.Domain.Entities;
using ego_auto.BFF.Domain.Requests.Payment;
using ego_auto.BFF.Domain.Responses;

namespace ego_auto.BFF.Application.Implementations;

public class PaymentService(IPaymentRepository _paymentRepository, IBookingRepository _bookingRepository) : IPaymentService
{
    public async Task<CustomResponse<Payment>> GetPaymentByIdAsync(int id)
    => CustomResponse<Payment>.IsSuccess
        (
            await _paymentRepository.GetPaymentByIdAsync(id)
        );

    public async Task<CustomResponse<PaginatedResult<Payment>>> GetPaymentsAsync(GetPaymentsRequest request)
    {
        return CustomResponse<PaginatedResult<Payment>>.IsSuccess
            (
                data: await _paymentRepository.GetPaymentsAsync(request)
            );
    }

    public async Task<CustomResponse> MakePayment(PaymentRequest request, int userId)
    {
        if (request.BookingId is null)
        {
            return CustomResponse.IsFailed(["The booking you search for doesn't exist"]);
        }

        var booking = await _bookingRepository.GetBookingByIdAsync((int)request.BookingId);

        if (booking is null)
        {
            return CustomResponse.IsFailed(["The booking you search for doesn't exist"]);
        }

        if (booking.RenterId != userId)
        {
            return CustomResponse.IsFailed(["Invalid renter id."]);
        }

        if (request.Amount < booking.TotalPrice)
        {
            return CustomResponse.IsFailed(["Insufficient payment amount."]);
        }

        await _paymentRepository.UpsertPayment(request);

        booking.Status = BookingStatus.Ongoing.ToString();

        await _bookingRepository.UpsertBooking(booking.MapBookingToUpsert());

        return CustomResponse.IsSuccess();
    }

    public Task<CustomResponse> RefundPaymentAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<CustomResponse> UpdatePaymentStatus(UpdatePaymentStatusRequest request)
    {
        throw new NotImplementedException();
    }
}
