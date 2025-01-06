using ego_auto.BFF.Application.Contracts;
using ego_auto.BFF.Domain.Common;
using ego_auto.BFF.Domain.Entities;
using ego_auto.BFF.Domain.Requests;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace ego_auto.BFF.Persistence.Repositories;

public sealed class PaymentRepository(AppDbContext _context) : IPaymentRepository
{
    public async Task<Payment?> GetPaymentByIdAsync(int id)
    => await _context.Payment.FirstOrDefaultAsync(b => b.Id == id);

    public async Task<PaginatedResult<Payment>> GetPaymentsAsync(GetPaymentsRequest request)
    {
        var query = _context.Payment.AsQueryable();

        query = query
                .Join(_context.Bookings,
                    payment => payment.BookingId,
                    booking => booking.Id,
                    (payment, booking) => new { Payment = payment, Booking = booking })
                .Where(e => e.Booking.RenterId == request.UserId)
                .Where(e => !request.StartDate.HasValue || e.Payment.PaymentDate >= request.StartDate)
                .Where(e => !request.EndDate.HasValue || e.Payment.PaymentDate <= request.EndDate)
                .Where(e => !request.MinAmount.HasValue || e.Payment.Amount >= request.MinAmount)
                .Where(e => !request.MaxAmount.HasValue || e.Payment.Amount <= request.MaxAmount)
                .Select(e => e.Payment);

        var totalCount = await query.CountAsync();

        var payments = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();

        return new PaginatedResult<Payment>
        {
            TotalCount = totalCount,
            Items = payments
        };
    }

    public async Task UpsertPayment(PaymentRequest request)
    {
        NpgsqlParameter bookingIdParam = new("p_booking_id", request.BookingId ?? (object)DBNull.Value);
        NpgsqlParameter amountParam = new("p_amount", request.Amount ?? (object)DBNull.Value);
        NpgsqlParameter statusParam = new("p_payment_status", request.Status.ToString() ?? (object)DBNull.Value);

        await _context.Database.ExecuteSqlRawAsync(
            "CALL public.process_payment(@p_booking_id, @p_amount, @p_payment_status);",
            bookingIdParam, amountParam, statusParam
        );
    }
}
