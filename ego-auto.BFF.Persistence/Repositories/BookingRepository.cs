using ego_auto.BFF.Application.Contracts.Persistence;
using ego_auto.BFF.Domain.Common;
using ego_auto.BFF.Domain.Entities;
using ego_auto.BFF.Domain.ExceptionTypes;
using ego_auto.BFF.Domain.Requests.Booking;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace ego_auto.BFF.Persistence.Repositories;

public sealed class BookingRepository(AppDbContext _context) : IBookingRepository
{
    public async Task<PaginatedResult<Booking>> GetBookingsAsync(GetBookingsRequest request)
    {
        var query = _context.Bookings.AsQueryable();

        query = query
            .Where(e => e.RenterId == request.RenterId)
            .Where(e => !request.StartDate.HasValue || e.StartDate >= request.StartDate)
            .Where(e => !request.EndDate.HasValue || e.EndDate <= request.EndDate)
            .Where(e => !request.MinPrice.HasValue || e.TotalPrice >= request.MinPrice)
            .Where(e => !request.MaxPrice.HasValue || e.TotalPrice <= request.MaxPrice);

        var totalCount = await query.CountAsync();

        var bookings = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();

        return new PaginatedResult<Booking>
        {
            TotalCount = totalCount,
            Items = bookings
        };
    }

    public async Task<Booking?> GetBookingByIdAsync(int id) => await _context.Bookings.FirstOrDefaultAsync(b => b.Id == id);

    public async Task UpsertBooking(BookingUpsertRequest booking)
    {
        NpgsqlParameter vehicleIdParam = new("p_vehicle_id", booking.VehicleId ?? (object)DBNull.Value);
        NpgsqlParameter bookingIdParam = new("p_booking_id", booking.BookingId ?? (object)DBNull.Value);
        NpgsqlParameter renterIdParam = new("p_renter_id", booking.RenterId ?? (object)DBNull.Value);
        NpgsqlParameter statusParam = new("p_status", booking.Status ?? (object)DBNull.Value);
        NpgsqlParameter startDateParam = new("p_start_date", booking.StartDate ?? (object)DBNull.Value);
        NpgsqlParameter endDateParam = new("p_end_date", booking.EndDate ?? (object)DBNull.Value);
        NpgsqlParameter totalPriceParam = new("p_total_price", booking.TotalPrice ?? (object)DBNull.Value);

        await _context.Database.ExecuteSqlRawAsync(
            "CALL public.upsert_booking(@p_vehicle_id, @p_renter_id, @p_start_date, @p_end_date, @p_status, @p_total_price, @p_booking_id);",
            vehicleIdParam,
            renterIdParam,
            startDateParam,
            endDateParam,
            statusParam,
            totalPriceParam,
            bookingIdParam
        );
    }

    public async Task DeleteBookingAsync(int id)
    {
        var booking = await _context.Bookings.FirstOrDefaultAsync(b => b.Id == id);

        if (booking is null)
        {
            throw new CustomNotFound($"Booking with ID {id} not found.");
        }

        _context.Bookings.Remove(booking);

        await _context.SaveChangesAsync();
    }
}