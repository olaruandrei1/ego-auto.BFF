using ego_auto.BFF.Domain.Dtos;
using ego_auto.BFF.Domain.Entities;
using ego_auto.BFF.Domain.Requests;

namespace ego_auto.BFF.Application.Contracts;

public interface IVehicleRepository
{
    Task<int> UpsertVehicleAsync(VehicleUpsertDto model);
    Task<PaginatedResult<Vehicle>> GetVehiclesAsync(GetVehiclesRequest request);
    Task<Vehicle> GetVehicleByIdAsync(int vehicleId);
}
