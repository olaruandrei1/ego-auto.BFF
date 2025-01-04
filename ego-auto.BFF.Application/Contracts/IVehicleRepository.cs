using ego_auto.BFF.Domain.Dtos;
using ego_auto.BFF.Domain.Entities;
using ego_auto.BFF.Domain.Requests;
using ego_auto.BFF.Domain.Responses;

namespace ego_auto.BFF.Application.Contracts;

public interface IVehicleRepository
{
    Task<PaginatedResult<VehicleModel>> GetVehiclesAsync(GetVehicleRequest request);
    Task<int> UpsertVehicleAsync(VehicleUpsertDto model);
}
