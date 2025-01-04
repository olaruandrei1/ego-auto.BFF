using ego_auto.BFF.Application.Contracts;
using ego_auto.BFF.Domain.Dtos;
using ego_auto.BFF.Domain.Entities;
using ego_auto.BFF.Domain.Requests;
using ego_auto.BFF.Domain.Responses;
using Microsoft.EntityFrameworkCore;

namespace ego_auto.BFF.Persistence.Repositories;

public class VehicleRepository(AppDbContext _context) : IVehicleRepository
{
    public async Task<PaginatedResult<VehicleModel>> GetVehiclesAsync(GetVehicleRequest request)
    {
        var query = _context.Vehicles.AsQueryable();

        if (!string.IsNullOrEmpty(request.VehicleModelFilter))
        {
            query = query.Where(v => v.Model.Contains(request.VehicleModelFilter));
        }

        if (request.MinPricePerDayFilter.HasValue)
        {
            query = query.Where(v => v.PricePerDay >= request.MinPricePerDayFilter.Value);
        }

        if (request.MaxPricePerDayFilter.HasValue)
        {
            query = query.Where(v => v.PricePerDay <= request.MaxPricePerDayFilter.Value);
        }

        if (!string.IsNullOrEmpty(request.StatusFilter))
        {
            query = query.Where(v => v.Status == request.StatusFilter);
        }

        if (!string.IsNullOrEmpty(request.DescriptionFilter))
        {
            query = query.Where(v => v.Description != null && v.Description.Contains(request.DescriptionFilter));
        }

        var totalCount = await query.CountAsync();

        var items = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();

        return new PaginatedResult<VehicleModel>(items, totalCount, request.PageNumber, request.PageSize);
    }

    public async Task<int> UpsertVehicleAsync(VehicleUpsertDto model)
    {
        var result = await _context.Database.ExecuteSqlRawAsync(
            "CALL upsert_vehicle({0}, {1}, {2}, {3}, {4}, {5});",
            model.VehicleId,
            model.Make,
            model.Model,
            model.Year,
            model.PricePerDay,
            model.Description);

        return result > 0 ? 1 : 0;
    }
}
