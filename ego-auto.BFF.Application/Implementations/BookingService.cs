using ego_auto.BFF.Application.Contracts.Application;
using ego_auto.BFF.Application.Contracts.Persistence;
using ego_auto.BFF.Domain.Common;
using ego_auto.BFF.Domain.Entities;
using ego_auto.BFF.Domain.Requests.Booking;
using ego_auto.BFF.Domain.Responses;

namespace ego_auto.BFF.Application.Implementations;

public class BookingService(IBookingRepository _bookingRepository, IVehicleRepository _vehicleRepository) : IBookingService
{
    public async Task<CustomResponse> DeleteBookingAsync(int id)
    {
        await _bookingRepository.DeleteBookingAsync(id);

        return CustomResponse.IsSuccess();
    }

    public async Task<CustomResponse<Booking>> GetBookingByIdAsync(int id)
    => CustomResponse<Booking>.IsSuccess
        (
            await _bookingRepository.GetBookingByIdAsync(id)
        );

    public async Task<CustomResponse<PaginatedResult<Booking>>> GetBookingsAsync(GetBookingsRequest request)
    {
        return CustomResponse<PaginatedResult<Booking>>.IsSuccess
            (
                data: await _bookingRepository.GetBookingsAsync(request)
            );
    }

    public async Task<CustomResponse> UpsertBooking(BookingUpsertRequest request)
    {
        await _bookingRepository.UpsertBooking(request);

        var vehicle = await _vehicleRepository.GetVehicleByIdAsync((int)request.VehicleId);

        return CustomResponse.IsSuccess
            (
                customProp: request.BookingId.HasValue ?
                string.Format("The booking with id {0} was updated successfully.", request.BookingId) :
                string.Format("Your booking for {0} initiated successfully.", vehicle.Make + ' ' + vehicle.Model)
            );
    }
}
