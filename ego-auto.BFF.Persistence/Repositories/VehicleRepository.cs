using ego_auto.BFF.Application.Contracts;
using ego_auto.BFF.Domain.Dtos;
using ego_auto.BFF.Domain.Entities;
using ego_auto.BFF.Domain.Requests;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace ego_auto.BFF.Persistence.Repositories;

public sealed class VehicleRepository(AppDbContext _context) : IVehicleRepository
{
    public async Task<int> UpsertVehicleAsync(VehicleUpsertDto model)
    {
        var vehicleIdParam = model.VehicleId.HasValue ?
            new NpgsqlParameter("p_vehicle_id", model.VehicleId.Value) :
            new NpgsqlParameter("p_vehicle_id", DBNull.Value);

        var makeParam = new NpgsqlParameter("p_make", model.Make ?? (object)DBNull.Value);
        var modelParam = new NpgsqlParameter("p_model", model.Model ?? (object)DBNull.Value);
        var yearParam = new NpgsqlParameter("p_year", model.Year ?? (object)DBNull.Value);
        var pricePerDayParam = new NpgsqlParameter("p_price_per_day", model.PricePerDay ?? (object)DBNull.Value);
        var descriptionParam = new NpgsqlParameter("p_description", model.Description ?? (object)DBNull.Value);

        return await _context.Database.ExecuteSqlRawAsync(
            "CALL public.upsert_vehicle(@p_vehicle_id, @p_make, @p_model, @p_year, @p_price_per_day, @p_description);",
            vehicleIdParam,
            makeParam,
            modelParam,
            yearParam,
            pricePerDayParam,
            descriptionParam
        );
    }


    public async Task<PaginatedResult<Vehicle>> GetVehiclesAsync(GetVehiclesRequest request)
    {
        var query = _context.Vehicles.AsQueryable();

        if (!string.IsNullOrEmpty(request.MakeFilter))
            query = query.Where(v => v.Make.Contains(request.MakeFilter));
        if (!string.IsNullOrEmpty(request.ModelFilter))
            query = query.Where(v => v.Model.Contains(request.ModelFilter));
        if (request.PricePerDayFilter.HasValue)
            query = query.Where(v => v.PricePerDay == request.PricePerDayFilter.Value);
        if (!string.IsNullOrEmpty(request.StatusFilter))
            query = query.Where(v => v.Status == request.StatusFilter);
        if (!string.IsNullOrEmpty(request.DescriptionFilter))
            query = query.Where(v => v.Description.Contains(request.DescriptionFilter));

        var totalCount = await query.CountAsync();

        var vehicles = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();

        return new PaginatedResult<Vehicle>
        {
            TotalCount = totalCount,
            Items = vehicles
        };
    }

    public async Task<Vehicle> GetVehicleByIdAsync(int vehicleId) => await _context.Vehicles.FirstOrDefaultAsync(v => v.Id == vehicleId);
}
